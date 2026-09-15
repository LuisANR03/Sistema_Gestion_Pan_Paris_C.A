using CapaNegocios;
using Entidades;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Llamen_a_Dios.Modales
{
    public partial class mdRegistrarCliente : Form
    {
        // 1. Variable para recibir la cédula desde las ventas
        public string CedulaSugerida { get; set; }

        // Variable global privada para guardar el usuario que inició sesión
        private Usuario _UsuarioActual;

        // 2. Modificamos el constructor para recibir el Usuario
        public mdRegistrarCliente(Usuario usuarioActual = null)
        {
            InitializeComponent();
            _UsuarioActual = usuarioActual; // Guardamos el usuario
        }

        // 3. Evento Load del formulario
        private void mdRegistrarCliente_Load(object sender, EventArgs e)
        {
            // --- NUEVO: Cargamos los tipos de documento al iniciar ---
            cbTipoDocumento.Items.Add("V");
            cbTipoDocumento.Items.Add("E");
            cbTipoDocumento.Items.Add("J");
            cbTipoDocumento.Items.Add("G");
            cbTipoDocumento.SelectedIndex = 0; // Por defecto seleccionado "V"

            if (!string.IsNullOrEmpty(CedulaSugerida))
            {
                tbCedula.Text = CedulaSugerida;
                tbnombre.Select(); // Pasa el foco al nombre
            }
        }

        // 4. Evento Click del botón Guardar
        private void BtnGuardar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(tbCedula.Text) || string.IsNullOrWhiteSpace(tbnombre.Text))
            {
                MessageBox.Show("La cédula y el nombre son campos obligatorios.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string mensaje = string.Empty;

            Cliente obj_cliente = new Cliente()
            {
                IdCliente = 0,
                TipoDocumento = cbTipoDocumento.SelectedItem.ToString(), // --- NUEVO ---
                Cedula = tbCedula.Text.Trim(),
                Nombre = tbnombre.Text.Trim(),
                Correo = tbcorreo.Text.Trim(),
                Telefono = tbtlf.Text.Trim(),
                Direccion = tbdir.Text.Trim(),
                Estado = true
            };

            // Obtenemos el ID del usuario logueado (si es null, mandamos 0)
            int idUsuarioLogueado = _UsuarioActual != null ? _UsuarioActual.IdUsuario : 0;

            CN_cliente obj_cn_cliente = new CN_cliente();

            // Pasamos el idUsuarioLogueado a la capa de negocios
            int idGenerado = obj_cn_cliente.Registrar(obj_cliente, idUsuarioLogueado, out mensaje);

            if (idGenerado != 0)
            {
                MessageBox.Show("Cliente registrado exitosamente para la venta.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                MessageBox.Show(mensaje, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // 5. Evento Click del botón Cancelar
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}