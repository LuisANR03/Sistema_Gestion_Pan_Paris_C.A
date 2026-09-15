using CapaNegocios;
using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace Llamen_a_Dios.Modales
{
    public partial class mdRecetas : Form
    {
        public List<DetalleReceta> IngredientesSeleccionados { get; private set; }
        public decimal CostoTotalCalculado { get; private set; }

        // Aquí agregamos el parámetro para poder recibir la receta existente
        public mdRecetas(List<DetalleReceta> recetaExistente = null)
        {
            InitializeComponent();
            IngredientesSeleccionados = new List<DetalleReceta>();
            CostoTotalCalculado = 0;

            // Si recibimos una receta (al editar un producto), la guardamos
            if (recetaExistente != null)
            {
                IngredientesSeleccionados = recetaExistente;
            }
        }

        private void mdRecetas_Load(object sender, EventArgs e)
        {
            // Ya no llamamos a ConfigurarColumnas() porque lo hiciste en el diseñador visual
            CargarIngredientes();
            ConfigurarAyudaVisual();
        }

        private void CargarIngredientes()
        {
            DGVStck.Rows.Clear();

            List<Ingrediente> listaIngredientes = new CN_Ingrediente().Listar();

            foreach (Ingrediente item in listaIngredientes)
            {
                // 1. Buscamos si el ingrediente está en la receta
                var detalleExistente = IngredientesSeleccionados.FirstOrDefault(d => d.IdIngrediente == item.IdIngrediente);

                bool estaSeleccionado = (detalleExistente != null);
                string cantidadMostrada = estaSeleccionado ? detalleExistente.CantidadRequerida.ToString("0.00") : "0.00";

                // 2. Creamos una fila vacía
                int indiceFila = DGVStck.Rows.Add();

                // 3. Llenamos celda por celda usando sus NOMBRES exactos (Revisa que así se llamen tus columnas)
                DGVStck.Rows[indiceFila].Cells["Seleccionar"].Value = estaSeleccionado;
                DGVStck.Rows[indiceFila].Cells["IdIngrediente"].Value = item.IdIngrediente;
                DGVStck.Rows[indiceFila].Cells["Nombre"].Value = item.Nombre;
                DGVStck.Rows[indiceFila].Cells["Cantidad"].Value = cantidadMostrada;
            }
        }
        

        private void btnReceta_Click(object sender, EventArgs e)
        {
            IngredientesSeleccionados.Clear();
            CostoTotalCalculado = 0; // Se queda en cero porque no usas costo

            DGVStck.EndEdit();

            foreach (DataGridViewRow row in DGVStck.Rows)
            {
                bool estaSeleccionado = Convert.ToBoolean(row.Cells["Seleccionar"].Value);

                if (estaSeleccionado)
                {
                    if (decimal.TryParse(row.Cells["Cantidad"].Value?.ToString(), out decimal cantidadIngresada))
                    {
                        if (cantidadIngresada <= 0)
                        {
                            MessageBox.Show($"La cantidad para {row.Cells["Nombre"].Value} debe ser mayor a 0.", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }

                        // Guardamos el ingrediente asumiendo costo 0
                        IngredientesSeleccionados.Add(new DetalleReceta()
                        {
                            IdIngrediente = Convert.ToInt32(row.Cells["IdIngrediente"].Value),
                            NombreIngrediente = row.Cells["Nombre"].Value.ToString(),
                            CostoUnitario = 0, // <-- Directamente en 0
                            CantidadRequerida = cantidadIngresada
                        });
                    }
                    else
                    {
                        MessageBox.Show($"Ingrese una cantidad válida en números para {row.Cells["Nombre"].Value}.", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                }
            }

            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        // ==============================================================
        // AYUDA VISUAL (ESTILO GLOBO) PARA EL MODAL DE RECETAS
        // ==============================================================
        private void ConfigurarAyudaVisual()
        {
            ToolTip toolTipReceta = new ToolTip();

            // Estilo Globo idéntico al resto del sistema
            toolTipReceta.IsBalloon = true;
            toolTipReceta.ToolTipIcon = ToolTipIcon.Info;
            toolTipReceta.ToolTipTitle = "Constructor de Recetas";

            // Configuración de tiempos
            toolTipReceta.AutoPopDelay = 7000; // Un poco más de tiempo para leer las instrucciones
            toolTipReceta.InitialDelay = 400;
            toolTipReceta.ReshowDelay = 300;
            toolTipReceta.ShowAlways = true;

            // --- TOOLTIPS PARA LA TABLA ---
            // Instrucción adaptada a la mecánica de este modal (Check + Cantidad)
            toolTipReceta.SetToolTip(this.DGVStck, "1. Marca la casilla del ingrediente.\n2. Escribe la cantidad necesaria en la columna 'Cantidad'.");

            // --- TOOLTIPS PARA LOS BOTONES ---
            if (this.btnReceta != null)
            {
                toolTipReceta.SetToolTip(this.btnReceta, "Guarda la selección actual y aplica esta receta al producto.");
            }

            if (this.btnCancelar != null)
            {
                toolTipReceta.SetToolTip(this.btnCancelar, "Cierra esta ventana sin guardar los cambios en la receta.");
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
