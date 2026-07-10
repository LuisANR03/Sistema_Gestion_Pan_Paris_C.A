using CapaDatos;
using CapaNegocios;
using Dato;
using Entidades;
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
    public partial class FrmClientes : Form
    {
        public List<Cliente> listaOriginalClientes;

        // 1. Añadimos una variable global privada para guardar el usuario que inició sesión
        private Usuario _UsuarioActual;

        // 2. Modificamos el constructor para recibir el Usuario. 
        // (Le ponemos "= null" temporalmente por si lo llamas desde algún lugar sin el parámetro aún)
        public FrmClientes(Usuario usuarioActual = null)
        {
            InitializeComponent();
            _UsuarioActual = usuarioActual; // Guardamos el usuario
        }

        private void CargarClientes()
        {
            // 1. Limpia las filas existentes
            DGVUs.Rows.Clear();

            // 2. Obtiene la lista nueva de la BDD
            CN_cliente obj_cn_cliente = new CN_cliente();
            listaOriginalClientes = obj_cn_cliente.Listar();

            // 3. Llena el DGV fila por fila
            foreach (Cliente item in listaOriginalClientes)
            {
                DGVUs.Rows.Add(new object[] {
                "", // Para el botón de seleccionar
                item.IdCliente,
                item.Cedula,
                item.Nombre,
                item.Correo,
                item.Telefono,
                item.Direccion,
                item.Estado == true ? 1 : 0, // Valor (para el ComboBox)
                item.EstadoValor // Texto (Activo/Inactivo)
            });
            }
        }

        private void LimpiarCampos()
        {
            tbindice.Text = "-1";
            tbid.Text = "0";

            tbCedula.Clear();
            tbnombre.Clear();
            tbcorreo.Clear();
            tbtlf.Clear();
            tbdir.Clear();

            // Resetea el ComboBox de Estado
            if (CBestado.Items.Count > 0)
                CBestado.SelectedIndex = 0;

            BtnGuardar.Text = "Guardar";
            tbCedula.Select();
        }

        private void FrmClientes_Load(object sender, EventArgs e)
        {
            CBestado.Items.Add(new Opcombo() { Texto = "Activo", Valor = 1 });
            CBestado.Items.Add(new Opcombo() { Texto = "No Activo", Valor = 0 });
            CBestado.DisplayMember = "Texto";
            CBestado.ValueMember = "Valor";
            CBestado.SelectedIndex = 0;

            CargarClientes();
            AplicarDiseñoModerno();

            foreach (DataGridViewColumn columna in DGVUs.Columns)
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

        private void pnlBuscador_Paint(object sender, PaintEventArgs e)
        {
            // Creamos un borde redondeado moderno
            Rectangle rect = new Rectangle(0, 0, pnlBuscador.Width - 1, pnlBuscador.Height - 1);
            int radioRedondeo = 15;

            System.Drawing.Drawing2D.GraphicsPath path = new System.Drawing.Drawing2D.GraphicsPath();
            path.AddArc(rect.X, rect.Y, radioRedondeo, radioRedondeo, 180, 90);
            path.AddArc(rect.Right - radioRedondeo, rect.Y, radioRedondeo, radioRedondeo, 270, 90);
            path.AddArc(rect.Right - radioRedondeo, rect.Bottom - radioRedondeo, radioRedondeo, radioRedondeo, 0, 90);
            path.AddArc(rect.X, rect.Bottom - radioRedondeo, radioRedondeo, radioRedondeo, 90, 90);
            path.CloseFigure();

            // Suavizamos los bordes
            e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

            // Pintamos el fondo blanco y el borde gris claro
            e.Graphics.FillPath(Brushes.White, path);
            using (Pen pen = new Pen(Color.FromArgb(209, 213, 219), 1))
            {
                e.Graphics.DrawPath(pen, path);
            }
        }

        private void AplicarDiseñoModerno()
        {
            Color azulOscuro = Color.FromArgb(21, 52, 168);
            Color fondoClaro = Color.FromArgb(244, 246, 250);
            Color textoTitulo = Color.FromArgb(31, 41, 55);

            this.BackColor = fondoClaro;

            BtnGuardar.BackColor = Color.FromArgb(22, 163, 74);
            BtnGuardar.FlatStyle = FlatStyle.Flat;
            BtnGuardar.FlatAppearance.BorderSize = 0;

            BtnLim.BackColor = Color.White;
            BtnLim.FlatAppearance.BorderColor = azulOscuro;

            btnBorrar.BackColor = Color.FromArgb(254, 242, 242);
            btnBorrar.ForeColor = Color.FromArgb(220, 38, 38);
            btnBorrar.FlatAppearance.BorderSize = 0;
        }

        private void DGVUs_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            if (DGVUs.Columns[e.ColumnIndex].Name == "BtnSelect")
            {
                int indice = e.RowIndex;

                tbindice.Text = indice.ToString();
                tbid.Text = DGVUs.Rows[indice].Cells[1].Value.ToString();
                tbCedula.Text = DGVUs.Rows[indice].Cells[2].Value.ToString();
                tbnombre.Text = DGVUs.Rows[indice].Cells[3].Value.ToString();
                tbcorreo.Text = DGVUs.Rows[indice].Cells[4].Value.ToString();
                tbtlf.Text = DGVUs.Rows[indice].Cells[5].Value?.ToString() ?? "";
                tbdir.Text = DGVUs.Rows[indice].Cells[6].Value?.ToString() ?? "";

                int estadoValor = Convert.ToInt32(DGVUs.Rows[indice].Cells[7].Value);

                foreach (Opcombo item in CBestado.Items)
                {
                    if (Convert.ToInt32(item.Valor) == estadoValor)
                    {
                        CBestado.SelectedItem = item;
                        break;
                    }
                }

                BtnGuardar.Text = "Actualizar";
            }
        }

        private void DGVUs_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.RowIndex < 0) return;

            if (e.ColumnIndex == 0)
            {
                e.Paint(e.CellBounds, DataGridViewPaintParts.All & ~DataGridViewPaintParts.ContentForeground);

                string textoIcono = "✏️";

                TextRenderer.DrawText(e.Graphics, textoIcono,
                    new Font("Segoe UI", 12F, FontStyle.Regular),
                    e.CellBounds,
                    Color.FromArgb(37, 99, 235),
                    TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter);

                e.Handled = true;
            }
        }

        private void BtnLimpiar_Click(object sender, EventArgs e)
        {
            TBBuscar.Clear();
            CBFiltro.SelectedIndex = 0;
        }

        private void BtnGuardar_Click(object sender, EventArgs e)
        {
            string mensaje = string.Empty;

            // 3. Obtenemos el ID del usuario logueado (si es null, mandamos 0)
            int idUsuarioLogueado = _UsuarioActual != null ? _UsuarioActual.IdUsuario : 0;

            Cliente obj_cliente = new Cliente()
            {
                IdCliente = Convert.ToInt32(tbid.Text),
                Cedula = tbCedula.Text,
                Nombre = tbnombre.Text,
                Correo = tbcorreo.Text,
                Telefono = tbtlf.Text,
                Direccion = tbdir.Text,
                Estado = Convert.ToInt32(((Opcombo)CBestado.SelectedItem).Valor) == 1
            };

            CN_cliente obj_cn_cliente = new CN_cliente();

            // MODO CREAR
            if (obj_cliente.IdCliente == 0)
            {
                // 4. Pasamos el ID del usuario a Registrar
                int idGenerado = obj_cn_cliente.Registrar(obj_cliente, idUsuarioLogueado, out mensaje);

                if (idGenerado != 0)
                {
                    MessageBox.Show(mensaje, "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    CargarClientes();
                    LimpiarCampos();
                }
                else
                {
                    MessageBox.Show(mensaje, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            // MODO EDITAR
            else
            {
                // 5. Pasamos el ID del usuario a Editar
                bool resultado = obj_cn_cliente.Editar(obj_cliente, idUsuarioLogueado, out mensaje);

                if (resultado)
                {
                    MessageBox.Show(mensaje, "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    CargarClientes();
                    LimpiarCampos();
                }
                else
                {
                    MessageBox.Show(mensaje, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void BtnLim_Click(object sender, EventArgs e)
        {
            LimpiarCampos();
        }

        private void btnBorrar_Click(object sender, EventArgs e)
        {
            if (Convert.ToInt32(tbid.Text) != 0)
            {
                if (MessageBox.Show("¿Está seguro de que desea desactivar este cliente?",
                                   "Confirmación",
                                   MessageBoxButtons.YesNo,
                                   MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    string mensaje = string.Empty;
                    int idCliente = Convert.ToInt32(tbid.Text);

                    // 6. Obtenemos el ID del usuario logueado
                    int idUsuarioLogueado = _UsuarioActual != null ? _UsuarioActual.IdUsuario : 0;

                    CN_cliente obj_cn_cliente = new CN_cliente();

                    // 7. Pasamos el ID del usuario al Eliminar
                    bool resultado = obj_cn_cliente.Eliminar(idCliente, idUsuarioLogueado, out mensaje);

                    if (resultado)
                    {
                        MessageBox.Show(mensaje, "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        CargarClientes();
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
                MessageBox.Show("Por favor, seleccione un cliente de la lista primero.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void TBBuscar_TextChanged(object sender, EventArgs e)
        {
            if (CBFiltro.SelectedItem == null)
            {
                return;
            }

            string columnaFiltro = ((Opcombo)CBFiltro.SelectedItem).Valor.ToString();
            string textoBusqueda = TBBuscar.Text.Trim().ToLower();

            foreach (DataGridViewRow row in DGVUs.Rows)
            {
                if (row.IsNewRow) continue;

                string valorCelda = row.Cells[columnaFiltro].Value?.ToString() ?? "";

                if (valorCelda.ToLower().Contains(textoBusqueda))
                {
                    row.Visible = true;
                }
                else
                {
                    row.Visible = false;
                }
            }
        }
    }
}