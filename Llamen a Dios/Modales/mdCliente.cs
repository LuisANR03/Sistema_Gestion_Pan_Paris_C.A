using CapaNegocios;
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

namespace Llamen_a_Dios.Modales
{
    public partial class mdCliente : Form
    {
        // 1. Agregamos la lista que te faltaba declarar
        public List<Cliente> listaOriginalClientes;

        // 2. Agregamos las propiedades para enviar los datos a la Venta
        public string IdClienteSeleccionado { get; set; }
        public string TipoDocumentoSeleccionado { get; set; }
        public string CedulaSeleccionada { get; set; }
        public string NombreSeleccionado { get; set; }

        public mdCliente()
        {
            InitializeComponent();
        }

        private void mdCliente_Load(object sender, EventArgs e)
        {
            CargarClientes();
            

            foreach (DataGridViewColumn columna in DGVUs.Columns)
            {
                if (columna.Visible == true && columna.Name != "BtnSelect" && columna.Name != "Valor")
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
            ConfigurarAyudaVisual();
        }

        // --- LOS MÉTODOS AHORA SÍ ESTÁN DENTRO DE LA CLASE ---


        private void CargarClientes()
        {
            DGVUs.Rows.Clear();

            CN_cliente obj_cn_cliente = new CN_cliente();
            listaOriginalClientes = obj_cn_cliente.Listar();

            foreach (Cliente item in listaOriginalClientes)
            {
                // Solo cargamos clientes activos (Estado == true)
                if (item.Estado == true)
                {
                    DGVUs.Rows.Add(new object[] {
                        "", // BtnSelect
                        item.IdCliente,
                        item.TipoDocumento,
                        item.Cedula,
                        item.Nombre,
                        item.Correo,
                        item.Telefono,
                        item.Direccion,
                        1,
                        "Activo"
                    });
                }
            }
        }

        // 3. NUEVO EVENTO: Cuando el usuario hace doble clic en un cliente
        private void DGVUs_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            // Validamos que haya hecho clic en una fila válida (no en el encabezado)
            if (e.RowIndex >= 0)
            {
                // Capturamos los datos basándonos en las posiciones de tu método CargarClientes
                IdClienteSeleccionado = DGVUs.Rows[e.RowIndex].Cells[1].Value.ToString();
                TipoDocumentoSeleccionado = DGVUs.Rows[e.RowIndex].Cells[2].Value.ToString();
                CedulaSeleccionada = DGVUs.Rows[e.RowIndex].Cells[3].Value.ToString();
                NombreSeleccionado = DGVUs.Rows[e.RowIndex].Cells[4].Value.ToString();

                // Confirmamos y cerramos el modal
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }

        private void TBBuscar__TextChanged(object sender, EventArgs e)
        {
            // 1. Asegúrate de que haya una columna seleccionada en el ComboBox
            if (CBFiltro.SelectedItem == null)
            {
                return;
            }

            // 2. Obtiene el nombre de la columna por la cual filtrar
            string columnaFiltro = ((Opcombo)CBFiltro.SelectedItem).Valor.ToString();

            // 3. Obtiene el texto de búsqueda (en minúsculas para evitar problemas de mayúsculas)
            string textoBusqueda = TBBuscar.Text.Trim().ToLower();

            // 4. Recorre cada fila del DataGridView
            foreach (DataGridViewRow row in DGVUs.Rows)
            {
                if (row.IsNewRow) continue;

                // 5. Obtiene el valor de la celda de forma segura
                string valorCelda = row.Cells[columnaFiltro].Value?.ToString() ?? "";

                // 6. Muestra u oculta la fila si coincide con la búsqueda
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

        private void BtnLimpiar_Click(object sender, EventArgs e)
        {
            TBBuscar.Clear();
            if (CBFiltro.Items.Count > 0)
            {
                CBFiltro.SelectedIndex = 0;
            }
        }

        // ==============================================================
        // AYUDA VISUAL (ESTILO GLOBO) PARA EL MODAL DE CLIENTES
        // ==============================================================
        private void ConfigurarAyudaVisual()
        {
            ToolTip toolTipModal = new ToolTip();

            // Estilo Globo idéntico al resto del sistema
            toolTipModal.IsBalloon = true;
            toolTipModal.ToolTipIcon = ToolTipIcon.Info;
            toolTipModal.ToolTipTitle = "Selección de Cliente";

            // Configuración de tiempos
            toolTipModal.AutoPopDelay = 6000;
            toolTipModal.InitialDelay = 400;
            toolTipModal.ReshowDelay = 300;
            toolTipModal.ShowAlways = true;

            // --- TOOLTIPS PARA LOS CONTROLES DEL MODAL ---
            toolTipModal.SetToolTip(this.TBBuscar, "Escribe aquí para buscar rápidamente a un cliente.");
            toolTipModal.SetToolTip(this.BtnLimpiar, "Borra el texto de búsqueda y muestra todos los clientes activos.");
            toolTipModal.SetToolTip(this.CBFiltro, "Elige por cuál columna deseas realizar la búsqueda (Ej: Cédula, Nombre).");

            // Instrucción clave para el DataGridView
            toolTipModal.SetToolTip(this.DGVUs, "Haz DOBLE CLIC sobre la fila del cliente\npara seleccionarlo y agregarlo a la factura.");

            // Si tienes el botón cancelar declarado, le ponemos su ayuda
            if (this.btnCancelar != null)
            {
                toolTipModal.SetToolTip(this.btnCancelar, "Cierra esta ventana sin seleccionar ningún cliente.");
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}