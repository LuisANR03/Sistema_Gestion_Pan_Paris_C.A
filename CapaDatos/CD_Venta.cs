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
        // MÉTODO 1: REGISTRAR (El que tú creaste para guardar las ventas)
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
                    // 1. Insertar Cabecera
                    string queryVenta = @"INSERT INTO ventas (idUsuario, idVendedor, idCliente, TipoDocumento, NumeroDocumento, SubTotal, Impuesto, MontoTotal) 
                                        VALUES (@idusu, @idvend, @idcli, @tipo, @num, @sub, @imp, @total);
                                        SELECT LAST_INSERT_ID();";

                    MySqlCommand cmdVenta = new MySqlCommand(queryVenta, oconexion, transaction);
                    cmdVenta.Parameters.AddWithValue("@idusu", obj.IdUsuario);
                    cmdVenta.Parameters.AddWithValue("@idvend", obj.IdVendedor == 0 ? 1 : obj.IdVendedor);
                    cmdVenta.Parameters.AddWithValue("@idcli", obj.IdCliente);
                    cmdVenta.Parameters.AddWithValue("@tipo", obj.TipoDocumento);
                    cmdVenta.Parameters.AddWithValue("@num", obj.NumeroDocumento);
                    cmdVenta.Parameters.AddWithValue("@sub", obj.SubTotal);
                    cmdVenta.Parameters.AddWithValue("@imp", obj.Impuesto);
                    cmdVenta.Parameters.AddWithValue("@total", obj.MontoTotal);

                    object res = cmdVenta.ExecuteScalar();
                    int idVentaGenerado = Convert.ToInt32(res);

                    // 2. Insertar Detalles
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

                    transaction.Commit();
                    respuesta = true;
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    respuesta = false;
                    Mensaje = ex.Message;
                }
            }
            return respuesta;
        }

        // ====================================================================
        // MÉTODO 2: LISTAR (El nuevo para llenar tu historial de ventas)
        // ====================================================================
        public List<Ventas> Listar()
        {
            List<Ventas> lista = new List<Ventas>();

            using (MySqlConnection oconexion = Conexion.obtenerConexion())
            {
                try
                {
                    // CAMBIO AQUÍ: v.FechaRegistro -> v.FechaVenta
                    string query = @"SELECT 
                v.idVenta, 
                v.NumeroDocumento, 
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
                                FechaVenta = Convert.ToDateTime(dr["FechaVenta"]), // Corregido aquí también
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
                    // Si vuelve a dar 0, este mensaje te dirá por qué
                    System.Windows.Forms.MessageBox.Show("Error en CD_Venta: " + ex.Message);
                    lista = new List<Ventas>();
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
                    // 1. Buscamos la cabecera de la venta
                    string query = @"SELECT v.idVenta, v.NumeroDocumento, v.TipoDocumento, v.FechaVenta, v.MontoTotal,
                            c.Nombre as NombreCliente, u.Nombre as NombreCajero
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
                                TipoDocumento = dr["TipoDocumento"].ToString(),
                                FechaVenta = Convert.ToDateTime(dr["FechaVenta"]),
                                MontoTotal = Convert.ToDecimal(dr["MontoTotal"]),
                                Cliente = new Cliente() { Nombre = dr["NombreCliente"].ToString() },
                                Usuario = new Usuario() { Nombre = dr["NombreCajero"].ToString() },
                                Detalles = new List<DetalleVenta>() // Preparamos la lista de productos
                            };
                        }
                    }

                    // 2. Buscamos los productos (detalles) de esa venta
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
                                // AQUÍ ESTÁ EL PRODUCTO DESCOMENTADO
                                // Nota: Si tu entidad usa "oProducto" en vez de "Producto", agrégale la "o" al principio
                                Producto = new Producto() { Nombre = dr2["Nombre"].ToString() },

                                PrecioUnitario = Convert.ToDecimal(dr2["precio_unitario"]),
                                Cantidad = Convert.ToInt32(dr2["cantidad"])
                            });
                        }
                    }
                }
                catch (Exception) { objeto = new Ventas(); }
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
                    // Sumamos (Monto Recibido - Vuelto) para tener el ingreso real de la caja
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
                    System.Windows.Forms.MessageBox.Show("Error al cargar datos para el cierre: " + ex.Message);
                }
            }
            return tabla;
        }
    }
}