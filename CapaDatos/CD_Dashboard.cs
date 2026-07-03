using System;
using System.Collections.Generic;
using System.Data;
using MySql.Data.MySqlClient;
using CapaEntidades;
using Dato; // Hacemos referencia al namespace de tu archivo de conexión

namespace CapaDatos
{
    public class CD_Dashboard
    {
        public Dashboard ObtenerMetricas()
        {
            Dashboard objDashboard = new Dashboard();

            // Llamamos directamente a tu método. Al terminar el bloque 'using', 
            // la conexión se cerrará y liberará de forma automática y segura.
            using (MySqlConnection oconexion = Conexion.obtenerConexion())
            {
                try
                {
                    // 1. CONSULTA: Total de Ventas del Mes Actual
                    string queryVentas = @"SELECT IFNULL(SUM(MontoTotal), 0) 
                                           FROM ventas 
                                           WHERE MONTH(FechaVenta) = MONTH(CURDATE()) 
                                             AND YEAR(FechaVenta) = YEAR(CURDATE());";

                    using (MySqlCommand cmd = new MySqlCommand(queryVentas, oconexion))
                    {
                        objDashboard.TotalVentasMes = Convert.ToDecimal(cmd.ExecuteScalar());
                    }

                    // 2. CONSULTA: Alertas de Stock (Productos con 10 o menos unidades)
                    string queryStock = "SELECT COUNT(*) FROM producto WHERE Stock <= 10 AND estado = 1;";
                    using (MySqlCommand cmd = new MySqlCommand(queryStock, oconexion))
                    {
                        objDashboard.AlertasStock = Convert.ToInt32(cmd.ExecuteScalar());
                    }

                    // 3. CONSULTA: Total de Productos Activos
                    string queryProductos = "SELECT COUNT(*) FROM producto WHERE estado = 1;";
                    using (MySqlCommand cmd = new MySqlCommand(queryProductos, oconexion))
                    {
                        objDashboard.TotalProductos = Convert.ToInt32(cmd.ExecuteScalar());
                    }

                    // 4. CONSULTA: Top 5 de Productos Más Vendidos (Para tu gráfico)
                    string queryTop = @"SELECT p.Nombre, SUM(dv.cantidad) as TotalVendido
                                        FROM detalle_venta dv
                                        INNER JOIN producto p ON dv.idProducto = p.idproducto
                                        GROUP BY p.idproducto, p.Nombre
                                        ORDER BY TotalVendido DESC
                                        LIMIT 5;";

                    using (MySqlCommand cmd = new MySqlCommand(queryTop, oconexion))
                    {
                        using (MySqlDataReader dr = cmd.ExecuteReader())
                        {
                            while (dr.Read())
                            {
                                objDashboard.ListaTopProductos.Add(new ProductoTop()
                                {
                                    Nombre = dr["Nombre"].ToString(),
                                    Cantidad = Convert.ToInt32(dr["TotalVendido"])
                                });
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    // Si algo falla, registramos el error en la consola y devolvemos el objeto limpio
                    Console.WriteLine("Error en CD_Dashboard: " + ex.Message);
                    objDashboard = new Dashboard();
                }
            }

            return objDashboard;
        }
    }
}