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
using CapaNegocios;
using System.Runtime.InteropServices;

namespace Llamen_a_Dios
{
    public partial class FormUsuarios : Form
    {
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        private static extern IntPtr SendMessage(IntPtr hWnd, int msg, IntPtr wp, string lp);
        private int idUsuarioSeleccionado = 0;
        private List<Usuario> listaOriginalUsuarios;

        public FormUsuarios()
        {
            InitializeComponent();


        }

        private void FormUsuarios_Load(object sender, EventArgs e)
        {
            AplicarDiseñoModerno();

            // Esto le pone el texto fantasma nativo de Windows al buscador
            SendMessage(TBBuscar.Handle, 0x1501, (IntPtr)1, "Buscar...");

            DGVUs.CellFormatting += DGVUs_CellFormatting;
            CbEstado.Items.Add(new Opcombo() { Texto = "Activo", Valor = 1 });
            CbEstado.Items.Add(new Opcombo() { Texto = "No Activo", Valor = 0 });
            CbEstado.DisplayMember = "Texto";
            CbEstado.ValueMember = "Valor";
            CbEstado.SelectedIndex = 0;

            List<Rol> listaRoles = new CN_rol().Listar();
            foreach (Rol item in listaRoles)
            {
                CBRol.Items.Add(new Opcombo() { Texto = item.Descripcion, Valor = item.IdRol });
            }
            CBRol.DisplayMember = "Texto";
            CBRol.ValueMember = "Valor";
            if (CBRol.Items.Count > 0)
                CBRol.SelectedIndex = 0;

            CargarUsuarios();

            // Llamamos a configurar la tabla DESPUÉS de cargar los datos para que el auto-ajuste funcione perfecto
            ConfigurarTablaModerna();

            foreach (DataGridViewColumn columna in DGVUs.Columns)
            {
                if (columna.Visible == true && columna.Name != "BtnSelect")
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
            // 1. Colores principales basados en tu imagen de referencia
            Color azulOscuro = Color.FromArgb(21, 52, 168); // Azul del panel izquierdo
            Color fondoClaro = Color.FromArgb(244, 246, 250); // Gris súper claro del fondo derecho
            Color verdeBoton = Color.FromArgb(22, 163, 74); // Verde moderno

            // 2. Fondos Generales
            this.BackColor = fondoClaro;
            
            label1.Width = 320;

            // 3. Textos del Panel Izquierdo
            

            Label[] labelsIzquierda = { txtCedul, lblnombre, lblcorreo, lblrol, lblContraseña, lblrepetir };
            foreach (Label lbl in labelsIzquierda)
            {
                
                lbl.ForeColor = Color.White;
                lbl.Font = new Font("Segoe UI Semibold", 9.5F);
            }

            // --- ¡NUEVO! 4. Arreglar los títulos de la derecha (Lista de Usuarios, Buscar por) ---
            // Busca en tu diseño cómo se llaman esos labels (aquí asumo que iteramos sobre los controles del form)
            foreach (Control c in this.Controls)
            {
                // Si es un Label, está a la derecha (fuera del panel izquierdo) y no es el título principal
                if (c is Label && c.Location.X > 320)
                {
                    
                    

                    
                }
            }

            // --- ¡NUEVO! 5. Estilizar el Buscador ---
           // CBFiltro.BackColor = Color.White;
           // CBFiltro.Font = new Font("Segoe UI", 10F);

           // TBBuscar.BorderStyle = BorderStyle.FixedSingle;
           // TBBuscar.Font = new Font("Segoe UI", 10F);

            // TBBuscar.Height = 35; // Descomenta si te deja ajustar la altura

            // 6. Estilo de los Botones
            BtnGuardar.BackColor = verdeBoton;
            BtnGuardar.ForeColor = Color.White;
            BtnGuardar.FlatStyle = FlatStyle.Flat;
            BtnGuardar.FlatAppearance.BorderSize = 0;

            Btlimpiar.BackColor = Color.White;
            Btlimpiar.ForeColor = azulOscuro;
            Btlimpiar.FlatStyle = FlatStyle.Flat;

            btnBorrar.BackColor = Color.FromArgb(254, 242, 242);
            btnBorrar.ForeColor = Color.FromArgb(220, 38, 38);
            btnBorrar.FlatStyle = FlatStyle.Flat;
            btnBorrar.FlatAppearance.BorderSize = 0;
        }

        private void ConfigurarTablaModerna()
        {
            // 1. Configuración general y fondo
            DGVUs.BackgroundColor = Color.FromArgb(244, 246, 250); // El mismo gris claro del fondo derecho
            DGVUs.BorderStyle = BorderStyle.None;
            DGVUs.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal; // Solo líneas horizontales sutiles
            DGVUs.GridColor = Color.FromArgb(230, 230, 230); // Color de las líneas separadoras
            DGVUs.RowHeadersVisible = false; // Oculta la columna fea de la izquierda con la flechita
            DGVUs.AllowUserToAddRows = false; // Quita la fila vacía del final

            // 2. Estilo de la Cabecera (Títulos de las columnas)
            DGVUs.EnableHeadersVisualStyles = false; // ¡Súper importante para que nos deje cambiar colores!
            DGVUs.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            DGVUs.ColumnHeadersHeight = 45; // Cabecera más alta para que respire
            DGVUs.ColumnHeadersDefaultCellStyle.BackColor = Color.White;
            DGVUs.ColumnHeadersDefaultCellStyle.ForeColor = Color.DimGray;
            DGVUs.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            DGVUs.ColumnHeadersDefaultCellStyle.SelectionBackColor = Color.White; // Para que no cambie de color al hacer clic
            DGVUs.ColumnHeadersDefaultCellStyle.SelectionForeColor = Color.DimGray;

            // 3. Estilo de las Filas (Los datos)
            DGVUs.DefaultCellStyle.BackColor = Color.White;
            DGVUs.DefaultCellStyle.ForeColor = Color.FromArgb(64, 64, 64);
            DGVUs.DefaultCellStyle.Font = new Font("Segoe UI", 10F, FontStyle.Regular);
            DGVUs.RowTemplate.Height = 45; // Filas más altas
            DGVUs.SelectionMode = DataGridViewSelectionMode.FullRowSelect; // Selecciona toda la fila junta

            // 4. Color al seleccionar una fila (El azul clarito moderno)
            DGVUs.DefaultCellStyle.SelectionBackColor = Color.FromArgb(240, 244, 255);
            DGVUs.DefaultCellStyle.SelectionForeColor = Color.FromArgb(25, 66, 210);

            // 5. Ajuste de ancho de columnas
            DGVUs.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            // 6. Ajustar el tamaño y centrado del DataGridView
            // Dejamos un margen de 40 píxeles a cada lado (izquierdo y derecho del área blanca)
            int margen = 40;
            int panelIzquierdoAncho = 320; // El ancho de tu menú azul
            int inicioX = panelIzquierdoAncho + margen;

            // Calculamos el ancho ideal restando el panel izquierdo y los márgenes de ambos lados
            int nuevoAncho = this.ClientSize.Width - inicioX - margen;

            // Aplicamos la nueva posición y tamaño
            DGVUs.Location = new Point(inicioX, DGVUs.Location.Y);
            DGVUs.Width = nuevoAncho;

            // Le ponemos anclajes para que si estiras o maximizas la ventana, la tabla se estire sola
            DGVUs.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
        }

        private void CargarUsuarios()
        {
            DGVUs.Rows.Clear();
            List<Usuario> listausuario = new CN_Usuario().Listar();

            foreach (Usuario item in listausuario)
            {
                DGVUs.Rows.Add(new object[] {
                    "", // Para el botón de seleccionar
                    item.IdUsuario,
                    item.Cedula,
                    item.Nombre,
                    item.Correo,
                    item.Clave,
                    item.oRol.IdRol,
                    item.oRol.Descripcion,
                    item.Estado == true ? 1 : 0,
                    item.Estado == true ? "Activo" : "No Activo"
                });
            }
        }

        private void BtnGuardar_Click(object sender, EventArgs e)
        {
            string mensaje = string.Empty;
            bool claveCambiada = false;

            Usuario obj_usuario = new Usuario()
            {
                IdUsuario = Convert.ToInt32(txtid.Text),
                Cedula = tvCedula.Text,
                Nombre = tbnombre.Text,
                Correo = tbcorreo.Text,
                oRol = new Rol() { IdRol = Convert.ToInt32(((Opcombo)CBRol.SelectedItem).Valor) },
                Estado = Convert.ToInt32(((Opcombo)CbEstado.SelectedItem).Valor) == 1
            };

            if (obj_usuario.IdUsuario == 0)
            {
                obj_usuario.Clave = tbContraseña.Text;
            }

            CN_Usuario obj_cn_usuario = new CN_Usuario();

            // MODO CREAR
            if (obj_usuario.IdUsuario == 0)
            {
                int idGenerado = obj_cn_usuario.Registrar(obj_usuario, out mensaje);

                if (idGenerado != 0)
                {
                    MessageBox.Show(mensaje, "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    CargarUsuarios();
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
                bool resultadoDatos = obj_cn_usuario.Editar(obj_usuario, out mensaje);
                bool resultadoClave = true;
                string mensajeClave = string.Empty;

                if (resultadoDatos && !string.IsNullOrEmpty(tbContraseña.Text))
                {
                    claveCambiada = obj_cn_usuario.CambiarClave(obj_usuario.IdUsuario, tbContraseña.Text, out mensajeClave);
                    resultadoClave = claveCambiada;
                }

                if (resultadoDatos && resultadoClave)
                {
                    string msgExito = claveCambiada ? "Usuario y contraseña actualizados con éxito." : "Usuario actualizado con éxito.";
                    MessageBox.Show(msgExito, "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    CargarUsuarios();
                    LimpiarCampos();
                }
                else
                {
                    string msgError = !resultadoDatos ? mensaje : mensajeClave;
                    MessageBox.Show(msgError, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void LimpiarCampos()
        {
            tbindice.Text = "-1";
            txtid.Clear(); // Ojo: txtid.Text = "0" en LimpiarC, asegúrate de unificar si lo prefieres
            tvCedula.Clear();
            tbnombre.Clear();
            tbcorreo.Clear();
            tbContraseña.Clear();
            if (CBRol.Items.Count > 0) CBRol.SelectedIndex = 0;
            if (CbEstado.Items.Count > 0) CbEstado.SelectedIndex = 0;
            BtnGuardar.Text = "Guardar";
            tvCedula.Select();
        }

        private void LimpiarC()
        {
            tbindice.Text = "-1";
            TBBuscar.Clear();
            txtid.Text = "0";
            tvCedula.Clear();
            tbnombre.Clear();
            tbcorreo.Clear();
            tbContraseña.Clear();

            if (CBRol.Items.Count > 0) CBRol.SelectedIndex = 0;
            if (CbEstado.Items.Count > 0) CbEstado.SelectedIndex = 0;

            BtnGuardar.Text = "Guardar";
            tvCedula.Select();
        }

        private void Btlimpiar_Click(object sender, EventArgs e)
        {
            LimpiarC();
        }

        private void BtnLimpiar_Click(object sender, EventArgs e)
        {
            TBBuscar.Clear();
            if (CBFiltro.Items.Count > 0) CBFiltro.SelectedIndex = 0;
        }

        private void DGVUs_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.RowIndex < 0)
                return;

            // Reemplazamos la imagen gigante por un icono sutil de texto (lapicito)
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

        private void DGVUs_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (DGVUs.Columns[e.ColumnIndex].Name == "BtnSelect" && e.RowIndex >= 0)
            {
                tbindice.Text = e.RowIndex.ToString();
                txtid.Text = DGVUs.Rows[e.RowIndex].Cells["IdUsuario"].Value.ToString();
                idUsuarioSeleccionado = Convert.ToInt32(txtid.Text);

                tvCedula.Text = DGVUs.Rows[e.RowIndex].Cells["Cedula"].Value.ToString();
                tbnombre.Text = DGVUs.Rows[e.RowIndex].Cells["Nombre"].Value.ToString();
                tbcorreo.Text = DGVUs.Rows[e.RowIndex].Cells["Correo"].Value.ToString();

                foreach (Opcombo item in CBRol.Items)
                {
                    if (Convert.ToInt32(item.Valor) == Convert.ToInt32(DGVUs.Rows[e.RowIndex].Cells["IdRol"].Value))
                    {
                        CBRol.SelectedItem = item;
                        break;
                    }
                }

                string estadoTexto = DGVUs.Rows[e.RowIndex].Cells["EstadoValor"].Value.ToString();
                int estadoInt = (estadoTexto == "Activo") ? 1 : 0;

                foreach (Opcombo item in CbEstado.Items)
                {
                    if (Convert.ToInt32(item.Valor) == estadoInt)
                    {
                        CbEstado.SelectedItem = item;
                        break;
                    }
                }

                BtnGuardar.Text = "Actualizar";
            }
        }

        private void btnBorrar_Click(object sender, EventArgs e)
        {
            if (Convert.ToInt32(txtid.Text) != 0)
            {
                if (MessageBox.Show("¿Está seguro de que desea desactivar este usuario?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    string mensaje = string.Empty;
                    int idUsuario = Convert.ToInt32(txtid.Text);
                    CN_Usuario obj_cn_usuario = new CN_Usuario();

                    bool resultado = obj_cn_usuario.Eliminar(idUsuario, out mensaje);

                    if (resultado)
                    {
                        MessageBox.Show("Usuario desactivado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        CargarUsuarios();
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
                MessageBox.Show("Por favor, seleccione un usuario de la lista primero.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
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
        private void DGVUs_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex < 0 || e.Value == null) return;

            // Centrar el texto en todas las celdas (menos la del botón de edición)
            if (e.ColumnIndex > 0)
            {
                e.CellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }

            // Usamos HeaderText (el título visible) en lugar de Name para no fallar
            string tituloColumna = DGVUs.Columns[e.ColumnIndex].HeaderText;

            // Colorear ESTADO
            if (tituloColumna == "Estado")
            {
                e.CellStyle.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
                string estado = e.Value.ToString().Trim();

                if (estado == "Activo")
                    e.CellStyle.ForeColor = Color.FromArgb(22, 163, 74); // Verde moderno
                else if (estado == "No Activo" || estado == "Inactivo")
                    e.CellStyle.ForeColor = Color.FromArgb(220, 38, 38); // Rojo moderno
            }

            // Colorear ROL
            if (tituloColumna == "Rol")
            {
                e.CellStyle.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
                string rol = e.Value.ToString().ToLower().Trim();

                if (rol.Contains("administrador"))
                    e.CellStyle.ForeColor = Color.FromArgb(147, 51, 234); // Morado
                else if (rol.Contains("vendedor"))
                    e.CellStyle.ForeColor = Color.FromArgb(37, 99, 235); // Azul
                else if (rol.Contains("cajero"))
                    e.CellStyle.ForeColor = Color.FromArgb(217, 119, 6); // Naranja/Dorado
            }
        
        }
    }
}