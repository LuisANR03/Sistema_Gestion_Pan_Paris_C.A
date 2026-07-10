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
using Entidades;      // Añadido para acceder a la clase Ingrediente
using CapaNegocios;   // Añadido para acceder a CN_Ingrediente

namespace Llamen_a_Dios
{
    public partial class FrmIngredientes : Form
    {
        // 1. Variable global para guardar el usuario logueado
        private Usuario _usuarioActual;

        // 2. Modificamos el constructor para que reciba al usuario
        public FrmIngredientes(Usuario usuario)
        {
            InitializeComponent();
            _usuarioActual = usuario;
        }

        // ==============================================================
        // MÉTODO LIMPIAR (Para reiniciar las cajas de texto)
        // ==============================================================
        private void Limpiar()
        {
            txtId.Text = "0";
            tbnombre.Text = "";
            tbStock.Text = "";
            cbUnidad.Text = "";
            txtStockMinimo.Text = "";

            if (cbEstado.Items.Count > 0)
                cbEstado.SelectedIndex = 0;

            tbnombre.Select();
            BtnGuardar.Text = "Guardar";
        }

        // ==============================================================
        // EVENTOS DEL DATAGRIDVIEW
        // ==============================================================
        private void dgvData_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvData.Columns[e.ColumnIndex].Name == "BtnSelect" && e.RowIndex >= 0)
            {
                txtId.Text = dgvData.Rows[e.RowIndex].Cells["IdIngrediente"].Value.ToString();
                tbnombre.Text = dgvData.Rows[e.RowIndex].Cells["Nombre"].Value.ToString();
                tbStock.Text = dgvData.Rows[e.RowIndex].Cells["StockActual"].Value.ToString();
                cbUnidad.Text = dgvData.Rows[e.RowIndex].Cells["UnidadMedida"].Value.ToString();
                txtStockMinimo.Text = dgvData.Rows[e.RowIndex].Cells["StockMinimo"].Value.ToString();

                string estadoTexto = dgvData.Rows[e.RowIndex].Cells["EstadoValor"].Value.ToString();
                int estadoInt = (estadoTexto == "Activo") ? 1 : 0;

                foreach (Opcombo item in cbEstado.Items)
                {
                    if (Convert.ToInt32(item.Valor) == estadoInt)
                    {
                        cbEstado.SelectedItem = item;
                        break;
                    }
                }

                BtnGuardar.Text = "Actualizar";
            }
        }

        private void dgvData_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.RowIndex < 0)
                return;

            if (e.ColumnIndex == 0)
            {
                e.Paint(e.CellBounds, DataGridViewPaintParts.All & ~DataGridViewPaintParts.ContentForeground);

                string textoIcono = "✏️";

                TextRenderer.DrawText(e.Graphics, textoIcono,
                    new Font("Segoe UI", 12F, FontStyle.Regular),
                    e.CellBounds,
                    Color.FromArgb(21, 52, 168),
                    TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter);

                e.Handled = true;
            }
        }

        // ==============================================================
        // BOTÓN GUARDAR / ACTUALIZAR
        // ==============================================================
        private void BtnGuardar_Click(object sender, EventArgs e)
        {
            // Validación preventiva para que no guarden un ingrediente en blanco
            if (string.IsNullOrWhiteSpace(tbnombre.Text))
            {
                MessageBox.Show("Debe ingresar el nombre del ingrediente.", "Faltan Datos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                tbnombre.Focus();
                return;
            }

            string mensaje = string.Empty;

            // 1. Armamos el objeto (Usando NumberStyles.Any como te recomendé antes para evitar errores de comas/puntos)
            Ingrediente obj = new Ingrediente()
            {
                IdIngrediente = Convert.ToInt32(string.IsNullOrEmpty(txtId.Text) ? "0" : txtId.Text),
                Nombre = tbnombre.Text,
                StockActual = decimal.TryParse(tbStock.Text, System.Globalization.NumberStyles.Any, System.Globalization.CultureInfo.CurrentCulture, out decimal stock) ? stock : 0,
                UnidadMedida = cbUnidad.Text,
                StockMinimo = decimal.TryParse(txtStockMinimo.Text, System.Globalization.NumberStyles.Any, System.Globalization.CultureInfo.CurrentCulture, out decimal stockMin) ? stockMin : 0,
                Estado = Convert.ToInt32(((Opcombo)cbEstado.SelectedItem).Valor) == 1 ? true : false
            };

            // 2. REGISTRO NUEVO
            if (obj.IdIngrediente == 0)
            {
                int idGenerado = new CN_Ingrediente().Registrar(obj, _usuarioActual.IdUsuario, out mensaje);

                if (idGenerado != 0)
                {
                    dgvData.Rows.Add(new object[] {
                "",
                idGenerado,
                obj.Nombre,
                obj.StockActual.ToString("N2"),
                obj.UnidadMedida,
                obj.StockMinimo.ToString("N2"),
                obj.Estado == true ? "Activo" : "Inactivo"
            });

                    // 🌟 MENSAJE DE ÉXITO AL GUARDAR
                    MessageBox.Show("Ingrediente guardado exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    Limpiar();
                }
                else
                {
                    MessageBox.Show(mensaje, "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            // 3. EDICIÓN
            else
            {
                bool resultado = new CN_Ingrediente().Editar(obj, _usuarioActual.IdUsuario, out mensaje);

                if (resultado)
                {
                    foreach (DataGridViewRow row in dgvData.Rows)
                    {
                        if (row.Cells["Id"].Value.ToString() == obj.IdIngrediente.ToString()) // Asegúrate de usar "Id" y no "IdIngrediente" según tu imagen
                        {
                            row.Cells["Nombre"].Value = obj.Nombre;
                            row.Cells["Stock"].Value = obj.StockActual.ToString("N2"); // Usar "Stock" según tu imagen
                            row.Cells["Unidad"].Value = obj.UnidadMedida; // Usar "Unidad" según tu imagen
                            row.Cells["StockMinimo"].Value = obj.StockMinimo.ToString("N2");
                            row.Cells["Estado"].Value = obj.Estado == true ? "Activo" : "Inactivo"; // Usar "Estado" según tu imagen
                            break;
                        }
                    }

                    // 🌟 MENSAJE DE ÉXITO AL ACTUALIZAR
                    MessageBox.Show("Ingrediente actualizado exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    Limpiar();
                }
                else
                {
                    MessageBox.Show(mensaje, "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
        }

        // ==============================================================
        // BOTÓN LIMPIAR
        // ==============================================================
        private void Btlimpiar_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        // ==============================================================
        // BOTÓN BORRAR
        // ==============================================================
        private void btnBorrar_Click(object sender, EventArgs e)
        {
            int idActual = Convert.ToInt32(string.IsNullOrEmpty(txtId.Text) ? "0" : txtId.Text);

            if (idActual != 0)
            {
                if (MessageBox.Show("¿Está seguro de eliminar el ingrediente seleccionado?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    string mensaje = string.Empty;
                    // Pasamos el Id del Usuario para la auditoría
                    bool respuesta = new CN_Ingrediente().Eliminar(idActual, _usuarioActual.IdUsuario, out mensaje);

                    if (respuesta)
                    {
                        foreach (DataGridViewRow row in dgvData.Rows)
                        {
                            // Asegúrate de usar "Id" según el nombre corto en tu DataGridView
                            if (row.Cells["Id"].Value.ToString() == idActual.ToString())
                            {
                                dgvData.Rows.Remove(row);
                                break;
                            }
                        }

                        // 🌟 MENSAJE DE ÉXITO AL ELIMINAR
                        MessageBox.Show("Ingrediente eliminado exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        Limpiar();
                    }
                    else
                    {
                        MessageBox.Show(mensaje, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                MessageBox.Show("Por favor, seleccione un ingrediente de la lista usando el icono del lápiz.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void FrmIngredientes_Load(object sender, EventArgs e)
        {
            cbEstado.Items.Add(new Opcombo() { Valor = 1, Texto = "Activo" });
            cbEstado.Items.Add(new Opcombo() { Valor = 0, Texto = "Inactivo" });
            cbEstado.DisplayMember = "Texto";
            cbEstado.ValueMember = "Valor";
            cbEstado.SelectedIndex = 0;

            cbUnidad.Items.Add("Kg");
            cbUnidad.Items.Add("Gramos");
            cbUnidad.Items.Add("Litros");
            cbUnidad.Items.Add("Mililitros");
            cbUnidad.Items.Add("Unidades");
            cbUnidad.Items.Add("Sacos");
            cbUnidad.SelectedIndex = 0;

            dgvData.Rows.Clear();
            List<Ingrediente> listaIngredientes = new CN_Ingrediente().Listar();

            foreach (Ingrediente item in listaIngredientes)
            {
                dgvData.Rows.Add(new object[] {
                    "",
                    item.IdIngrediente,
                    item.Nombre,
                    item.StockActual.ToString("N2"),
                    item.UnidadMedida,
                    item.StockMinimo.ToString("N2"),
                    item.Estado == true ? "Activo" : "Inactivo"
                });
            }
        }
    }
}