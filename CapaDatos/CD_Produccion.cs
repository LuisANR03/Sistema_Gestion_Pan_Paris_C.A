using CapaEntidades;
using Dato; // Tu archivo de conexión
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

            // Usamos tu clase Conexion para abrir la base de datos automáticamente
            using (MySqlConnection oconexion = Conexion.obtenerConexion())
            {
                try
                {
                    // Buscamos solo el ID, Nombre y Stock de los productos que están activos (estado = 1)
                    string query = "SELECT idproducto, Nombre, Stock FROM producto WHERE estado = 1;";

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
                                    Stock = Convert.ToInt32(dr["Stock"])
                                });
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error al obtener productos de producción: " + ex.Message);
                    lista = new List<Producto>(); // Si hay error, devolvemos una lista vacía para que no se caiga el programa
                }
            }

            return lista;
        }

        // Método para calcular la predicción inteligente según el día de la semana actual
        public Dictionary<int, int> ObtenerSugerenciasIA()
        {
            Dictionary<int, int> sugerencias = new Dictionary<int, int>();

            using (MySqlConnection oconexion = Conexion.obtenerConexion())
            {
                try
                {
                    // QUERY EXPLICADA: 
                    // 1. Filtra las ventas hechas en los últimos 60 días.
                    // 2. Filtra para que SOLO tome los días que coincidan con el día de hoy (ej: solo miércoles anteriores).
                    // 3. Saca el promedio de venta por producto y le suma un 10% de stock de seguridad (MULTIPLIED BY 1.1) y redondea hacia arriba (CEIL).
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
                    // Si el sistema es nuevo y no hay ventas registradas, devolverá el diccionario vacío
                }
            }
            return sugerencias;
        }

        public bool RegistrarProduccion(List<ControlProduccion> lista)
        {
            bool respuesta = true;

            using (MySqlConnection oconexion = Conexion.obtenerConexion())
            {
                // Iniciamos una transacción para asegurar que se guarde TODO o NADA
                MySqlTransaction transaction = oconexion.BeginTransaction();

                try
                {
                    foreach (ControlProduccion cp in lista)
                    {
                        // Query 1: Insertar en la tabla de control de producción
                        string queryInsert = @"
                    INSERT INTO control_produccion (IdProducto, FechaRegistro, SugeridoIA, EntradaHorno, Merma) 
                    VALUES (@idproducto, CURDATE(), @sugerido, @entrada, @merma);";

                        using (MySqlCommand cmdInsert = new MySqlCommand(queryInsert, oconexion, transaction))
                        {
                            cmdInsert.Parameters.AddWithValue("@idproducto", cp.oProducto.IdProducto);
                            cmdInsert.Parameters.AddWithValue("@sugerido", cp.SugeridoIA);
                            cmdInsert.Parameters.AddWithValue("@entrada", cp.EntradaHorno);
                            cmdInsert.Parameters.AddWithValue("@merma", cp.Merma);
                            cmdInsert.ExecuteNonQuery();
                        }

                        // Query 2: Actualizar el Stock Real en la tabla producto 
                        // (Fórmula: Stock Actual + Horneado - Merma)
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

                    // Si todo el bucle se ejecutó sin errores, confirmamos los cambios en la BD
                    transaction.Commit();
                }
                catch (Exception ex)
                {
                    // Si algo falló, deshacemos todo para evitar descuadres en el inventario
                    transaction.Rollback();
                    Console.WriteLine("Error al registrar la producción: " + ex.Message);
                    respuesta = false;
                }
            }

            return respuesta;
        }

    }
}