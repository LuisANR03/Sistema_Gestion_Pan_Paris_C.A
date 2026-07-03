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
            btnexcel.Enabled = false;
            CargarTotalesDelSistema();
        }

        // ==============================================================
        // MÉTODO: CARGAR TOTALES DESDE NUESTRA ENTIDAD
        // ==============================================================
        private void CargarTotalesDelSistema()
        {
            try
            {
                int idUsuarioActual = 2; // OJO: Reemplaza por tu variable global del usuario

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
                }
                else if (diferencia > 0)
                {
                    txtcuadre.Text = "+ $ " + diferencia.ToString("N2");
                    txtcuadre.ForeColor = Color.Goldenrod; // Color Oro / Naranja para Sobrantes
                    lblcuadre.Text = "SOBRANTE EN CAJA";
                    lblcuadre.ForeColor = Color.Goldenrod;
                }
                else
                {
                    txtcuadre.Text = "- $ " + Math.Abs(diferencia).ToString("N2");
                    txtcuadre.ForeColor = Color.Crimson; // Color Carmesí / Rojo para Faltantes
                    lblcuadre.Text = "FALTANTE EN CAJA";
                    lblcuadre.ForeColor = Color.Crimson;
                }
            }
            catch
            {
                // Previene excepciones visuales mientras el operador limpia o edita los campos
            }
        }

        // ==============================================================
        // EVENTO: GUARDAR CIERRE DEFINITIVO
        // ==============================================================
        private void btnGuardarCierre_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("¿Está seguro de que desea realizar el cierre de caja definitivo? Esto finalizará su turno.",
                                                "Confirmar Cierre", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.No) return;

            CapaEntidades.CierreCaja objCierreFinal = new CapaEntidades.CierreCaja();

            objCierreFinal.Cajero = new Usuario() { IdUsuario = 2 }; // Cambiar por tu ID dinámico
            objCierreFinal.FondoInicial = 0.00m;

            objCierreFinal.TotalEfectivoUSD = totalesSistema.TotalEfectivoUSD;
            objCierreFinal.TotalEfectivoBs = totalesSistema.TotalEfectivoBs;
            objCierreFinal.TotalPagoMovil = totalesSistema.TotalPagoMovil;
            objCierreFinal.TotalPuntoVenta = totalesSistema.TotalPuntoVenta;
            objCierreFinal.TotalCashea = totalesSistema.TotalCashea;
            objCierreFinal.TotalZelle = totalesSistema.TotalZelle;
            objCierreFinal.TotalIGTF = totalesSistema.TotalIGTF;
            objCierreFinal.TotalVentas = totalesSistema.TotalVentas;

            objCierreFinal.Observaciones = "Cierre efectuado. Cuadre: " + txtcuadre.Text + " - " + lblcuadre.Text;

            string mensaje = string.Empty;

            bool exito = objCN_Cierre.RegistrarCierre(objCierreFinal, out mensaje);

            if (exito)
            {
                MessageBox.Show("¡Cierre de caja registrado exitosamente!\n\nPor favor, exporte su comprobante en Excel ahora.", "Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // =========================================================
                // CAMBIO DE VISTA
                // =========================================================

                // 1. Apagamos el botón de cerrar caja para evitar duplicados
                btnProcesarCierre.Enabled = false;

                // 2. Encendemos el botón de exportar Excel
                btnexcel.Enabled = true;

                // 3. (Opcional) Te recomiendo bloquear los TextBox para que el cajero no siga editando números
                txtFisicoBs.Enabled = false;
                txtFisicoUsd.Enabled = false;
                txtFisicoPagoMovil.Enabled = false;
                txtFisicoPuntoVenta.Enabled = false;
                txtFisicoTransferencia.Enabled = false;
                txtFisicoZinly.Enabled = false;
                txtFisicoCashea.Enabled = false;

                // ELIMINAMOS el this.Close() para que el usuario se quede en la pantalla y le dé al botón del Excel.
            }
            else
            {
                MessageBox.Show("No se pudo guardar el cierre: " + mensaje, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                objCierreFinal.Cajero = new Usuario() { IdUsuario = 2 }; // Cambiar por tu ID dinámico
                objCierreFinal.FondoInicial = 0.00m;
                // NOTA: Si en tu entidad tienes una propiedad para la Tasa, agrégala aquí (ej. objCierreFinal.TasaCambio = 36.50m;)

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

                objCierreFinal.Observaciones = "Cierre efectuado. Cuadre: " + txtcuadre.Text + " - " + lblcuadre.Text;

                // 5. Envío a la Capa de Negocio
                string mensaje = string.Empty;
                bool exito = objCN_Cierre.RegistrarCierre(objCierreFinal, out mensaje);

                if (exito)
                {
                    MessageBox.Show("¡Cierre de caja registrado exitosamente!", "Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // =========================================================
                    // ¡AQUÍ ES DONDE GENERAMOS EL EXCEL AUTOMÁTICAMENTE!
                    // =========================================================
                    GenerarReporteExcel();

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

        private void txtFisicoBs__TextChanged(object sender, EventArgs e)
        {
            CalcularArqueo();
        }

        private void txtFisicoUsd__TextChanged(object sender, EventArgs e)
        {
            CalcularArqueo();
        }

        private void txtFisicoPagoMovil__TextChanged(object sender, EventArgs e)
        {
            CalcularArqueo();
        }

        private void txtFisicoTransferencia__TextChanged(object sender, EventArgs e)
        {
            CalcularArqueo();   

        } 

        private void txtFisicoPuntoVenta__TextChanged(object sender, EventArgs e)
        {
            CalcularArqueo();
        }

        private void txtFisicoZinly__TextChanged(object sender, EventArgs e)
        {
            CalcularArqueo();
        }

        private void txtFisicoCashea__TextChanged(object sender, EventArgs e)
        {
            CalcularArqueo();
        }

        private void GenerarReporteExcel()
        {
            // Declaramos los objetos de Excel afuera para poder liberarlos de forma segura en el 'finally'
            Excel.Application excelApp = null;
            Excel.Workbook workbook = null;
            Excel.Worksheet wsCaja = null;
            Excel.Worksheet wsProd = null;

            try
            {
                // 1. Instanciamos la capa de negocio y obtenemos los datos de la Base de Datos
                CN_Venta objNegocioVenta = new CN_Venta();
                DataTable dtPagos = objNegocioVenta.ObtenerTotalesCierreCaja();
                DataTable dtProductos = objNegocioVenta.ObtenerMovimientoProductosDelDia();

                // Si ambas tablas están vacías, avisamos al usuario y detenemos el proceso
                if ((dtPagos == null || dtPagos.Rows.Count == 0) && (dtProductos == null || dtProductos.Rows.Count == 0))
                {
                    MessageBox.Show("No hay ventas ni movimientos registrados el día de hoy para generar el reporte.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // 2. Inicializamos la aplicación de Excel en modo oculto (en segundo plano)
                excelApp = new Excel.Application();
                excelApp.Visible = false;
                excelApp.DisplayAlerts = false; // Evita que Excel muestre alertas molestas de confirmación

                // 3. Creamos un nuevo libro de trabajo limpio
                workbook = excelApp.Workbooks.Add(Type.Missing);

                // =========================================================================
                // --- PESTAÑA 1: RESUMEN DE CIERRE DE CAJA (Métodos de Pago) ---
                // =========================================================================
                wsCaja = (Excel.Worksheet)workbook.Sheets[1];
                wsCaja.Name = "Cierre de Caja";

                // Título Principal de la Pestaña 1
                wsCaja.Cells[1, 1] = "REPORTE DE CIERRE DE CAJA";
                Excel.Range tituloCaja = wsCaja.Range["A1", "B1"];
                tituloCaja.Merge();
                tituloCaja.Font.Bold = true;
                tituloCaja.Font.Size = 14;

                // Fecha y hora del reporte
                wsCaja.Cells[2, 1] = "Fecha: " + DateTime.Now.ToString("dd/MM/yyyy hh:mm tt");

                // Encabezados de la Tabla de Pagos
                wsCaja.Cells[4, 1] = "Método de Pago";
                wsCaja.Cells[4, 2] = "Total Ingresado";
                Excel.Range encCaja = wsCaja.Range["A4", "B4"];
                encCaja.Font.Bold = true;
                encCaja.Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.LightGray);

                // Llenado de los datos de métodos de pago
                int filaCaja = 5;
                decimal totalGeneralCaja = 0;

                if (dtPagos != null)
                {
                    foreach (DataRow row in dtPagos.Rows)
                    {
                        wsCaja.Cells[filaCaja, 1] = row["MetodoPago"].ToString();

                        decimal monto = Convert.ToDecimal(row["TotalVendido"]);
                        wsCaja.Cells[filaCaja, 2] = monto;

                        // Aplicamos formato de moneda ($) a la celda del dinero
                        Excel.Range celdaMonto = (Excel.Range)wsCaja.Cells[filaCaja, 2];
                        celdaMonto.NumberFormat = "$ #,##0.00";

                        totalGeneralCaja += monto;
                        filaCaja++;
                    }
                }

                // Fila de Totales de la Caja
                wsCaja.Cells[filaCaja, 1] = "TOTAL EN CAJA:";
                wsCaja.Cells[filaCaja, 1].Font.Bold = true;
                wsCaja.Cells[filaCaja, 2] = totalGeneralCaja;
                wsCaja.Cells[filaCaja, 2].Font.Bold = true;
                ((Excel.Range)wsCaja.Cells[filaCaja, 2]).NumberFormat = "$ #,##0.00";

                // Autoajustar el ancho de las columnas de la pestaña 1 para que el texto no se corte
                wsCaja.Columns.AutoFit();


                // =========================================================================
                // --- PESTAÑA 2: MOVIMIENTO DE PRODUCTOS (Panes y productos vendidos) ---
                // =========================================================================
                // Añadimos una nueva pestaña en el libro justo después de la pestaña de Caja
                wsProd = (Excel.Worksheet)workbook.Sheets.Add(Type.Missing, wsCaja, Type.Missing, Type.Missing);
                wsProd.Name = "Movimiento de Productos";

                // Título Principal de la Pestaña 2
                wsProd.Cells[1, 1] = "PANES Y PRODUCTOS VENDIDOS HOY";
                Excel.Range tituloProd = wsProd.Range["A1", "D1"];
                tituloProd.Merge();
                tituloProd.Font.Bold = true;
                tituloProd.Font.Size = 14;

                // Encabezados de la Tabla de Productos
                wsProd.Cells[3, 1] = "Código";
                wsProd.Cells[3, 2] = "Producto";
                wsProd.Cells[3, 3] = "Unidades Vendidas";
                wsProd.Cells[3, 4] = "Total Generado";
                Excel.Range encProd = wsProd.Range["A3", "D3"];
                encProd.Font.Bold = true;
                encProd.Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.LightSkyBlue);

                // Llenado de los datos de productos desde el DataTable
                int filaProd = 4;
                if (dtProductos != null)
                {
                    foreach (DataRow row in dtProductos.Rows)
                    {
                        wsProd.Cells[filaProd, 1] = row[0].ToString(); // Código de producto
                        wsProd.Cells[filaProd, 2] = row[1].ToString(); // Nombre del producto
                        wsProd.Cells[filaProd, 3] = row[2];            // Cantidad de unidades (int)
                        wsProd.Cells[filaProd, 4] = row[3];            // Total acumulado en dinero (decimal)

                        // Formato de moneda ($) a la columna de totales de productos
                        Excel.Range celdaTotalProd = (Excel.Range)wsProd.Cells[filaProd, 4];
                        celdaTotalProd.NumberFormat = "$ #,##0.00";

                        filaProd++;
                    }
                }

                // Autoajustar el ancho de las columnas de la pestaña 2
                wsProd.Columns.AutoFit();


                // =========================================================================
                // --- RUTA Y GUARDADO AUTOMÁTICO EN EL ESCRITORIO ---
                // =========================================================================
                string rutaEscritorio = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
                // El nombre incluirá la fecha y la hora exacta para evitar que un reporte reemplace a otro
                string nombreArchivo = $"CierreCaja_{DateTime.Now.ToString("dd-MM-yyyy_HH-mm-ss")}.xlsx";
                string rutaCompleta = Path.Combine(rutaEscritorio, nombreArchivo);

                // Guardamos el documento especificando el formato oficial moderno (.xlsx)
                workbook.SaveAs(rutaCompleta, Excel.XlFileFormat.xlOpenXMLWorkbook, Type.Missing,
                    Type.Missing, false, false, Excel.XlSaveAsAccessMode.xlNoChange,
                    Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing);

                // Mensaje de éxito al usuario
                MessageBox.Show($"¡Reporte generado con éxito de manera nativa!\nGuardado en tu escritorio como:\n{nombreArchivo}", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                // Si algo llega a fallar con las celdas o los permisos de Windows, lo atrapamos aquí
                MessageBox.Show("Error crítico al generar el archivo Excel nativo: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                // =========================================================================
                // 🔥 LIMPIEZA TOTAL Y LIBERACIÓN DE MEMORIA RAM COM (Crucial para Office)
                // =========================================================================
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

                // Le ordenamos a C# que limpie de forma inmediata cualquier rastro muerto de Office en la RAM
                GC.Collect();
                GC.WaitForPendingFinalizers();
            }
        }

        private void btnexcel_Click(object sender, EventArgs e)
        {
            GenerarReporteExcel();
        }
    }
    
}