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
        // ==========================================================
        // 1. OBTENER PRODUCTOS 
        // ==========================================================
        public List<Producto> ObtenerProductosParaProduccion()
        {
            List<Producto> lista = new List<Producto>();

            using (MySqlConnection oconexion = Conexion.obtenerConexion())
            {
                try
                {
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

        // ==========================================================
        // 2. SUGERENCIAS IA (Predicción Específica por Día)
        // ==========================================================
        public Dictionary<int, int> ObtenerSugerenciasIA()
        {
            Dictionary<int, int> sugerencias = new Dictionary<int, int>();

            using (MySqlConnection oconexion = Conexion.obtenerConexion())
            {
                try
                {
                    // CORREGIDO: 'ventas' y 'FechaVenta'
                    string query = @"
                SELECT dv.idproducto, 
                       CEIL(AVG(dv.Cantidad) * 1.1) as Sugerido
                FROM detalle_venta dv
                INNER JOIN ventas v ON dv.idVenta = v.idVenta
                WHERE v.FechaVenta >= DATE_SUB(CURDATE(), INTERVAL 3 MONTH)
                  AND DAYOFWEEK(v.FechaVenta) = DAYOFWEEK(CURDATE())
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

        // ==========================================================
        // 3. HISTORIAL 3 MESES (Promedio General de Respaldo)
        // ==========================================================
        public DataTable ObtenerHistorial3Meses()
        {
            DataTable tabla = new DataTable();
            using (MySqlConnection oconexion = Conexion.obtenerConexion())
            {
                try
                {
                    // CORREGIDO: 'ventas' y 'FechaVenta'
                    string query = @"
                        SELECT 
                            p.idproducto,
                            p.nombre AS Producto, 
                            SUM(dv.cantidad) AS TotalUnidades, 
                            SUM(dv.cantidad * dv.precio_unitario) AS Ingresos
                        FROM detalle_venta dv
                        INNER JOIN ventas v ON dv.idVenta = v.idVenta
                        INNER JOIN producto p ON dv.idproducto = p.idproducto
                        WHERE v.FechaVenta >= DATE_SUB(CURDATE(), INTERVAL 3 MONTH)
                        GROUP BY p.idproducto, p.nombre
                        ORDER BY TotalUnidades DESC;";

                    MySqlCommand cmd = new MySqlCommand(query, oconexion);
                    cmd.CommandType = CommandType.Text;

                    using (MySqlDataReader dr = cmd.ExecuteReader())
                    {
                        tabla.Load(dr);
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception("Error en la base de datos al obtener historial de 3 meses: " + ex.Message);
                }
            }
            return tabla;
        }

        // ==========================================================
        // 4. REGISTRAR PRODUCCIÓN (Con descuento de ingredientes)
        // ==========================================================
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
                        decimal costoTotalLote = cp.EntradaHorno * cp.oProducto.CostoProduccion;

                        // --- Query 1: Registrar en control_produccion ---
                        string queryInsert = @"
                    INSERT INTO control_produccion (IdProducto, FechaRegistro, SugeridoIA, EntradaHorno, Merma, costo_total) 
                    VALUES (@idproducto, CURDATE(), @sugerido, @entrada, @merma, @costototal);";

                        using (MySqlCommand cmdInsert = new MySqlCommand(queryInsert, oconexion, transaction))
                        {
                            cmdInsert.Parameters.AddWithValue("@idproducto", cp.oProducto.IdProducto);
                            cmdInsert.Parameters.AddWithValue("@sugerido", cp.SugeridoIA);
                            cmdInsert.Parameters.AddWithValue("@entrada", cp.EntradaHorno);
                            cmdInsert.Parameters.AddWithValue("@merma", cp.Merma);
                            cmdInsert.Parameters.AddWithValue("@costototal", costoTotalLote);
                            cmdInsert.ExecuteNonQuery();
                        }

                        // --- Query 2: Actualizar el Stock del pan/producto terminado ---
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

                        // --- Query 3: Descontar los ingredientes según la receta ---
                        string queryDescontarIngredientes = @"
                    UPDATE ingrediente i
                    INNER JOIN receta r ON i.IdIngrediente = r.IdIngrediente
                    SET i.stock_actual = i.stock_actual - (r.cantidad_requerida * @entrada)
                    WHERE r.idProducto = @idproducto;";

                        using (MySqlCommand cmdIngredientes = new MySqlCommand(queryDescontarIngredientes, oconexion, transaction))
                        {
                            cmdIngredientes.Parameters.AddWithValue("@entrada", cp.EntradaHorno);
                            cmdIngredientes.Parameters.AddWithValue("@idproducto", cp.oProducto.IdProducto);
                            cmdIngredientes.ExecuteNonQuery();
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