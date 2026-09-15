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
using System.IO;


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

                // 1. Nos aseguramos de que esta línea exista (es la que escribe el texto)
                RestaurarInterfaz(respuestaIA);

                // 🌟 EL TRUCO VISUAL: Obligamos a la pantalla a dibujarse
                rtbResultadoIA.Refresh(); // Fuerza a la caja de texto a mostrar su contenido
                await Task.Delay(300);    // Le damos una pausa invisible de 0.3 segundos a C# antes de continuar

                // 6. ¡LA PREGUNTA MILLONARIA!
                DialogResult respuestaUsuario = MessageBox.Show(
                    "Análisis completado.\n\n¿Deseas generar un reporte en Excel con la meta de producción sugerida para el próximo mes?",
                    "Proyección de Inventario IA",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (respuestaUsuario == DialogResult.Yes)
                {
                    
                    string input = MostrarInputBox(
                        "La IA sugiere un ajuste. Ingrese el porcentaje de crecimiento o reducción para el próximo mes (ejemplo: 15 para aumentar un 15%, o -5 para reducir un 5%):",
                        "Definir Meta de Crecimiento",
                        "15");

                    decimal crecimientoDefinidoPorGerente = 15m;

                    // Validamos que el usuario haya ingresado un número válido
                    if (!string.IsNullOrEmpty(input) && decimal.TryParse(input, out decimal porcentajeIngresado))
                    {
                        crecimientoDefinidoPorGerente = porcentajeIngresado;
                    }
                    else if (input == "") // Si el usuario presiona "Cancelar" o cierra la ventana
                    {
                        MessageBox.Show("Operación cancelada. No se generará el reporte.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                    else
                    {
                        MessageBox.Show("El valor ingresado no es un número válido. Se utilizará el 15% por defecto.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }

                    // Enviamos el historial y el porcentaje dinámico elegido por el gerente
                    GenerarExcelProyeccion(dtHistorial, crecimientoDefinidoPorGerente);
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
        // --- MÉTODO CON MATEMÁTICA E INYECTADO DE DATOS 100% DINÁMICO ---
        private void GenerarExcelProyeccion(System.Data.DataTable dtHistorial, decimal porcentajeCrecimiento)
        {
            Excel.Application excelApp = null;
            Excel.Workbook workbook = null;
            Excel.Worksheet wsProy = null;
            Excel.Worksheet wsDiario = null;

            try
            {
                string nombrePlantilla = "Plantilla Proyeccion y Metas.xlsx";
                string rutaPlantilla = Path.Combine(Application.StartupPath, "Resources", nombrePlantilla);

                string rutaEscritorio = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
                string nombreArchivo = $"Metas_Ventas_{DateTime.Now.ToString("MMM_yyyy")}.xlsx";
                string rutaCompleta = System.IO.Path.Combine(rutaEscritorio, nombreArchivo);

                if (!File.Exists(rutaPlantilla))
                {
                    MessageBox.Show("No se encontró la plantilla en la ruta de recursos:\n" + rutaPlantilla, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                excelApp = new Excel.Application();
                excelApp.Visible = false;
                excelApp.DisplayAlerts = false;

                workbook = excelApp.Workbooks.Open(rutaPlantilla);

                // =========================================================================
                // --- HOJA 1: PROYECCIÓN MENSUAL ---
                // =========================================================================
                wsProy = (Excel.Worksheet)workbook.Sheets[1];

                wsProy.Cells[4, 3] = "Generado: " + DateTime.Now.ToString("dd/MM/yyyy hh:mm tt");
                wsProy.Cells[5, 3] = "Por: Gerente de Operaciones";

                // 🌟 NUEVO: Calculamos el factor matemático en base al porcentaje ingresado.
                // Si ingresa 20 -> factor = 1 + (20 / 100) = 1.20 (Crecimiento)
                // Si ingresa -10 -> factor = 1 + (-10 / 100) = 0.90 (Reducción por temporada baja)
                decimal factorCrecimiento = 1m + (porcentajeCrecimiento / 100m);

                // 🌟 NUEVO: Reescribimos dinámicamente el título de la columna C con el porcentaje real elegido
                wsProy.Cells[11, 3] = $"Crecimiento Estimado ({porcentajeCrecimiento}%)";

                decimal totalIngresosProyectadosMes = 0;
                int filaProy = 12; // Inicia en la fila 12 respetando tu diseño físico

                foreach (System.Data.DataRow row in dtHistorial.Rows)
                {
                    string producto = row["Producto"].ToString();

                    int total3Meses = Convert.ToInt32(row["TotalUnidades"]);
                    double promedioMensual = total3Meses / 3.0;

                    // 🌟 NUEVO: Multiplicamos por el factor dinámico elegido por el usuario
                    int metaSugerida = Convert.ToInt32(Math.Ceiling(promedioMensual * (double)factorCrecimiento));

                    decimal ingresos3Meses = Convert.ToDecimal(row["Ingresos"]);
                    decimal ingresosMensuales = ingresos3Meses / 3m;

                    // 🌟 NUEVO: Los ingresos esperados también se calculan dinámicamente
                    decimal ingresosProyectados = ingresosMensuales * factorCrecimiento;

                    totalIngresosProyectadosMes += ingresosProyectados;

                    // Inyectamos los datos en las celdas
                    wsProy.Cells[filaProy, 1] = producto;
                    wsProy.Cells[filaProy, 2] = Math.Round(promedioMensual, 0);
                    wsProy.Cells[filaProy, 3] = $"{porcentajeCrecimiento} %"; // Muestra el porcentaje real en la tabla
                    wsProy.Cells[filaProy, 4] = metaSugerida;

                    ((Excel.Range)wsProy.Cells[filaProy, 4]).Font.Bold = true;
                    ((Excel.Range)wsProy.Cells[filaProy, 4]).Font.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.DarkGreen);

                    filaProy++;
                }
                wsProy.Columns.AutoFit();

                // =========================================================================
                // --- HOJA 2: METAS DIARIAS (INGRESOS) ---
                // =========================================================================
                wsDiario = (Excel.Worksheet)workbook.Sheets[2];

                wsDiario.Cells[4, 2] = "Generado: " + DateTime.Now.ToString("dd/MM/yyyy hh:mm tt");
                wsDiario.Cells[5, 2] = "Por: Gerente de Operaciones";

                DateTime mesProximo = DateTime.Now.AddMonths(1);
                int diasDelMes = DateTime.DaysInMonth(mesProximo.Year, mesProximo.Month);

                wsDiario.Cells[12, 1] = $"Fecha ({mesProximo.ToString("MMMM yyyy").ToUpper()})";

                // La bolsa total de dinero calculada dinámicamente se divide entre los días del mes
                decimal metaDineroDiario = totalIngresosProyectadosMes / diasDelMes;
                int filaDiaria = 13; // Inicia en la fila 13 respetando tu diseño físico

                for (int dia = 1; dia <= diasDelMes; dia++)
                {
                    DateTime fechaDia = new DateTime(mesProximo.Year, mesProximo.Month, dia);

                    wsDiario.Cells[filaDiaria, 1] = fechaDia.ToString("dddd, dd/MM/yyyy");
                    wsDiario.Cells[filaDiaria, 2] = metaDineroDiario;

                    ((Excel.Range)wsDiario.Cells[filaDiaria, 2]).NumberFormat = "$ #,##0.00";

                    filaDiaria++;
                }

                // Fila Totalizadora al final de los días
                wsDiario.Cells[filaDiaria, 1] = "TOTAL PROYECTADO DEL MES:";
                ((Excel.Range)wsDiario.Cells[filaDiaria, 1]).Font.Bold = true;

                wsDiario.Cells[filaDiaria, 2] = totalIngresosProyectadosMes;
                ((Excel.Range)wsDiario.Cells[filaDiaria, 2]).Font.Bold = true;
                ((Excel.Range)wsDiario.Cells[filaDiaria, 2]).NumberFormat = "$ #,##0.00";

                wsDiario.Columns.AutoFit();

                // Guardamos los cambios en un archivo nuevo en el escritorio
                workbook.SaveAs(rutaCompleta, Excel.XlFileFormat.xlOpenXMLWorkbook);

                MessageBox.Show($"¡Excel predictivo generado con éxito!\nPorcentaje aplicado: {porcentajeCrecimiento}%\nGuardado en tu escritorio como:\n{nombreArchivo}", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al procesar la plantilla de proyección: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
        // --- MÉTODO C# NATIVO PARA REEMPLAZAR EL INPUTBOX DE VB ---
        private string MostrarInputBox(string mensaje, string titulo, string valorPorDefecto)
        {
            Form prompt = new Form()
            {
                Width = 450,
                Height = 200,
                FormBorderStyle = FormBorderStyle.FixedDialog,
                Text = titulo,
                StartPosition = FormStartPosition.CenterScreen,
                MaximizeBox = false,
                MinimizeBox = false
            };

            Label textLabel = new Label() { Left = 20, Top = 20, Width = 400, Text = mensaje };
            TextBox textBox = new TextBox() { Left = 20, Top = 60, Width = 390, Text = valorPorDefecto };
            Button confirmation = new Button() { Text = "Aceptar", Left = 230, Width = 80, Top = 100, DialogResult = DialogResult.OK };
            Button cancel = new Button() { Text = "Cancelar", Left = 330, Width = 80, Top = 100, DialogResult = DialogResult.Cancel };

            confirmation.Click += (sender, e) => { prompt.Close(); };
            cancel.Click += (sender, e) => { prompt.Close(); };

            prompt.Controls.Add(textBox);
            prompt.Controls.Add(confirmation);
            prompt.Controls.Add(cancel);
            prompt.Controls.Add(textLabel);

            // Al presionar Enter acepta, al presionar Esc cancela
            prompt.AcceptButton = confirmation;
            prompt.CancelButton = cancel;

            // Muestra la ventana y devuelve lo que el usuario escribió
            return prompt.ShowDialog() == DialogResult.OK ? textBox.Text : "";
        }
        // ==============================================================
        // AYUDA VISUAL (ESTILO GLOBO) PARA ANALÍTICA IA
        // ==============================================================
        private void ConfigurarAyudaVisual()
        {
            ToolTip toolTipIA = new ToolTip();

            // Estilo Globo idéntico al resto del sistema
            toolTipIA.IsBalloon = true;
            toolTipIA.ToolTipIcon = ToolTipIcon.Info;
            toolTipIA.ToolTipTitle = "Asistente de Inteligencia Artificial";

            // Configuración de tiempos
            toolTipIA.AutoPopDelay = 7000;
            toolTipIA.InitialDelay = 400;
            toolTipIA.ReshowDelay = 300;
            toolTipIA.ShowAlways = true;

            // --- TOOLTIPS PARA LOS BOTONES DE ACCIÓN ---
            if (this.btnAnalisisVentas != null)
            {
                toolTipIA.SetToolTip(this.btnAnalisisVentas, "Analiza el historial de ventas para encontrar tu producto estrella y sugiere estrategias de venta.");
            }

            if (this.btnSugerirCompras != null)
            {
                toolTipIA.SetToolTip(this.btnSugerirCompras, "Revisa el stock de vitrinas y almacén para sugerir qué hornear hoy y qué pedir a proveedores.");
            }

            if (this.btnProyeccion != null)
            {
                toolTipIA.SetToolTip(this.btnProyeccion, "Analiza los últimos 3 meses para predecir la demanda y permite generar un Excel con metas de producción.");
            }

            // --- TOOLTIP PARA LA PANTALLA DE RESULTADOS ---
            if (this.rtbResultadoIA != null)
            {
                toolTipIA.SetToolTip(this.rtbResultadoIA, "Aquí se mostrarán los reportes y recomendaciones generadas por la IA.");
            }
        }

        private void FormAnaliticaIA_Load(object sender, EventArgs e)
        {
            ConfigurarAyudaVisual();
        }
    }

    
}