using CapaEntidades;
using Dato;
using Entidades;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;

namespace CapaDatos
{
    public class CD_Produccion
    {
        // Método para listar los productos en la tabla del formulario
        public List<Producto> ObtenerProductosParaProduccion()
        {
            List<Producto> lista = new List<Producto>();

            using (MySqlConnection oconexion = Conexion.obtenerConexion())
            {
                try
                {
                    // NUEVO: Agregamos 'costo_produccion' al SELECT
                    string query = "SELECT idproducto, Nombre, Stock, costo_produccion FROM producto WHERE estado = 1;";

                    using (MySqlCommand cmd = new MySqlCommand(query, oconexion))
                    {
                        using (MySqlDataReader dr = cmd.ExecuteReader())
                        {
                            while (dr.Read())
                            {
                                lista.Add(new Producto()
                                {
                                    IdProducto = Convert.ToInt32(dr["idproducto"]),
                                    Nombre = dr["Nombre"].ToString(),
                                    Stock = Convert.ToInt32(dr["Stock"]),
                                    // NUEVO: Leemos el costo y lo guardamos en la entidad
                                    CostoProduccion = Convert.ToDecimal(dr["costo_produccion"])
                                });
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error al obtener productos de producción: " + ex.Message);
                    lista = new List<Producto>();
                }
            }

            return lista;
        }

        // (ObtenerSugerenciasIA queda exactamente igual, no necesitamos tocarlo)
        public Dictionary<int, int> ObtenerSugerenciasIA()
        {
            Dictionary<int, int> sugerencias = new Dictionary<int, int>();

            using (MySqlConnection oconexion = Conexion.obtenerConexion())
            {
                try
                {
                    string query = @"
                SELECT dv.idproducto, 
                       CEIL(AVG(dv.Cantidad) * 1.1) as Sugerido
                FROM detalle_venta dv
                INNER JOIN venta v ON dv.idventa = v.idventa
                WHERE v.FechaRegistro >= DATE_SUB(CURDATE(), INTERVAL 60 DAY)
                  AND DAYOFWEEK(v.FechaRegistro) = DAYOFWEEK(CURDATE())
                GROUP BY dv.idproducto;";

                    using (MySqlCommand cmd = new MySqlCommand(query, oconexion))
                    {
                        using (MySqlDataReader dr = cmd.ExecuteReader())
                        {
                            while (dr.Read())
                            {
                                int idProd = Convert.ToInt32(dr["idproducto"]);
                                int sugerido = Convert.ToInt32(dr["Sugerido"]);
                                sugerencias[idProd] = sugerido;
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error en la predicción IA: " + ex.Message);
                }
            }
            return sugerencias;
        }

        public bool RegistrarProduccion(List<ControlProduccion> lista)
        {
            bool respuesta = true;

            using (MySqlConnection oconexion = Conexion.obtenerConexion())
            {
                MySqlTransaction transaction = oconexion.BeginTransaction();

                try
                {
                    foreach (ControlProduccion cp in lista)
                    {
                        // NUEVO: Calculamos el costo total de lo que se horneó
                        // Multiplicamos los panes que entraron al horno por lo que cuesta hacer cada uno
                        decimal costoTotalLote = cp.EntradaHorno * cp.oProducto.CostoProduccion;

                        // NUEVO: Agregamos costo_total al INSERT
                        string queryInsert = @"
                    INSERT INTO control_produccion (IdProducto, FechaRegistro, SugeridoIA, EntradaHorno, Merma, costo_total) 
                    VALUES (@idproducto, CURDATE(), @sugerido, @entrada, @merma, @costototal);";

                        using (MySqlCommand cmdInsert = new MySqlCommand(queryInsert, oconexion, transaction))
                        {
                            cmdInsert.Parameters.AddWithValue("@idproducto", cp.oProducto.IdProducto);
                            cmdInsert.Parameters.AddWithValue("@sugerido", cp.SugeridoIA);
                            cmdInsert.Parameters.AddWithValue("@entrada", cp.EntradaHorno);
                            cmdInsert.Parameters.AddWithValue("@merma", cp.Merma);
                            // NUEVO: Pasamos el parámetro a la base de datos
                            cmdInsert.Parameters.AddWithValue("@costototal", costoTotalLote);

                            cmdInsert.ExecuteNonQuery();
                        }

                        // Query 2: Actualizar el Stock (queda igual)
                        string queryUpdateStock = @"
                    UPDATE producto 
                    SET Stock = Stock + @entrada - @merma 
                    WHERE idproducto = @idproducto;";

                        using (MySqlCommand cmdUpdate = new MySqlCommand(queryUpdateStock, oconexion, transaction))
                        {
                            cmdUpdate.Parameters.AddWithValue("@entrada", cp.EntradaHorno);
                            cmdUpdate.Parameters.AddWithValue("@merma", cp.Merma);
                            cmdUpdate.Parameters.AddWithValue("@idproducto", cp.oProducto.IdProducto);
                            cmdUpdate.ExecuteNonQuery();
                        }
                    }

                    transaction.Commit();
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    Console.WriteLine("Error al registrar la producción: " + ex.Message);
                    respuesta = false;
                }
            }

            return respuesta;
        }
    }
}