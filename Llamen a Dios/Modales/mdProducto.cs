using CapaNegocios;
using Entidades;
using Llamen_a_Dios.Utiles; // Para la clase Opcombo
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Llamen_a_Dios.Modales
{
    public partial class mdProducto : Form
    {
        // 1. Propiedad pública donde guardaremos el producto para que FrmVentas lo reciba
        public Producto _Producto { get; private set; }

        public mdProducto()
        {
            InitializeComponent();
        }

        private void mdProducto_Load(object sender, EventArgs e)
        {
            // Llenar el combo de filtros con las columnas visibles del DataGridView
            foreach (DataGridViewColumn columna in DGVStck.Columns)
            {
                if (columna.Visible)
                {
                    CBFiltro.Items.Add(new Opcombo() { Texto = columna.HeaderText, Valor = columna.Name });
                }
            }
            CBFiltro.DisplayMember = "Texto";
            CBFiltro.ValueMember = "Valor";
            if (CBFiltro.Items.Count > 0) CBFiltro.SelectedIndex = 0;

            // Cargar los datos a la tabla
            CargarProductos();
            ConfigurarAyudaVisual();
        }

        private void CargarProductos()
        {
            DGVStck.Rows.Clear();
            List<Producto> lista = new CN_Producto().Listar();

            foreach (Producto item in lista)
            {
                // El orden aquí debe ser IDÉNTICO al orden de tus columnas en el diseño
                DGVStck.Rows.Add(new object[] {
                "",                         // [0] BtnSelect (La columna vacía del principio)
                item.IdProducto,            // [1] Id
                item.Codigo,                // [2] Codigo
                item.Nombre,                // [3] Nombre
                item.Descripcion,           // [4] Descripcion
                item.oCategoria.IdCategoria,// [5] IdCategoria (Invisible según tu imagen)
                item.oCategoria.Descripcion,// [6] Categoria
                item.Stock,                 // [7] Stock
                item.PrecioVenta,           // [8] Precio
                item.PrecioPromocion ?? 0,  // [9] Promocion
                item.Estado ? 1 : 0,        // [10] Valor
                item.EstadoValor,           // [11] EstadoValor
        });
            }
        }

        private void TBBuscar__TextChanged(object sender, EventArgs e)
        {
            if (CBFiltro.SelectedItem == null) return;

            string columnaFiltro = ((Opcombo)CBFiltro.SelectedItem).Valor.ToString();
            string textoBusqueda = TBBuscar.Text.Trim().ToLower();

            foreach (DataGridViewRow row in DGVStck.Rows)
            {
                if (row.IsNewRow) continue;
                string valorCelda = row.Cells[columnaFiltro].Value?.ToString().ToLower() ?? "";
                row.Visible = valorCelda.Contains(textoBusqueda);
            }
        }

        private void BtnLimpiar_Click(object sender, EventArgs e)
        {
            TBBuscar.Clear();
            foreach (DataGridViewRow row in DGVStck.Rows)
            {
                row.Visible = true;
            }
        }

        private void DGVStck_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            int iRow = e.RowIndex;

            try
            {
                _Producto = new Producto()
                {
                    IdProducto = Convert.ToInt32(DGVStck.Rows[iRow].Cells[1].Value), // Columna Id
                    Codigo = DGVStck.Rows[iRow].Cells[2].Value.ToString(),           // Columna Codigo
                    Nombre = DGVStck.Rows[iRow].Cells[3].Value.ToString(),           // Columna Nombre
                    Stock = Convert.ToInt32(DGVStck.Rows[iRow].Cells[7].Value),      // Columna Stock
                    PrecioVenta = Convert.ToDecimal(DGVStck.Rows[iRow].Cells[8].Value)// Columna Precio
                };

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al capturar: " + ex.Message);
            }
        }

        // ==============================================================
        // AYUDA VISUAL (ESTILO GLOBO) PARA EL MODAL DE PRODUCTOS
        // ==============================================================
        private void ConfigurarAyudaVisual()
        {
            ToolTip toolTipProducto = new ToolTip();

            // Estilo Globo idéntico al resto del sistema
            toolTipProducto.IsBalloon = true;
            toolTipProducto.ToolTipIcon = ToolTipIcon.Info;
            toolTipProducto.ToolTipTitle = "Selección de Producto";

            // Configuración de tiempos
            toolTipProducto.AutoPopDelay = 6000;
            toolTipProducto.InitialDelay = 400;
            toolTipProducto.ReshowDelay = 300;
            toolTipProducto.ShowAlways = true;

            // --- TOOLTIPS PARA LOS CONTROLES DEL MODAL ---
            toolTipProducto.SetToolTip(this.TBBuscar, "Escribe aquí para buscar rápidamente un producto en el inventario.");
            toolTipProducto.SetToolTip(this.CBFiltro, "Elige por cuál columna deseas buscar (Ej: Código, Nombre, Categoría).");
            toolTipProducto.SetToolTip(this.BtnLimpiar, "Borra el texto de búsqueda y muestra todos los productos disponibles.");

            // Instrucción clave para el DataGridView
            toolTipProducto.SetToolTip(this.DGVStck, "Haz DOBLE CLIC sobre la fila del producto\npara seleccionarlo y agregarlo a tu venta.");

            // Si tienes el botón cancelar declarado, le ponemos su ayuda
            if (this.btnCancelar != null)
            {
                toolTipProducto.SetToolTip(this.btnCancelar, "Cierra esta ventana sin seleccionar ningún producto.");
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}