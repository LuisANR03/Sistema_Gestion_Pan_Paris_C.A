using CapaNegocios;
using Entidades;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;

namespace Llamen_a_Dios
{
    public partial class FormAnaliticaIA : Form
    {
        // Tu llave de API
        private readonly string apiKey = "AQ.Ab8RN6Kr0lV7cefU4wKuihEdzEvcAzLyz1KOSR12Y1Df9WP9TQ";

        // HttpClient estático para optimizar conexiones
        private static readonly HttpClient client = new HttpClient();

        public FormAnaliticaIA()
        {
            InitializeComponent();
        }

        // --- EL CEREBRO: Método genérico para hablar con la IA ---
        private async Task<string> ConsultarGemini(string prompt)
        {
            string endpoint = $"https://generativelanguage.googleapis.com/v1beta/models/gemini-2.5-flash:generateContent?key={apiKey}";

            var requestBody = new
            {
                contents = new[]
                {
                    new
                    {
                        parts = new[]
                        {
                            new { text = prompt }
                        }
                    }
                }
            };

            string json = JsonConvert.SerializeObject(requestBody);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            try
            {
                HttpResponseMessage response = await client.PostAsync(endpoint, content);
                response.EnsureSuccessStatusCode();

                string responseString = await response.Content.ReadAsStringAsync();

                JObject jsonResponse = JObject.Parse(responseString);
                string textoGenerado = jsonResponse["candidates"][0]["content"]["parts"][0]["text"].ToString();

                return textoGenerado;
            }
            catch (Exception ex)
            {
                return $"❌ Hubo un error de conexión con la IA:\n\n{ex.Message}";
            }
        }

        // --- 1. BOTÓN ANÁLISIS DE VENTAS (CONECTADO A MYSQL) ---
        private async void btnAnalisisVentas_Click_1(object sender, EventArgs e)
        {
            PrepararInterfaz("⏳ Analizando tu historial de ventas reales...");

            try
            {
                // 1. Instanciamos tu Capa de Negocios de Ventas
                CN_Venta objNegocioVenta = new CN_Venta();

                // 2. Traemos el resumen agrupado de los panes vendidos
                List<string> listaVentas = objNegocioVenta.ResumenVentasParaIA();

                // Verificamos si la lista está vacía
                if (listaVentas.Count == 0 || (listaVentas.Count > 0 && listaVentas[0].StartsWith("Error")))
                {
                    RestaurarInterfaz("📊 Aún no hay ventas registradas recientemente. ¡Ve al cajero y registra algunas ventas de pan para que la IA pueda analizarlas!");
                    return;
                }

                // 3. Construimos el texto con la lista
                StringBuilder datosVentas = new StringBuilder();
                foreach (string item in listaVentas)
                {
                    datosVentas.AppendLine(item);
                }

                // 4. El Prompt estratégico para el Maestro Panadero
                string prompt = $@"Actúa como un analista de ventas experto en panaderías y pastelerías. 
Acabo de extraer estos datos reales de ventas recientes de mi sistema: 

{datosVentas.ToString()}

Escribe un reporte de 3 viñetas concisas. 
1. Identifica el pan más vendido (producto estrella).
2. Advierte cuál se está quedando rezagado.
3. Dame 1 recomendación estratégica breve y creativa (ej. un combo) para aumentar la venta del producto menos vendido.
REGLA ESTRICTA: Solo menciona los panes que están en la lista proporcionada. No inventes datos. y no des las respuestas tipadas/formateadas en MarkDown,";

                // 5. Enviamos a Gemini
                string respuesta = await ConsultarGemini(prompt);
                RestaurarInterfaz(respuesta);
            }
            catch (Exception ex)
            {
                RestaurarInterfaz($"❌ Error al leer las ventas de la base de datos:\n\n{ex.Message}");
            }
        }

        // --- 2. BOTÓN SUGERIR COMPRAS (VERSIÓN PANADERÍA COMPLETA) ---
        private async void btnSugerirCompras_Click(object sender, EventArgs e)
        {
            PrepararInterfaz("⏳ Analizando vitrinas y almacén de ingredientes...");

            try
            {
                // 1. Revisamos Panes en vitrina
                CN_Producto objNegocioProducto = new CN_Producto();
                List<Producto> listaProductos = objNegocioProducto.Listar();

                // 2. Revisamos Materia Prima
                CN_Ingrediente objNegocioIngrediente = new CN_Ingrediente();
                List<Ingrediente> listaIngredientes = objNegocioIngrediente.Listar();

                StringBuilder datosInventario = new StringBuilder();
                int alertas = 0;

                datosInventario.AppendLine("--- PANES EN VITRINA CON POCO STOCK ---");
                foreach (Producto item in listaProductos)
                {
                    if (item.Estado == true && item.Stock <= 10) // Alerta si quedan 10 panes o menos
                    {
                        datosInventario.AppendLine($"- {item.Nombre}: Quedan solo {item.Stock} unidades.");
                        alertas++;
                    }
                }

                datosInventario.AppendLine("\n--- INGREDIENTES A PUNTO DE AGOTARSE ---");
                foreach (Ingrediente ing in listaIngredientes)
                {
                    if (ing.Estado == true && ing.StockActual <= ing.StockMinimo)
                    {
                        datosInventario.AppendLine($"- {ing.Nombre}: Quedan {ing.StockActual} {ing.UnidadMedida} (Recomendado mínimo: {ing.StockMinimo}).");
                        alertas++;
                    }
                }


                if (alertas == 0)
                {
                    RestaurarInterfaz("✅ ¡Todo en orden! Las vitrinas tienen suficiente pan y el almacén tiene materia prima.");
                    return;
                }

                // 3. El Prompt del Maestro Panadero
                string prompt = $@"Actúa como un Maestro Panadero y Gerente de Compras. 
Revisé la base de datos de mi panadería y estos son los problemas actuales de inventario:

{datosInventario.ToString()}

Escribe un reporte muy conciso de máximo 4 viñetas.
Indica qué panes debemos hornear con urgencia hoy, y qué ingredientes debo pedir a mis proveedores para no detener la producción mañana. 
REGLA ESTRICTA: Basa tu respuesta ÚNICAMENTE en la lista anterior. No inventes ingredientes ni productos y no des las respuestas tipadas/formateadas en MarkDown";

                string respuesta = await ConsultarGemini(prompt);
                RestaurarInterfaz(respuesta);
            }
            catch (Exception ex)
            {
                RestaurarInterfaz($"❌ Hubo un error al leer MySQL o conectar con la IA:\n\n{ex.Message}");
            }
        }

        // --- 3. BOTÓN AUDITORÍA DE CAJA ---
        private async void btnAuditoriaCaja_Click(object sender, EventArgs e)
        {

        }

        // --- MÉTODOS AYUDANTES PARA NO REPETIR CÓDIGO ---
        private void PrepararInterfaz(string mensajeCarga)
        {
            lblCargando.Visible = true;
            lblCargando.Text = mensajeCarga;
            lblCargando.ForeColor = System.Drawing.Color.FromArgb(70, 136, 242);
            rtbResultadoIA.Text = "";

            btnAnalisisVentas.Enabled = false;
            btnSugerirCompras.Enabled = false;
            btnProyeccion.Enabled = false;
        }

        private void RestaurarInterfaz(string respuestaIA)
        {
            rtbResultadoIA.Text = respuestaIA;
            lblCargando.Visible = false;

            btnAnalisisVentas.Enabled = true;
            btnSugerirCompras.Enabled = true;
            btnProyeccion.Enabled = true;
        }

        private async void btnProyeccion_Click(object sender, EventArgs e)
        {
            PrepararInterfaz("⏳ Analizando el historial de los últimos 3 meses...");

            try
            {
                // 1. Instanciamos la Capa de Negocio
                CN_Venta objNegocioVenta = new CN_Venta();

                // 2. Traemos el historial agrupado de 3 meses (Haremos este método en el Paso 2)
                System.Data.DataTable dtHistorial = objNegocioVenta.ObtenerHistorial3Meses();

                if (dtHistorial == null || dtHistorial.Rows.Count == 0)
                {
                    RestaurarInterfaz("📊 No hay datos suficientes de meses anteriores para realizar una proyección.");
                    return;
                }

                // 3. Traducimos la tabla de MySQL para que Gemini la entienda
                StringBuilder datosVentas = new StringBuilder();
                foreach (System.Data.DataRow row in dtHistorial.Rows)
                {
                    string producto = row["Producto"].ToString();
                    string cantidad = row["TotalUnidades"].ToString();
                    decimal ingresos = Convert.ToDecimal(row["Ingresos"]);

                    datosVentas.AppendLine($"- {producto}: {cantidad} unidades en 3 meses. (Total generado: {ingresos.ToString("$ #,##0.00")})");
                }

                // 4. El Prompt Avanzado para predecir el futuro
                string prompt = $@"Actúa como un analista financiero predictivo. 
Aquí tienes el resumen total de ventas de mi panadería de los ÚLTIMOS 3 MESES:

{datosVentas.ToString()}

Escribe un reporte directivo y conciso de 3 viñetas:
1. Análisis de tendencia: Qué dice este volumen sobre las preferencias de mis clientes.
2. Predicción: Basado en esto, qué producto será el más demandado el próximo mes.
3. Sugerencia de Producción: Una recomendación para ajustar el inventario y evitar mermas.
REGLA: Basa tus predicciones solo en los datos provistos y no des las respuestas tipadas/formateadas en MarkDown";

                // 5. Enviamos a la IA y mostramos el resultado
                string respuestaIA = await ConsultarGemini(prompt);
                RestaurarInterfaz(respuestaIA);

                // 6. ¡LA PREGUNTA MILLONARIA!
                DialogResult respuestaUsuario = MessageBox.Show(
                    "Análisis completado.\n\n¿Deseas generar un reporte en Excel con la meta de producción sugerida para el próximo mes?",
                    "Proyección de Inventario IA",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (respuestaUsuario == DialogResult.Yes)
                {
                    GenerarExcelProyeccion(dtHistorial);
                }
            }
            catch (Exception ex)
            {
                RestaurarInterfaz($"❌ Error al generar la proyección:\n\n{ex.Message}");
            }
        }

        // --- MÉTODO PARA CREAR EL EXCEL PREDICTIVO ---
        // --- MÉTODO PARA CREAR EL EXCEL PREDICTIVO (CON METAS DIARIAS) ---
        // --- MÉTODO PARA CREAR EL EXCEL PREDICTIVO (CON METAS FINANCIERAS DIARIAS) ---
        private void GenerarExcelProyeccion(System.Data.DataTable dtHistorial)
        {
            Excel.Application excelApp = null;
            Excel.Workbook workbook = null;
            Excel.Worksheet wsProy = null;
            Excel.Worksheet wsDiario = null;

            try
            {
                excelApp = new Excel.Application();
                excelApp.Visible = false;
                excelApp.DisplayAlerts = false;
                workbook = excelApp.Workbooks.Add(Type.Missing);

                // ==========================================
                // --- HOJA 1: RESUMEN MENSUAL POR PRODUCTO ---
                // ==========================================
                wsProy = (Excel.Worksheet)workbook.Sheets[1];
                wsProy.Name = "Proyección Mensual";

                wsProy.Cells[1, 1] = "PROYECCIÓN DE PRODUCCIÓN PARA EL PRÓXIMO MES";
                Excel.Range titulo = wsProy.Range["A1", "D1"];
                titulo.Merge();
                titulo.Font.Bold = true;
                titulo.Font.Size = 14;

                wsProy.Cells[3, 1] = "Producto";
                wsProy.Cells[3, 2] = "Promedio Mensual Actual";
                wsProy.Cells[3, 3] = "Crecimiento Estimado (+15%)";
                wsProy.Cells[3, 4] = "META A HORNEAR SUGERIDA";

                Excel.Range encabezados = wsProy.Range["A3", "D3"];
                encabezados.Font.Bold = true;
                encabezados.Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Gold);

                // Variable para acumular todo el dinero proyectado del mes
                decimal totalIngresosProyectadosMes = 0;

                int fila = 4;
                foreach (System.Data.DataRow row in dtHistorial.Rows)
                {
                    string producto = row["Producto"].ToString();

                    // Cálculos de unidades
                    int total3Meses = Convert.ToInt32(row["TotalUnidades"]);
                    double promedioMensual = total3Meses / 3.0;
                    int metaSugerida = Convert.ToInt32(Math.Ceiling(promedioMensual * 1.15));

                    // Cálculos financieros (Dinero)
                    decimal ingresos3Meses = Convert.ToDecimal(row["Ingresos"]);
                    decimal ingresosMensuales = ingresos3Meses / 3m;
                    decimal ingresosProyectados = ingresosMensuales * 1.15m; // +15% de dinero esperado

                    totalIngresosProyectadosMes += ingresosProyectados; // Sumamos a la gran bolsa del mes

                    wsProy.Cells[fila, 1] = producto;
                    wsProy.Cells[fila, 2] = Math.Round(promedioMensual, 0);
                    wsProy.Cells[fila, 3] = "15 %";
                    wsProy.Cells[fila, 4] = metaSugerida;
                    wsProy.Cells[fila, 4].Font.Bold = true;
                    wsProy.Cells[fila, 4].Font.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.DarkGreen);

                    fila++;
                }
                wsProy.Columns.AutoFit();

                // ==========================================
                // --- HOJA 2: METAS DE VENTAS DIARIAS ($) ---
                // ==========================================
                wsDiario = (Excel.Worksheet)workbook.Sheets.Add(After: wsProy);
                wsDiario.Name = "Metas Diarias (Ingresos)";

                wsDiario.Cells[1, 1] = "META ESTIMADA DE VENTAS DIARIAS EN CAJA";
                Excel.Range tituloDiario = wsDiario.Range["A1", "B1"];
                tituloDiario.Merge();
                tituloDiario.Font.Bold = true;
                tituloDiario.Font.Size = 14;

                // Calculamos el mes siguiente y sus días
                DateTime mesProximo = DateTime.Now.AddMonths(1);
                int diasDelMes = DateTime.DaysInMonth(mesProximo.Year, mesProximo.Month);

                // Encabezados
                wsDiario.Cells[3, 1] = $"Fecha ({mesProximo.ToString("MMMM yyyy").ToUpper()})";
                wsDiario.Cells[3, 2] = "Meta de Ingresos a Facturar";

                Excel.Range encDiario = wsDiario.Range["A3", "B3"];
                encDiario.Font.Bold = true;
                encDiario.Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.LightGreen);

                // Dividimos la bolsa de dinero entre los días del mes
                decimal metaDineroDiario = totalIngresosProyectadosMes / diasDelMes;

                // Llenamos los días hacia abajo
                int filaDiaria = 4;
                for (int dia = 1; dia <= diasDelMes; dia++)
                {
                    DateTime fechaDia = new DateTime(mesProximo.Year, mesProximo.Month, dia);

                    // Columna 1: Fecha
                    wsDiario.Cells[filaDiaria, 1] = fechaDia.ToString("dddd, dd/MM/yyyy"); // Formato "lunes, 01/07/2026"

                    // Columna 2: Meta de dinero
                    wsDiario.Cells[filaDiaria, 2] = metaDineroDiario;

                    // Le damos formato de Moneda
                    Excel.Range celdaMonto = (Excel.Range)wsDiario.Cells[filaDiaria, 2];
                    celdaMonto.NumberFormat = "$ #,##0.00";

                    filaDiaria++;
                }

                // Fila Total al final
                wsDiario.Cells[filaDiaria, 1] = "TOTAL PROYECTADO DEL MES:";
                wsDiario.Cells[filaDiaria, 1].Font.Bold = true;
                wsDiario.Cells[filaDiaria, 2] = totalIngresosProyectadosMes;
                wsDiario.Cells[filaDiaria, 2].Font.Bold = true;
                ((Excel.Range)wsDiario.Cells[filaDiaria, 2]).NumberFormat = "$ #,##0.00";

                wsDiario.Columns.AutoFit();

                // ==========================================
                // --- GUARDAR ARCHIVO EN ESCRITORIO ---
                // ==========================================
                string rutaEscritorio = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
                string nombreArchivo = $"Metas_Ventas_{DateTime.Now.ToString("MMM_yyyy")}.xlsx";
                string rutaCompleta = System.IO.Path.Combine(rutaEscritorio, nombreArchivo);

                workbook.SaveAs(rutaCompleta, Excel.XlFileFormat.xlOpenXMLWorkbook);

                MessageBox.Show($"¡Excel predictivo generado con éxito!\nGuardado en tu escritorio como:\n{nombreArchivo}", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al crear el Excel de proyección: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (workbook != null) { workbook.Close(false); Marshal.ReleaseComObject(workbook); }
                if (excelApp != null) { excelApp.Quit(); Marshal.ReleaseComObject(excelApp); }
                if (wsProy != null) Marshal.ReleaseComObject(wsProy);
                if (wsDiario != null) Marshal.ReleaseComObject(wsDiario);
                GC.Collect();
                GC.WaitForPendingFinalizers();
            }
        }
    }
    
}