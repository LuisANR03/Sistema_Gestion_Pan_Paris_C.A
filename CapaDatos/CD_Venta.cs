using System;
using System.Collections.Generic;
using System.Data;
using MySql.Data.MySqlClient;
using Entidades;
using Dato;

namespace CapaDatos
{
    public class CD_Venta
    {
        // ====================================================================
        // MÉTODO 1: REGISTRAR (Con soporte para guardar pagos en venta_pagos)
        // ====================================================================
        public bool Registrar(Ventas obj, List<DetalleVenta> detalle, out string Mensaje)
        {
            Mensaje = string.Empty;
            bool respuesta = false;

            using (MySqlConnection oconexion = Conexion.obtenerConexion())
            {
                MySqlTransaction transaction = oconexion.BeginTransaction();

                try
                {
                    // 1. Insertar Cabecera (AGREGADO NumeroControl)
                    string queryVenta = @"INSERT INTO ventas (idUsuario, idVendedor, idCliente, TipoDocumento, NumeroDocumento, NumeroControl, SubTotal, Impuesto, MontoTotal) 
                                        VALUES (@idusu, @idvend, @idcli, @tipo, @num, @numCtrl, @sub, @imp, @total);
                                        SELECT LAST_INSERT_ID();";

                    MySqlCommand cmdVenta = new MySqlCommand(queryVenta, oconexion, transaction);
                    cmdVenta.Parameters.AddWithValue("@idusu", obj.IdUsuario);
                    cmdVenta.Parameters.AddWithValue("@idvend", obj.IdVendedor == 0 ? 1 : obj.IdVendedor);
                    cmdVenta.Parameters.AddWithValue("@idcli", obj.IdCliente);
                    cmdVenta.Parameters.AddWithValue("@tipo", obj.TipoDocumento);
                    cmdVenta.Parameters.AddWithValue("@num", obj.NumeroDocumento);
                    cmdVenta.Parameters.AddWithValue("@numCtrl", obj.NumeroControl); // NUEVO
                    cmdVenta.Parameters.AddWithValue("@sub", obj.SubTotal);
                    cmdVenta.Parameters.AddWithValue("@imp", obj.Impuesto);
                    cmdVenta.Parameters.AddWithValue("@total", obj.MontoTotal);

                    object res = cmdVenta.ExecuteScalar();
                    int idVentaGenerado = Convert.ToInt32(res);

                    // 2. Insertar Detalles y 3. Actualizar Stock
                    foreach (DetalleVenta dv in detalle)
                    {
                        string queryDetalle = "INSERT INTO detalle_venta (idVenta, idProducto, precio_unitario, cantidad) VALUES (@idv, @idp, @prec, @cant)";
                        MySqlCommand cmdDetalle = new MySqlCommand(queryDetalle, oconexion, transaction);
                        cmdDetalle.Parameters.AddWithValue("@idv", idVentaGenerado);
                        cmdDetalle.Parameters.AddWithValue("@idp", dv.IdProducto);
                        cmdDetalle.Parameters.AddWithValue("@prec", dv.PrecioUnitario);
                        cmdDetalle.Parameters.AddWithValue("@cant", dv.Cantidad);
                        cmdDetalle.ExecuteNonQuery();

                        // 3. Actualizar Stock
                        string queryStock = "UPDATE producto SET stock = stock - @cant WHERE idproducto = @idp";
                        MySqlCommand cmdStock = new MySqlCommand(queryStock, oconexion, transaction);
                        cmdStock.Parameters.AddWithValue("@cant", dv.Cantidad);
                        cmdStock.Parameters.AddWithValue("@idp", dv.IdProducto);
                        cmdStock.ExecuteNonQuery();
                    }

                    // ====================================================================
                    // ¡PASO 4 NUEVO!: REGISTRAR LOS INGRESOS EN LA TABLA VENTA_PAGOS
                    // ====================================================================
                    if (obj.Pagos != null && obj.Pagos.Count > 0)
                    {
                        string queryPago = @"INSERT INTO venta_pagos (idVenta, idMetodoPago, monto_recibido, monto_cambio) 
                                             VALUES (@idv, @idmp, @mrec, @mcam);";

                        foreach (VentaPagos pago in obj.Pagos)
                        {
                            MySqlCommand cmdPago = new MySqlCommand(queryPago, oconexion, transaction);
                            cmdPago.Parameters.AddWithValue("@idv", idVentaGenerado);
                            cmdPago.Parameters.AddWithValue("@idmp", pago.IdMetodoPago);
                            cmdPago.Parameters.AddWithValue("@mrec", pago.MontoRecibido);
                            cmdPago.Parameters.AddWithValue("@mcam", pago.MontoCambio);
                            cmdPago.ExecuteNonQuery();
                        }
                    }

                    // Si todo salió bien hasta aquí, guardamos permanentemente en la BD
                    transaction.Commit();
                    respuesta = true;
                }
                catch (Exception ex)
                {
                    // Si algo falló en cualquier paso, deshacemos todo lo que se intentó guardar
                    transaction.Rollback();
                    respuesta = false;
                    Mensaje = ex.Message;
                }
            }
            return respuesta;
        }

        // ====================================================================
        // MÉTODO EXCLUSIVO PARA LA IA: PRODUCTOS MÁS VENDIDOS (ÚLTIMOS 7 DÍAS)
        // ====================================================================
        public List<string> ResumenVentasParaIA()
        {
            List<string> resumen = new List<string>();

            using (MySqlConnection oconexion = Conexion.obtenerConexion())
            {
                try
                {
                    // Sumamos las cantidades vendidas agrupadas por el nombre del pan
                    string query = @"
                        SELECT p.Nombre, SUM(dv.cantidad) AS TotalVendidos 
                        FROM detalle_venta dv
                        INNER JOIN producto p ON dv.idProducto = p.idproducto
                        INNER JOIN ventas v ON dv.idVenta = v.idVenta
                        WHERE v.FechaVenta >= DATE_SUB(CURDATE(), INTERVAL 7 DAY)
                        GROUP BY p.Nombre
                        ORDER BY TotalVendidos DESC";

                    MySqlCommand cmd = new MySqlCommand(query, oconexion);
                    cmd.CommandType = CommandType.Text;

                    using (MySqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            // Formateamos el texto exactamente como le gusta leerlo a la IA
                            resumen.Add($"- {dr["Nombre"]}: {dr["TotalVendidos"]} unidades vendidas.");
                        }
                    }
                }
                catch (Exception ex)
                {
                    resumen.Add("Error al obtener ventas: " + ex.Message);
                }
            }
            return resumen;
        }

        // ====================================================================
        // MÉTODO 2: LISTAR (Para llenar tu historial de ventas)
        // ====================================================================
        public List<Ventas> Listar()
        {
            List<Ventas> lista = new List<Ventas>();

            using (MySqlConnection oconexion = Conexion.obtenerConexion())
            {
                try
                {
                    // AGREGADO: v.NumeroControl
                    string query = @"SELECT 
                                v.idVenta, 
                                v.NumeroDocumento, 
                                v.NumeroControl,
                                v.FechaVenta, 
                                c.Nombre as Cliente, 
                                u.Nombre as Cajero, 
                                uv.Nombre as Vendedor, 
                                v.MontoTotal 
                                FROM ventas v
                                INNER JOIN cliente c ON v.idCliente = c.idCliente
                                INNER JOIN usuario u ON v.idUsuario = u.idUsuario
                                INNER JOIN usuario uv ON v.idVendedor = uv.idUsuario";

                    MySqlCommand cmd = new MySqlCommand(query, oconexion);
                    cmd.CommandType = CommandType.Text;

                    using (MySqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            lista.Add(new Ventas()
                            {
                                IdVenta = Convert.ToInt32(dr["idVenta"]),
                                NumeroDocumento = dr["NumeroDocumento"].ToString(),
                                NumeroControl = dr["NumeroControl"] == DBNull.Value ? "" : dr["NumeroControl"].ToString(), // NUEVO
                                FechaVenta = Convert.ToDateTime(dr["FechaVenta"]),
                                MontoTotal = Convert.ToDecimal(dr["MontoTotal"]),

                                Cliente = new Cliente() { Nombre = dr["Cliente"].ToString() },
                                Usuario = new Usuario() { Nombre = dr["Cajero"].ToString() },
                                Vendedor = new Vendedor() { NombreCompleto = dr["Vendedor"].ToString() }
                            });
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception("Error en la base de datos al listar ventas: " + ex.Message);
                }
            }
            return lista;
        }

        public Ventas ObtenerVenta(int idVenta)
        {
            Ventas objeto = new Ventas();
            using (MySqlConnection oconexion = Conexion.obtenerConexion())
            {
                try
                {
                    // 1. OBTENER CABECERA DE LA VENTA (Ajustado con minúsculas exactas de tu BD)
                    string query = @"SELECT v.idVenta, v.NumeroDocumento, v.NumeroControl, v.TipoDocumento, v.FechaVenta, v.MontoTotal, 
                             c.Nombre as NombreCliente, c.cedula, c.correo, c.direccion, 
                             u.Nombre as NombreCajero 
                             FROM ventas v 
                             INNER JOIN cliente c ON v.idCliente = c.idCliente 
                             INNER JOIN usuario u ON v.idUsuario = u.idUsuario 
                             WHERE v.idVenta = @id";

                    MySqlCommand cmd = new MySqlCommand(query, oconexion);
                    cmd.Parameters.AddWithValue("@id", idVenta);
                    cmd.CommandType = CommandType.Text;

                    using (MySqlDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr.Read())
                        {
                            objeto = new Ventas()
                            {
                                IdVenta = Convert.ToInt32(dr["idVenta"]),
                                NumeroDocumento = dr["NumeroDocumento"].ToString(),
                                NumeroControl = dr["NumeroControl"] == DBNull.Value ? "" : dr["NumeroControl"].ToString(),
                                TipoDocumento = dr["TipoDocumento"].ToString(),
                                FechaVenta = Convert.ToDateTime(dr["FechaVenta"]),
                                MontoTotal = Convert.ToDecimal(dr["MontoTotal"]),

                                // Mapeo exacto con los nombres de las columnas de tu imagen
                                Cliente = new Cliente()
                                {
                                    Nombre = dr["NombreCliente"].ToString(),
                                    Cedula = dr["cedula"] == DBNull.Value ? "" : dr["cedula"].ToString(),
                                    Correo = dr["correo"] == DBNull.Value ? "" : dr["correo"].ToString(),
                                    Direccion = dr["direccion"] == DBNull.Value ? "" : dr["direccion"].ToString()
                                },

                                Usuario = new Usuario() { Nombre = dr["NombreCajero"].ToString() },
                                Detalles = new List<DetalleVenta>(),
                                Pagos = new List<VentaPagos>()
                            };
                        }
                    }

                    // 2. OBTENER PRODUCTOS (DETALLE)
                    string queryDetalle = @"SELECT p.Nombre, dv.precio_unitario, dv.cantidad 
                                    FROM detalle_venta dv 
                                    INNER JOIN producto p ON p.idProducto = dv.idProducto 
                                    WHERE dv.idVenta = @id";

                    MySqlCommand cmd2 = new MySqlCommand(queryDetalle, oconexion);
                    cmd2.Parameters.AddWithValue("@id", idVenta);

                    using (MySqlDataReader dr2 = cmd2.ExecuteReader())
                    {
                        while (dr2.Read())
                        {
                            objeto.Detalles.Add(new DetalleVenta()
                            {
                                Producto = new Producto() { Nombre = dr2["Nombre"].ToString() },
                                PrecioUnitario = Convert.ToDecimal(dr2["precio_unitario"]),
                                Cantidad = Convert.ToInt32(dr2["cantidad"])
                            });
                        }
                    }

                    // =========================================================
                    // 3. OBTENER LOS MÉTODOS DE PAGO USADOS
                    // =========================================================
                    string queryPagos = @"SELECT mp.nombre as Metodo, vp.monto_recibido, vp.monto_cambio 
                                  FROM venta_pagos vp 
                                  INNER JOIN metodo_pago mp ON vp.idMetodoPago = mp.idMetodoPago 
                                  WHERE vp.idVenta = @id";

                    MySqlCommand cmd3 = new MySqlCommand(queryPagos, oconexion);
                    cmd3.Parameters.AddWithValue("@id", idVenta);

                    using (MySqlDataReader dr3 = cmd3.ExecuteReader())
                    {
                        while (dr3.Read())
                        {
                            objeto.Pagos.Add(new VentaPagos()
                            {
                                DescripcionMetodo = dr3["Metodo"].ToString(),
                                MontoRecibido = Convert.ToDecimal(dr3["monto_recibido"]),
                                MontoCambio = Convert.ToDecimal(dr3["monto_cambio"])
                            });
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception("Error en la base de datos al obtener venta individual: " + ex.Message);
                }
            }
            return objeto;
        }

        // ====================================================================
        // MÉTODO 3: OBTENER TOTALES POR MÉTODO PARA EL CIERRE DE CAJA
        // ====================================================================
        public DataTable ObtenerTotalesDelDiaParaCierre()
        {
            DataTable tabla = new DataTable();

            using (MySqlConnection oconexion = Conexion.obtenerConexion())
            {
                try
                {
                    string query = @"
                        SELECT UPPER(mp.nombre) AS MetodoPago, 
                               SUM(vp.monto_recibido - vp.monto_cambio) AS TotalVendido 
                        FROM venta_pagos vp
                        INNER JOIN ventas v ON vp.idVenta = v.idVenta
                        INNER JOIN metodo_pago mp ON vp.idMetodoPago = mp.idMetodoPago
                        WHERE DATE(v.FechaVenta) = CURDATE()
                        GROUP BY mp.nombre";

                    MySqlCommand cmd = new MySqlCommand(query, oconexion);
                    cmd.CommandType = CommandType.Text;

                    using (MySqlDataReader dr = cmd.ExecuteReader())
                    {
                        tabla.Load(dr);
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception("Error en la base de datos al cargar datos para el cierre: " + ex.Message);
                }
            }
            return tabla;
        }

        // ====================================================================
        // MÉTODO PARA EL EXCEL: MOVIMIENTO DE PRODUCTOS DEL DÍA
        // ====================================================================
        public DataTable ObtenerMovimientoProductosDelDia()
        {
            DataTable tabla = new DataTable();
            using (MySqlConnection oconexion = Conexion.obtenerConexion())
            {
                try
                {
                    // Sumamos cuántos panes de cada tipo se vendieron exactamente HOY
                    string query = @"
                        SELECT 
                            p.codigo AS Codigo,
                            p.Nombre AS Producto, 
                            SUM(dv.cantidad) AS UnidadesVendidas, 
                            SUM(dv.cantidad * dv.precio_unitario) AS TotalIngresado
                        FROM detalle_venta dv
                        INNER JOIN producto p ON dv.idProducto = p.idproducto
                        INNER JOIN ventas v ON dv.idVenta = v.idVenta
                        WHERE DATE(v.FechaVenta) = CURDATE()
                        GROUP BY p.codigo, p.Nombre
                        ORDER BY UnidadesVendidas DESC";

                    MySqlCommand cmd = new MySqlCommand(query, oconexion);
                    cmd.CommandType = CommandType.Text;

                    using (MySqlDataReader dr = cmd.ExecuteReader())
                    {
                        tabla.Load(dr);
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception("Error en la base de datos al cargar productos del día: " + ex.Message);
                }
            }
            return tabla;
        }

        // ====================================================================
        // MÉTODO NUEVO PARA IA Y PROYECCIONES: HISTORIAL DE 3 MESES
        // ====================================================================
        public DataTable ObtenerHistorial3Meses()
        {
            DataTable tabla = new DataTable();
            using (MySqlConnection oconexion = Conexion.obtenerConexion())
            {
                try
                {
                    string query = @"
                        SELECT 
                            p.nombre AS Producto, 
                            SUM(dv.cantidad) AS TotalUnidades, 
                            SUM(dv.cantidad * dv.precio_unitario) AS Ingresos
                        FROM detalle_venta dv
                        INNER JOIN ventas v ON dv.idVenta = v.idVenta
                        INNER JOIN producto p ON dv.idProducto = p.idproducto
                        WHERE v.FechaVenta >= DATE_SUB(CURDATE(), INTERVAL 3 MONTH)
                        GROUP BY p.idproducto, p.nombre
                        ORDER BY TotalUnidades DESC";

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

        public decimal ObtenerTotalVendidoPorRango(DateTime fechaInicio, DateTime fechaFin)
        {
            decimal totalVendido = 0;

            using (MySqlConnection oconexion = Conexion.obtenerConexion())
            {
                try
                {
                    // Usamos DATE() para ignorar las horas y buscar días completos exactos
                    string query = @"
                SELECT SUM(MontoTotal) 
                FROM ventas 
                WHERE DATE(FechaVenta) BETWEEN DATE(@fechaInicio) AND DATE(@fechaFin);";

                    using (MySqlCommand cmd = new MySqlCommand(query, oconexion))
                    {
                        cmd.Parameters.AddWithValue("@fechaInicio", fechaInicio);
                        cmd.Parameters.AddWithValue("@fechaFin", fechaFin);

                        object resultado = cmd.ExecuteScalar();

                        // Validamos que el resultado no sea nulo (por si no hay ventas en esas fechas)
                        if (resultado != DBNull.Value && resultado != null)
                        {
                            totalVendido = Convert.ToDecimal(resultado);
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error al sumar el total de ventas: " + ex.Message);
                }
            }

            return totalVendido;
        }



    }
}