using CapaEntidades;
using Dato;
using MySql.Data.MySqlClient;
using System;
using System.Data;

namespace CapaDatos
{
    public class CD_CierreCaja
    {
        // ==========================================
        // MÉTODO PRIVADO PARA AUDITORÍA (LOG)
        // ==========================================
        private void GuardarLog(MySqlConnection conexion, int idUsuarioLogueado, string accion, string tabla, string descripcion)
        {
            using (MySqlCommand cmdLog = new MySqlCommand("sp_RegistrarLog", conexion))
            {
                cmdLog.CommandType = CommandType.StoredProcedure;
                cmdLog.Parameters.AddWithValue("p_id_usuario", idUsuarioLogueado);
                cmdLog.Parameters.AddWithValue("p_accion", accion);
                cmdLog.Parameters.AddWithValue("p_tabla_afectada", tabla);
                cmdLog.Parameters.AddWithValue("p_descripcion", descripcion);
                cmdLog.ExecuteNonQuery();
            }
        }

        public CierreCaja CalcularTotalesDelDia(int idUsuario)
        {
            CierreCaja totales = new CierreCaja();

            using (MySqlConnection oconexion = Conexion.obtenerConexion())
            {
                try
                {
                    if (oconexion.State == ConnectionState.Closed)
                    {
                        oconexion.Open();
                    }

                    // 1. CONSULTA DE VENTAS TOTALES
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

                    // 2. CONSULTA DE METODOS DE PAGO
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

                    // 3. ACTUALIZADO: CONSULTA DE COSTOS DE PRODUCCIÓN DEL DÍA
                    // Sumamos todo el costo de producción registrado hoy
                    string queryCostos = @"SELECT IFNULL(SUM(costo_total), 0) as CostoDiario 
                                           FROM control_produccion 
                                           WHERE DATE(FechaRegistro) = CURDATE()";

                    MySqlCommand cmd3 = new MySqlCommand(queryCostos, oconexion);
                    using (MySqlDataReader dr3 = cmd3.ExecuteReader())
                    {
                        if (dr3.Read())
                        {
                            // Usamos el nuevo nombre de la propiedad de tu entidad
                            totales.CostoTotalProduccion = Convert.ToDecimal(dr3["CostoDiario"]);
                        }
                    }

                    // ACTUALIZADO: Calculamos la ganancia neta usando los nombres correctos
                    totales.GananciaNeta = totales.TotalVentas - totales.CostoTotalProduccion;

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

        // SE AÑADEN LOS 2 PARÁMETROS NUEVOS: idUsuarioLogueado y detalleCuadre
        public bool RegistrarCierre(CierreCaja obj, int idUsuarioLogueado, string detalleCuadre, out string Mensaje)
        {
            bool respuesta = false;
            Mensaje = string.Empty;

            using (MySqlConnection oconexion = Conexion.obtenerConexion())
            {
                try
                {
                    if (oconexion.State == ConnectionState.Closed)
                    {
                        oconexion.Open();
                    }

                    // ACTUALIZADO: Las columnas ahora coinciden exactamente con tu base de datos
                    string query = @"INSERT INTO cierre_caja 
                            (idUsuario, FondoInicial, TasaCambio, 
                             TotalEfectivoUSD, TotalEfectivoBs, TotalPagoMovil, TotalPuntoVenta, TotalCashea, TotalZelle, TotalIGTF, TotalVentas, 
                             FisicoEfectivoUSD, FisicoEfectivoBs, FisicoPagoMovil, FisicoPuntoVenta, FisicoTransferencia, FisicoZinly, FisicoCashea, 
                             TotalSistemaCalculado, TotalFisicoDeclarado, DiferenciaCuadre, 
                             costo_total_produccion, ganancia_neta, Observaciones, Estado) 
                            VALUES 
                            (@idUsuario, @FondoInicial, @TasaCambio, 
                             @EfeUSD, @EfeBs, @PagoMovil, @PuntoVenta, @Cashea, @Zelle, @IGTF, @Ventas, 
                             @FisUSD, @FisBs, @FisPagoMovil, @FisPuntoVenta, @FisTransferencia, @FisZinly, @FisCashea, 
                             @TotalSis, @TotalFis, @DifCuadre, @CostoProd, @Ganancia, @Obs, @Estado)";

                    MySqlCommand cmd = new MySqlCommand(query, oconexion);

                    cmd.Parameters.AddWithValue("@idUsuario", obj.Cajero.IdUsuario);
                    cmd.Parameters.AddWithValue("@FondoInicial", obj.FondoInicial);
                    cmd.Parameters.AddWithValue("@TasaCambio", obj.TasaCambio);
                    cmd.Parameters.AddWithValue("@EfeUSD", obj.TotalEfectivoUSD);
                    cmd.Parameters.AddWithValue("@EfeBs", obj.TotalEfectivoBs);
                    cmd.Parameters.AddWithValue("@PagoMovil", obj.TotalPagoMovil);
                    cmd.Parameters.AddWithValue("@PuntoVenta", obj.TotalPuntoVenta);
                    cmd.Parameters.AddWithValue("@Cashea", obj.TotalCashea);
                    cmd.Parameters.AddWithValue("@Zelle", obj.TotalZelle);
                    cmd.Parameters.AddWithValue("@IGTF", obj.TotalIGTF);
                    cmd.Parameters.AddWithValue("@Ventas", obj.TotalVentas);
                    cmd.Parameters.AddWithValue("@FisUSD", obj.FisicoEfectivoUSD);
                    cmd.Parameters.AddWithValue("@FisBs", obj.FisicoEfectivoBs);
                    cmd.Parameters.AddWithValue("@FisPagoMovil", obj.FisicoPagoMovil);
                    cmd.Parameters.AddWithValue("@FisPuntoVenta", obj.FisicoPuntoVenta);
                    cmd.Parameters.AddWithValue("@FisTransferencia", obj.FisicoTransferencia);
                    cmd.Parameters.AddWithValue("@FisZinly", obj.FisicoZinly);
                    cmd.Parameters.AddWithValue("@FisCashea", obj.FisicoCashea);
                    cmd.Parameters.AddWithValue("@TotalSis", obj.TotalSistemaCalculado);
                    cmd.Parameters.AddWithValue("@TotalFis", obj.TotalFisicoDeclarado);
                    cmd.Parameters.AddWithValue("@DifCuadre", obj.DiferenciaCuadre);

                    // ACTUALIZADO: Pasamos los valores correctos desde tu objeto CierreCaja
                    cmd.Parameters.AddWithValue("@CostoProd", obj.CostoTotalProduccion);
                    cmd.Parameters.AddWithValue("@Ganancia", obj.GananciaNeta);

                    cmd.Parameters.AddWithValue("@Obs", string.IsNullOrEmpty(obj.Observaciones) ? "" : obj.Observaciones);
                    cmd.Parameters.AddWithValue("@Estado", "CERRADO");

                    int filasAfectadas = cmd.ExecuteNonQuery();

                    if (filasAfectadas > 0)
                    {
                        respuesta = true;

                        // ==========================================
                        // REGISTRAR LA AUDITORÍA SI SE GUARDÓ CON ÉXITO
                        // ==========================================
                        string descripcionLog = $"Se registró cierre de caja. Cuadre: {detalleCuadre}. Ganancia Neta: {obj.GananciaNeta}";
                        GuardarLog(oconexion, idUsuarioLogueado, "INSERT", "cierre_caja", descripcionLog);
                    }
                    else
                    {
                        Mensaje = "No se pudo registrar el cierre de caja en la base de datos.";
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

        // ==========================================
        // NUEVO MÉTODO PARA REPORTES DE RENTABILIDAD
        // ==========================================
        public CierreCaja ObtenerRentabilidadPorFechas(string fechaInicio, string fechaFin)
        {
            CierreCaja rentabilidad = new CierreCaja();

            using (MySqlConnection oconexion = Conexion.obtenerConexion())
            {
                try
                {
                    if (oconexion.State == ConnectionState.Closed)
                    {
                        oconexion.Open();
                    }

                    // Sumamos los totales agrupando por las fechas seleccionadas
                    string query = @"
                        SELECT 
                            IFNULL(SUM(TotalSistemaCalculado), 0) AS TotalIngresado,
                            IFNULL(SUM(costo_total_produccion), 0) AS CostoTotal,
                            IFNULL(SUM(ganancia_neta), 0) AS GananciaTotal
                        FROM cierre_caja 
                        WHERE DATE(FechaCierre) BETWEEN @fechaInicio AND @fechaFin AND Estado = 'CERRADO'";

                    MySqlCommand cmd = new MySqlCommand(query, oconexion);
                    cmd.Parameters.AddWithValue("@fechaInicio", fechaInicio);
                    cmd.Parameters.AddWithValue("@fechaFin", fechaFin);
                    cmd.CommandType = CommandType.Text;

                    using (MySqlDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr.Read())
                        {
                            // Reutilizamos la entidad CierreCaja para llevar los datos al formulario
                            rentabilidad.TotalVentas = Convert.ToDecimal(dr["TotalIngresado"]);
                            rentabilidad.CostoTotalProduccion = Convert.ToDecimal(dr["CostoTotal"]);
                            rentabilidad.GananciaNeta = Convert.ToDecimal(dr["GananciaTotal"]);
                        }
                    }
                }
                catch (Exception ex)
                {
                    rentabilidad = new CierreCaja();
                    // Opcional: Podrías poner aquí un MessageBox o enviar el error a tu Log
                }
            }

            return rentabilidad;
        }
    }
}