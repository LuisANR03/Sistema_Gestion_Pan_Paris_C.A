using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using CapaNegocios;
using Entidades;

namespace Llamen_a_Dios
{
    public partial class Frmregistrarventa : Form
    {
        public Frmregistrarventa()
        {
            InitializeComponent();

            // Suscribimos los eventos del DataGridView
            this.DGVStck.CellPainting += new DataGridViewCellPaintingEventHandler(this.DGVStck_CellPainting);
            this.DGVStck.CellContentClick += new DataGridViewCellEventHandler(this.DGVStck_CellContentClick);
        }

        private void Frmregistrarventa_Load(object sender, EventArgs e)
        {
            AplicarDiseñoModerno();
        }

        #region MÉTODOS DE OPERACIÓN (CARRITO DE COMPRAS)

        private void btnagregarproducto_Click(object sender, EventArgs e)
        {
            string codigoIngresado = txbproducto.Text.Trim();

            if (string.IsNullOrEmpty(codigoIngresado))
            {
                MessageBox.Show("Por favor, ingrese un código de producto.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Instanciamos la capa de negocios y traemos los productos
            CN_Producto obj_cn_producto = new CN_Producto();
            List<Producto> listaProductos = obj_cn_producto.Listar();

            // Buscamos el producto que coincida con el código y que esté activo
            Producto productoEncontrado = listaProductos.Find(p => p.Codigo == codigoIngresado && p.Estado == true);

            if (productoEncontrado != null)
            {
                if (productoEncontrado.Stock > 0)
                {
                    // Asumimos que la cantidad inicial a vender es 1
                    int cantidad = 1;

                    // Calculamos el precio real (si hay promo, usamos promo, si no, precio de venta)
                    decimal precioAplicado = (productoEncontrado.PrecioPromocion > 0)
                                             ? (decimal)productoEncontrado.PrecioPromocion
                                             : productoEncontrado.PrecioVenta;

                    decimal subtotal = cantidad * precioAplicado;

                    // Agregamos el producto al DataGridView (Carrito)
                    DGVStck.Rows.Add(new object[] {
                        "", // Columna 0: BtnSelect (Lo usaremos para eliminar)
                        productoEncontrado.IdProducto,
                        productoEncontrado.Codigo,
                        productoEncontrado.Nombre,
                        productoEncontrado.Descripcion,
                        productoEncontrado.oCategoria.IdCategoria,
                        productoEncontrado.oCategoria.Descripcion,
                        cantidad, // Columna de Cantidad 
                        productoEncontrado.PrecioVenta,
                        productoEncontrado.PrecioPromocion ?? 0,
                        subtotal, // Columna Subtotal
                        productoEncontrado.EstadoValor,
                        DateTime.Now.ToString("d")
                    });

                    // Limpiamos el textbox y le regresamos el foco (adaptado para textbox modernos)
                    txbproducto.Text = "";
                    txbproducto.Focus();
                }
                else
                {
                    MessageBox.Show("El producto no tiene stock disponible.", "Sin Stock", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {
                MessageBox.Show("Código de producto no encontrado o inactivo.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                // Limpiamos el texto para que el cajero intente escanear de nuevo rápidamente
                txbproducto.Text = "";
                txbproducto.Focus();
            }
        }

        private void btnbuscarproducto_Click(object sender, EventArgs e)
        {
            // NOTA: Descomenta esto cuando crees tu FrmModalProductos
            /*
            using (var modal = new FrmModalProductos())
            {
                var result = modal.ShowDialog();

                if (result == DialogResult.OK)
                {
                    txbproducto.Text = modal.CodigoSeleccionado;
                    btnagregarproducto.PerformClick(); // Agrega automáticamente el producto
                }
            }
            */
            MessageBox.Show("Aquí se abrirá la ventana para buscar productos.", "Buscador");
        }

        private void DGVStck_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            // Si hacen clic en la primera columna (el botón de eliminar con la X)
            if (DGVStck.Columns[e.ColumnIndex].Name == "BtnSelect" || e.ColumnIndex == 0)
            {
                DGVStck.Rows.RemoveAt(e.RowIndex);
            }
        }

        private void DGVStck_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.RowIndex < 0) return;

            if (e.ColumnIndex == 0) // La columna del botón
            {
                e.Paint(e.CellBounds, DataGridViewPaintParts.All & ~DataGridViewPaintParts.ContentForeground);

                // Dibujamos una X roja para eliminar del carrito
                var font = new Font("Segoe UI Emoji", 10F);
                var color = Color.FromArgb(239, 68, 68); // Rojo moderno
                TextRenderer.DrawText(e.Graphics, "❌", font, e.CellBounds, color, TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter);

                e.Handled = true;
            }
        }

        #endregion

        #region MÉTODOS DE DISEÑO

        private void AplicarDiseñoModerno()
        {
            // --- 1. CONFIGURACIÓN DEL FONDO PRINCIPAL ---
            this.BackColor = Color.FromArgb(243, 244, 246); // Gris súper claro como en la web
            lbllistausu.BackColor = Color.White; // Tarjeta principal

            // --- 2. COLORES POR SECCIÓN (Basado en el diseño web) ---

            // Grupo 1: Información Venta (Tonos Azules)
            groupBox1.BackColor = Color.FromArgb(239, 246, 255); // Fondo azul muy sutil
            groupBox1.ForeColor = Color.FromArgb(37, 99, 235);   // Texto azul fuerte
            groupBox1.Font = new Font("Segoe UI Semibold", 10F);

            // Grupo 2: Información Cliente (Tonos Verdes)
            groupBox2.BackColor = Color.FromArgb(240, 253, 244); // Fondo verde muy sutil
            groupBox2.ForeColor = Color.FromArgb(22, 163, 74);   // Texto verde fuerte
            groupBox2.Font = new Font("Segoe UI Semibold", 10F);

            // Grupo 3: Información Productos (Tonos Morados)
            groupBox3.BackColor = Color.FromArgb(250, 245, 255); // Fondo morado muy sutil
            groupBox3.ForeColor = Color.FromArgb(147, 51, 234);  // Texto morado fuerte
            groupBox3.Font = new Font("Segoe UI Semibold", 10F);

            // Restaurar fuente de los controles internos para que no queden de colores
            foreach (Control c in this.Controls)
            {
                if (c is GroupBox gb)
                {
                    foreach (Control child in gb.Controls)
                    {
                        if (!(child is Button))
                        {
                            child.ForeColor = Color.FromArgb(71, 85, 105); // Gris oscuro estándar para labels internos
                            child.Font = new Font("Segoe UI", 9F);
                        }
                    }
                }
            }

            // --- 3. CONFIGURAR DATAGRIDVIEW ---
            ConfigurarDGVModerno();

            // --- 4. ESTILIZAR BOTONES ---
            EstilizarBotonesYCampos();
        }

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

            // Solución al cuadro azul en la esquina superior izquierda
            DGVStck.TopLeftHeaderCell.Style.BackColor = colorCabecera;
            DGVStck.ColumnHeadersDefaultCellStyle.SelectionBackColor = colorCabecera;
            DGVStck.RowHeadersDefaultCellStyle.SelectionBackColor = Color.Empty;

            // Filas
            DGVStck.DefaultCellStyle.BackColor = Color.White;
            DGVStck.DefaultCellStyle.ForeColor = Color.FromArgb(30, 41, 59);
            DGVStck.DefaultCellStyle.SelectionBackColor = Color.FromArgb(235, 242, 255); // Resaltado azul suave
            DGVStck.DefaultCellStyle.SelectionForeColor = Color.FromArgb(37, 99, 235);
            DGVStck.RowTemplate.Height = 40;
            DGVStck.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void EstilizarBotonesYCampos()
        {
            // --- BOTONES PRINCIPALES ---

            // Botón Agregar (+) - Verde Moderno
            btnagregarproducto.BackColor = Color.FromArgb(34, 197, 94);
            btnagregarproducto.ForeColor = Color.White;
            btnagregarproducto.ColorBorde = Color.FromArgb(34, 197, 94);
            btnagregarproducto.ColorHover = Color.FromArgb(22, 163, 74);
            btnagregarproducto.IconColor = Color.White;
            btnagregarproducto.ColorIconoHover = Color.White;

            // Botón Crear Venta (Esquina inferior derecha) - Azul claro/fuerte
            btnVenta.BackColor = Color.FromArgb(147, 197, 253); // Un azul suave
            btnVenta.ForeColor = Color.FromArgb(30, 58, 138); // Letra azul oscuro
            btnVenta.ColorBorde = Color.FromArgb(147, 197, 253);
            btnVenta.ColorHover = Color.FromArgb(191, 219, 254);
            btnVenta.IconColor = Color.FromArgb(30, 58, 138);
            btnVenta.ColorIconoHover = Color.FromArgb(30, 58, 138);

            // --- BOTONES SECUNDARIOS (Lupas y Stock) ---
            Color fondoSecundario = Color.FromArgb(248, 250, 252);
            Color bordeSecundario = Color.FromArgb(203, 213, 225);
            Color iconoGris = Color.FromArgb(71, 85, 105);

            var botonesSecundarios = new[] { btnbuscarcliente, btnbuscarproducto };
            foreach (var btn in botonesSecundarios)
            {
                if (btn != null)
                {
                    btn.BackColor = fondoSecundario;
                    btn.ColorBorde = bordeSecundario;
                    btn.GrosorBorde = 1;
                    btn.IconColor = iconoGris;
                    btn.ColorHover = Color.FromArgb(226, 232, 240);
                    btn.ColorIconoHover = Color.Black;
                }
            }

            // --- CAMPOS DE TEXTO MODERNOS ---
            var textboxes = new[] { txbfecha, txbcajero, txbcliente, txbcedula, txbproducto };
            foreach (var txt in textboxes)
            {
                if (txt != null)
                {
                    txt.ColorBorde = Color.FromArgb(226, 232, 240); // Borde gris súper claro
                    txt.ColorBordeFocus = Color.FromArgb(147, 51, 234); // Focus morado (basado en la zona)
                }
            }

            if (cbvendedor != null)
            {
                cbvendedor.BorderColor = Color.FromArgb(226, 232, 240);
            }
        }

        #endregion

        private void DGVStck_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}