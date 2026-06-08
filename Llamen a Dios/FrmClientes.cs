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
        public FrmClientes()
        {
            InitializeComponent();
        }
        private void CargarClientes()
        {
            // 1. Limpia las filas existentes
            DGVUs.Rows.Clear(); // Asegúrate de que tu DGV se llame DGVUs

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

            // Asegúrate de que tus TextBoxes se llamen así
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
           // ConfigurarTablaModerna();
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
            int radioRedondeo = 15; // Qué tan redondo lo quieres

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
            using (Pen pen = new Pen(Color.FromArgb(209, 213, 219), 1)) // Color gris clarito para el borde
            {
                e.Graphics.DrawPath(pen, path);
            }
        }
        private void AplicarDiseñoModerno()
        {
            Color azulOscuro = Color.FromArgb(21, 52, 168);
            Color fondoClaro = Color.FromArgb(244, 246, 250);
            Color textoTitulo = Color.FromArgb(31, 41, 55); // Gris muy oscuro para contraste

            this.BackColor = fondoClaro;

            // Botones (Se mantienen tus nombres actuales)
            BtnGuardar.BackColor = Color.FromArgb(22, 163, 74);
            BtnGuardar.FlatStyle = FlatStyle.Flat;
            BtnGuardar.FlatAppearance.BorderSize = 0;

            BtnLim.BackColor = Color.White;
            BtnLim.FlatAppearance.BorderColor = azulOscuro;

            btnBorrar.BackColor = Color.FromArgb(254, 242, 242);
            btnBorrar.ForeColor = Color.FromArgb(220, 38, 38);
            btnBorrar.FlatAppearance.BorderSize = 0;
        }

        /*private void ConfigurarTablaModerna()
        {
            // Colores y diseño basados en tu nueva configuración (DGVStck)
            DGVUs.BackgroundColor = Color.White;
            DGVUs.BorderStyle = BorderStyle.None;
            DGVUs.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            DGVUs.GridColor = Color.FromArgb(240, 240, 240); // Añadido para mantener la línea divisoria
            DGVUs.RowHeadersVisible = false;
            DGVUs.AllowUserToAddRows = false;
            DGVUs.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            DGVUs.MultiSelect = false;

            // Cabecera estilizada
            DGVUs.EnableHeadersVisualStyles = false;
            DGVUs.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            DGVUs.ColumnHeadersHeight = 40;

            Color colorCabecera = Color.FromArgb(245, 247, 250);
            DGVUs.ColumnHeadersDefaultCellStyle.BackColor = colorCabecera;
            DGVUs.ColumnHeadersDefaultCellStyle.ForeColor = Color.FromArgb(71, 85, 105);
            DGVUs.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI Semibold", 9F);
            DGVUs.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;

            // Solución al cuadro azul en la esquina superior izquierda
            DGVUs.TopLeftHeaderCell.Style.BackColor = colorCabecera;
            DGVUs.ColumnHeadersDefaultCellStyle.SelectionBackColor = colorCabecera;
            DGVUs.RowHeadersDefaultCellStyle.SelectionBackColor = Color.Empty;

            // Filas
            DGVUs.DefaultCellStyle.BackColor = Color.White;
            DGVUs.DefaultCellStyle.ForeColor = Color.FromArgb(30, 41, 59);
            DGVUs.DefaultCellStyle.SelectionBackColor = Color.FromArgb(235, 242, 255); // Resaltado azul suave
            DGVUs.DefaultCellStyle.SelectionForeColor = Color.FromArgb(37, 99, 235);
            DGVUs.DefaultCellStyle.Font = new Font("Segoe UI", 9F);
            DGVUs.RowTemplate.Height = 40;
            DGVUs.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            // Alineación y tamaño de la tabla en tu formulario (MANTENIDO)
            int margen = 40;
            int panelIzquierdoAncho = 320;
            DGVUs.Location = new Point(panelIzquierdoAncho + margen, DGVUs.Location.Y);
            DGVUs.Width = this.ClientSize.Width - (panelIzquierdoAncho + (margen * 2));
            DGVUs.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
        }
        */
        private void DGVUs_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // 1. Verifica que no sea la fila de cabecera
            if (e.RowIndex < 0) return;

            // 2. Verifica que se haya presionado la columna del botón "Seleccionar"
            if (DGVUs.Columns[e.ColumnIndex].Name == "BtnSelect")
            {
                int indice = e.RowIndex;

                // 3. Guarda el índice y el ID
                tbindice.Text = indice.ToString();

                // --- LECTURA POR ÍNDICE ---
                tbid.Text = DGVUs.Rows[indice].Cells[1].Value.ToString();
                tbCedula.Text = DGVUs.Rows[indice].Cells[2].Value.ToString();
                tbnombre.Text = DGVUs.Rows[indice].Cells[3].Value.ToString();
                tbcorreo.Text = DGVUs.Rows[indice].Cells[4].Value.ToString();

                // --- ESTA ES LA LÍNEA CORREGIDA (usando tu TextBox 'tbtlf' y el índice 5) ---
                tbtlf.Text = DGVUs.Rows[indice].Cells[5].Value?.ToString() ?? "";

                tbdir.Text = DGVUs.Rows[indice].Cells[6].Value?.ToString() ?? "";

                // 4. Selecciona el Estado (leemos el índice 7)
                int estadoValor = Convert.ToInt32(DGVUs.Rows[indice].Cells[7].Value);

                foreach (Opcombo item in CBestado.Items)
                {
                    if (Convert.ToInt32(item.Valor) == estadoValor)
                    {
                        CBestado.SelectedItem = item;
                        break;
                    }
                }

                // 5. Pone el formulario en "Modo Editar"
                BtnGuardar.Text = "Actualizar";
            }
        }

        private void DGVUs_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.RowIndex < 0) return;

            // Reemplazamos la imagen gigante por un icono sutil de texto (lapicito)
            if (e.ColumnIndex == 0) // Si tu botón está en otra columna, cambia el 0
            {
                e.Paint(e.CellBounds, DataGridViewPaintParts.All & ~DataGridViewPaintParts.ContentForeground);

                string textoIcono = "✏️";

                TextRenderer.DrawText(e.Graphics, textoIcono,
                    new Font("Segoe UI", 12F, FontStyle.Regular),
                    e.CellBounds,
                    Color.FromArgb(37, 99, 235), // <--- NUEVO COLOR AZUL PARA EL LÁPIZ
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

            // 1. Crea el objeto Cliente con los datos de los campos
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

            // MODO CREAR (El ID es 0)
            if (obj_cliente.IdCliente == 0)
            {
                int idGenerado = obj_cn_cliente.Registrar(obj_cliente, out mensaje);

                // Comprueba si se generó un ID (éxito)
                if (idGenerado != 0)
                {
                    MessageBox.Show(mensaje, "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    CargarClientes();
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
                bool resultado = obj_cn_cliente.Editar(obj_cliente, out mensaje);

                // Comprueba si 'resultado' es true (éxito)
                if (resultado)
                {
                    MessageBox.Show(mensaje, "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    CargarClientes();
                    LimpiarCampos();
                }
                else // Si es false, fue un error
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
            // 1. Verifica que haya un cliente seleccionado (que el ID no sea 0)
            if (Convert.ToInt32(tbid.Text) != 0)
            {
                // 2. MUESTRA UNA CONFIRMACIÓN ANTES DE BORRAR
                if (MessageBox.Show("¿Está seguro de que desea desactivar este cliente?",
                                   "Confirmación",
                                   MessageBoxButtons.YesNo,
                                   MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    string mensaje = string.Empty;
                    int idCliente = Convert.ToInt32(tbid.Text);

                    CN_cliente obj_cn_cliente = new CN_cliente();

                    // 3. Llama al procedimiento de ELIMINAR (Desactivar)
                    bool resultado = obj_cn_cliente.Eliminar(idCliente, out mensaje);

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
            // (Asegúrate de que tu DGV se llame DGVUs)
            foreach (DataGridViewRow row in DGVUs.Rows)
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
