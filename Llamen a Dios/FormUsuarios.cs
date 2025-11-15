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

namespace Llamen_a_Dios
{
    public partial class FormUsuarios : Form
    {
        private int idUsuarioSeleccionado = 0;
        public FormUsuarios()
        {
            InitializeComponent();
          
        }

        private void FormUsuarios_Load(object sender, EventArgs e)
        {
          CbEstado.Items.Add(new Opcombo() { Texto = "Activo", Valor = 1 });
          CbEstado.Items.Add(new Opcombo() { Texto = "No Activo", Valor = 0 });
          CbEstado.DisplayMember = "Texto";
          CbEstado.ValueMember = "Valor";
          CbEstado.SelectedIndex = 0;

          List<Rol> listaRoles = new CN_rol().Listar();
            foreach (Rol item in listaRoles)
            {
                CBRol.Items.Add(new Opcombo() { Texto = item.Descripcion, Valor = item.IdRol });
                CBRol.DisplayMember = "Texto";
                CBRol.ValueMember = "Valor";
                CBRol.SelectedIndex = 0;

            }

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
            
            //Mostrar usuarios
            List<Usuario> listausuario = new CN_Usuario().Listar();
            foreach (Usuario item in listausuario)
            {
            DGVUs.Rows.Add(new object[] {"", item.IdUsuario, item.Cedula, item.Nombre, item.Correo,item.Clave,
            item.oRol.IdRol,
            item.oRol.Descripcion,
            item.Estado == true ?1 : 0,
            item.Estado == true ?"Activo" : "No Activo"

            });

            }
        }

        private void CargarUsuarios()
        {
            // Limpia la lista antes de cargar
            // (Esto es importante si tu DGV no se limpia solo)
            DGVUs.DataSource = null;

            CN_Usuario obj_cn_usuario = new CN_Usuario();
            List<Usuario> listaUsuarios = obj_cn_usuario.Listar();
            DGVUs.DataSource = listaUsuarios;
        }

        private void BtnGuardar_Click(object sender, EventArgs e)
        {
            string mensaje = string.Empty;
            bool claveCambiada = false;

            // 1. Crea el objeto Usuario
            Usuario obj_usuario = new Usuario()
            {
                IdUsuario = Convert.ToInt32(txtid.Text),
                Cedula = tvCedula.Text,
                Nombre = tbnombre.Text,
                Correo = tbcorreo.Text,
                oRol = new Rol() { IdRol = Convert.ToInt32(((Opcombo)CBRol.SelectedItem).Valor) },
                Estado = Convert.ToInt32(((Opcombo)CbEstado.SelectedItem).Valor) == 1
            };

            // Asignamos la clave SOLO si estamos creando un usuario nuevo
            if (obj_usuario.IdUsuario == 0)
            {
                obj_usuario.Clave = tbContraseña.Text;
            }

            CN_Usuario obj_cn_usuario = new CN_Usuario();

            // ----------------------------------------------------
            // INICIO DE LA LÓGICA DE DECISIÓN
            // ----------------------------------------------------

            // MODO CREAR (El ID es 0)
            if (obj_usuario.IdUsuario == 0)
            {
                // YA NO SE VALIDA LA CLAVE REPETIDA

                // Llama al procedimiento de REGISTRAR
                int idGenerado = obj_cn_usuario.Registrar(obj_usuario, out mensaje);

                if (idGenerado == 0) // Si hubo un error
                {
                    MessageBox.Show(mensaje, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            // MODO EDITAR (El ID NO es 0)
            else
            {
                // 1. Llama al procedimiento de EDITAR (que no cambia la clave)
                bool resultadoDatos = obj_cn_usuario.Editar(obj_usuario, out mensaje);

                // 2. Comprueba si los datos se editaron Y si se escribió una nueva clave
                if (resultadoDatos && !string.IsNullOrEmpty(tbContraseña.Text))
                {
                    // YA NO SE VALIDA LA CLAVE REPETIDA

                    // 2b. Llama al procedimiento para CAMBIAR CLAVE
                    string mensajeClave;
                    claveCambiada = obj_cn_usuario.CambiarClave(obj_usuario.IdUsuario, tbContraseña.Text, out mensajeClave);

                    if (!claveCambiada)
                        mensaje = mensajeClave; // Actualiza el mensaje si falló la clave
                }

                // 3. Muestra el mensaje de éxito (si no hubo errores)
                if (string.IsNullOrEmpty(mensaje))
                {
                    if (resultadoDatos && !claveCambiada && string.IsNullOrEmpty(tbContraseña.Text))
                    {
                        MessageBox.Show("Usuario actualizado con éxito.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else if (resultadoDatos && claveCambiada)
                    {
                        MessageBox.Show("Usuario y contraseña actualizados con éxito.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else // Muestra el error que vino de la capa de negocios
                {
                    MessageBox.Show(mensaje, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            // 4. Si NO hubo mensaje de error, recarga y limpia todo
            if (string.IsNullOrEmpty(mensaje))
            {
                CargarUsuarios(); // Recarga el DataGridView
                LimpiarCampos();  // Limpia los campos
            }

            //    DGVUs.Rows.Add(new object[] {"", txtid.Text, tvCedula.Text, tbnombre.Text, tbcorreo.Text,tbContraseña.Text,
            //    ((Opcombo)CBRol.SelectedItem).Texto.ToString(),
            //    ((Opcombo)CBRol.SelectedItem).Texto.ToString(),
            //    ((Opcombo)CbEstado.SelectedItem).Valor.ToString(),
            //    ((Opcombo)CbEstado.SelectedItem).Texto.ToString()
            //});
            //    LimpiarCampos();
        }
        private void LimpiarCampos()
        {
            tbindice.Text = "-1";
            txtid.Clear();
            tvCedula.Clear();
            tbnombre.Clear();
            tbcorreo.Clear();
            tbContraseña.Clear();
            CBRol.SelectedIndex = 0;
            CbEstado.SelectedIndex = 0;
        }

        private void BtnBuscar_Click(object sender, EventArgs e)
        {

        }

        private void BtnLimpiar_Click(object sender, EventArgs e)
        {
            LimpiarCampos();
        }

        private void DGVUs_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.RowIndex < 0)
                return;

            if (e.ColumnIndex == 0)
            {
                e.Paint(e.CellBounds, DataGridViewPaintParts.All & ~DataGridViewPaintParts.ContentForeground);
                int padding = 4;
                var x = e.CellBounds.Left + padding;
                var y = e.CellBounds.Top + padding;
                var w = e.CellBounds.Width - (padding * 2);
                var h = e.CellBounds.Height - (padding * 2);
                Rectangle rectDestino = new Rectangle(x, y, w, h);

                e.Graphics.DrawImage(Properties.Resources._checked, rectDestino);

                e.Handled = true; 
            

        }


        }

        private void DGVUs_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (DGVUs.Columns[e.ColumnIndex].Name == "BtnSelect" && e.RowIndex >= 0)
            {
                // 1. Guarda el índice y el ID para el botón "Guardar"
                tbindice.Text = e.RowIndex.ToString();
                txtid.Text = DGVUs.Rows[e.RowIndex].Cells["IdUsuario"].Value.ToString();

                // --- AÑADE ESTA LÍNEA (Importante para la lógica de Guardar/Editar) ---
                idUsuarioSeleccionado = Convert.ToInt32(txtid.Text);

                // 2. Carga los TextBoxes
                tvCedula.Text = DGVUs.Rows[e.RowIndex].Cells["Cedula"].Value.ToString();
                tbnombre.Text = DGVUs.Rows[e.RowIndex].Cells["Nombre"].Value.ToString();
                tbcorreo.Text = DGVUs.Rows[e.RowIndex].Cells["Correo"].Value.ToString();

                // 3. Carga el ComboBox de Rol (Ahora funciona gracias al Paso 1)
                foreach (Opcombo item in CBRol.Items)
                {
                    if (Convert.ToInt32(item.Valor) == Convert.ToInt32(DGVUs.Rows[e.RowIndex].Cells["IdRol"].Value))
                    {
                        CBRol.SelectedItem = item;
                        break;
                    }
                }

                // 4. --- CORRECCIÓN DEFINITIVA ---
                //    Lee la columna VISIBLE "EstadoValor" (que es un string)
                string estadoTexto = DGVUs.Rows[e.RowIndex].Cells["EstadoValor"].Value.ToString();

                //    Convierte el texto ("Activo" / "Inactivo") al valor (1 / 0)
                int estadoInt = (estadoTexto == "Activo") ? 1 : 0;

                //    Ahora busca ese valor (1 o 0) en tu ComboBox de Estado
                foreach (Opcombo item in CbEstado.Items)
                {
                    if (Convert.ToInt32(item.Valor) == estadoInt)
                    {
                        CbEstado.SelectedItem = item;
                        break;
                    }
                }

                // 5. --- AÑADE ESTA LÍNEA (Mejora de Interfaz) ---
                BtnGuardar.Text = "Actualizar";
            
        }

                //string idusuario = DGVUs.Rows[e.RowIndex].Cells["IdUsuario"].Value.ToString();
                //MessageBox.Show("Seleccionó el usuario con ID: " + idusuario);
            }


        private void LimpiarC()
        {
            
            tbindice.Text = "-1";
            txtid.Text = "0";

            
            tvCedula.Clear();
            tbnombre.Clear();
            tbcorreo.Clear();
            

            
            if (CBRol.Items.Count > 0)
                CBRol.SelectedIndex = 0;

            if (CbEstado.Items.Count > 0)
                CbEstado.SelectedIndex = 0;

            
            BtnGuardar.Text = "Guardar";

            
            tvCedula.Select();
        }

        private void Btlimpiar_Click(object sender, EventArgs e)
        {
            LimpiarC();
        }

        private void btnBorrar_Click(object sender, EventArgs e)
        {

        }
    }

}
