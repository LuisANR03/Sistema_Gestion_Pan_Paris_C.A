using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CapaNegocios;
using CapaEntidades;
using OfficeOpenXml;
using System.IO;
using System.Runtime.InteropServices;
using Excel = Microsoft.Office.Interop.Excel;

namespace Llamen_a_Dios
{
    public partial class CierreCaja : Form
    {
        // 1. Instanciamos nuestra capa de negocio específica
        private CN_CierreCaja objCN_Cierre = new CN_CierreCaja();

        // Le ponemos CapaEntidades delante para que no se confunda con el Formulario
        private CapaEntidades.CierreCaja totalesSistema = new CapaEntidades.CierreCaja();

        public CierreCaja()
        {
            InitializeComponent();

            // ==============================================================
            // ENLAZAR EVENTOS AUTOMÁTICAMENTE
            // ==============================================================
            // Un solo manejador de eventos centralizado para todo el Arqueo Físico
            txtFisicoBs.TextChanged += new EventHandler(CajasFisicas_TextChanged);
            txtFisicoUsd.TextChanged += new EventHandler(CajasFisicas_TextChanged);
            txtFisicoPagoMovil.TextChanged += new EventHandler(CajasFisicas_TextChanged);
            txtFisicoTransferencia.TextChanged += new EventHandler(CajasFisicas_TextChanged);
            txtFisicoPuntoVenta.TextChanged += new EventHandler(CajasFisicas_TextChanged);
            txtFisicoZinly.TextChanged += new EventHandler(CajasFisicas_TextChanged);
            txtFisicoCashea.TextChanged += new EventHandler(CajasFisicas_TextChanged);
        }

        private void CierreCaja_Load(object sender, EventArgs e)
        {
            btnProcesarCierre.Enabled = false; // Desactivamos el botón de cierre hasta que se carguen los totales del sistema
            btnexcel.Enabled = false;
            CargarTotalesDelSistema();
            ConfigurarAyudaVisual();
        }

        // ==============================================================
        // MÉTODO: CARGAR TOTALES DESDE NUESTRA ENTIDAD
        // ==============================================================
        private void CargarTotalesDelSistema()
        {
            try
            {
                int idUsuarioActual = Inicio.usuarioActual.IdUsuario;

                totalesSistema = objCN_Cierre.CalcularTotalesDelDia(idUsuarioActual);

                // Repartimos los montos directo a las cajas de texto del Sistema (Formato estándar)
                txtSistemaBs.Text = totalesSistema.TotalEfectivoBs.ToString("N2");
                txtSistemaUsd.Text = totalesSistema.TotalEfectivoUSD.ToString("N2");
                txtSistemaPagoMovil.Text = totalesSistema.TotalPagoMovil.ToString("N2");
                txtSistemaPuntoVenta.Text = totalesSistema.TotalPuntoVenta.ToString("N2");
                txtSistemaCashea.Text = totalesSistema.TotalCashea.ToString("N2");

                // Mapeamos Zelle en la caja de transferencia del sistema
                txtSistemaTransferencia.Text = totalesSistema.TotalZelle.ToString("N2");
                txtSistemaZinly.Text = "0.00";

                // ==========================================================
                // MOSTRAR RENTABILIDAD Y ESTÉTICA DE UTILIDADES
                // ==========================================================
                txtCostoProduccion.Text = totalesSistema.CostoTotalProduccion.ToString("N2");
                txtGananciaNeta.Text = totalesSistema.GananciaNeta.ToString("N2");

                // Condición para cambiar textos y colores dependiendo si hay ganancia o pérdida
                if (totalesSistema.GananciaNeta >= 0)
                {
                    lblUtilidades.Text = "GANANCIAS";
                    lblUtilidades.ForeColor = Color.MediumSeaGreen; // Verde para ganancias
                    txtGananciaNeta.ForeColor = Color.MediumSeaGreen;
                }
                else
                {
                    lblUtilidades.Text = "PÉRDIDAS";
                    lblUtilidades.ForeColor = Color.Crimson; // Rojo para pérdidas
                    txtGananciaNeta.ForeColor = Color.Crimson;
                }
                // ==========================================================

                // Calculamos el arqueo inicial con los datos limpios
                CalcularArqueo();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar ventas del sistema: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Este es el detonante que se ejecuta cada vez que el usuario teclea en el área verde
        private void CajasFisicas_TextChanged(object sender, EventArgs e)
        {
            CalcularArqueo();
        }

        // ==============================================================
        // MÉTODO: CALCULAR ARQUEO (Matemática y Estética Corregidas)
        // ==============================================================
        private void CalcularArqueo()
        {
            try
            {
                decimal tasaBCV = 36.50m; // Recuerda cambiarlo por la variable global de tu sistema
                if (tasaBCV <= 0) tasaBCV = 1m;

                // Función local ultra segura para leer TextBox (Soporta comas y puntos de forma universal)
                decimal LeerMonto(TextBoxModerno textBox)
                {
                    if (string.IsNullOrWhiteSpace(textBox.Text)) return 0m;

                    string textoLimpio = textBox.Text.Trim().Replace(".", ""); // Quitamos separadores de miles
                    textoLimpio = textoLimpio.Replace(",", ".");             // Forzamos el punto decimal

                    if (decimal.TryParse(textoLimpio, System.Globalization.NumberStyles.Any, System.Globalization.CultureInfo.InvariantCulture, out decimal resultado))
                    {
                        return resultado;
                    }
                    return 0m;
                }

                // --- 1. SUMAR COLUMNA SISTEMA (Moneda por Moneda) ---
                // Solo lo que es ESTRICTAMENTE Bolívares (Bs)
                decimal sisBs = LeerMonto(txtSistemaBs) +
                                LeerMonto(txtSistemaPagoMovil) +
                                LeerMonto(txtSistemaPuntoVenta);

                // Solo lo que es ESTRICTAMENTE Dólares (USD / Pasarelas)
                decimal sisUsd = LeerMonto(txtSistemaUsd) +
                                 LeerMonto(txtSistemaTransferencia) + // Zelle es USD
                                 LeerMonto(txtSistemaZinly) +         // Zinly es USD
                                 LeerMonto(txtSistemaCashea);         // Cashea es USD

                // Convertimos la bolsa de Bs a Dólares y sumamos los dólares puros
                decimal totalSistema = (sisBs / tasaBCV) + sisUsd;
                txtTotalSis.Text = "$ " + totalSistema.ToString("N2");

                // --- 2. SUMAR COLUMNA FÍSICA (Moneda por Moneda) ---
                // Solo lo que el cajero contó en Bolívares (Bs)
                decimal fisBs = LeerMonto(txtFisicoBs) +
                                LeerMonto(txtFisicoPagoMovil) +
                                LeerMonto(txtFisicoPuntoVenta);

                // Solo lo que el cajero contó en Dólares (USD / Pasarelas)
                decimal fisUsd = LeerMonto(txtFisicoUsd) +
                                 LeerMonto(txtFisicoTransferencia) +
                                 LeerMonto(txtFisicoZinly) +
                                 LeerMonto(txtFisicoCashea);

                // Convertimos el total del conteo físico a Dólares
                decimal totalFisico = (fisBs / tasaBCV) + fisUsd;
                txtTotaldec.Text = "$ " + totalFisico.ToString("N2");

                // --- 3. CALCULAR DIFERENCIA, ESTÉTICA Y COLORES ---
                decimal diferencia = totalFisico - totalSistema;

                // Margen de tolerancia mínimo para variaciones infinitesimales por redondeo
                if (Math.Abs(diferencia) < 0.01m)
                {
                    txtcuadre.Text = "$ 0.00";
                    txtcuadre.ForeColor = Color.MediumSeaGreen;
                    lblcuadre.Text = "CAJA CUADRADA EXACTA";
                    lblcuadre.ForeColor = Color.MediumSeaGreen;

                    // Solo si entra aquí, se enciende el botón
                    btnProcesarCierre.Enabled = true;
                }
                else if (diferencia > 0)
                {
                    txtcuadre.Text = "+ $ " + diferencia.ToString("N2");
                    txtcuadre.ForeColor = Color.Goldenrod; // Color Oro / Naranja para Sobrantes
                    lblcuadre.Text = "SOBRANTE EN CAJA";
                    lblcuadre.ForeColor = Color.Goldenrod;

                    // Hay sobrante, apagamos el botón
                    btnProcesarCierre.Enabled = false;
                }
                else
                {
                    txtcuadre.Text = "- $ " + Math.Abs(diferencia).ToString("N2");
                    txtcuadre.ForeColor = Color.Crimson; // Color Carmesí / Rojo para Faltantes
                    lblcuadre.Text = "FALTANTE EN CAJA";
                    lblcuadre.ForeColor = Color.Crimson;

                    // Hay faltante, apagamos el botón
                    btnProcesarCierre.Enabled = false;
                }
            }
            catch
            {
                // Previene excepciones visuales mientras el operador limpia o edita los campos
            }
        }

        private void btnProcesarCierre_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("¿Está seguro de que desea realizar el cierre de caja definitivo? Esto finalizará su turno.",
                                                "Confirmar Cierre", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.No) return;

            try
            {
                // Función local rápida para limpiar el formato "$ 1.234,56" antes de mandar a la BDD
                decimal LimpiarMontoDecimal(string texto)
                {
                    if (string.IsNullOrWhiteSpace(texto)) return 0m;
                    string limpio = texto.Replace("$", "").Replace("+", "").Replace("-", "").Trim();
                    limpio = limpio.Replace(".", "");
                    limpio = limpio.Replace(",", ".");

                    if (decimal.TryParse(limpio, System.Globalization.NumberStyles.Any, System.Globalization.CultureInfo.InvariantCulture, out decimal res))
                        return res;
                    return 0m;
                }

                CapaEntidades.CierreCaja objCierreFinal = new CapaEntidades.CierreCaja();

                // 1. Datos de Control
                int idUsuarioLogueado = Inicio.usuarioActual.IdUsuario;
                objCierreFinal.Cajero = new Usuario() { IdUsuario = idUsuarioLogueado };
                objCierreFinal.FondoInicial = 0.00m;
                objCierreFinal.TasaCambio = 36.50m; // Se asigna la tasa para guardar la del día

                // 2. Lo que calculó el SISTEMA (Caja Azul)
                objCierreFinal.TotalEfectivoUSD = totalesSistema.TotalEfectivoUSD;
                objCierreFinal.TotalEfectivoBs = totalesSistema.TotalEfectivoBs;
                objCierreFinal.TotalPagoMovil = totalesSistema.TotalPagoMovil;
                objCierreFinal.TotalPuntoVenta = totalesSistema.TotalPuntoVenta;
                objCierreFinal.TotalCashea = totalesSistema.TotalCashea;
                objCierreFinal.TotalZelle = totalesSistema.TotalZelle;
                objCierreFinal.TotalIGTF = totalesSistema.TotalIGTF;
                objCierreFinal.TotalVentas = totalesSistema.TotalVentas;

                // 3. Lo que contó el CAJERO físicamente (Caja Verde)
                objCierreFinal.FisicoEfectivoBs = LimpiarMontoDecimal(txtFisicoBs.Text);
                objCierreFinal.FisicoEfectivoUSD = LimpiarMontoDecimal(txtFisicoUsd.Text);
                objCierreFinal.FisicoPagoMovil = LimpiarMontoDecimal(txtFisicoPagoMovil.Text);
                objCierreFinal.FisicoPuntoVenta = LimpiarMontoDecimal(txtFisicoPuntoVenta.Text);
                objCierreFinal.FisicoTransferencia = LimpiarMontoDecimal(txtFisicoTransferencia.Text);
                objCierreFinal.FisicoZinly = LimpiarMontoDecimal(txtFisicoZinly.Text);
                objCierreFinal.FisicoCashea = LimpiarMontoDecimal(txtFisicoCashea.Text);

                // 4. Totales Finales
                objCierreFinal.TotalSistemaCalculado = LimpiarMontoDecimal(txtTotalSis.Text);
                objCierreFinal.TotalFisicoDeclarado = LimpiarMontoDecimal(txtTotaldec.Text);
                objCierreFinal.DiferenciaCuadre = LimpiarMontoDecimal(txtcuadre.Text);

                if (txtcuadre.Text.Contains("-"))
                {
                    objCierreFinal.DiferenciaCuadre = -objCierreFinal.DiferenciaCuadre;
                }

                // =========================================================
                // ASIGNAR RENTABILIDAD AL OBJETO FINAL DE BASE DE DATOS
                // =========================================================
                objCierreFinal.CostoTotalProduccion = totalesSistema.CostoTotalProduccion;
                objCierreFinal.GananciaNeta = totalesSistema.GananciaNeta;

                // Preparamos el texto del cuadre para la Base de Datos y el Log
                string detalleDelCuadre = txtcuadre.Text + " - " + lblcuadre.Text;
                objCierreFinal.Observaciones = "Cierre efectuado. Cuadre: " + detalleDelCuadre;

                // =========================================================
                // 5. Envío a la Capa de Negocio
                // =========================================================
                string mensaje = string.Empty;

                bool exito = objCN_Cierre.RegistrarCierre(objCierreFinal, idUsuarioLogueado, detalleDelCuadre, out mensaje);

                if (exito)
                {
                    MessageBox.Show("¡Cierre de caja y log de auditoría registrados exitosamente!", "Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // =========================================================
                    // CAMBIO DE VISTA Y BLOQUEO DE SEGURIDAD
                    // =========================================================
                    btnProcesarCierre.Enabled = false;

                    txtFisicoBs.Enabled = false;
                    txtFisicoUsd.Enabled = false;
                    txtFisicoPagoMovil.Enabled = false;
                    txtFisicoPuntoVenta.Enabled = false;
                    txtFisicoTransferencia.Enabled = false;
                    txtFisicoZinly.Enabled = false;
                    txtFisicoCashea.Enabled = false;

                    // Deshabilitamos también los campos de rentabilidad por estética
                    txtCostoProduccion.Enabled = false;
                    txtGananciaNeta.Enabled = false;

                    // =========================================================
                    // GENERAR EL EXCEL AUTOMÁTICAMENTE
                    // =========================================================
                    GenerarReporteExcelAPdf();

                    btnexcel.Enabled = true;
                }
                else
                {
                    MessageBox.Show("No se pudo guardar el cierre: " + mensaje, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error de formato antes de guardar: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtFisicoBs__TextChanged(object sender, EventArgs e) => CalcularArqueo();
        private void txtFisicoUsd__TextChanged(object sender, EventArgs e) => CalcularArqueo();
        private void txtFisicoPagoMovil__TextChanged(object sender, EventArgs e) => CalcularArqueo();
        private void txtFisicoTransferencia__TextChanged(object sender, EventArgs e) => CalcularArqueo();
        private void txtFisicoPuntoVenta__TextChanged(object sender, EventArgs e) => CalcularArqueo();
        private void txtFisicoZinly__TextChanged(object sender, EventArgs e) => CalcularArqueo();
        private void txtFisicoCashea__TextChanged(object sender, EventArgs e) => CalcularArqueo();

        private void btnexcel_Click(object sender, EventArgs e)
        {
            GenerarReporteExcelAPdf();
        }

        // ==============================================================
        // MÉTODO: GENERAR REPORTE HÍBRIDO (EPPLUS + INTEROP PDF)
        // ==============================================================
        private void GenerarReporteExcelAPdf()
        {
            Excel.Application excelApp = null;
            Excel.Workbook workbook = null;
            Excel.Worksheet wsCaja = null;
            Excel.Worksheet wsProd = null;

            try
            {
                CN_Venta objNegocioVenta = new CN_Venta();
                DataTable dtPagos = objNegocioVenta.ObtenerTotalesCierreCaja();
                DataTable dtProductos = objNegocioVenta.ObtenerMovimientoProductosDelDia();

                if ((dtPagos == null || dtPagos.Rows.Count == 0) && (dtProductos == null || dtProductos.Rows.Count == 0))
                {
                    MessageBox.Show("No hay ventas ni movimientos registrados el día de hoy para generar el reporte.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                string nombrePlantilla = "Plantilla Cierre de Caja.xlsx";
                string rutaPlantilla = Path.Combine(Application.StartupPath, "Resources", nombrePlantilla);

                string rutaEscritorio = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
                string nombrePdf = $"CierreCaja_{DateTime.Now.ToString("dd-MM-yyyy_HH-mm-ss")}.pdf";
                string rutaFinalPdf = Path.Combine(rutaEscritorio, nombrePdf);

                if (!File.Exists(rutaPlantilla))
                {
                    MessageBox.Show("No se encontró la plantilla en la ruta:\n" + rutaPlantilla, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                excelApp = new Excel.Application();
                excelApp.Visible = false;
                excelApp.DisplayAlerts = false;

                workbook = excelApp.Workbooks.Open(rutaPlantilla);

                // --- PESTAÑA 1: CIERRE DE CAJA ---
                wsCaja = (Excel.Worksheet)workbook.Sheets[1];
                wsCaja.Cells[5, 3] = "Generado: " + DateTime.Now.ToString("dd/MM/yyyy hh:mm tt");
                wsCaja.Cells[6, 3] = "Por: " + Inicio.usuarioActual.Nombre;

                int filaCaja = 12;
                decimal totalGeneralCaja = 0;

                // ==========================================================
                // COSTO DE PRODUCCIÓN Y UTILIDADES CONVERTIDOS A BS (Fila 12)
                // ==========================================================
                decimal tasaBs = 620.50m; // Tasa solicitada

                // Conversión Costo de Producción
                decimal costoProduccionBs = totalesSistema.CostoTotalProduccion * tasaBs;
                wsCaja.Cells[12, 3] = costoProduccionBs;
                ((Excel.Range)wsCaja.Cells[12, 3]).NumberFormat = "\"Bs\" #,##0.00";

                // Conversión Utilidades
                decimal utilidadBs = totalesSistema.GananciaNeta * tasaBs;
                wsCaja.Cells[12, 4] = utilidadBs;
                ((Excel.Range)wsCaja.Cells[12, 4]).NumberFormat = "\"Bs\" #,##0.00";
                ((Excel.Range)wsCaja.Cells[12, 4]).Font.Bold = true;

                // Le damos color a la Utilidad (Verde si es ganancia, Rojo si es pérdida)
                if (utilidadBs >= 0)
                {
                    ((Excel.Range)wsCaja.Cells[12, 4]).Font.Color = ColorTranslator.ToOle(Color.ForestGreen);
                }
                else
                {
                    ((Excel.Range)wsCaja.Cells[12, 4]).Font.Color = ColorTranslator.ToOle(Color.Crimson);
                }
                // ==========================================================

                if (dtPagos != null)
                {
                    foreach (DataRow row in dtPagos.Rows)
                    {
                        wsCaja.Cells[filaCaja, 1] = row["MetodoPago"].ToString();
                        decimal monto = Convert.ToDecimal(row["TotalVendido"]);
                        wsCaja.Cells[filaCaja, 2] = monto;
                        ((Excel.Range)wsCaja.Cells[filaCaja, 2]).NumberFormat = "\"Bs\" #,##0.00"; // Aseguramos que diga "Bs"

                        totalGeneralCaja += monto;
                        filaCaja++;
                    }
                }

                // TOTALES EN CAJA (Se ubica debajo del último método de pago iterado)
                wsCaja.Cells[filaCaja, 1] = "TOTAL EN CAJA:";
                ((Excel.Range)wsCaja.Cells[filaCaja, 1]).Font.Bold = true;
                wsCaja.Cells[filaCaja, 2] = totalGeneralCaja;
                ((Excel.Range)wsCaja.Cells[filaCaja, 2]).Font.Bold = true;
                ((Excel.Range)wsCaja.Cells[filaCaja, 2]).NumberFormat = "\"Bs\" #,##0.00";

                // --- PESTAÑA 2: MOVIMIENTO DE PRODUCTOS ---
                wsProd = (Excel.Worksheet)workbook.Sheets[2];
                wsProd.Cells[4, 3] = "Generado: " + DateTime.Now.ToString("dd/MM/yyyy hh:mm tt");
                wsProd.Cells[5, 3] = "Por: " + Inicio.usuarioActual.Nombre;

                int filaProd = 12;

                if (dtProductos != null)
                {
                    foreach (DataRow row in dtProductos.Rows)
                    {
                        wsProd.Cells[filaProd, 1] = row[0].ToString();
                        wsProd.Cells[filaProd, 2] = row[1].ToString();
                        wsProd.Cells[filaProd, 3] = Convert.ToInt32(row[2]);
                        wsProd.Cells[filaProd, 4] = Convert.ToDecimal(row[3]);
                        ((Excel.Range)wsProd.Cells[filaProd, 4]).NumberFormat = "\"Bs\" #,##0.00"; // Si los productos también están en Bs

                        filaProd++;
                    }
                }

                // EXPORTAR A PDF
                workbook.ExportAsFixedFormat(
                    Excel.XlFixedFormatType.xlTypePDF,
                    rutaFinalPdf,
                    Excel.XlFixedFormatQuality.xlQualityStandard,
                    true, false, Type.Missing, Type.Missing, false, Type.Missing);

                MessageBox.Show($"¡Reporte PDF generado con éxito desde la plantilla!\nGuardado en tu escritorio como:\n{nombrePdf}", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al procesar la plantilla e Interop: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (workbook != null)
                {
                    workbook.Close(false);
                    Marshal.ReleaseComObject(workbook);
                }
                if (excelApp != null)
                {
                    excelApp.Quit();
                    Marshal.ReleaseComObject(excelApp);
                }
                if (wsCaja != null) Marshal.ReleaseComObject(wsCaja);
                if (wsProd != null) Marshal.ReleaseComObject(wsProd);

                GC.Collect();
                GC.WaitForPendingFinalizers();
            }
        }
        // ==============================================================
        // AYUDA VISUAL (ESTILO GLOBO) PARA EL CIERRE DE CAJA
        // ==============================================================
        private void ConfigurarAyudaVisual()
        {
            ToolTip toolTipCierre = new ToolTip();

            // Estilo Globo idéntico al resto del sistema
            toolTipCierre.IsBalloon = true;
            toolTipCierre.ToolTipIcon = ToolTipIcon.Info;
            toolTipCierre.ToolTipTitle = "Arqueo y Cierre de Caja";

            // Configuración de tiempos
            toolTipCierre.AutoPopDelay = 7000;
            toolTipCierre.InitialDelay = 400;
            toolTipCierre.ReshowDelay = 300;
            toolTipCierre.ShowAlways = true;

            // --- TOOLTIPS PARA EL ÁREA FÍSICA (LO QUE CUENTA EL CAJERO) ---
            string msjFisico = "Ingresa aquí el monto exacto que contaste físicamente en tu gaveta/cuentas para este método.";

            if (this.txtFisicoBs != null) toolTipCierre.SetToolTip(this.txtFisicoBs, msjFisico);
            if (this.txtFisicoUsd != null) toolTipCierre.SetToolTip(this.txtFisicoUsd, msjFisico);
            if (this.txtFisicoPagoMovil != null) toolTipCierre.SetToolTip(this.txtFisicoPagoMovil, msjFisico);
            if (this.txtFisicoPuntoVenta != null) toolTipCierre.SetToolTip(this.txtFisicoPuntoVenta, msjFisico);
            if (this.txtFisicoTransferencia != null) toolTipCierre.SetToolTip(this.txtFisicoTransferencia, msjFisico);
            if (this.txtFisicoZinly != null) toolTipCierre.SetToolTip(this.txtFisicoZinly, msjFisico);
            if (this.txtFisicoCashea != null) toolTipCierre.SetToolTip(this.txtFisicoCashea, msjFisico);

            // --- TOOLTIPS PARA EL ÁREA DEL SISTEMA ---
            string msjSistema = "Monto calculado automáticamente por el sistema según las ventas de tu turno.";
            if (this.txtSistemaBs != null) toolTipCierre.SetToolTip(this.txtSistemaBs, msjSistema);
            if (this.txtSistemaUsd != null) toolTipCierre.SetToolTip(this.txtSistemaUsd, msjSistema);

            // --- TOOLTIPS PARA RESULTADOS Y RENTABILIDAD ---
            if (this.txtcuadre != null)
            {
                toolTipCierre.SetToolTip(this.txtcuadre, "Diferencia entre el sistema y tu conteo físico.\nDebe ser $0.00 para poder cerrar la caja.");
            }

            if (this.txtGananciaNeta != null)
            {
                toolTipCierre.SetToolTip(this.txtGananciaNeta, "Utilidad neta generada durante este turno (Ingresos - Costos de Producción).");
            }

            // --- TOOLTIPS PARA BOTONES DE ACCIÓN ---
            if (this.btnProcesarCierre != null)
            {
                toolTipCierre.SetToolTip(this.btnProcesarCierre, "Procesa el cierre definitivo. Solo se habilitará si el cuadre es exacto.");
            }

            if (this.btnexcel != null)
            {
                toolTipCierre.SetToolTip(this.btnexcel, "Exporta el reporte de cierre a PDF. Disponible tras procesar el cierre.");
            }
        }
    }
}