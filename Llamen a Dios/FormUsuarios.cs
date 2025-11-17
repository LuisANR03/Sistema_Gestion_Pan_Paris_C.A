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
        private List<Usuario> listaOriginalUsuarios;
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

            // --- 2. LLENA EL COMBO DE ROL (Tu código estaba bien) ---
            // (Solo moví las propiedades fuera del bucle para que sea más eficiente)
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

            // 1. Crea el objeto Usuario (tu código está perfecto)
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

            // MODO CREAR (El ID es 0)
            if (obj_usuario.IdUsuario == 0)
            {
                int idGenerado = obj_cn_usuario.Registrar(obj_usuario, out mensaje);

                // --- CORRECCIÓN AQUÍ ---
                // Comprueba si se generó un ID (éxito)
                if (idGenerado != 0)
                {
                    MessageBox.Show(mensaje, "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    CargarUsuarios();
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
                bool resultadoDatos = obj_cn_usuario.Editar(obj_usuario, out mensaje);
                bool resultadoClave = true; // Asumimos éxito hasta que se demuestre lo contrario
                string mensajeClave = string.Empty;

                // Comprueba si se escribió una nueva clave
                if (resultadoDatos && !string.IsNullOrEmpty(tbContraseña.Text))
                {
                    claveCambiada = obj_cn_usuario.CambiarClave(obj_usuario.IdUsuario, tbContraseña.Text, out mensajeClave);
                    resultadoClave = claveCambiada; // Actualiza el resultado
                }

                // --- CORRECCIÓN AQUÍ ---
                // Comprueba si AMBOS resultados fueron exitosos
                if (resultadoDatos && resultadoClave)
                {
                    // Define el mensaje de éxito correcto
                    string msgExito = claveCambiada ? "Usuario y contraseña actualizados con éxito." : "Usuario actualizado con éxito.";

                    MessageBox.Show(msgExito, "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    CargarUsuarios();
                    LimpiarCampos();
                }
                else // Si CUALQUIERA de los dos falló, es un error
                {
                    // Muestra el mensaje de error (el de Editar o el de Cambiar Clave)
                    string msgError = !resultadoDatos ? mensaje : mensajeClave;
                    MessageBox.Show(msgError, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
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

        private void BtnLimpiar_Click(object sender, EventArgs e)
        {
            TBBuscar.Clear();
            CBFiltro.SelectedIndex = 0; 
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
            tbContraseña.Clear();



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
            // 1. Verifica que haya un usuario seleccionado (que el ID no sea 0)
            if (Convert.ToInt32(txtid.Text) != 0)
            {
                // 2. MUESTRA UNA CONFIRMACIÓN ANTES DE BORRAR
                if (MessageBox.Show("¿Está seguro de que desea desactivar este usuario?",
                                   "Confirmación",
                                   MessageBoxButtons.YesNo,
                                   MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    // Si el usuario hace clic en "Sí"
                    string mensaje = string.Empty;
                    int idUsuario = Convert.ToInt32(txtid.Text);

                    CN_Usuario obj_cn_usuario = new CN_Usuario();

                    // 3. Llama al procedimiento de ELIMINAR (Desactivar)
                    bool resultado = obj_cn_usuario.Eliminar(idUsuario, out mensaje);

                    if (resultado)
                    {
                        MessageBox.Show("Usuario desactivado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        // 4. Recarga el DGV y limpia los campos
                        CargarUsuarios();
                        LimpiarCampos();
                    }
                    else
                    {
                        // Muestra el error que vino de la Capa de Negocios
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
            // 1. Asegúrate de que haya una columna seleccionada en el ComboBox
            if (CBFiltro.SelectedItem == null)
            {
                // Si no hay nada seleccionado, no hagas nada
                return;
            }

            // 2. Obtiene el NOMBRE de la columna por la cual se va a filtrar
            //    (Ej: "Cedula", "Nombre", "Correo")
            string columnaFiltro = ((Opcombo)CBFiltro.SelectedItem).Valor.ToString();

            // 3. Obtiene el texto que el usuario está escribiendo (en minúsculas)
            string textoBusqueda = TBBuscar.Text.Trim().ToLower();

            // 4. Recorre CADA fila del DataGridView
            foreach (DataGridViewRow row in DGVUs.Rows)
            {
                // (Nos saltamos la fila "nueva" al final, si es que existe)
                if (row.IsNewRow) continue;

                // 5. Obtiene el valor de la celda de esa fila
                //    (Usa ?.ToString() ?? "" para evitar errores si la celda es nula)
                string valorCelda = row.Cells[columnaFiltro].Value?.ToString() ?? "";

                // 6. Compara el valor de la celda (en minúsculas) con el texto de búsqueda
                if (valorCelda.ToLower().Contains(textoBusqueda))
                {
                    // Si el texto SÍ está, muestra la fila
                    row.Visible = true;
                }
                else
                {
                    // Si el texto NO está, oculta la fila
                    row.Visible = false;
                }
            }
        }

        private void BtnBuscar_Click(object sender, EventArgs e)
        {

        }
    }

}
