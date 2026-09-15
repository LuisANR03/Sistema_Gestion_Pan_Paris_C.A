using CapaDatos;
using CapaNegocios;
using Entidades;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;

namespace Llamen_a_Dios
{
    public partial class Frmdetalleventa : Form
    {
        // Variable privada para guardar el usuario logueado actualmente
        private Usuario _usuarioActual;

        // Modificamos el constructor para recibir el usuario actual desde el formulario principal/login
        public Frmdetalleventa(Usuario usuario = null)
        {
            InitializeComponent();
            _usuarioActual = usuario;
        }

        private void Frmdetalleventa_Load(object sender, EventArgs e)
        {
            // 1. Limpiamos el ComboBox por si acaso
            cbBusqueda.Items.Clear();

            // 2. Llenar el ComboBox leyendo directamente las columnas de tu tabla
            foreach (DataGridViewColumn columna in DGV.Columns)
            {
                // Filtramos para que no agregue la columna del botón ni las ocultas
                if (columna.Visible && columna.Name != "Boton")
                {
                    cbBusqueda.Items.Add(new { Valor = columna.Name, Texto = columna.HeaderText });
                }
            }

            // 3. Le decimos al ComboBox qué mostrar y qué guardar internamente
            cbBusqueda.DisplayMember = "Texto";
            cbBusqueda.ValueMember = "Valor";

            // 4. Seleccionamos el primer elemento por defecto
            if (cbBusqueda.Items.Count > 0)
            {
                cbBusqueda.SelectedIndex = 0;
            }

            // 5. Finalmente, cargamos las ventas de la base de datos
            CargarVentas();
            ConfigurarAyudaVisual();
        }

        private void CargarVentas()
        {
            DGV.Rows.Clear();
            List<Ventas> lista = new CN_Venta().Listar(); // Llamada a tu capa de negocio
            MessageBox.Show("Ventas encontradas: " + lista.Count.ToString());

            foreach (Ventas item in lista)
            {
                DGV.Rows.Add(new object[] {
                    "🔍", // Columna del botón
                    item.IdVenta,
                    item.NumeroDocumento,
                    item.FechaVenta.ToString("dd/MM/yyyy"), // Le damos un formato limpio a la fecha
                    item.Cliente.Nombre,
                    item.Usuario.Nombre,
                    item.Vendedor.NombreCompleto,
                    item.MontoTotal.ToString("0.00")
                });
            }
        }

        private void txtBusqueda__TextChanged(object sender, EventArgs e)
        {
            // Obtenemos el nombre interno de la columna seleccionada en el ComboBox
            string columnaFiltro = ((dynamic)cbBusqueda.SelectedItem).Valor;

            if (DGV.Rows.Count > 0)
            {
                foreach (DataGridViewRow fila in DGV.Rows)
                {
                    // Verificamos si el valor de la celda contiene lo que el usuario escribió
                    if (fila.Cells[columnaFiltro].Value != null &&
                        fila.Cells[columnaFiltro].Value.ToString().Trim().ToUpper().Contains(txtBusqueda.Text.Trim().ToUpper()))
                    {
                        fila.Visible = true;
                    }
                    else
                    {
                        CurrencyManager currencyManager = (CurrencyManager)BindingContext[DGV.DataSource];
                        if (currencyManager != null) currencyManager.SuspendBinding();

                        fila.Visible = false;

                        if (currencyManager != null) currencyManager.ResumeBinding();
                    }
                }
            }
        }

        private void btnBuscarFecha_Click(object sender, EventArgs e)
        {
            txtBusqueda.Text = "";

            DateTime fechaInicio = dtpInicio.Value.Date;
            DateTime fechaFin = dtpFin.Value.Date;

            if (DGV.Rows.Count > 0)
            {
                foreach (DataGridViewRow fila in DGV.Rows)
                {
                    if (fila.Cells["FechaVenta"].Value != null)
                    {
                        DateTime fechaFila = Convert.ToDateTime(fila.Cells["FechaVenta"].Value.ToString()).Date;

                        if (fechaFila >= fechaInicio && fechaFila <= fechaFin)
                            fila.Visible = true;
                        else
                            fila.Visible = false;
                    }
                }
            }
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            txtBusqueda.Text = "";
            dtpInicio.Value = DateTime.Now;
            dtpFin.Value = DateTime.Now;

            if (DGV.Rows.Count > 0)
            {
                foreach (DataGridViewRow fila in DGV.Rows)
                {
                    fila.Visible = true;
                }
            }
        }

        private void DGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (DGV.Columns[e.ColumnIndex].Name == "Boton" || e.ColumnIndex == 0)
            {
                int rowIndex = e.RowIndex;
                if (rowIndex >= 0)
                {
                    int idVenta = Convert.ToInt32(DGV.Rows[rowIndex].Cells["IdVenta"].Value);

                    DialogResult respuesta = MessageBox.Show(
                        "¿Deseas exportar la factura de esta venta a PDF?\n\nSelecciona 'Sí' para exportar a PDF o 'No' para ver el resumen en pantalla.",
                        "Acción requerida",
                        MessageBoxButtons.YesNoCancel,
                        MessageBoxIcon.Question);

                    if (respuesta == DialogResult.Yes)
                    {
                        ExportarVentaIndividualAPdf(idVenta);
                    }
                    else if (respuesta == DialogResult.No)
                    {
                        Ventas oVenta = new CN_Venta().ObtenerVenta(idVenta);

                        if (oVenta.IdVenta != 0)
                        {
                            string mensaje = "======================================\n";
                            mensaje += "          DATOS DE LA EMPRESA          \n";
                            mensaje += "======================================\n";
                            mensaje += "EMPRESA: [PAN DE PARIS C.A.]\n";
                            mensaje += "RIF: J-30018877-9\n";
                            mensaje += "--------------------------------------\n";
                            mensaje += "          DATOS DE LA VENTA            \n";
                            mensaje += "--------------------------------------\n";
                            mensaje += $"Factura / Venta Nro: {oVenta.NumeroDocumento}\n";

                            if (!string.IsNullOrEmpty(oVenta.NumeroControl))
                                mensaje += $"Nro. Control: {oVenta.NumeroControl}\n";

                            mensaje += $"Fecha: {oVenta.FechaVenta.ToString("dd/MM/yyyy")}\n";
                            mensaje += "--------------------------------------\n";
                            mensaje += "          DATOS DEL CLIENTE            \n";
                            mensaje += "--------------------------------------\n";
                            mensaje += $"Nombre/Razón Social: {oVenta.Cliente.Nombre}\n";
                            mensaje += $"C.I. / R.I.F.: {oVenta.Cliente.Cedula}\n";

                            string correo = string.IsNullOrEmpty(oVenta.Cliente.Correo) ? "No registrado" : oVenta.Cliente.Correo;
                            string direccion = string.IsNullOrEmpty(oVenta.Cliente.Direccion) ? "No registrada" : oVenta.Cliente.Direccion;

                            mensaje += $"Correo: {correo}\n";
                            mensaje += $"Dirección: {direccion}\n";
                            mensaje += "======================================\n";
                            mensaje += "          PRODUCTOS VENDIDOS          \n";
                            mensaje += "======================================\n";

                            foreach (DetalleVenta dv in oVenta.Detalles)
                            {
                                decimal subTotalProducto = dv.PrecioUnitario;
                                decimal precioUnitarioReal = dv.Cantidad > 0 ? (subTotalProducto / dv.Cantidad) : 0;
                                mensaje += $"- {dv.Cantidad}x {dv.Producto.Nombre} \n  (P.U: ${precioUnitarioReal.ToString("0.00")}) -> SubTotal: ${subTotalProducto.ToString("0.00")}\n\n";
                            }

                            mensaje += "======================================\n";
                            mensaje += $"TOTAL A PAGAR: ${oVenta.MontoTotal.ToString("0.00")}\n";
                            mensaje += "======================================\n";
                            mensaje += "MÉTODO(S) DE PAGO:\n";

                            if (oVenta.Pagos != null && oVenta.Pagos.Count > 0)
                            {
                                foreach (VentaPagos vp in oVenta.Pagos)
                                {
                                    mensaje += $"- {vp.DescripcionMetodo}: ${vp.MontoRecibido.ToString("0.00")}";
                                    if (vp.MontoCambio > 0)
                                    {
                                        mensaje += $" (Vuelto: ${vp.MontoCambio.ToString("0.00")})";
                                    }
                                    mensaje += "\n";
                                }
                            }
                            else
                            {
                                mensaje += "- Pago en efectivo / Método no registrado.\n";
                            }

                            MessageBox.Show(mensaje, "Detalle Legal de la Venta", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                }
            }
        }

        private void btnBuscador_Click(object sender, EventArgs e)
        {
            if (cbBusqueda.SelectedItem == null) return;

            string columnaFiltro = ((dynamic)cbBusqueda.SelectedItem).Valor;

            if (DGV.Rows.Count > 0)
            {
                foreach (DataGridViewRow fila in DGV.Rows)
                {
                    if (fila.Cells[columnaFiltro].Value != null &&
                        fila.Cells[columnaFiltro].Value.ToString().Trim().ToUpper().Contains(txtBusqueda.Text.Trim().ToUpper()))
                    {
                        fila.Visible = true;
                    }
                    else
                    {
                        CurrencyManager currencyManager = (CurrencyManager)BindingContext[DGV.DataSource];
                        if (currencyManager != null) currencyManager.SuspendBinding();

                        fila.Visible = false;

                        if (currencyManager != null) currencyManager.ResumeBinding();
                    }
                }
            }
        }

        private void ExportarVentaIndividualAPdf(int idVenta)
        {
            Excel.Application excelApp = null;
            Excel.Workbook workbook = null;
            Excel.Worksheet wsFactura = null;

            try
            {
                // 1. OBTENER LOS DATOS DE LA VENTA
                CN_Venta objNegocioVenta = new CN_Venta();
                Ventas oVenta = objNegocioVenta.ObtenerVenta(idVenta);

                if (oVenta == null || oVenta.IdVenta == 0)
                {
                    MessageBox.Show("No se encontró la venta solicitada.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // 2. CONFIGURAR RUTAS
                string nombrePlantilla = "Plantilla_Factura.xlsx";
                string rutaPlantilla = Path.Combine(Application.StartupPath, "Resources", nombrePlantilla);

                // Guardaremos el PDF en el escritorio del usuario
                string rutaEscritorio = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
                string nombrePdf = $"Factura_{oVenta.NumeroDocumento}_{DateTime.Now.ToString("dd-MM-yyyy")}.pdf";
                string rutaFinalPdf = Path.Combine(rutaEscritorio, nombrePdf);

                if (!File.Exists(rutaPlantilla))
                {
                    MessageBox.Show("No se encontró la plantilla de factura en la ruta:\n" + rutaPlantilla, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // 3. INICIAR EXCEL INTEROP DE FONDO
                excelApp = new Excel.Application();
                excelApp.Visible = false;
                excelApp.DisplayAlerts = false;

                workbook = excelApp.Workbooks.Open(rutaPlantilla);
                wsFactura = (Excel.Worksheet)workbook.Sheets[1];

                // ==========================================================
                // 4. LLENAR ENCABEZADOS DE LA FACTURA
                // ==========================================================

                // Datos de la Factura (Columna 2 = B)
                wsFactura.Cells[11, 2] = oVenta.NumeroDocumento; // Celda B11
                ((Excel.Range)wsFactura.Cells[12, 2]).NumberFormat = "@";
                wsFactura.Cells[12, 2] = oVenta.FechaVenta.ToString("dd/MM/yyyy");
                wsFactura.Cells[13, 2] = oVenta.Usuario.Nombre; // Celda B13

                // Datos del Cliente (Columna 2 = B)
                wsFactura.Cells[15, 2] = oVenta.Cliente.Nombre; // Celda B15
                wsFactura.Cells[16, 2] = oVenta.Cliente.Cedula; // Celda B16
                wsFactura.Cells[17, 2] = string.IsNullOrEmpty(oVenta.Cliente.Direccion) ? "Sin dirección" : oVenta.Cliente.Direccion; // Celda B17

                // ==========================================================
                // 5. LLENAR EL DETALLE DE PRODUCTOS VENDIDOS
                // ==========================================================
                int filaInicioProductos = 20;
                int filaActual = filaInicioProductos;

                foreach (DetalleVenta dv in oVenta.Detalles)
                {
                    wsFactura.Cells[filaActual, 1] = dv.Cantidad;
                    wsFactura.Cells[filaActual, 2] = dv.Producto.Nombre;

                    decimal precioUnitario = dv.Cantidad > 0 ? (dv.PrecioUnitario / dv.Cantidad) : 0;
                    wsFactura.Cells[filaActual, 3] = precioUnitario;
                    ((Excel.Range)wsFactura.Cells[filaActual, 3]).NumberFormat = "$ #,##0.00";

                    wsFactura.Cells[filaActual, 4] = dv.PrecioUnitario;
                    ((Excel.Range)wsFactura.Cells[filaActual, 4]).NumberFormat = "$ #,##0.00";

                    filaActual++;
                }

                // ==========================================================
                // 6. TOTALES Y MÉTODOS DE PAGO
                // ==========================================================
                filaActual += 1;

                wsFactura.Cells[filaActual, 3] = "TOTAL A PAGAR:";
                ((Excel.Range)wsFactura.Cells[filaActual, 3]).Font.Bold = true;

                wsFactura.Cells[filaActual, 4] = oVenta.MontoTotal;
                ((Excel.Range)wsFactura.Cells[filaActual, 4]).Font.Bold = true;
                ((Excel.Range)wsFactura.Cells[filaActual, 4]).NumberFormat = "$ #,##0.00";

                filaActual += 2;
                wsFactura.Cells[filaActual, 1] = "MÉTODOS DE PAGO USADOS:";
                ((Excel.Range)wsFactura.Cells[filaActual, 1]).Font.Bold = true;
                filaActual++;

                if (oVenta.Pagos != null)
                {
                    foreach (VentaPagos pago in oVenta.Pagos)
                    {
                        wsFactura.Cells[filaActual, 1] = pago.DescripcionMetodo;
                        wsFactura.Cells[filaActual, 2] = pago.MontoRecibido;
                        ((Excel.Range)wsFactura.Cells[filaActual, 2]).NumberFormat = "$ #,##0.00";

                        if (pago.MontoCambio > 0)
                        {
                            wsFactura.Cells[filaActual, 3] = "Vuelto: ";
                            wsFactura.Cells[filaActual, 4] = pago.MontoCambio;
                            ((Excel.Range)wsFactura.Cells[filaActual, 4]).NumberFormat = "$ #,##0.00";
                        }
                        filaActual++;
                    }
                }

                // 7. EXPORTAR A PDF
                workbook.ExportAsFixedFormat(
                    Excel.XlFixedFormatType.xlTypePDF,
                    rutaFinalPdf,
                    Excel.XlFixedFormatQuality.xlQualityStandard,
                    true, false, Type.Missing, Type.Missing, false, Type.Missing);

                MessageBox.Show($"¡Factura PDF generada con éxito!\nGuardada en tu escritorio como:\n{nombrePdf}", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al generar la factura PDF: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                if (wsFactura != null) Marshal.ReleaseComObject(wsFactura);

                GC.Collect();
                GC.WaitForPendingFinalizers();
            }
        }

        private void btnVentas_Click(object sender, EventArgs e)
        {
            try
            {
                DateTime fechaInicio = dtpInicio.Value.Date;
                DateTime fechaFin = dtpFin.Value.Date;

                decimal totalRango = new CN_Venta().ObtenerTotalVendidoPorRango(fechaInicio, fechaFin);

                DialogResult respuesta = MessageBox.Show(
                    $"En este rango de fechas se ha vendido un total de: $ {totalRango.ToString("0.00")}\n\n" +
                    "¿Deseas exportar el Total vendido a PDF?\n\n" +
                    "Selecciona 'Sí' para exportar a PDF (Cierre + Productos) o 'No' para cerrar este mensaje.",
                    "Resumen de Ventas / Exportar",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (respuesta == DialogResult.Yes)
                {
                    ExportarCierreCajaAPdf(fechaInicio, fechaFin);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hubo un error al calcular el total: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ExportarCierreCajaAPdf(DateTime fechaInicio, DateTime fechaFin)
        {
            Excel.Application excelApp = null;
            Excel.Workbook workbook = null;
            Excel.Worksheet wsCierre = null;
            Excel.Worksheet wsMovimientos = null;

            try
            {
                var resumenMetodos = new Dictionary<string, (decimal Total, decimal Costo, decimal Utilidad)>();
                var resumenProductos = new Dictionary<string, (string Codigo, string Nombre, int Cantidad, decimal TotalGenerado)>();

                decimal granTotalVendido = 0;
                decimal granCostoProduccion = 0;
                decimal granUtilidadNeta = 0;

                // ASIGNACIÓN DEL USUARIO ACTUAL (Si es nulo de igual manera cae en un fallback seguro)
                string usuarioCajero = _usuarioActual != null ? _usuarioActual.Nombre : "Administrador";

                string formatoMoneda = "\"Bs.S \"#,##0.00";

                // ==========================================================
                // 1. PROCESAR Y AGRUPAR TODAS LAS VENTAS VISIBLES EN EL DGV
                // ==========================================================
                foreach (DataGridViewRow fila in DGV.Rows)
                {
                    if (fila.Visible && fila.Cells["IdVenta"].Value != null)
                    {
                        int idVenta = Convert.ToInt32(fila.Cells["IdVenta"].Value);
                        Ventas oVenta = new CN_Venta().ObtenerVenta(idVenta);

                        if (oVenta != null)
                        {
                            // A. Calcular Costo de Producción y Acumular Productos
                            decimal costoVentaActual = 0;
                            if (oVenta.Detalles != null)
                            {
                                foreach (DetalleVenta dv in oVenta.Detalles)
                                {
                                    costoVentaActual += (dv.Producto.CostoProduccion * dv.Cantidad);

                                    string idProd = dv.Producto.IdProducto.ToString();
                                    string codigoProd = string.IsNullOrEmpty(dv.Producto.Codigo) ? "N/A" : dv.Producto.Codigo;

                                    if (resumenProductos.ContainsKey(idProd))
                                    {
                                        var p = resumenProductos[idProd];
                                        resumenProductos[idProd] = (p.Codigo, p.Nombre, p.Cantidad + dv.Cantidad, p.TotalGenerado + dv.PrecioUnitario);
                                    }
                                    else
                                    {
                                        resumenProductos[idProd] = (codigoProd, dv.Producto.Nombre, dv.Cantidad, dv.PrecioUnitario);
                                    }
                                }
                            }

                            // B. Calcular Ingresos Netos de la Venta
                            decimal totalNetoVentaActual = 0;
                            if (oVenta.Pagos != null)
                            {
                                foreach (VentaPagos pago in oVenta.Pagos)
                                {
                                    totalNetoVentaActual += (pago.MontoRecibido - pago.MontoCambio);
                                }
                            }

                            // C. Distribuir Costos y Utilidades por Método de Pago
                            if (oVenta.Pagos != null)
                            {
                                foreach (VentaPagos pago in oVenta.Pagos)
                                {
                                    string metodo = string.IsNullOrEmpty(pago.DescripcionMetodo) ? "Efectivo" : pago.DescripcionMetodo;
                                    decimal montoNetoPago = pago.MontoRecibido - pago.MontoCambio;

                                    decimal proporcion = totalNetoVentaActual > 0 ? (montoNetoPago / totalNetoVentaActual) : 0;
                                    decimal costoProporcional = costoVentaActual * proporcion;
                                    decimal utilidadProporcional = montoNetoPago - costoProporcional;

                                    if (resumenMetodos.ContainsKey(metodo))
                                    {
                                        var m = resumenMetodos[metodo];
                                        resumenMetodos[metodo] = (m.Total + montoNetoPago, m.Costo + costoProporcional, m.Utilidad + utilidadProporcional);
                                    }
                                    else
                                    {
                                        resumenMetodos[metodo] = (montoNetoPago, costoProporcional, utilidadProporcional);
                                    }

                                    granTotalVendido += montoNetoPago;
                                    granCostoProduccion += costoProporcional;
                                    granUtilidadNeta += utilidadProporcional;
                                }
                            }
                        }
                    }
                }

                if (resumenMetodos.Count == 0)
                {
                    MessageBox.Show("No se encontraron registros de ventas en la cuadrícula para exportar.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // ==========================================================
                // 2. CONFIGURAR INTEROP EXCEL
                // ==========================================================
                string nombrePlantilla = "Plantilla Total.xlsx";
                string rutaPlantilla = Path.Combine(Application.StartupPath, "Resources", nombrePlantilla);
                string rutaEscritorio = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
                string nombrePdf = $"Cierre_Caja_{fechaInicio.ToString("dd-MM-yy")}_al_{fechaFin.ToString("dd-MM-yy")}.pdf";
                string rutaFinalPdf = Path.Combine(rutaEscritorio, nombrePdf);

                if (!File.Exists(rutaPlantilla))
                {
                    MessageBox.Show("No se encontró la plantilla:\n" + rutaPlantilla, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                excelApp = new Excel.Application();
                excelApp.Visible = false;
                excelApp.DisplayAlerts = false;

                workbook = excelApp.Workbooks.Open(rutaPlantilla);
                wsCierre = (Excel.Worksheet)workbook.Sheets["Cierre de Caja"];
                wsMovimientos = (Excel.Worksheet)workbook.Sheets["Movimiento de Productos"];

                string textoRango = $"Del {fechaInicio.ToString("dd/MM/yyyy")} al {fechaFin.ToString("dd/MM/yyyy")}";
                string fechaEmisionActual = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss");

                // ==========================================================
                // 3. LLENAR HOJA 1: CIERRE DE CAJA
                // ==========================================================
                wsCierre.Cells[8, 3] = textoRango;           // C8 -> Rango del reporte
                wsCierre.Cells[6, 4] = usuarioCajero;        // D6 -> Nombre real del usuario logueado
                wsCierre.Cells[5, 4] = fechaEmisionActual;   // D5 -> FECHA DE EMISIÓN EXACTA (¡Añadido!)

                int filaCierre = 12;
                foreach (var item in resumenMetodos)
                {
                    wsCierre.Cells[filaCierre, 1] = item.Key;
                    wsCierre.Cells[filaCierre, 2] = item.Value.Total;
                    

                    for (int col = 2; col <= 4; col++)
                        ((Excel.Range)wsCierre.Cells[filaCierre, col]).NumberFormat = formatoMoneda;

                    filaCierre++;
                }

                // Fila de Totales Generales
                filaCierre++;
                wsCierre.Cells[filaCierre, 1] = "TOTALES:";
                wsCierre.Cells[filaCierre, 2] = granTotalVendido;
              

                for (int col = 1; col <= 4; col++)
                {
                    ((Excel.Range)wsCierre.Cells[filaCierre, col]).Font.Bold = true;
                    if (col > 1) ((Excel.Range)wsCierre.Cells[filaCierre, col]).NumberFormat = formatoMoneda;
                }

                // ==========================================================
                // 4. LLENAR HOJA 2: MOVIMIENTO DE PRODUCTOS
                // ==========================================================
                wsMovimientos.Cells[7, 3] = textoRango;         // C7 -> Rango en hoja 2
                wsMovimientos.Cells[5, 4] = usuarioCajero;      // D5 -> Nombre real del usuario en hoja 2
                wsMovimientos.Cells[4, 4] = fechaEmisionActual; // D4 -> FECHA DE EMISIÓN EXACTA (¡Añadido!)

                int filaMov = 12;
                int granTotalUnidades = 0;

                foreach (var item in resumenProductos.Values)
                {
                    wsMovimientos.Cells[filaMov, 1] = item.Codigo;
                    wsMovimientos.Cells[filaMov, 2] = item.Nombre;
                    wsMovimientos.Cells[filaMov, 3] = item.Cantidad; // Unidades
                    wsMovimientos.Cells[filaMov, 4] = item.TotalGenerado;

                    ((Excel.Range)wsMovimientos.Cells[filaMov, 4]).NumberFormat = formatoMoneda;

                    granTotalUnidades += item.Cantidad;
                    filaMov++;
                }

                // Fila de Totales de Productos
                filaMov++;
                wsMovimientos.Cells[filaMov, 2] = "TOTAL ARTÍCULOS VENDIDOS:";
                wsMovimientos.Cells[filaMov, 3] = granTotalUnidades;
                wsMovimientos.Cells[filaMov, 4] = granTotalVendido;

                for (int col = 2; col <= 4; col++)
                {
                    ((Excel.Range)wsMovimientos.Cells[filaMov, col]).Font.Bold = true;
                    if (col == 4) ((Excel.Range)wsMovimientos.Cells[filaMov, col]).NumberFormat = formatoMoneda;
                }

                // ==========================================================
                // 5. EXPORTAR A PDF
                // ==========================================================
                workbook.ExportAsFixedFormat(
                    Excel.XlFixedFormatType.xlTypePDF,
                    rutaFinalPdf,
                    Excel.XlFixedFormatQuality.xlQualityStandard,
                    true, false, Type.Missing, Type.Missing, false, Type.Missing);

                MessageBox.Show($"¡Reporte Consolidado generado con éxito!\nGuardado en el escritorio como:\n{nombrePdf}", "Éxito Administrativo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error generando el Reporte de Cierre: " + ex.Message, "Error Operacional", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (workbook != null) { workbook.Close(false); Marshal.ReleaseComObject(workbook); }
                if (excelApp != null) { excelApp.Quit(); Marshal.ReleaseComObject(excelApp); }
                if (wsCierre != null) Marshal.ReleaseComObject(wsCierre);
                if (wsMovimientos != null) Marshal.ReleaseComObject(wsMovimientos);

                GC.Collect();
                GC.WaitForPendingFinalizers();
            }
        }
        // ==============================================================
        // AYUDA VISUAL (ESTILO GLOBO) PARA EL MÓDULO DE DETALLE DE VENTAS
        // ==============================================================
        private void ConfigurarAyudaVisual()
        {
            ToolTip toolTipVentas = new ToolTip();

            // Estilo Globo idéntico a las otras pantallas
            toolTipVentas.IsBalloon = true;
            toolTipVentas.ToolTipIcon = ToolTipIcon.Info;
            toolTipVentas.ToolTipTitle = "Detalles y Reportes de Ventas";

            // Configuración de tiempos
            toolTipVentas.AutoPopDelay = 6000;
            toolTipVentas.InitialDelay = 400;
            toolTipVentas.ReshowDelay = 300;
            toolTipVentas.ShowAlways = true;

            // --- TOOLTIPS PARA BÚSQUEDA GENERAL ---
            toolTipVentas.SetToolTip(this.cbBusqueda, "Selecciona la columna por la cual deseas buscar.");
            toolTipVentas.SetToolTip(this.txtBusqueda, "Escribe aquí el término a buscar (ej. número de documento o nombre del cliente).");
            toolTipVentas.SetToolTip(this.btnBuscador, "Haz clic para buscar coincidencias en la tabla.");
            toolTipVentas.SetToolTip(this.btnLimpiar, "Limpia todos los filtros de texto y fechas para mostrar la lista completa.");

            // --- TOOLTIPS PARA BÚSQUEDA POR FECHAS ---
            toolTipVentas.SetToolTip(this.dtpInicio, "Selecciona la fecha de inicio para consultar o generar el reporte.");
            toolTipVentas.SetToolTip(this.dtpFin, "Selecciona la fecha de límite (fin) para consultar o generar el reporte.");
            toolTipVentas.SetToolTip(this.btnBuscarFecha, "Filtra la lista de ventas mostrando únicamente las que entren en el rango de fechas.");

            // --- TOOLTIPS PARA ACCIONES GENERALES Y TABLA ---
            toolTipVentas.SetToolTip(this.btnVentas, "Genera y exporta a PDF el reporte de Cierre de Caja con las ventas del rango seleccionado.");
            toolTipVentas.SetToolTip(this.DGV, "Haz clic en la lupa 🔍 para ver el detalle de la factura o para exportarla a formato PDF.");
        }
    }
}