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
    public partial class FrmCategoria : Form
    {
        public FrmCategoria()
        {
            InitializeComponent();
        }
        private void CargarCategorias()
        {
            // 1. Limpia las filas
            DGVCat.Rows.Clear(); // Asegúrate de que tu DGV se llame DGVDatos

            // 2. Obtiene la lista nueva de la BDD
            CN_Categoria obj_cn_categoria = new CN_Categoria();
            List<Categoria> listaCategorias = obj_cn_categoria.Listar();

            // 3. Llena el DGV fila por fila
            foreach (Categoria item in listaCategorias)
            {
                DGVCat.Rows.Add(new object[] {
                "", // Para el botón de seleccionar
                item.IdCategoria,
                item.Descripcion,
                item.Estado == true ? 1 : 0, // Valor (para el ComboBox)
                item.EstadoValor // Texto (Activo/Inactivo)
            });
            }
        }

        private void LimpiarCampos()
        {
            tbindice.Text = "-1";
            txtid.Text = "0";

            tbDescripcion.Clear(); // Asegúrate que tu TextBox se llame así

            // Resetea el ComboBox de Estado
            if (CbEstado.Items.Count > 0)
                CbEstado.SelectedIndex = 0;

            BtnGuardar.Text = "Guardar";
            tbDescripcion.Select();
        }
        private void FrmCategoria_Load(object sender, EventArgs e)
        {
            // --- 1. LLENA EL COMBOBOX DE ESTADO ---
            CbEstado.Items.Add(new Opcombo() { Texto = "Activo", Valor = 1 });
            CbEstado.Items.Add(new Opcombo() { Texto = "No Activo", Valor = 0 });
            CbEstado.DisplayMember = "Texto";
            CbEstado.ValueMember = "Valor";
            CbEstado.SelectedIndex = 0;

            // --- 2. LLAMA AL MÉTODO PARA CARGAR EL DATAGRIDVIEW ---
            CargarCategorias();

            // --- 3. LLENA EL COMBOBOX DE FILTRO ---
            // (Asumo que tienes un CBFiltro como en los otros formularios)
            foreach (DataGridViewColumn columna in DGVCat.Columns)
            {
                if (columna.Visible == true && columna.Name != "BtnSelect" && columna.Name != "Valor")
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

        private void DGVCat_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // 1. Verifica que no sea la fila de cabecera
            if (e.RowIndex < 0) return;

            // 2. Verifica que se haya presionado la columna del botón "Seleccionar"
            if (DGVCat.Columns[e.ColumnIndex].Name == "BtnSelect")
            {
                int indice = e.RowIndex;

                // 3. Guarda el índice y el ID
                tbindice.Text = indice.ToString();

                // --- LECTURA POR ÍNDICE ---
                // Basado en CargarCategorias():
                // 0: Botón
                // 1: IdCategoria
                // 2: Descripcion
                // 3: Valor (1 o 0)
                // 4: EstadoValor (Activo/Inactivo)

                txtid.Text = DGVCat.Rows[indice].Cells[1].Value.ToString();
                tbDescripcion.Text = DGVCat.Rows[indice].Cells[2].Value.ToString();

                // 4. Selecciona el Estado (leemos el índice 3)
                int estadoValor = Convert.ToInt32(DGVCat.Rows[indice].Cells[3].Value);

                foreach (Opcombo item in CbEstado.Items)
                {
                    if (Convert.ToInt32(item.Valor) == estadoValor)
                    {
                        CbEstado.SelectedItem = item;
                        break;
                    }
                }

                // 5. Pone el formulario en "Modo Editar"
                BtnGuardar.Text = "Actualizar";
            }
        }

        private void DGVCat_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
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

            // 1. Crea el objeto Categoria con los datos de los campos
            Categoria obj_categoria = new Categoria()
            {
                IdCategoria = Convert.ToInt32(txtid.Text),
                Descripcion = tbDescripcion.Text,
                Estado = Convert.ToInt32(((Opcombo)CbEstado.SelectedItem).Valor) == 1
            };

            CN_Categoria obj_cn_categoria = new CN_Categoria();

            // MODO CREAR (El ID es 0)
            if (obj_categoria.IdCategoria == 0)
            {
                int idGenerado = obj_cn_categoria.Registrar(obj_categoria, out mensaje);

                // Comprueba si se generó un ID (éxito)
                if (idGenerado != 0)
                {
                    MessageBox.Show(mensaje, "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    CargarCategorias();
                    LimpiarCampos();
                }
                else // Si el ID es 0, fue un error
                {
                    MessageBox.Show(mensaje, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            // MODO EDITAR (El ID NO es 0)
            else
            {
                bool resultado = obj_cn_categoria.Editar(obj_categoria, out mensaje);

                // Comprueba si 'resultado' es true (éxito)
                if (resultado)
                {
                    MessageBox.Show(mensaje, "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    CargarCategorias();
                    LimpiarCampos();
                }
                else // Si es false, fue un error
                {
                    MessageBox.Show(mensaje, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        private void BtnLimc_Click(object sender, EventArgs e)
        {
            LimpiarCampos();
        }

        private void btnBorrar_Click(object sender, EventArgs e)
        {
            if (Convert.ToInt32(txtid.Text) != 0)
            {
                if (MessageBox.Show("¿Está seguro de que desea desactivar esta categoría?\n(No podrá si está en uso por un producto)",
                                   "Confirmación",
                                   MessageBoxButtons.YesNo,
                                   MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    string mensaje = string.Empty;
                    int idCategoria = Convert.ToInt32(txtid.Text);

                    CN_Categoria obj_cn_categoria = new CN_Categoria();
                    bool resultado = obj_cn_categoria.Eliminar(idCategoria, out mensaje);

                    if (resultado)
                    {
                        MessageBox.Show(mensaje, "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        CargarCategorias();
                        LimpiarCampos();
                    }
                    else
                    {
                        // Muestra el error (ej. "Categoría en uso")
                        MessageBox.Show(mensaje, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                MessageBox.Show("Por favor, seleccione una categoría de la lista primero.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void BtnLimpiar_Click(object sender, EventArgs e)
        {
            TBBuscar.Clear();
            CBFiltro.SelectedIndex = 0;
            foreach (DataGridViewRow row in DGVCat.Rows)
            {
                row.Visible = true;
            }
            TBBuscar.Select();
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
            foreach (DataGridViewRow row in DGVCat.Rows)
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
    }
}