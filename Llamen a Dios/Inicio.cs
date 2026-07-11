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
                menuActivo.BackColor = Color.FromArgb(28, 78, 216); // Azul de tu sidebar
            }

            // Identificamos si se hizo clic en un botón principal
            if (senderMenu is IconButton)
            {
                menuActivo = (IconButton)senderMenu;
                menuActivo.BackColor = Color.FromArgb(45, 96, 238);
            }
            // Identificamos si se hizo clic en un submenú
            else if (senderMenu is Button)
            {
                Button btn = (Button)senderMenu;
                if (btn.Parent == PanelSubmenuVentas) menuActivo = btnVentas;
                if (btn.Parent == PanelSubmenuStock) menuActivo = btnStock;
                if (btn.Parent == PanelSubmenuInformes) menuActivo = btnInformes; // Vincula los subbotones a Informes

                if (menuActivo != null)
                    menuActivo.BackColor = Color.FromArgb(45, 96, 238);
            }

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
            AbrirFrm(sender, new Frmdetalleventa());
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