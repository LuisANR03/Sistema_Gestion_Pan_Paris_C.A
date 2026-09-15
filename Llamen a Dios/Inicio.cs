using CapaDatos;
using CapaNegocios;
using Dato;
using Entidades;
using FontAwesome.Sharp;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Windows.Forms;


namespace Llamen_a_Dios
{
    public partial class Inicio : Form
    {
        public static Usuario usuarioActual = null;
        private IconButton menuActivo = null;
        private static Form formularioActivo = null;

        public Inicio(Usuario obj_usuario)
        {
            if (obj_usuario == null) usuarioActual = new Usuario() { Nombre = "Predefinido", IdUsuario = 1 };
            else usuarioActual = obj_usuario;

            InitializeComponent();
            usuarioActual = obj_usuario;
        }

        public Inicio()
        {
            InitializeComponent();
        }

        private void Inicio_Load(object sender, EventArgs e)
        {
            if (usuarioActual != null)
            {
                lblnombreuser.Text = usuarioActual.Nombre;

                // 1. OCULTAMOS TODOS LOS BOTONES POR SEGURIDAD
                // Botones Principales
                btndashboard.Visible = false;
                Btnasistente.Visible = false;
                btnProduccion.Visible = false;
                btnAcerca.Visible = false;
                btnUsuarios.Visible = false;
                btnClientes.Visible = false;
                btnVentas.Visible = false;
                btnStock.Visible = false;
                btnInformes.Visible = false;
                btnrespaldo.Visible = false;
                // Submenús
                submenuregistrarventa.Visible = false;
                submenudetalleventa.Visible = false;
                submenuinv.Visible = false;
                submenucierrecaja.Visible = false;
                

                // 2. BUSCAMOS LOS PERMISOS DEL USUARIO EN LA BASE DE DATOS
                // Asumiendo que tienes un método Listar en CN_permisos que recibe el IdRol
                List<Permisos> ListaPermisos = new CN_permisos().Listar(usuarioActual.IdUsuario);

                // 3. MOSTRAMOS SOLO LOS BOTONES A LOS QUE TIENE ACCESO
                // Recorremos los botones principales (Sidebar)
                foreach (Control control in PanelSidebar.Controls)
                {
                    if (control is FontAwesome.Sharp.IconButton || control is Button)
                    {
                        foreach (Permisos permiso in ListaPermisos)
                        {
                            if (control.Name == permiso.NombreMenu)
                            {
                                control.Visible = true;
                                break; // Si lo encuentra, deja de buscar y pasa al siguiente control
                            }
                        }
                    }
                }

                // Recorremos los submenús de Ventas
                foreach (Control control in PanelSubmenuVentas.Controls)
                {
                    foreach (Permisos permiso in ListaPermisos)
                    {
                        if (control.Name == permiso.NombreMenu) { control.Visible = true; break; }
                    }
                }

                // Recorremos los submenús de Stock
                foreach (Control control in PanelSubmenuStock.Controls)
                {
                    foreach (Permisos permiso in ListaPermisos)
                    {
                        if (control.Name == permiso.NombreMenu) { control.Visible = true; break; }
                    }
                }

                // Recorremos los submenús de Informes
                foreach (Control control in PanelSubmenuInformes.Controls)
                {
                    foreach (Permisos permiso in ListaPermisos)
                    {
                        if (control.Name == permiso.NombreMenu) { control.Visible = true; break; }
                    }
                }

                ConfigurarAyudaVisual();
            }

            // Por defecto abrimos el Dashboard o Acerca de
            AbrirFrm(sender, new Dashboard());
        }

        // --- LÓGICA DEL MENÚ ACORDEÓN ---
        private void OcultarSubmenus()
        {
            if (PanelSubmenuVentas.Visible) PanelSubmenuVentas.Visible = false;
            if (PanelSubmenuStock.Visible) PanelSubmenuStock.Visible = false;
            if (PanelSubmenuInformes.Visible) PanelSubmenuInformes.Visible = false; // Actualizado para incluir Informes
        }

        private void MostrarSubmenu(Panel submenu)
        {
            if (submenu.Visible == false)
            {
                OcultarSubmenus(); // Cierra los otros paneles que estén abiertos
                submenu.Visible = true;
            }
            else
            {
                submenu.Visible = false; // Lo esconde si le vuelves a dar clic
            }
        }

        // --- ABRIR FORMULARIO EN EL CONTENEDOR ---
        private void AbrirFrm(object senderMenu, Form formulario)
        {
            if (menuActivo != null)
            {
                // menuActivo.BackColor = Color.FromArgb(28, 78, 216); // Azul de tu sidebar
            }

            // Identificamos si se hizo clic en un botón principal
            if (senderMenu is IconButton)
            {
                menuActivo = (IconButton)senderMenu;
                // menuActivo.BackColor = Color.FromArgb(45, 96, 238);
            }
            // Identificamos si se hizo clic en un submenú
            else if (senderMenu is Button)
            {
                Button btn = (Button)senderMenu;
                if (btn.Parent == PanelSubmenuVentas) menuActivo = btnVentas;
                if (btn.Parent == PanelSubmenuStock) menuActivo = btnStock;
                if (btn.Parent == PanelSubmenuInformes) menuActivo = btnInformes; // Vincula los subbotones a Informes

                //     if (menuActivo != null)
                //     menuActivo.BackColor = Color.FromArgb(45, 96, 238);
            }
//
            if (formularioActivo != null)
            {
                formularioActivo.Close();
            }

            formularioActivo = formulario;
            formulario.TopLevel = false;
            formulario.FormBorderStyle = FormBorderStyle.None;
            formulario.Dock = DockStyle.Fill;

            Contenedor.Controls.Add(formulario);
            formulario.Show();
        }

        // --- EVENTOS DE BOTONES PRINCIPALES ---
        private void MenuUs_Click(object sender, EventArgs e)
        {
            OcultarSubmenus();
            AbrirFrm(sender, new FormUsuarios());
        }

        private void MenuClient_Click(object sender, EventArgs e)
        {
            OcultarSubmenus();
            AbrirFrm(sender, new FrmClientes(usuarioActual));
        }

        private void MenuInformes_Click(object sender, EventArgs e)
        {
            // Cambiado: Ahora despliega el menú en vez de abrir el formulario directo
            MostrarSubmenu(PanelSubmenuInformes);
        }

        private void MenuAcerca_Click(object sender, EventArgs e)
        {
            OcultarSubmenus();
            AbrirFrm(sender, new FrmAcercade());
        }

        private void iconButton1_Click(object sender, EventArgs e) // Cerrar Sesión
        {
            this.Close();
        }

        // --- EVENTOS QUE DESPLIEGAN EL ACORDEÓN ---
        private void btnVentas_Click(object sender, EventArgs e)
        {
            MostrarSubmenu(PanelSubmenuVentas);
        }

        private void btnStock_Click(object sender, EventArgs e)
        {
            MostrarSubmenu(PanelSubmenuStock);
        }

        // --- EVENTOS DE LOS SUBMENÚS ---
        private void submenuregistrarventa_Click(object sender, EventArgs e)
        {
            AbrirFrm(sender, new Frmregistrarventa());
        }

        private void submenudetalleventa_Click(object sender, EventArgs e)
        {
            AbrirFrm(sender, new Frmdetalleventa(usuarioActual));
        }

        private void submenuinv_Click(object sender, EventArgs e)
        {
            AbrirFrm(sender, new FrmStock(usuarioActual));
        }

        private void submenucategorias_Click(object sender, EventArgs e)
        {
            AbrirFrm(sender, new FrmCategoria());
        }

        // --- NUEVOS EVENTOS DE SUBMENÚ INFORMES (Solución a tus errores) ---
        private void submenucierrecaja_Click(object sender, EventArgs e)
        {
            // Vinculado a tu Frminformes actual que ya tenías creado
            AbrirFrm(sender, new CierreCaja());
        }


        private void submenureporteventas_Click(object sender, EventArgs e)
        {
           
        }

        private void timerHora_Tick(object sender, EventArgs e)
        {
            lblHora.Text = DateTime.Now.ToString("dd/MM/yyyy  |  hh:mm:ss tt");
        }

        private void Btnasistente_Click(object sender, EventArgs e)
        {
            AbrirFrm(sender, new FormAnaliticaIA());
        }

        private void Contenedor_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btndashboard_Click(object sender, EventArgs e)
        {
            AbrirFrm(sender, new Dashboard());
        }

        private void btnProduccion_Click(object sender, EventArgs e)
        {
            AbrirFrm(sender, new Produccion());
        }

        private void btnIngredientes_Click(object sender, EventArgs e)
        {
            AbrirFrm(sender, new FrmIngredientes(usuarioActual));
        }

        // ==============================================================
        // MÉTODO PARA CREAR TOOLTIPS PERSONALIZADOS (ESTILO ALERTA)
        // ==============================================================
        // ==============================================================
        // MÉTODO PARA CREAR TOOLTIPS PERSONALIZADOS (ESTILO ALERTA DE STOCK)
        // ==============================================================
        // ==============================================================
        // MÉTODO PARA CREAR TOOLTIPS ESTILO GLOBO (COMO LA IMAGEN)
        // ==============================================================
        private void ConfigurarAyudaVisual()
        {
            ToolTip toolTipMenu = new ToolTip();

            // 1. EL SECRETO PARA QUE SE VEA EXACTAMENTE COMO TU IMAGEN:
            toolTipMenu.IsBalloon = true;                   // Activa la forma de burbuja/globo con la flechita
            toolTipMenu.ToolTipIcon = ToolTipIcon.Info;     // Agrega el ícono azul de "i"
            toolTipMenu.ToolTipTitle = "Módulo del Sistema"; // El título azul en negrita (Aplica a todos)

            // 2. CONFIGURACIÓN DE TIEMPOS
            toolTipMenu.AutoPopDelay = 6000;
            toolTipMenu.InitialDelay = 400;
            toolTipMenu.ReshowDelay = 300;
            toolTipMenu.ShowAlways = true;

            // --- BOTONES PRINCIPALES (SIDEBAR) ---
            toolTipMenu.SetToolTip(this.btndashboard, "Resumen general de las operaciones del día.");
            toolTipMenu.SetToolTip(this.Btnasistente, "Análisis inteligente del negocio y predicciones.");
            toolTipMenu.SetToolTip(this.btnProduccion, "Gestión de recetas, insumos y órdenes de horneado.");
            toolTipMenu.SetToolTip(this.btnVentas, "Despliega las opciones de facturación y facturas emitidas.");
            toolTipMenu.SetToolTip(this.btnStock, "Despliega el control de existencias y categorías.");
            toolTipMenu.SetToolTip(this.btnInformes, "Despliega los reportes y el cierre de caja diario.");
            toolTipMenu.SetToolTip(this.btnClientes, "Administración de la base de datos de clientes registrados.");
            toolTipMenu.SetToolTip(this.btnUsuarios, "Configuración de personal, roles y permisos de acceso.");
            toolTipMenu.SetToolTip(this.btnrespaldo, "Generar una copia de seguridad (.SQL) de la base de datos.");
            toolTipMenu.SetToolTip(this.btnAcerca, "Información técnica del software y desarrolladores.");

            // --- SUBMENÚS DE VENTAS ---
            toolTipMenu.SetToolTip(this.submenuregistrarventa, "Abre el módulo de facturación para registrar un pedido.");
            toolTipMenu.SetToolTip(this.submenudetalleventa, "Consulta y busca facturas emitidas anteriormente.");

            // --- SUBMENÚS DE STOCK ---
            toolTipMenu.SetToolTip(this.submenuinv, "Control de inventario de productos terminados.");
         
            toolTipMenu.SetToolTip(this.btnIngredientes, "Inventario de materia prima (harina, azúcar, etc.).");

            // --- SUBMENÚS DE INFORMES ---
            toolTipMenu.SetToolTip(this.submenucierrecaja, "Realiza el cuadre de dinero en Bs/Dólares y genera el PDF.");
           
        }

        private void ToolTipMenu_Popup(object sender, PopupEventArgs e)
        {
            // Medimos el texto y agregamos márgenes cómodos (Padding)
            Size tamañoTexto = TextRenderer.MeasureText(((ToolTip)sender).GetToolTip(e.AssociatedControl), new Font("Segoe UI", 9.5f));
            e.ToolTipSize = new Size(tamañoTexto.Width + 24, tamañoTexto.Height + 16);
        }

        private void ToolTipMenu_Draw(object sender, DrawToolTipEventArgs e)
        {
            // COLORES ESTILO ALERTA PREMIUM
            Color colorFondo = Color.FromArgb(28, 28, 30);      // Gris ultra oscuro (Modo oscuro limpio)
            Color colorAlerta = Color.FromArgb(245, 158, 11);   // Ámbar/Dorado (Color típico de alertas visuales de stock)

            // 1. Dibujar el fondo plano
            e.Graphics.FillRectangle(new SolidBrush(colorFondo), e.Bounds);

            // 2. Dibujar el borde estilizado (2 píxeles de grosor para que resalte)
            using (Pen penBorde = new Pen(colorAlerta, 2))
            {
                e.Graphics.DrawRectangle(penBorde, new Rectangle(0, 0, e.Bounds.Width - 1, e.Bounds.Height - 1));
            }

            // 3. Dibujar el texto en alta definición
            Font fuente = new Font("Segoe UI", 9.5f, FontStyle.Regular);
            TextRenderer.DrawText(e.Graphics, e.ToolTipText, fuente,
                new Point(12, 8), // Margen interno de inicio del texto
                Color.White,
                TextFormatFlags.NoPadding | TextFormatFlags.Left);
        }

        private void btnrespaldo_Click(object sender, EventArgs e)
        {
            // =================================================================
            // 2. CONFIGURACIÓN DE LA VENTANA DE GUARDADO
            // =================================================================
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "Archivo de Respaldo SQL (*.sql)|*.sql";
            sfd.Title = "Guardar respaldo de la base de datos";

            // Sugerimos un nombre automático con la fecha y hora actual para no sobrescribir respaldos viejos
            sfd.FileName = "Backup_Llamen_a_Dios_" + DateTime.Now.ToString("yyyyMMdd_HHmmss") + ".sql";

            // =================================================================
            // 3. PROCESO DE EXPORTACIÓN (Si el usuario presionó "Guardar")
            // =================================================================
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                // Cambiamos el cursor a modo "Cargando" porque la exportación puede tomar unos segundos
                Cursor.Current = Cursors.WaitCursor;

                try
                {
                    // Usamos tu clase de conexión para conectarnos a MySQL
                    using (MySqlConnection oconexion = Conexion.obtenerConexion())
                    {
                        using (MySqlCommand cmd = new MySqlCommand())
                        {
                            // Inicializamos la librería encargada del respaldo
                            using (MySqlBackup mb = new MySqlBackup(cmd))
                            {
                                cmd.Connection = oconexion;

                                // Nos aseguramos de que la conexión esté abierta antes de empezar
                                if (oconexion.State == ConnectionState.Closed)
                                {
                                    oconexion.Open();
                                }

                                // Genera el archivo .sql con toda la estructura y datos de tu BD
                                mb.ExportToFile(sfd.FileName);
                            }
                        }
                    }

                    // Notificamos al usuario que todo salió perfecto
                    MessageBox.Show("El respaldo de la base de datos se generó exitosamente.\n\nGuardado en:\n" + sfd.FileName,
                                    "Copia de Seguridad Completada",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    // Capturamos cualquier error (ej. disco lleno, pérdida de red, etc.)
                    MessageBox.Show("Ocurrió un error al intentar generar el respaldo:\n\n" + ex.Message,
                                    "Error de Respaldo",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Error);
                }
                finally
                {
                    // Restauramos el cursor a la normalidad pase lo que pase
                    Cursor.Current = Cursors.Default;
                }
            }
        }
    }
}