using Dato;
using FontAwesome.Sharp;
using System;
using System.Drawing;
using System.Windows.Forms;
using CapaNegocios;
using Entidades;

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
            }
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
            AbrirFrm(sender, new FrmClientes());
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
            AbrirFrm(sender, new FrmStock());
        }

        private void submenucategorias_Click(object sender, EventArgs e)
        {
            AbrirFrm(sender, new FrmCategoria());
        }

        // --- NUEVOS EVENTOS DE SUBMENÚ INFORMES (Solución a tus errores) ---
        private void submenucierrecaja_Click(object sender, EventArgs e)
        {
            // NOTA: Si creas un formulario específico para esto, cambia "new Form()" por tu nuevo formulario
            // Ejemplo: AbrirFrm(sender, new FrmCierreCaja());
            MessageBox.Show("Formulario de Cierre de Caja (Próximamente)");
        }

        private void submenucomisiones_Click(object sender, EventArgs e)
        {
            // NOTA: Si creas un formulario específico para esto, cambia "new Form()" por tu nuevo formulario
            // Ejemplo: AbrirFrm(sender, new FrmComisiones());
            MessageBox.Show("Formulario de Comisiones (Próximamente)");
        }

        private void submenureporteventas_Click(object sender, EventArgs e)
        {
            // Vinculado a tu Frminformes actual que ya tenías creado
            AbrirFrm(sender, new CierreCaja());
        }

        private void timerHora_Tick(object sender, EventArgs e)
        {
            lblHora.Text = DateTime.Now.ToString("dd/MM/yyyy  |  hh:mm:ss tt");
        }
    }
}