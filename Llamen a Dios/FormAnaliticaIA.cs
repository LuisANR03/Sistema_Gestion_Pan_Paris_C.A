using CapaNegocios;
using Entidades;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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
REGLA ESTRICTA: Solo menciona los panes que están en la lista proporcionada. No inventes datos.";

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
REGLA ESTRICTA: Basa tu respuesta ÚNICAMENTE en la lista anterior. No inventes ingredientes ni productos.";

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
            PrepararInterfaz("⏳ Cruzando datos de cuadre de caja...");

            // Este aún tiene el texto de prueba. Más adelante lo conectaremos 
            // al cierre de caja real usando tu método CN_Venta.ObtenerTotalesCierreCaja()
            string prompt = "Actúa como un auditor financiero de tiendas. Escribe un reporte de 1 párrafo muy breve simulando que encontraste un pequeño descuadre de 5 dólares en la caja del turno de la tarde. Da 2 consejos rápidos y prácticos para evitar que esto vuelva a suceder.";

            string respuesta = await ConsultarGemini(prompt);
            RestaurarInterfaz(respuesta);
        }

        // --- MÉTODOS AYUDANTES PARA NO REPETIR CÓDIGO ---
        private void PrepararInterfaz(string mensajeCarga)
        {
            lblCargando.Visible = true;
            lblCargando.Text = mensajeCarga;
            lblCargando.ForeColor = System.Drawing.Color.MediumSpringGreen;
            rtbResultadoIA.Text = "";

            btnAnalisisVentas.Enabled = false;
            btnSugerirCompras.Enabled = false;
            btnAuditoriaCaja.Enabled = false;
        }

        private void RestaurarInterfaz(string respuestaIA)
        {
            rtbResultadoIA.Text = respuestaIA;
            lblCargando.Visible = false;

            btnAnalisisVentas.Enabled = true;
            btnSugerirCompras.Enabled = true;
            btnAuditoriaCaja.Enabled = true;
        }
    }
}