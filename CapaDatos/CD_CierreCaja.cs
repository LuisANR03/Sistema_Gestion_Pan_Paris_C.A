using CapaEntidades;
using Dato;
using MySql.Data.MySqlClient;
using System;
using System.Data;

namespace CapaDatos
{
    public class CD_CierreCaja
    {
        // 1. AHORA RECIBE EL idUsuario PARA MOSTRAR SOLO LO DE ESE CAJERO
        public CierreCaja CalcularTotalesDelDia(int idUsuario)
        {
            CierreCaja totales = new CierreCaja();

            using (MySqlConnection oconexion = Conexion.obtenerConexion())
            {
                try
                {
                    // Validación para no chocar con conexiones abiertas
                    if (oconexion.State == ConnectionState.Closed)
                    {
                        oconexion.Open();
                    }

                    // 1. NOMBRES CORRECTOS: MontoTotal, idUsuario, FechaVenta
                    string queryVentas = @"SELECT 0 as TotalIGTF, 
                                                  IFNULL(SUM(MontoTotal), 0) as TotalVentas 
                                           FROM ventas 
                                           WHERE idUsuario = @idUsuario AND DATE(FechaVenta) = CURDATE()";

                    MySqlCommand cmd1 = new MySqlCommand(queryVentas, oconexion);
                    cmd1.Parameters.AddWithValue("@idUsuario", idUsuario);

                    using (MySqlDataReader dr = cmd1.ExecuteReader())
                    {
                        if (dr.Read())
                        {
                            totales.TotalIGTF = Convert.ToDecimal(dr["TotalIGTF"]);
                            totales.TotalVentas = Convert.ToDecimal(dr["TotalVentas"]);
                        }
                    }

                    // 2. NOMBRES CORRECTOS: idMetodoPago, idVenta, FechaVenta, idUsuario
                    string queryPagos = @"SELECT vp.idMetodoPago as idMetodoPago, 
                                                 IFNULL(SUM(vp.monto_recibido - vp.monto_cambio), 0) as TotalRecaudado 
                                          FROM venta_pagos vp
                                          INNER JOIN ventas v ON vp.idVenta = v.idVenta
                                          WHERE v.idUsuario = @idUsuario AND DATE(v.FechaVenta) = CURDATE()
                                          GROUP BY vp.idMetodoPago";

                    MySqlCommand cmd2 = new MySqlCommand(queryPagos, oconexion);
                    cmd2.Parameters.AddWithValue("@idUsuario", idUsuario);

                    using (MySqlDataReader dr2 = cmd2.ExecuteReader())
                    {
                        while (dr2.Read())
                        {
                            int idMetodo = Convert.ToInt32(dr2["idMetodoPago"]);
                            decimal monto = Convert.ToDecimal(dr2["TotalRecaudado"]);

                            // Lógica de Switch-Case
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
                    // Validación para no chocar con conexiones abiertas
                    if (oconexion.State == ConnectionState.Closed)
                    {
                        oconexion.Open();
                    }

                    // 1. EL QUERY ACTUALIZADO CON TODAS LAS COLUMNAS NUEVAS
                    string query = @"INSERT INTO cierre_caja 
                            (idUsuario, FondoInicial, TasaCambio, 
                             TotalEfectivoUSD, TotalEfectivoBs, TotalPagoMovil, TotalPuntoVenta, TotalCashea, TotalZelle, TotalIGTF, TotalVentas, 
                             FisicoEfectivoUSD, FisicoEfectivoBs, FisicoPagoMovil, FisicoPuntoVenta, FisicoTransferencia, FisicoZinly, FisicoCashea, 
                             TotalSistemaCalculado, TotalFisicoDeclarado, DiferenciaCuadre, Observaciones, Estado) 
                            VALUES 
                            (@idUsuario, @FondoInicial, @TasaCambio, 
                             @EfeUSD, @EfeBs, @PagoMovil, @PuntoVenta, @Cashea, @Zelle, @IGTF, @Ventas, 
                             @FisUSD, @FisBs, @FisPagoMovil, @FisPuntoVenta, @FisTransferencia, @FisZinly, @FisCashea, 
                             @TotalSis, @TotalFis, @DifCuadre, @Obs, @Estado)";

                    MySqlCommand cmd = new MySqlCommand(query, oconexion);

                    // ==========================================
                    // 2. PASAMOS LOS PARÁMETROS GENERALES
                    // ==========================================
                    cmd.Parameters.AddWithValue("@idUsuario", obj.Cajero.IdUsuario);
                    cmd.Parameters.AddWithValue("@FondoInicial", obj.FondoInicial);
                    cmd.Parameters.AddWithValue("@TasaCambio", obj.TasaCambio);

                    // ==========================================
                    // 3. PARÁMETROS DEL SISTEMA (CAJA AZUL)
                    // ==========================================
                    cmd.Parameters.AddWithValue("@EfeUSD", obj.TotalEfectivoUSD);
                    cmd.Parameters.AddWithValue("@EfeBs", obj.TotalEfectivoBs);
                    cmd.Parameters.AddWithValue("@PagoMovil", obj.TotalPagoMovil);
                    cmd.Parameters.AddWithValue("@PuntoVenta", obj.TotalPuntoVenta);
                    cmd.Parameters.AddWithValue("@Cashea", obj.TotalCashea);
                    cmd.Parameters.AddWithValue("@Zelle", obj.TotalZelle);
                    cmd.Parameters.AddWithValue("@IGTF", obj.TotalIGTF);
                    cmd.Parameters.AddWithValue("@Ventas", obj.TotalVentas);

                    // ==========================================
                    // 4. PARÁMETROS DEL CONTEO FÍSICO (CAJA VERDE)
                    // ==========================================
                    cmd.Parameters.AddWithValue("@FisUSD", obj.FisicoEfectivoUSD);
                    cmd.Parameters.AddWithValue("@FisBs", obj.FisicoEfectivoBs);
                    cmd.Parameters.AddWithValue("@FisPagoMovil", obj.FisicoPagoMovil);
                    cmd.Parameters.AddWithValue("@FisPuntoVenta", obj.FisicoPuntoVenta);
                    cmd.Parameters.AddWithValue("@FisTransferencia", obj.FisicoTransferencia);
                    cmd.Parameters.AddWithValue("@FisZinly", obj.FisicoZinly);
                    cmd.Parameters.AddWithValue("@FisCashea", obj.FisicoCashea);

                    // ==========================================
                    // 5. PARÁMETROS DE TOTALES Y CUADRE
                    // ==========================================
                    cmd.Parameters.AddWithValue("@TotalSis", obj.TotalSistemaCalculado);
                    cmd.Parameters.AddWithValue("@TotalFis", obj.TotalFisicoDeclarado);
                    cmd.Parameters.AddWithValue("@DifCuadre", obj.DiferenciaCuadre);

                    // ==========================================
                    // 6. ESTADO Y OBSERVACIONES
                    // ==========================================
                    cmd.Parameters.AddWithValue("@Obs", string.IsNullOrEmpty(obj.Observaciones) ? "" : obj.Observaciones);
                    cmd.Parameters.AddWithValue("@Estado", "CERRADO");

                    // Ejecutamos la inserción
                    int filasAfectadas = cmd.ExecuteNonQuery();

                    if (filasAfectadas > 0)
                    {
                        respuesta = true;
                    }
                    else
                    {
                        Mensaje = "No se pudo registrar el cierre de caja en la base de datos.";
                    }
                }
                catch (Exception ex)
                {
                    respuesta = false;
                    Mensaje = ex.Message; // Si hay algún error en nombres o tipos, aquí lo atrapará
                }
            }
            return respuesta;
        }
    }
}