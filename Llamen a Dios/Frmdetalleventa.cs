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
using CapaDatos;

namespace Llamen_a_Dios
{
    public partial class Frmdetalleventa : Form
    {
        public Frmdetalleventa()
        {
            InitializeComponent();
        }

        private void Frmdetalleventa_Load(object sender, EventArgs e)
        {
            // 1. Limpiamos el ComboBox por si acaso
            cbBusqueda.Items.Clear();

            // 2. Llenar el ComboBox leyendo directamente las columnas de tu tabla
            foreach (DataGridViewColumn columna in DGV.Columns)
            {
                // Filtramos para que no agregue la columna del botón ni las ocultas
                // Nota: Asegúrate de que tu columna del botón se llame "Boton" en el diseño, o cambia este nombre.
                if (columna.Visible && columna.Name != "Boton")
                {
                    cbBusqueda.Items.Add(new { Valor = columna.Name, Texto = columna.HeaderText });
                }
            }

            // 3. Le decimos al ComboBox qué mostrar y qué guardar internamente
            cbBusqueda.DisplayMember = "Texto";
            cbBusqueda.ValueMember = "Valor";

            // 4. Seleccionamos el primer elemento por defecto
            if (cbBusqueda.Items.Count > 0)
            {
                cbBusqueda.SelectedIndex = 0;
            }

            // 5. Finalmente, cargamos las ventas de la base de datos
            CargarVentas();
        }

        private void CargarVentas()
        {
            DGV.Rows.Clear();
            List<Ventas> lista = new CN_Venta().Listar(); // Llamada a tu capa de negocio
            MessageBox.Show("Ventas encontradas: " + lista.Count.ToString());

            foreach (Ventas item in lista)
            {
                DGV.Rows.Add(new object[] {
                    "🔍", // Columna del botón
                    item.IdVenta,
                    item.NumeroDocumento,
                    item.FechaVenta.ToString("dd/MM/yyyy"), // Le damos un formato limpio a la fecha
                    item.Cliente.Nombre,  // OJO: Si tu clase Cliente usa "Nombre" en lugar de "NombreCompleto", cámbialo aquí.
                    item.Usuario.Nombre,  // Quitamos la "o" de oUsuario para que coincida con tu clase
                    item.Vendedor.NombreCompleto, // Usamos la clase Vendedor en lugar de NombreVendedor
                    item.MontoTotal.ToString("0.00")
                });
            }
        }

        private void txtBusqueda__TextChanged(object sender, EventArgs e)
        {
            // Obtenemos el nombre interno de la columna seleccionada en el ComboBox
            string columnaFiltro = ((dynamic)cbBusqueda.SelectedItem).Valor;

            if (DGV.Rows.Count > 0)
            {
                foreach (DataGridViewRow fila in DGV.Rows)
                {
                    // Verificamos si el valor de la celda contiene lo que el usuario escribió
                    if (fila.Cells[columnaFiltro].Value != null &&
                        fila.Cells[columnaFiltro].Value.ToString().Trim().ToUpper().Contains(txtBusqueda.Text.Trim().ToUpper()))
                    {
                        fila.Visible = true;
                    }
                    else
                    {
                        // Importante: No puedes ocultar la fila si es la que está seleccionada actualmente,
                        // así que quitamos la selección primero por si acaso.
                        CurrencyManager currencyManager = (CurrencyManager)BindingContext[DGV.DataSource];
                        if (currencyManager != null) currencyManager.SuspendBinding();

                        fila.Visible = false;

                        if (currencyManager != null) currencyManager.ResumeBinding();
                    }
                }
            }
        }

        private void btnBuscarFecha_Click(object sender, EventArgs e)
        {
            // Limpiamos el buscador de texto para no cruzar los filtros
            txtBusqueda.Text = "";

            DateTime fechaInicio = dtpInicio.Value.Date;
            DateTime fechaFin = dtpFin.Value.Date;

            if (DGV.Rows.Count > 0)
            {
                foreach (DataGridViewRow fila in DGV.Rows)
                {
                    if (fila.Cells["FechaVenta"].Value != null) // Cambia "FechaVenta" por el Name real de tu columna en el diseño
                    {
                        // Convertimos el valor de la celda a fecha para compararlo
                        DateTime fechaFila = Convert.ToDateTime(fila.Cells["FechaVenta"].Value.ToString()).Date;

                        if (fechaFila >= fechaInicio && fechaFila <= fechaFin)
                            fila.Visible = true;
                        else
                            fila.Visible = false;
                    }
                }
            }
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            // Restablecemos los controles
            txtBusqueda.Text = "";
            dtpInicio.Value = DateTime.Now;
            dtpFin.Value = DateTime.Now;

            // Volvemos a mostrar todas las filas
            if (DGV.Rows.Count > 0)
            {
                foreach (DataGridViewRow fila in DGV.Rows)
                {
                    fila.Visible = true;
                }
            }
        }

        private void DGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // Verificamos que se hizo clic en la columna de la lupa (columna 0)
            if (DGV.Columns[e.ColumnIndex].Name == "Boton" || e.ColumnIndex == 0)
            {
                int rowIndex = e.RowIndex;
                if (rowIndex >= 0)
                {
                    // 1. Obtenemos el ID de la venta de la fila seleccionada
                    int idVenta = Convert.ToInt32(DGV.Rows[rowIndex].Cells["IdVenta"].Value);

                    // 2. Consultamos todos los detalles a la base de datos
                    Ventas oVenta = new CN_Venta().ObtenerVenta(idVenta);

                    if (oVenta.IdVenta != 0)
                    {
                        // 3. ARMAMOS EL MENSAJE FINAL
                        string mensaje = $"Venta Nro: {oVenta.NumeroDocumento}\n";
                        mensaje += $"Cliente: {oVenta.Cliente.Nombre}\n";
                        mensaje += "--------------------------------------\n";
                        mensaje += "PRODUCTOS VENDIDOS:\n";

                        foreach (DetalleVenta dv in oVenta.Detalles)
                        {
                            // Si cambiaste Producto a oProducto arriba, hazlo aquí también
                            mensaje += $"- {dv.Producto.Nombre} | Cant: {dv.Cantidad} | Precio: ${dv.PrecioUnitario.ToString("0.00")}\n";
                        }

                        mensaje += "--------------------------------------\n";
                        mensaje += $"TOTAL DE LA VENTA: ${oVenta.MontoTotal.ToString("0.00")}";

                        // 4. MOSTRAMOS LA INFO
                        MessageBox.Show(mensaje, "Detalle Completo de la Venta", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
        }

        private void btnBuscador_Click(object sender, EventArgs e)
        {
            // Validamos que haya una columna seleccionada en el ComboBox
            if (cbBusqueda.SelectedItem == null) return;

            // Obtenemos el nombre interno de la columna (Valor)
            string columnaFiltro = ((dynamic)cbBusqueda.SelectedItem).Valor;

            if (DGV.Rows.Count > 0)
            {
                foreach (DataGridViewRow fila in DGV.Rows)
                {
                    // Comparamos lo que tiene la celda con lo que escribiste en el TextBox
                    if (fila.Cells[columnaFiltro].Value != null &&
                        fila.Cells[columnaFiltro].Value.ToString().Trim().ToUpper().Contains(txtBusqueda.Text.Trim().ToUpper()))
                    {
                        fila.Visible = true; // Si coincide, lo mostramos
                    }
                    else
                    {
                        // Si no coincide, lo ocultamos de forma segura
                        CurrencyManager currencyManager = (CurrencyManager)BindingContext[DGV.DataSource];
                        if (currencyManager != null) currencyManager.SuspendBinding();

                        fila.Visible = false;

                        if (currencyManager != null) currencyManager.ResumeBinding();
                    }
                }
            }
        }
    }


}