using CapaDatos;
using CapaNegocios;
using Entidades;
using Llamen_a_Dios.Utiles;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Llamen_a_Dios
{
    public partial class FrmStock : Form
    {
        public FrmStock()
        {
            InitializeComponent();
        }
        private List<Producto> listaOriginalProductos;
        private void CargarProductos()
        {

            DGVStck.Rows.Clear(); 

            // 2. Obtiene la lista nueva de la BDD
            CN_Producto obj_cn_producto = new CN_Producto();
            listaOriginalProductos = obj_cn_producto.Listar();

            // 3. Llena el DGV fila por fila
            foreach (Producto item in listaOriginalProductos)
            {
                DGVStck.Rows.Add(new object[] {
                "", // Para el botón de seleccionar
                item.IdProducto,
                item.Codigo,
                item.Nombre,
                item.Descripcion,
                item.oCategoria.IdCategoria, // Id de Categoría (Oculto)
                item.oCategoria.Descripcion, // Nombre de Categoría (Visible)
                item.Stock,
                item.PrecioVenta,
                // Manejamos el nulo. Si es null, mostramos 0.
                item.PrecioPromocion.HasValue ? item.PrecioPromocion.Value : 0,
                item.Estado == true ? 1 : 0, // Valor (Oculto)
                item.EstadoValor // Texto (Activo/Inactivo)
            });
                {
                }
            }
        }
        private void LimpiarCampos()
        {
            tbindice.Text = "-1";
            txtid.Text = "0";

            TBCodigo.Clear();
            tbnombre.Clear();
            tbdesc.Clear();
            TBStock.Clear();
            tbPrecio.Clear();
            tbPrecioPromocion.Clear(); // Limpia la promoción

            // Resetea los ComboBox
            if (CBCategoria.Items.Count > 0)
                CBCategoria.SelectedIndex = 0;
            if (CBEstado.Items.Count > 0)
                CBEstado.SelectedIndex = 0;

            BtnGuardar.Text = "Guardar";
            TBCodigo.Select();
        }

        private void FrmStock_Load(object sender, EventArgs e)
        {
            // --- 1. LLENA EL COMBOBOX DE ESTADO ---
            CBEstado.Items.Add(new Opcombo() { Texto = "Activo", Valor = 1 });
            CBEstado.Items.Add(new Opcombo() { Texto = "No Activo", Valor = 0 });
            CBEstado.DisplayMember = "Texto";
            CBEstado.ValueMember = "Valor";
            CBEstado.SelectedIndex = 0;

            // --- 2. LLENA EL COMBOBOX DE CATEGORÍAS (DESDE LA BDD) ---
            CN_Categoria obj_cn_categoria = new CN_Categoria();
            List<Categoria> listaCategorias = obj_cn_categoria.Listar();

            foreach (Categoria item in listaCategorias)
            {
                // Solo añadimos categorías ACTIVAS al ComboBox
                if (item.Estado == true)
                {
                    CBCategoria.Items.Add(new Opcombo() { Texto = item.Descripcion, Valor = item.IdCategoria });
                }
            }
            CBCategoria.DisplayMember = "Texto";
            CBCategoria.ValueMember = "Valor";
            if (CBCategoria.Items.Count > 0)
                CBCategoria.SelectedIndex = 0;

            // --- 3. CARGA LOS PRODUCTOS EN EL DATAGRIDVIEW ---
            CargarProductos();

            // --- 4. LLENA EL COMBOBOX DE FILTRO ---
            foreach (DataGridViewColumn columna in DGVStck.Columns)
            {
                // Ocultamos las columnas que no queremos filtrar
                if (columna.Visible == true && columna.Name != "BtnSelect" &&
                    columna.Name != "IdCategoria" && columna.Name != "Valor")
                {
                    CBFiltro.Items.Add(new Opcombo() { Texto = columna.HeaderText, Valor = columna.Name });
                }
            }
            CBFiltro.DisplayMember = "Texto";
            CBFiltro.ValueMember = "Valor";
            if (CBFiltro.Items.Count > 0)
            {
                CBFiltro.SelectedIndex = 0;
            }
        }

        private void DGVStck_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            // Usamos el nombre de tu DGV: DGVStck
            if (DGVStck.Columns[e.ColumnIndex].Name == "BtnSelect")
            {
                int indice = e.RowIndex;

                tbindice.Text = indice.ToString();

                // --- LECTURA POR ÍNDICE (Basado en tu CargarProductos) ---
                txtid.Text = DGVStck.Rows[indice].Cells[1].Value.ToString();
                TBCodigo.Text = DGVStck.Rows[indice].Cells[2].Value.ToString();
                tbnombre.Text = DGVStck.Rows[indice].Cells[3].Value.ToString();
                tbdesc.Text = DGVStck.Rows[indice].Cells[4].Value.ToString();

                // --- ¡AQUÍ ESTÁ LA CORRECCIÓN! ---
                // El Stock está en el índice 7
                TBStock.Text = DGVStck.Rows[indice].Cells[7].Value.ToString();

                tbPrecio.Text = DGVStck.Rows[indice].Cells[8].Value.ToString();

                string precioPromo = DGVStck.Rows[indice].Cells[9].Value.ToString();
                tbPrecioPromocion.Text = (precioPromo == "0") ? "" : precioPromo;

                // Categoría (índice 5)
                int idCategoria = Convert.ToInt32(DGVStck.Rows[indice].Cells[5].Value);
                foreach (Opcombo item in CBCategoria.Items)
                {
                    if (Convert.ToInt32(item.Valor) == idCategoria)
                    {
                        CBCategoria.SelectedItem = item;
                        break;
                    }
                }

                // Estado (índice 10)
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

        private void DGVStck_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.RowIndex < 0)
                return;

            if (e.ColumnIndex == 0)
            {
                e.Paint(e.CellBounds, DataGridViewPaintParts.All & ~DataGridViewPaintParts.ContentForeground);
                int padding = 4;
                var x = e.CellBounds.Left + padding;
                var y = e.CellBounds.Top + padding;
                var w = e.CellBounds.Width - (padding * 2);
                var h = e.CellBounds.Height - (padding * 2);
                Rectangle rectDestino = new Rectangle(x, y, w, h);

                e.Graphics.DrawImage(Properties.Resources._checked, rectDestino);

                e.Handled = true;
            }
        }

        private void BtnGuardar_Click(object sender, EventArgs e)
        {
            string mensaje = string.Empty;

            // --- 1. Lee el Precio de Promoción de forma segura ---
            decimal? precioPromo = null; // Lo definimos como 'nullable'
            if (!string.IsNullOrEmpty(tbPrecioPromocion.Text))
            {
                // Si el textbox no está vacío, intentamos convertirlo
                decimal promo;
                if (decimal.TryParse(tbPrecioPromocion.Text, out promo))
                {
                    precioPromo = promo; // Asignamos el valor
                }
            }

            // --- 2. Crea el objeto Producto ---
            Producto obj_producto = new Producto()
            {
                IdProducto = Convert.ToInt32(txtid.Text),
                Codigo = TBCodigo.Text,
                Nombre = tbnombre.Text,
                Descripcion = tbdesc.Text,
                // (No hay PrecioCompra)
                PrecioVenta = Convert.ToDecimal(tbPrecio.Text), // Asumimos que este nunca está vacío
                Stock = Convert.ToInt32(TBStock.Text), // Asumimos que este nunca está vacío
                Estado = Convert.ToInt32(((Opcombo)CBEstado.SelectedItem).Valor) == 1,

                // Asigna el objeto Categoría desde el ComboBox
                oCategoria = new Categoria() { IdCategoria = Convert.ToInt32(((Opcombo)CBCategoria.SelectedItem).Valor) },

                // Asigna el precio de promoción (puede ser 'null')
                PrecioPromocion = precioPromo
            };

            CN_Producto obj_cn_producto = new CN_Producto();

            // --- 3. Decide si CREAR o EDITAR ---

            // MODO CREAR (El ID es 0)
            if (obj_producto.IdProducto == 0)
            {
                int idGenerado = obj_cn_producto.Registrar(obj_producto, out mensaje);

                if (idGenerado != 0) // Éxito
                {
                    MessageBox.Show(mensaje, "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    CargarProductos();
                    LimpiarCampos();
                }
                else // Error
                {
                    MessageBox.Show(mensaje, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            // MODO EDITAR (El ID NO es 0)
            else
            {
                bool resultado = obj_cn_producto.Editar(obj_producto, out mensaje);

                if (resultado) // Éxito
                {
                    MessageBox.Show(mensaje, "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    CargarProductos();
                    LimpiarCampos();
                }
                else // Error
                {
                    MessageBox.Show(mensaje, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void Btlimc_Click(object sender, EventArgs e)
        {
            LimpiarCampos();
        }

        private void btnBorrar_Click(object sender, EventArgs e)
        {
            // 1. Verifica que haya un producto seleccionado
            if (Convert.ToInt32(txtid.Text) != 0)
            {
                // 2. Muestra confirmación
                if (MessageBox.Show("¿Está seguro de que desea desactivar este producto?",
                                   "Confirmación",
                                   MessageBoxButtons.YesNo,
                                   MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    string mensaje = string.Empty;
                    int idProducto = Convert.ToInt32(txtid.Text);

                    CN_Producto obj_cn_producto = new CN_Producto();

                    // 3. Llama al procedimiento de ELIMINAR (Desactivar)
                    bool resultado = obj_cn_producto.Eliminar(idProducto, out mensaje);

                    if (resultado)
                    {
                        MessageBox.Show(mensaje, "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        CargarProductos();
                        LimpiarCampos();
                    }
                    else
                    {
                        MessageBox.Show(mensaje, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                MessageBox.Show("Por favor, seleccione un producto de la lista primero.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void TBBuscar_TextChanged(object sender, EventArgs e)
        {
            // 1. Asegúrate de que haya una columna seleccionada
            if (CBFiltro.SelectedItem == null)
            {
                return;
            }

            // 2. Obtiene el NOMBRE de la columna por la cual filtrar
            string columnaFiltro = ((Opcombo)CBFiltro.SelectedItem).Valor.ToString();

            // 3. Obtiene el texto de búsqueda (en minúsculas)
            string textoBusqueda = TBBuscar.Text.Trim().ToLower();

            // 4. Recorre CADA fila del DataGridView
            // (¡Asegúrate de que tu DGV se llame DGVDatos!)
            foreach (DataGridViewRow row in DGVStck.Rows)
            {
                // (Nos saltamos la fila "nueva" al final)
                if (row.IsNewRow) continue;

                // 5. Obtiene el valor de la celda de forma segura
                string valorCelda = row.Cells[columnaFiltro].Value?.ToString() ?? "";

                // 6. Compara el valor de la celda con el texto de búsqueda
                if (valorCelda.ToLower().Contains(textoBusqueda))
                {
                    // Si coincide, muestra la fila
                    row.Visible = true;
                }
                else
                {
                    // Si NO coincide, oculta la fila
                    row.Visible = false;
                }
            }
        }

        private void BtnLimpiar_Click(object sender, EventArgs e)
        {
            // 1. Vacía el TextBox
            TBBuscar.Text = "";

            // 2. Muestra TODAS las filas de nuevo
            foreach (DataGridViewRow row in DGVStck.Rows)
            {
                row.Visible = true;
            }

            // 3. Pone el cursor de vuelta en el buscador
            TBBuscar.Select();
        }
    }
}