using CapaDatos;
using CapaNegocios;
using Entidades;
using Llamen_a_Dios.Modales;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Llamen_a_Dios
{
    public partial class Frmregistrarventa : Form
    {
        public Frmregistrarventa()
        {
            InitializeComponent();
           
            // Suscribimos los eventos del DataGridView
            this.DGVStck.CellPainting += new DataGridViewCellPaintingEventHandler(this.DGVStck_CellPainting);
            this.DGVStck.CellContentClick += new DataGridViewCellEventHandler(this.DGVStck_CellContentClick);
        }

        private void Frmregistrarventa_Load(object sender, EventArgs e)
        {
            List<Usuario> listaVendedores = new CN_Usuario().ListarVendedores();
            cbvendedor.DataSource = listaVendedores;
            cbvendedor.DisplayMember = "Nombre";    // La propiedad que se muestra al usuario (asegúrate que tu clase Usuario usa "Nombre")
            cbvendedor.ValueMember = "IdUsuario";   // El ID que guardaremos en la BD

            // Para que no haya ninguno seleccionado por defecto
            cbvendedor.SelectedIndex = -1;

            txbcajero.Text = Inicio.usuarioActual.Nombre;
            txbfecha.Text = DateTime.Now.ToString("dd/MM/yyyy");
            tbtotalitems.Text = "0";
            tbpreciodolar.Text = "0.00";
            tbpreciobs.Text = "0.00";
        }

        #region MÉTODOS DE OPERACIÓN (CARRITO DE COMPRAS)

        private void btnagregarproducto_Click(object sender, EventArgs e)
        {
            string codigoIngresado = txbproducto.Text.Trim();

            if (string.IsNullOrEmpty(codigoIngresado))
            {
                MessageBox.Show("Por favor, ingrese un código de producto.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            CN_Producto obj_cn_producto = new CN_Producto();
            List<Producto> listaProductos = obj_cn_producto.Listar();

            // Buscamos el producto en la base de datos
            Producto productoEncontrado = listaProductos.Find(p => p.Codigo == codigoIngresado && p.Estado == true);

            if (productoEncontrado != null)
            {
                if (productoEncontrado.Stock > 0)
                {
                    bool producto_existe = false;

                    // --- 1. RECORREMOS EL DGV PARA VER SI YA ESTÁ AGREGADO ---
                    foreach (DataGridViewRow fila in DGVStck.Rows)
                    {
                        // Comparamos el ID del producto (Celda 1 según tu estructura)
                        if (fila.Cells[1].Value.ToString() == productoEncontrado.IdProducto.ToString())
                        {
                            producto_existe = true;

                            // Obtenemos la cantidad actual y el precio que se está aplicando
                            int cantidadActual = Convert.ToInt32(fila.Cells[7].Value);
                            decimal precioAplicado = Convert.ToDecimal(fila.Cells[10].Value) / cantidadActual;

                            // Validamos que no exceda el stock físico al intentar sumar 1
                            if ((cantidadActual + 1) <= productoEncontrado.Stock)
                            {
                                fila.Cells[7].Value = cantidadActual + 1; // Actualizamos Cantidad
                                fila.Cells[10].Value = (cantidadActual + 1) * precioAplicado; // Actualizamos Subtotal
                            }
                            else
                            {
                                MessageBox.Show("No se puede agregar más. Stock máximo alcanzado.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            }
                            break;
                        }
                    }

                    // --- 2. SI NO EXISTE EN LA TABLA, LO AGREGAMOS POR PRIMERA VEZ ---
                    if (!producto_existe)
                    {
                        decimal precioAplicado = (productoEncontrado.PrecioPromocion > 0)
                                                 ? (decimal)productoEncontrado.PrecioPromocion
                                                 : productoEncontrado.PrecioVenta;

                        DGVStck.Rows.Add(new object[] {
                    "",
                    productoEncontrado.IdProducto,
                    productoEncontrado.Codigo,
                    productoEncontrado.Nombre,
                    productoEncontrado.Descripcion,
                    productoEncontrado.oCategoria.IdCategoria,
                    productoEncontrado.oCategoria.Descripcion,
                    1, // Cantidad inicial
                    productoEncontrado.PrecioVenta,
                    productoEncontrado.PrecioPromocion ?? 0,
                    precioAplicado, // Subtotal (1 * precioAplicado)
                    productoEncontrado.EstadoValor,
                    DateTime.Now.ToString("d")
                });
                    }

                    // --- 3. RECALCULAMOS TOTALES Y LIMPIAMOS ---
                    CalcularTotales();
                    txbproducto.Text = "";
                    txbproducto.Focus();
                }
                else
                {
                    MessageBox.Show("El producto no tiene stock disponible.", "Sin Stock", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {
                MessageBox.Show("Código de producto no encontrado o inactivo.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txbproducto.Text = "";
                txbproducto.Focus();
            }
        }

        private void btnbuscarproducto_Click(object sender, EventArgs e)
        {
            string codigoIngresado = txbproducto.Text.Trim();

            if (string.IsNullOrEmpty(codigoIngresado))
            {
                // Si está vacío, el cajero quiere abrir la lista para buscar a mano
                AbrirModalBusquedaProducto();
            }
            else
            {
                // Si hay texto, actúa como el botón de agregar / Enter
                BuscarProductoPorCodigo();
            }
        }
        private void AbrirModalBusquedaProducto()
        {
            using (var modal = new mdProducto())
            {
                var result = modal.ShowDialog();

                if (result == DialogResult.OK)
                {
                    // Pegamos el código y llamamos a la función de agregar
                    txbproducto.Text = modal._Producto.Codigo;
                    BuscarProductoPorCodigo();
                }
            }
        }

        private void DGVStck_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            // Si hacen clic en la primera columna (el botón de eliminar con la X)
            if (DGVStck.Columns[e.ColumnIndex].Name == "BtnSelect" || e.ColumnIndex == 0)
            {
                DGVStck.Rows.RemoveAt(e.RowIndex);
            }
        }

        private void DGVStck_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {

        }

        #endregion



        private void btnbuscarcliente_Click(object sender, EventArgs e)
        {
            using (mdCliente modal = new mdCliente())
            {
                if (modal.ShowDialog() == DialogResult.OK)
                {
                    txbcedula.Text = modal.CedulaSeleccionada;
                    txbcliente.Text = modal.NombreSeleccionado;
                    txtIdClienteOculto.Text = modal.IdClienteSeleccionado;
                }
            }
        }

        private void CalcularTotales()
        {
            decimal totalDolar = 0;
            int totalItems = 0;
            decimal tasaCambio = 505m; // Define aquí tu tasa de cambio actual del BCV

            foreach (DataGridViewRow row in DGVStck.Rows)
            {
                // Sumamos los subtotales (Asumiendo que es la Columna 10 según tu código anterior)
                totalDolar += Convert.ToDecimal(row.Cells[10].Value);
                // Sumamos las cantidades (Columna 7)
                totalItems += Convert.ToInt32(row.Cells[7].Value);
            }

            // Actualizamos los campos visuales
            tbpreciodolar.Text = totalDolar.ToString("0.00");
            tbpreciobs.Text = (totalDolar * tasaCambio).ToString("0.00");
            tbtotalitems.Text = totalItems.ToString();
        }

        private void txbproducto_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
               
                MessageBox.Show("Enter detectado"); 

                btnagregarproducto_Click(sender, e);
            }
        }



        // 1. LA OPCIÓN NUCLEAR: Intercepta las teclas a nivel global del formulario
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Enter)
            {
                // 1. Si el Enter fue en la Cédula
                if (txbcedula.ContainsFocus)
                {
                    BuscarClientePorCedula();
                    return true;
                }

                // 2. Si el Enter fue en el Código del Producto
                if (txbproducto.ContainsFocus)
                {
                    BuscarProductoPorCodigo(); // Llamamos al nuevo método
                    return true;
                }
            }

            return base.ProcessCmdKey(ref msg, keyData);
        }

        // 2. EL MÉTODO QUE HACE EL TRABAJO
        private void BuscarClientePorCedula()
        {
            string cedulaBuscar = txbcedula.Text.Trim();

            if (!string.IsNullOrEmpty(cedulaBuscar))
            {
                CN_cliente obj_cn_cliente = new CN_cliente();
                List<Cliente> listaClientes = obj_cn_cliente.Listar();

                // Ajusta 'Documento' o 'NombreCompleto' según cómo se llamen en tu clase Cliente
                Cliente clienteEncontrado = listaClientes.Find(c => c.Cedula == cedulaBuscar && c.Estado == true);

                if (clienteEncontrado != null)
                {
                    txbcliente.Text = clienteEncontrado.Nombre;
                    txtIdClienteOculto.Text = clienteEncontrado.IdCliente.ToString();

                    // Foco al producto para vender rápido
                    txbproducto.Focus();
                }
                else
                {
                    txbcliente.Text = "";
                    txtIdClienteOculto.Text = "";

                    // Cambiamos la pregunta para invitar a registrarlo
                    DialogResult respuesta = MessageBox.Show(
                        "El cliente con la cédula " + cedulaBuscar + " no existe. ¿Deseas registrarlo ahora?",
                        "Nuevo Cliente",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Question);

                    if (respuesta == DialogResult.Yes)
                    {
                        using (var modalRegistro = new mdRegistrarCliente())
                        {
                            // AQUÍ ESTÁ EL CAMBIO: Le pasamos la cédula a la variable pública que creamos
                            modalRegistro.CedulaSugerida = cedulaBuscar;

                            var resultadoModal = modalRegistro.ShowDialog();

                            // Si el usuario guardó el cliente correctamente y cerró el modal con DialogResult.OK
                            if (resultadoModal == DialogResult.OK)
                            {
                                // ¡MAGIA! Volvemos a llamar a la búsqueda automáticamente.
                                BuscarClientePorCedula();
                            }
                        }
                    }
                }
            }
        }
        private void BuscarProductoPorCodigo()
        {
            string codigoIngresado = txbproducto.Text.Trim();

            // Si por alguna razón llega vacío, nos salimos
            if (string.IsNullOrEmpty(codigoIngresado)) return;

            CN_Producto obj_cn_producto = new CN_Producto();
            List<Producto> listaProductos = obj_cn_producto.Listar();

            Producto productoEncontrado = listaProductos.Find(p => p.Codigo == codigoIngresado && p.Estado == true);

            if (productoEncontrado != null)
            {
                if (productoEncontrado.Stock > 0)
                {
                    bool producto_existe = false;

                    foreach (DataGridViewRow fila in DGVStck.Rows)
                    {
                        if (fila.Cells[1].Value.ToString() == productoEncontrado.IdProducto.ToString())
                        {
                            producto_existe = true;

                            int cantidadActual = Convert.ToInt32(fila.Cells[7].Value);
                            decimal precioAplicado = Convert.ToDecimal(fila.Cells[10].Value) / cantidadActual;

                            if ((cantidadActual + 1) <= productoEncontrado.Stock)
                            {
                                fila.Cells[7].Value = cantidadActual + 1;
                                fila.Cells[10].Value = (cantidadActual + 1) * precioAplicado;
                            }
                            else
                            {
                                MessageBox.Show("No se puede agregar más. Stock máximo alcanzado.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            }
                            break;
                        }
                    }

                    if (!producto_existe)
                    {
                        decimal precioAplicado = (productoEncontrado.PrecioPromocion > 0)
                                                 ? (decimal)productoEncontrado.PrecioPromocion
                                                 : productoEncontrado.PrecioVenta;

                        DGVStck.Rows.Add(new object[] {
                            "",
                            productoEncontrado.IdProducto,
                            productoEncontrado.Codigo,
                            productoEncontrado.Nombre,
                            productoEncontrado.Descripcion,
                            productoEncontrado.oCategoria.IdCategoria,
                            productoEncontrado.oCategoria.Descripcion,
                            1,
                            productoEncontrado.PrecioVenta,
                            productoEncontrado.PrecioPromocion ?? 0,
                            precioAplicado,
                            productoEncontrado.EstadoValor,
                            DateTime.Now.ToString("d")
                        });
                    }

                    CalcularTotales();
                    txbproducto.Text = "";
                    txbproducto.Focus();
                }
                else
                {
                    MessageBox.Show("El producto no tiene stock disponible.", "Sin Stock", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    
                }
            }
            else
            {
                // AQUÍ ESTÁ EL AJUSTE CLAVE
                DialogResult respuesta = MessageBox.Show(
                    "El producto con código '" + codigoIngresado + "' no se encuentra. ¿Deseas abrir el buscador manual?",
                    "Producto No Encontrado",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (respuesta == DialogResult.Yes)
                {
                    txbproducto.Text = ""; // Borramos el código malo antes de abrir el modal
                    AbrirModalBusquedaProducto(); // Llamamos al nuevo método directamente
                }
                else
                {
                    txbproducto.Text = "";
                }
            }
        }

        private void btnborrar_Click(object sender, EventArgs e)
        {
            // 1. Verificamos si hay alguna fila actualmente seleccionada en el DataGridView
            if (DGVStck.CurrentRow != null)
            {
                // Opcional pero recomendado: Preguntarle al cajero si de verdad quiere borrarlo
                DialogResult respuesta = MessageBox.Show(
                    "¿Estás seguro de que deseas eliminar este producto de la venta?",
                    "Eliminar Producto",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (respuesta == DialogResult.Yes)
                {
                    
                    DGVStck.Rows.Remove(DGVStck.CurrentRow);

                    
                    CalcularTotales();

                    
                    txbproducto.Focus();
                }
            }
            else
            {
                // Si apretó el botón sin seleccionar nada, le avisamos
                MessageBox.Show("Por favor, selecciona un producto de la lista para eliminarlo.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnVenta_Click(object sender, EventArgs e)
        {
            // 1. VALIDACIONES DE INTERFAZ
            if (DGVStck.Rows.Count == 0)
            {
                MessageBox.Show("Debe agregar productos a la venta", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            if (string.IsNullOrEmpty(txtIdClienteOculto.Text))
            {
                MessageBox.Show("Debe seleccionar un cliente", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            // --- NUEVA VALIDACIÓN: VENDEDOR ---
            if (cbvendedor.SelectedIndex == -1)
            {
                MessageBox.Show("Debe seleccionar un vendedor", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            // 2. ABRIR MODAL DE COBRO
            // Asumiendo que tienes textboxes o labels con los totales ya calculados en el formulario principal
            using (var modal = new mdCobrar())
            {
                // Pasamos los totales al modal (ajusta el nombre de los textbox a los que uses en tu diseño)
                modal._TotalPagarUsd = Convert.ToDecimal(tbpreciodolar.Text);
                modal._TotalPagarBs = Convert.ToDecimal(tbpreciobs.Text); // Ajusta al textbox de Bolívares

                var resultado = modal.ShowDialog();

                if (resultado == DialogResult.OK)
                {
                    // --- INICIO DEL PROCESO DE GUARDADO ---
                    List<DetalleVenta> oListaDetalle = new List<DetalleVenta>();

                    foreach (DataGridViewRow row in DGVStck.Rows)
                    {
                        oListaDetalle.Add(new DetalleVenta()
                        {
                            IdProducto = Convert.ToInt32(row.Cells["IdProducto"].Value),
                            PrecioUnitario = Convert.ToDecimal(row.Cells["Precio"].Value),
                            Cantidad = Convert.ToInt32(row.Cells["Cantidad"].Value)
                        });
                    }

                    // B. Creamos el objeto principal Ventas
                    Ventas oVenta = new Ventas()
                    {
                        IdUsuario = Inicio.usuarioActual.IdUsuario,

                        // --- CAMBIO AQUÍ: Tomamos el ID del ComboBox ---
                        IdVendedor = Convert.ToInt32(cbvendedor.SelectedValue),

                        IdCliente = Convert.ToInt32(txtIdClienteOculto.Text),
                        TipoDocumento = "Factura",
                        NumeroDocumento = "V-" + DateTime.Now.ToString("mmss"),
                        SubTotal = Convert.ToDecimal(tbpreciodolar.Text), // Total base
                        Impuesto = 0.00m,
                        MontoTotal = Convert.ToDecimal(tbpreciodolar.Text)
                    };

                    // C. Llamamos a la Capa de Negocio
                    string mensaje = string.Empty;
                    bool respuesta = new CN_Venta().Registrar(oVenta, oListaDetalle, out mensaje);

                    if (respuesta)
                    {
                        MessageBox.Show("Venta Generada con Éxito", "Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LimpiarVenta();
                    }
                    else
                    {
                        MessageBox.Show("Error: " + mensaje, "Error al registrar", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }
        private void LimpiarVenta()
        {
            txbcedula.Clear();
            txbcliente.Clear();
            txtIdClienteOculto.Clear();
            txbproducto.Clear();
            DGVStck.Rows.Clear();

            // Llamamos a tu método que calcula los totales para que vuelvan a cero
            CalcularTotales();

            txbcedula.Focus();
        }
    }
}
