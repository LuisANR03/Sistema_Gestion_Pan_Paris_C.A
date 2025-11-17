using CapaNegocios;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D; // <-- Agregado para los bordes redondeados
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Dato;
using Entidades;

namespace Llamen_a_Dios
{
    public partial class Login : Form
    {
        // --- VARIABLES PARA MOVER LA VENTANA ---
        private bool arrastrando = false;
        private Point puntoInicioArraste;

        // --- VARIABLE PARA EL REDONDEO ---
        private int radioEsquinasFormulario = 30; // Puedes subir o bajar este número para más/menos curva

        public Login()
        {
            InitializeComponent();
        }

        // --- CÓDIGO PARA REDONDEAR LOS BORDES DE LA VENTANA ---
        private GraphicsPath CrearRutaRedondeada(Rectangle rect, int radio)
        {
            GraphicsPath ruta = new GraphicsPath();
            float tamañoCurva = radio * 2F;

            if (radio <= 0)
            {
                ruta.AddRectangle(rect);
                return ruta;
            }

            ruta.StartFigure();
            ruta.AddArc(rect.X, rect.Y, tamañoCurva, tamañoCurva, 180, 90);
            ruta.AddArc(rect.Right - tamañoCurva, rect.Y, tamañoCurva, tamañoCurva, 270, 90);
            ruta.AddArc(rect.Right - tamañoCurva, rect.Bottom - tamañoCurva, tamañoCurva, tamañoCurva, 0, 90);
            ruta.AddArc(rect.X, rect.Bottom - tamañoCurva, tamañoCurva, tamañoCurva, 90, 90);
            ruta.CloseFigure();

            return ruta;
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            // Corta las esquinas del formulario al cargar
            Rectangle rectArea = new Rectangle(0, 0, this.Width, this.Height);
            using (GraphicsPath ruta = CrearRutaRedondeada(rectArea, radioEsquinasFormulario))
            {
                this.Region = new Region(ruta);
            }
        }

        // --- EVENTOS PARA MOVER LA VENTANA SIN BORDE ---
        public void MoverVentana_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                arrastrando = true;
                puntoInicioArraste = new Point(e.X, e.Y);
            }
        }

        public void MoverVentana_MouseMove(object sender, MouseEventArgs e)
        {
            if (arrastrando)
            {
                Point p = PointToScreen(e.Location);
                this.Location = new Point(p.X - puntoInicioArraste.X, p.Y - puntoInicioArraste.Y);
            }
        }

        public void MoverVentana_MouseUp(object sender, MouseEventArgs e)
        {
            arrastrando = false;
        }

        // --- TUS BOTONES ORIGINALES ---

        private void BotonCancel_Click(object sender, EventArgs e)
        {

        }

        private void frm_closing(object sender, FormClosingEventArgs e)
        {
            this.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MySqlConnection conn = null;
            try
            {
                conn = Conexion.obtenerConexion();
                MessageBox.Show("¡Conexión a la base de datos exitosa!", "Éxito",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al conectar: " + ex.Message, "Error de Conexión",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (conn != null && conn.State == System.Data.ConnectionState.Open)
                {
                    conn.Close();
                }
            }
        }

        private void btnmingresar_Click(object sender, EventArgs e)
        {
            CN_Usuario obj_cn_usuario = new CN_Usuario();
            Usuario usuario_encontrado = obj_cn_usuario.Loguear(tbmcedula.Text, tbmcontraseña.Text);

            if (usuario_encontrado != null)
            {
                MessageBox.Show("Bienvenido " + usuario_encontrado.Nombre, "Ingreso Exitoso",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);

                Inicio frm = new Inicio(usuario_encontrado);
                tbmcedula.Clear();
                tbmcontraseña.Clear();
                frm.Show();
                this.Hide();

                frm.FormClosing += frm_closing;
            }
            else
            {
                MessageBox.Show("Cédula o clave incorrecta.", "Error de Ingreso",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);

                tbmcedula.Clear();
                tbmcontraseña.Clear();
            }
        }

        private void btnmcerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}