using CapaDatos;
using CapaNegocios;
using Entidades;
using Llamen_a_Dios.Utiles;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D; // Necesario para los bordes redondeados
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Llamen_a_Dios
{
    public partial class FrmStock : Form
    {
        private List<Producto> listaOriginalProductos;

        public FrmStock()
        {
            InitializeComponent();
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
            Color colorCabecera = Color.FromArgb(245, 247, 250); // Color gris suave de tu diseño
            DGVStck.ColumnHeadersDefaultCellStyle.BackColor = colorCabecera;
            DGVStck.ColumnHeadersDefaultCellStyle.ForeColor = Color.FromArgb(71, 85, 105);
            DGVStck.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI Semibold", 9F);
            DGVStck.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;

            // --- SOLUCIÓN AL CUADRO AZUL ---
            // 1. Cambia el color de la celda de la esquina (Top Left)
            DGVStck.TopLeftHeaderCell.Style.BackColor = colorCabecera;

            // 2. Evita que la cabecera cambie a azul cuando la celda tiene el foco
            DGVStck.ColumnHeadersDefaultCellStyle.SelectionBackColor = colorCabecera;

            // 3. Quita el borde de enfoque (dotted line) que a veces aparece
            DGVStck.RowHeadersDefaultCellStyle.SelectionBackColor = Color.Empty;
            // -------------------------------

            // Filas
            DGVStck.DefaultCellStyle.BackColor = Color.White;
            DGVStck.DefaultCellStyle.ForeColor = Color.FromArgb(30, 41, 59);
            DGVStck.DefaultCellStyle.SelectionBackColor = Color.FromArgb(235, 242, 255);
            DGVStck.DefaultCellStyle.SelectionForeColor = Color.FromArgb(37, 99, 235);
            DGVStck.RowTemplate.Height = 40;
            DGVStck.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }



        // Pintado del botón de selección con icono moderno
        private void DGVStck_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.RowIndex < 0) return;

            if (e.ColumnIndex == 0) // La columna del botón seleccionar
            {
                e.Paint(e.CellBounds, DataGridViewPaintParts.All & ~DataGridViewPaintParts.ContentForeground);

                // Dibujamos un icono de lápiz o check usando texto Unicode (más ligero que imágenes)
                var font = new Font("Segoe UI Emoji", 10F);
                var color = Color.FromArgb(37, 99, 235); // Azul moderno
                TextRenderer.DrawText(e.Graphics, "✏️", font, e.CellBounds, color, TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter);

                e.Handled = true;
            }
        }

        // Evento para redondear el panel del buscador si usas uno
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
                    item.EstadoValor
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
            tbPrecioPromocion.Clear();

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
                BtnGuardar.Text = "Actualizar";
            }
        }

        private void BtnGuardar_Click(object sender, EventArgs e)
        {
            string mensaje = string.Empty;
            decimal? precioPromo = null;

            if (!string.IsNullOrEmpty(tbPrecioPromocion.Text) && decimal.TryParse(tbPrecioPromocion.Text, out decimal promo))
                precioPromo = promo;

            Producto obj_producto = new Producto()
            {
                IdProducto = Convert.ToInt32(txtid.Text),
                Codigo = TBCodigo.Text,
                Nombre = tbnombre.Text,
                Descripcion = tbdesc.Text,
                PrecioVenta = Convert.ToDecimal(tbPrecio.Text),
                Stock = Convert.ToInt32(tbPrecioPromocion.Text),
                Estado = Convert.ToInt32(((Opcombo)CBEstado.SelectedItem).Valor) == 1,
                oCategoria = new Categoria() { IdCategoria = Convert.ToInt32(((Opcombo)CBCategoria.SelectedItem).Valor) },
                PrecioPromocion = precioPromo
            };

            CN_Producto obj_cn_producto = new CN_Producto();

            if (obj_producto.IdProducto == 0)
            {
                int idGenerado = obj_cn_producto.Registrar(obj_producto, out mensaje);
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
                bool resultado = obj_cn_producto.Editar(obj_producto, out mensaje);
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
                    bool resultado = new CN_Producto().Eliminar(Convert.ToInt32(txtid.Text), out mensaje);
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

        private void Btlimc_Click(object sender, EventArgs e) => LimpiarCampos();
    }

}