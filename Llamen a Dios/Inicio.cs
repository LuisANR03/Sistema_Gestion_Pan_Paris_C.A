using Dato;
using FontAwesome.Sharp;
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
using Entidades;

namespace Llamen_a_Dios
{
    public partial class Inicio : Form
    {
        private static Usuario usuarioActual =null;
        private static IconMenuItem menuActivo = null;
        private static Form formularioActivo = null;
        public Inicio(Usuario obj_usuario)
        {
            if (obj_usuario == null) usuarioActual = new Usuario() { Nombre = "Predefinido", IdUsuario = 1};
            else usuarioActual = obj_usuario;


            InitializeComponent();
            // Guarda el usuario que se recibió del login en la variable.
            usuarioActual = obj_usuario;
        }
        public Inicio()
        {
            InitializeComponent();
             
        }

        private void Inicio_Load(object sender, EventArgs e)
        {

            List<Permisos> lista_permisos = new CN_permisos().Listar(usuarioActual.IdUsuario);
            foreach (IconMenuItem menu in MenuTitulo.Items)
            {
                // Verificamos si el menú actual está en la lista de permisos del usuario.
                bool tienePermiso = lista_permisos.Any(p => p.NombreMenu == menu.Name);
                // Si no tiene permiso, ocultamos el menú.
                if (!tienePermiso)
                {
                    menu.Visible = false;
                }
            }

            // Hacemos una comprobación de seguridad para asegurarnos de que el usuario no sea nulo.
            if (usuarioActual != null)
            {
                // Asignamos el nombre y el rol del usuario al texto del Label.
                lblnombreuser.Text = usuarioActual.Nombre;
            }
            



        }
        private void AbrirFrm(IconMenuItem menu, Form formulario)
        {
            if (menuActivo != null) {
                menuActivo.BackColor = Color.White;
            }
            menu.BackColor = Color.LightGray;   
            menuActivo = menu;

            if (formularioActivo != null) {
                formularioActivo.Close();
            }
            formularioActivo = formulario;
            formulario.TopLevel = false;
            formulario.FormBorderStyle = FormBorderStyle.None;
            formulario.Dock = DockStyle.Fill;
            
            Contenedor.Controls.Add(formulario);
            formulario.Show();


        }

        private void MenuUs_Click(object sender, EventArgs e)
        {
            AbrirFrm((IconMenuItem)sender, new FormUsuarios());
        }

        private void submenuregistrarventa_Click(object sender, EventArgs e)
        {
            AbrirFrm((IconMenuItem)sender, new Frmregistrarventa());
        }

        private void submenudetalleventa_Click(object sender, EventArgs e)
        {
            AbrirFrm((IconMenuItem)sender, new Frmdetalleventa());
        }
        private void MenuClient_Click(object sender, EventArgs e)
        {
            AbrirFrm((IconMenuItem)sender, new FrmClientes());
        }

        private void MenuInformes_Click(object sender, EventArgs e)
        {
            AbrirFrm((IconMenuItem)sender, new Frminformes());
        }

        private void MenuStock_Click(object sender, EventArgs e)
        {
            AbrirFrm((IconMenuItem)sender, new FrmStock());
        }

        private void MenuAcerca_Click(object sender, EventArgs e)
        {
            AbrirFrm((IconMenuItem)sender, new FrmAcercade());
        }

        private void iconButton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
