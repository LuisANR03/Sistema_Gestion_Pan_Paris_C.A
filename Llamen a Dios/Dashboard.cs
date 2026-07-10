using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq; // ¡Agregado para poder usar .Where() en las listas!
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using CapaNegocio;
using CapaEntidades;
using CapaNegocios;  // Añadido para acceder a CN_Ingrediente
using Entidades;     // Añadido para acceder a tu clase Ingrediente

namespace Llamen_a_Dios
{
    public partial class Dashboard : Form
    {
        // 1. Instanciamos la Capa de Negocio para pedir los datos
        private CN_Dashboard objetoNegocio = new CN_Dashboard();

        public Dashboard()
        {
            InitializeComponent();
        }

        // 2. Evento Load: Ocurre cuando se abre la ventana
        private void Dashboard_Load(object sender, EventArgs e)
        {
            CargarMetricas();

            // Llamamos a nuestro nuevo método para sobreescribir la tarjeta de alertas
            CargarAlertasIngredientes();
        }

        private void CargarMetricas()
        {
            try
            {
                // 3. Solicitamos la entidad completa a la Capa de Negocio
                CapaEntidades.Dashboard datos = objetoNegocio.ObtenerMetricas();

                // --- LLENADO DE TARJETAS (KPIs) ---

                // Formato "C2" convierte el número a moneda (Ej: $ 1,500.25)
                lblTotalMes.Text = datos.TotalVentasMes.ToString("C2");
                lblTotalProductos.Text = datos.TotalProductos.ToString();

                // --- LLENADO DEL GRÁFICO (CHART) ---

                // Limpiamos los datos de prueba que trae el gráfico por defecto
                chartTopProductos.Series["Unidades"].Points.Clear();
                chartTopProductos.Titles.Clear();

                // Añadimos un título profesional al gráfico
                Title tituloGrafico = chartTopProductos.Titles.Add("Top 5 Productos Más Vendidos");
                tituloGrafico.Font = new Font("Segoe UI", 12, FontStyle.Bold);
                tituloGrafico.ForeColor = Color.FromArgb(13, 13, 13); // Tu Negro Ónice

                // Recorremos la lista de productos que viene en la entidad
                foreach (ProductoTop item in datos.ListaTopProductos)
                {
                    // AddXY(Eje X: Nombre del pan, Eje Y: Cantidad vendida)
                    chartTopProductos.Series["Unidades"].Points.AddXY(item.Nombre, item.Cantidad);
                }

                // Estilo opcional: Hacer que las barras tengan el color Azul #3D76D3 que definiste
                chartTopProductos.Series["Unidades"].Color = Color.FromArgb(61, 118, 211);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hubo un error al cargar el Dashboard: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // =====================================================================
        // MÉTODO: CARGAR ALERTAS DE STOCK DE MATERIA PRIMA EN LA TARJETA
        // =====================================================================
        private void CargarAlertasIngredientes()
        {
            try
            {
                // 1. Traemos TODO el inventario de ingredientes de la BD
                List<Ingrediente> listaCompleta = new CN_Ingrediente().Listar();

                // 2. Filtramos SOLAMENTE los críticos (<= Mínimo) y que estén activos
                var ingredientesCriticos = listaCompleta.Where(i => i.StockActual <= i.StockMinimo && i.Estado == true).ToList();

                // 3. Actualizamos el número de la tarjeta con la cantidad real de ingredientes en peligro
                lblAlertasStock.Text = ingredientesCriticos.Count.ToString();

                // 4. Creamos el ToolTip nativo de Windows Forms
                ToolTip ttAlertas = new ToolTip();
                ttAlertas.IsBalloon = true; // Lo hace redondito como un globo de diálogo
                ttAlertas.ToolTipTitle = "Estado de Materia Prima";

                // 5. Lógica de colores y texto al pasar el mouse
                if (ingredientesCriticos.Count > 0)
                {
                    lblAlertasStock.ForeColor = Color.FromArgb(220, 38, 38); // Rojo de alerta
                    ttAlertas.ToolTipIcon = ToolTipIcon.Warning;

                    // Armamos la lista de lo que falta para mostrar en el globo
                    string detalleAlertas = "ATENCIÓN - Ingredientes en nivel crítico:\n\n";
                    foreach (var ing in ingredientesCriticos)
                    {
                        detalleAlertas += $"• {ing.Nombre} (Quedan: {ing.StockActual.ToString("N2")} {ing.UnidadMedida})\n";
                    }

                    // Se lo asignamos al texto y a tu panel pnlCardStock
                    ttAlertas.SetToolTip(lblAlertasStock, detalleAlertas);
                    ttAlertas.SetToolTip(pnlCardStock, detalleAlertas);
                }
                else
                {
                    lblAlertasStock.ForeColor = Color.FromArgb(22, 163, 74); // Verde (Todo OK)
                    ttAlertas.ToolTipIcon = ToolTipIcon.Info;

                    string mensajeOk = "El inventario de ingredientes está en niveles óptimos.";
                    ttAlertas.SetToolTip(lblAlertasStock, mensajeOk);
                    ttAlertas.SetToolTip(pnlCardStock, mensajeOk);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al cargar alertas de ingredientes: " + ex.Message);
            }
        }
    }
}