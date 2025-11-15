using CapaNegocios;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
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
        public Login()
        {
            InitializeComponent();
        }

        private void BotonCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BtonIngreso_Click(object sender, EventArgs e)
        {
            //  Llama al método Loguear de la capa de negocios.
            CN_Usuario obj_cn_usuario = new CN_Usuario();
            Usuario usuario_encontrado = obj_cn_usuario.Loguear(TbCedula.Text, TbPsw.Text);

            // Verifica si se encontró un usuario válido.
            if (usuario_encontrado != null)
            {
                // Muestra bienvenida y abre el formulario principal.
                MessageBox.Show("Bienvenido " + usuario_encontrado.Nombre, "Ingreso Exitoso",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Pasa los datos del usuario logueado al formulario de inicio.
                Inicio frm = new Inicio(usuario_encontrado);
                TbCedula.Clear();
                TbPsw.Clear();
                frm.Show();
                this.Hide();

                
                frm.FormClosing += frm_closing;
            }
            else
            {
                //Muestra un error.
                MessageBox.Show("Cédula o clave incorrecta.", "Error de Ingreso",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);

                TbPsw.Clear();
                TbCedula.Focus();
            }
        }
        private void frm_closing(object sender, FormClosingEventArgs e)
        {
            this.Show();
        }
        // Evita que se escriban caracteres no numéricos
        private void TbPsw_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Permitir teclas de control
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        // cualquier carácter no numérico
        private void TbPsw_TextChanged(object sender, EventArgs e)
        {
            var tb = sender as TextBox;
            if (tb == null) return;

            string original = tb.Text;
            string filtered = new string(original.Where(char.IsDigit).ToArray());

            if (filtered != original)
            {
                int selStart = tb.SelectionStart;
                tb.Text = filtered;
                tb.SelectionStart = Math.Min(selStart, tb.Text.Length);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MySqlConnection conn = null; // Declara la variable afuera del try
            try
            {
                // Intenta obtener la conexión
                conn = Conexion.obtenerConexion();

                // Si llega aquí, todo salió bien (Amen)
                MessageBox.Show("¡Conexión a la base de datos exitosa!", "Éxito",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                // Si "obtenerConexion" lanzó un error, lo atrapas aquí y lo muestras (Si da error Bombardeo Peru)
                MessageBox.Show("Error al conectar: " + ex.Message, "Error de Conexión",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                // Finalmente, cierra la conexión si se logró abrir
                if (conn != null && conn.State == System.Data.ConnectionState.Open)
                {
                    conn.Close();
                }
            }
        }
    }
}
