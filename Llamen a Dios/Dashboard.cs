using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting; // ¡Indispensable para el gráfico!
using CapaNegocio;   // Referencia a tu Capa de Negocio
using CapaEntidades; // Referencia a tu Capa de Entidades

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
        }

        private void CargarMetricas()
        {
            try
            {
                // 3. Solicitamos la entidad completa a la Capa de Negocio
                // Esta entidad ya trae: Ventas, Alertas de Stock, Total Productos y la Lista para el Gráfico
                CapaEntidades.Dashboard datos = objetoNegocio.ObtenerMetricas();

                // --- LLENADO DE TARJETAS (KPIs) ---

                // Formato "C2" convierte el número a moneda (Ej: $ 1,500.25)
                lblTotalMes.Text = datos.TotalVentasMes.ToString("C2");

                lblAlertasStock.Text = datos.AlertasStock.ToString();

                lblTotalProductos.Text = datos.TotalProductos.ToString();

                // Lógica visual extra: Si hay stock bajo, ponemos el número en rojo/alerta
                if (datos.AlertasStock > 0)
                {
                    lblAlertasStock.ForeColor = Color.Red;
                }

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
    }
}