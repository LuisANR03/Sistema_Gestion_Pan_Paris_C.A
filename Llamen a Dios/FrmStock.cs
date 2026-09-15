using CapaDatos;
using CapaNegocios;
using Entidades;
using Llamen_a_Dios.Modales;
using Llamen_a_Dios.Utiles;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Llamen_a_Dios
{
    public partial class FrmStock : Form
    {
        private List<Producto> listaOriginalProductos;

        // 1. Variable global para almacenar al usuario actual
        private Usuario _UsuarioActual;
        private List<DetalleReceta> recetaActual = new List<DetalleReceta>();

        // 2. Modificamos el constructor para recibir el Usuario
        public FrmStock(Usuario usuarioActual = null)
        {
            InitializeComponent();
            _UsuarioActual = usuarioActual; // Guardamos el usuario

        }

        private void FrmStock_Load(object sender, EventArgs e)
        {
            // --- 1. CONFIGURACIÓN VISUAL INICIAL ---
            ConfigurarDGVModerno();

            // --- 2. LLENAR COMBOS ---
            CBEstado.Items.Add(new Opcombo() { Texto = "Activo", Valor = 1 });
            CBEstado.Items.Add(new Opcombo() { Texto = "No Activo", Valor = 0 });
            CBEstado.DisplayMember = "Texto";
            CBEstado.ValueMember = "Valor";
            CBEstado.SelectedIndex = 0;

            CN_Categoria obj_cn_categoria = new CN_Categoria();
            List<Categoria> listaCategorias = obj_cn_categoria.Listar();
            foreach (Categoria item in listaCategorias)
            {
                if (item.Estado == true)
                    CBCategoria.Items.Add(new Opcombo() { Texto = item.Descripcion, Valor = item.IdCategoria });
            }
            CBCategoria.DisplayMember = "Texto";
            CBCategoria.ValueMember = "Valor";
            if (CBCategoria.Items.Count > 0) CBCategoria.SelectedIndex = 0;

            // --- 3. CARGA DE DATOS ---
            ConfigurarAyudaVisual();
            CargarProductos();

            // --- 4. CONFIGURAR FILTRO ---
            foreach (DataGridViewColumn columna in DGVStck.Columns)
            {
                if (columna.Visible && columna.Name != "BtnSelect" &&
                    columna.Name != "IdCategoria" && columna.Name != "Valor")
                {
                    CBFiltro.Items.Add(new Opcombo() { Texto = columna.HeaderText, Valor = columna.Name });
                }
            }
            CBFiltro.DisplayMember = "Texto";
            CBFiltro.ValueMember = "Valor";
            if (CBFiltro.Items.Count > 0) CBFiltro.SelectedIndex = 0;
        }

        #region Métodos de Diseño

        private void ConfigurarDGVModerno()
        {
            DGVStck.BackgroundColor = Color.White;
            DGVStck.BorderStyle = BorderStyle.None;
            DGVStck.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            DGVStck.RowHeadersVisible = false;
            DGVStck.AllowUserToAddRows = false;
            DGVStck.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            DGVStck.MultiSelect = false;

            // Cabecera estilizada
            DGVStck.EnableHeadersVisualStyles = false;
            DGVStck.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            DGVStck.ColumnHeadersHeight = 40;
            Color colorCabecera = Color.FromArgb(245, 247, 250);
            DGVStck.ColumnHeadersDefaultCellStyle.BackColor = colorCabecera;
            DGVStck.ColumnHeadersDefaultCellStyle.ForeColor = Color.FromArgb(71, 85, 105);
            DGVStck.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI Semibold", 9F);
            DGVStck.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;

            // --- SOLUCIÓN AL CUADRO AZUL ---
            DGVStck.TopLeftHeaderCell.Style.BackColor = colorCabecera;
            DGVStck.ColumnHeadersDefaultCellStyle.SelectionBackColor = colorCabecera;
            DGVStck.RowHeadersDefaultCellStyle.SelectionBackColor = Color.Empty;

            // Filas
            DGVStck.DefaultCellStyle.BackColor = Color.White;
            DGVStck.DefaultCellStyle.ForeColor = Color.FromArgb(30, 41, 59);
            DGVStck.DefaultCellStyle.SelectionBackColor = Color.FromArgb(235, 242, 255);
            DGVStck.DefaultCellStyle.SelectionForeColor = Color.FromArgb(37, 99, 235);
            DGVStck.RowTemplate.Height = 40;
            DGVStck.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void DGVStck_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.RowIndex < 0) return;

            if (e.ColumnIndex == 0) // La columna del botón seleccionar
            {
                e.Paint(e.CellBounds, DataGridViewPaintParts.All & ~DataGridViewPaintParts.ContentForeground);
                var font = new Font("Segoe UI Emoji", 10F);
                var color = Color.FromArgb(37, 99, 235);
                TextRenderer.DrawText(e.Graphics, "✏️", font, e.CellBounds, color, TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter);
                e.Handled = true;
            }
        }

        private void pnlBuscador_Paint(object sender, PaintEventArgs e)
        {
            GraphicsPath path = new GraphicsPath();
            int curveSize = 15;
            Rectangle rect = new Rectangle(0, 0, pnlBuscador.Width, pnlBuscador.Height);
            path.AddArc(rect.X, rect.Y, curveSize, curveSize, 180, 90);
            path.AddArc(rect.Right - curveSize, rect.Y, curveSize, curveSize, 270, 90);
            path.AddArc(rect.Right - curveSize, rect.Bottom - curveSize, curveSize, curveSize, 0, 90);
            path.AddArc(rect.X, rect.Bottom - curveSize, curveSize, curveSize, 90, 90);
            pnlBuscador.Region = new Region(path);
        }

        #endregion

        private void CargarProductos()
        {
            DGVStck.Rows.Clear();
            CN_Producto obj_cn_producto = new CN_Producto();
            listaOriginalProductos = obj_cn_producto.Listar();

            foreach (Producto item in listaOriginalProductos)
            {
                DGVStck.Rows.Add(new object[] {
                    "",
                    item.IdProducto,
                    item.Codigo,
                    item.Nombre,
                    item.Descripcion,
                    item.oCategoria.IdCategoria,
                    item.oCategoria.Descripcion,
                    item.Stock,
                    item.PrecioVenta,
                    item.PrecioPromocion ?? 0,
                    item.Estado ? 1 : 0,
                    item.EstadoValor,
                    item.CostoProduccion
                });
            }
        }

        private void LimpiarCampos()
        {
            tbindice.Text = "-1";
            txtid.Text = "0";
            TBCodigo.Clear();
            tbnombre.Clear();
            tbdesc.Clear();
            tbPrecioPromocion.Clear();
            tbPrecio.Clear();
            TBStock.Clear();

            // --- NUEVAS LÍNEAS ---
            txbcosto.Clear();
            recetaActual = new List<DetalleReceta>();
            // ---------------------

            if (CBCategoria.Items.Count > 0) CBCategoria.SelectedIndex = 0;
            if (CBEstado.Items.Count > 0) CBEstado.SelectedIndex = 0;

            BtnGuardar.Text = "Guardar";
            TBCodigo.Select();
        }

        private void DGVStck_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            if (DGVStck.Columns[e.ColumnIndex].Name == "BtnSelect")
            {
                int indice = e.RowIndex;
                tbindice.Text = indice.ToString();
                txtid.Text = DGVStck.Rows[indice].Cells[1].Value.ToString();
                TBCodigo.Text = DGVStck.Rows[indice].Cells[2].Value.ToString();
                tbnombre.Text = DGVStck.Rows[indice].Cells[3].Value.ToString();
                tbdesc.Text = DGVStck.Rows[indice].Cells[4].Value.ToString();
                TBStock.Text = DGVStck.Rows[indice].Cells[7].Value.ToString();

                tbPrecio.Text = DGVStck.Rows[indice].Cells[8].Value.ToString();

                string precioPromo = DGVStck.Rows[indice].Cells[9].Value.ToString();
                tbPrecioPromocion.Text = (precioPromo == "0") ? "" : precioPromo;

                // Selección de Categoría
                int idCategoria = Convert.ToInt32(DGVStck.Rows[indice].Cells[5].Value);
                foreach (Opcombo item in CBCategoria.Items)
                {
                    if (Convert.ToInt32(item.Valor) == idCategoria)
                    {
                        CBCategoria.SelectedItem = item;
                        break;
                    }
                }

                // Selección de Estado
                int estadoValor = Convert.ToInt32(DGVStck.Rows[indice].Cells[10].Value);
                foreach (Opcombo item in CBEstado.Items)
                {
                    if (Convert.ToInt32(item.Valor) == estadoValor)
                    {
                        CBEstado.SelectedItem = item;
                        break;
                    }
                }

                // --- NUEVO: CARGAR COSTO Y RECETA AL EDITAR ---
                int idProducto = Convert.ToInt32(txtid.Text);

                // Buscamos el producto en la lista original para extraer su Costo de Producción
                Producto prodSeleccionado = listaOriginalProductos.FirstOrDefault(p => p.IdProducto == idProducto);
                if (prodSeleccionado != null)
                {
                    txbcosto.Text = prodSeleccionado.CostoProduccion.ToString("0.00");
                }

                // Pedimos a la base de datos la receta de este producto
                recetaActual = new CN_Producto().ObtenerReceta(idProducto);
                // ----------------------------------------------

                BtnGuardar.Text = "Actualizar";
            }
        }

        private void BtnGuardar_Click(object sender, EventArgs e)
        {
            string mensaje = string.Empty;
            decimal? precioPromo = null;

            if (!string.IsNullOrEmpty(tbPrecioPromocion.Text) && decimal.TryParse(tbPrecioPromocion.Text, out decimal promo))
                precioPromo = promo;

            // --- NUEVO: Leemos el costo de producción ---
            decimal costoProd = 0;
            if (!string.IsNullOrEmpty(txbcosto.Text) && decimal.TryParse(txbcosto.Text, out decimal costo))
            {
                costoProd = costo;
            }
            // --------------------------------------------

            // Obtenemos el ID del usuario
            int idUsuarioLogueado = _UsuarioActual != null ? _UsuarioActual.IdUsuario : 0;

            Producto obj_producto = new Producto()
            {
                IdProducto = Convert.ToInt32(txtid.Text),
                Codigo = TBCodigo.Text,
                Nombre = tbnombre.Text,
                Descripcion = tbdesc.Text,
                PrecioVenta = Convert.ToDecimal(tbPrecio.Text),
                Stock = string.IsNullOrEmpty(TBStock.Text) ? 0 : Convert.ToInt32(TBStock.Text),
                Estado = Convert.ToInt32(((Opcombo)CBEstado.SelectedItem).Valor) == 1,
                oCategoria = new Categoria() { IdCategoria = Convert.ToInt32(((Opcombo)CBCategoria.SelectedItem).Valor) },
                PrecioPromocion = precioPromo,

                // --- NUEVOS CAMPOS ---
                CostoProduccion = costoProd,
                DetallesReceta = this.recetaActual // Le pasamos la receta actual (temporal)
                                                   // ---------------------
            };

            CN_Producto obj_cn_producto = new CN_Producto();

            if (obj_producto.IdProducto == 0)
            {
                // Pasamos el ID del usuario al método Registrar
                int idGenerado = obj_cn_producto.Registrar(obj_producto, idUsuarioLogueado, out mensaje);
                if (idGenerado != 0)
                {
                    MessageBox.Show("Producto registrado correctamente", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    CargarProductos();
                    LimpiarCampos();
                }
                else MessageBox.Show(mensaje, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                // Pasamos el ID del usuario al método Editar
                bool resultado = obj_cn_producto.Editar(obj_producto, idUsuarioLogueado, out mensaje);
                if (resultado)
                {
                    MessageBox.Show("Producto actualizado", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    CargarProductos();
                    LimpiarCampos();
                }
                else MessageBox.Show(mensaje, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnBorrar_Click(object sender, EventArgs e)
        {
            if (Convert.ToInt32(txtid.Text) != 0)
            {
                if (MessageBox.Show("¿Desea desactivar este producto?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    string mensaje = string.Empty;

                    // 6. Obtenemos y enviamos el ID del usuario al método Eliminar
                    int idUsuarioLogueado = _UsuarioActual != null ? _UsuarioActual.IdUsuario : 0;
                    bool resultado = new CN_Producto().Eliminar(Convert.ToInt32(txtid.Text), idUsuarioLogueado, out mensaje);

                    if (resultado)
                    {
                        CargarProductos();
                        LimpiarCampos();
                    }
                    else MessageBox.Show(mensaje, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void TBBuscar_TextChanged(object sender, EventArgs e)
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
            foreach (DataGridViewRow row in DGVStck.Rows) row.Visible = true;
        }

        // ==============================================================
        // AYUDA VISUAL (ESTILO GLOBO) PARA EL MÓDULO DE STOCK / PRODUCTOS
        // ==============================================================
        private void ConfigurarAyudaVisual()
        {
            ToolTip toolTipStock = new ToolTip();

            // Estilo Globo para mantener la estética del sistema
            toolTipStock.IsBalloon = true;
            toolTipStock.ToolTipIcon = ToolTipIcon.Info;
            toolTipStock.ToolTipTitle = "Gestión de Productos y Stock";

            // Configuración de tiempos
            toolTipStock.AutoPopDelay = 6000;
            toolTipStock.InitialDelay = 400;
            toolTipStock.ReshowDelay = 300;
            toolTipStock.ShowAlways = true;

            // --- TOOLTIPS PARA EL FORMULARIO DE REGISTRO/EDICIÓN ---
            toolTipStock.SetToolTip(this.TBCodigo, "Ingresa el código único o código de barras del producto.");
            toolTipStock.SetToolTip(this.tbnombre, "Escribe el nombre del producto que se mostrará en las ventas.");
            toolTipStock.SetToolTip(this.tbdesc, "Añade una breve descripción o características del producto.");
            toolTipStock.SetToolTip(this.CBCategoria, "Clasifica el producto seleccionando una categoría.");
            toolTipStock.SetToolTip(this.TBStock, "Indica la cantidad de unidades disponibles en el inventario.");
            toolTipStock.SetToolTip(this.tbPrecio, "Establece el precio regular de venta al público.");
            toolTipStock.SetToolTip(this.tbPrecioPromocion, "Opcional: Si el producto está en oferta, ingresa el precio promocional aquí.");
            toolTipStock.SetToolTip(this.txbcosto, "Muestra el costo de producción (calculado automáticamente en base a la receta).");
            toolTipStock.SetToolTip(this.CBEstado, "Controla si el producto está visible y disponible para la venta.");

            // --- TOOLTIPS PARA LOS BOTONES DE ACCIÓN ---
            toolTipStock.SetToolTip(this.btnReceta, "Abre el panel de recetas para asignar ingredientes y calcular el costo de este producto.");
            toolTipStock.SetToolTip(this.BtnGuardar, "Guarda un producto nuevo o actualiza los datos si estás editando uno existente.");
            toolTipStock.SetToolTip(this.Btlimc, "Limpia los campos del formulario para preparar un nuevo registro.");
            toolTipStock.SetToolTip(this.btnBorrar, "Desactiva el producto seleccionado en la tabla.");

            // --- TOOLTIPS PARA BÚSQUEDA Y TABLA ---
            toolTipStock.SetToolTip(this.CBFiltro, "Elige la columna por la que deseas filtrar (Ej. Nombre o Código).");
            toolTipStock.SetToolTip(this.TBBuscar, "Escribe aquí para filtrar la tabla en tiempo real.");
            toolTipStock.SetToolTip(this.BtnLimpiar, "Limpia el buscador y muestra la lista completa de productos.");
            toolTipStock.SetToolTip(this.DGVStck, "Lista general de productos. Haz clic en el lápiz (✏️) para seleccionar y editar un producto.");
        }

        private void Btlimc_Click(object sender, EventArgs e) => LimpiarCampos();

        private void btnReceta_Click(object sender, EventArgs e)
        {

            MessageBox.Show("Ingredientes encontrados en la BD: " + this.recetaActual.Count.ToString());
            // LE PASAMOS la recetaActual por los paréntesis
            using (var modal = new mdRecetas(this.recetaActual))
            {
                var result = modal.ShowDialog();

                if (result == DialogResult.OK)
                {
                    this.recetaActual = modal.IngredientesSeleccionados;
                    txbcosto.Text = modal.CostoTotalCalculado.ToString("0.00");
                }
            }
        }
    }
}