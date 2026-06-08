using CapaEntidades;
using Dato;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos
{
    public class CD_CierreCaja
    {
        // Método para calcular cuánto se ha vendido HOY antes de hacer el cierre definitivo
        public CierreCaja CalcularTotalesDelDia()
        {
            CierreCaja totales = new CierreCaja();

            using (MySqlConnection oconexion = Conexion.obtenerConexion())
            {
                try
                {
                    // 1. Sumamos el IGTF y el Subtotal de la tabla ventas (solo de hoy)
                    string queryVentas = @"SELECT IFNULL(SUM(Impuesto), 0) as TotalIGTF, 
                                                  IFNULL(SUM(SubTotal), 0) as TotalVentas 
                                           FROM ventas 
                                           WHERE DATE(FechaVenta) = CURDATE()";

                    MySqlCommand cmd1 = new MySqlCommand(queryVentas, oconexion);
                    using (MySqlDataReader dr = cmd1.ExecuteReader())
                    {
                        if (dr.Read())
                        {
                            totales.TotalIGTF = Convert.ToDecimal(dr["TotalIGTF"]);
                            totales.TotalVentas = Convert.ToDecimal(dr["TotalVentas"]);
                        }
                    }

                    // 2. Sumamos los montos agrupados por Método de Pago (solo de hoy)
                    string queryPagos = @"SELECT vp.idMetodoPago, 
                                                 IFNULL(SUM(vp.monto_recibido - vp.monto_cambio), 0) as TotalRecaudado 
                                          FROM venta_pagos vp
                                          INNER JOIN ventas v ON vp.idVenta = v.idVenta
                                          WHERE DATE(v.FechaVenta) = CURDATE()
                                          GROUP BY vp.idMetodoPago";

                    MySqlCommand cmd2 = new MySqlCommand(queryPagos, oconexion);
                    using (MySqlDataReader dr2 = cmd2.ExecuteReader())
                    {
                        while (dr2.Read())
                        {
                            int idMetodo = Convert.ToInt32(dr2["idMetodoPago"]);
                            decimal monto = Convert.ToDecimal(dr2["TotalRecaudado"]);

                            // Asignamos el monto a la propiedad correcta según el ID de tu tabla metodo_pago
                            switch (idMetodo)
                            {
                                case 1: totales.TotalEfectivoUSD = monto; break;
                                case 2: totales.TotalEfectivoBs = monto; break;
                                case 3: totales.TotalPagoMovil = monto; break;
                                case 4: totales.TotalPuntoVenta = monto; break;
                                case 5: totales.TotalCashea = monto; break;
                                case 6: totales.TotalZelle = monto; break;
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    System.Windows.Forms.MessageBox.Show("Error al calcular el cierre de caja: " + ex.Message,
                                             "Error de Base de Datos",
                                             System.Windows.Forms.MessageBoxButtons.OK,
                                             System.Windows.Forms.MessageBoxIcon.Error);

                    totales = new CierreCaja();
                }
            }
            return totales;
        }
        public bool RegistrarCierre(CierreCaja obj, out string Mensaje)
        {
            bool respuesta = false;
            Mensaje = string.Empty;

            using (MySqlConnection oconexion = Conexion.obtenerConexion())
            {
                try
                {
                    // Preparamos el query para insertar
                    string query = @"INSERT INTO cierre_caja 
                                    (idUsuario, FondoInicial, TotalEfectivoUSD, TotalEfectivoBs, 
                                     TotalPagoMovil, TotalPuntoVenta, TotalCashea, TotalZelle, 
                                     TotalIGTF, TotalVentas, Observaciones, Estado) 
                                    VALUES 
                                    (@idUsuario, @FondoInicial, @EfeUSD, @EfeBs, 
                                     @PagoMovil, @PuntoVenta, @Cashea, @Zelle, 
                                     @IGTF, @Ventas, @Obs, @Estado)";

                    MySqlCommand cmd = new MySqlCommand(query, oconexion);

                    cmd.Parameters.AddWithValue("@idUsuario", obj.Cajero.IdUsuario);
                    cmd.Parameters.AddWithValue("@FondoInicial", obj.FondoInicial);

                    cmd.Parameters.AddWithValue("@EfeUSD", obj.TotalEfectivoUSD);
                    cmd.Parameters.AddWithValue("@EfeBs", obj.TotalEfectivoBs);
                    cmd.Parameters.AddWithValue("@PagoMovil", obj.TotalPagoMovil);
                    cmd.Parameters.AddWithValue("@PuntoVenta", obj.TotalPuntoVenta);
                    cmd.Parameters.AddWithValue("@Cashea", obj.TotalCashea);
                    cmd.Parameters.AddWithValue("@Zelle", obj.TotalZelle);

                    cmd.Parameters.AddWithValue("@IGTF", obj.TotalIGTF);
                    cmd.Parameters.AddWithValue("@Ventas", obj.TotalVentas);

                    cmd.Parameters.AddWithValue("@Obs", string.IsNullOrEmpty(obj.Observaciones) ? "" : obj.Observaciones);
                    cmd.Parameters.AddWithValue("@Estado", "CERRADO");

                    int filasAfectadas = cmd.ExecuteNonQuery();

                    if (filasAfectadas > 0)
                    {
                        respuesta = true;
                    }
                    else
                    {
                        Mensaje = "No se pudo registrar el cierre de caja.";
                    }
                }
                catch (Exception ex)
                {
                    respuesta = false;
                    Mensaje = ex.Message;
                }
            }
            return respuesta;
        }
    }

}
