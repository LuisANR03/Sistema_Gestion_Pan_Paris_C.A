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
    public partial class mdCobrar : Form
    {
        public decimal _TotalPagarUsd { get; set; } // Viene del form ventas
        public decimal _TotalPagarBs { get; set; }  // Viene del form ventas
        private string metodoPagoActual = "Punto de Venta";
        private decimal tasaDolar = 36.50m; // Ajusta a tu tasa real o léela de un txt

        public mdCobrar()
        {
            InitializeComponent();
        }

        private void mdCobrar_Load(object sender, EventArgs e)
        {
            // 1. Sincronizamos valores (Usamos lo que llegó del formulario principal)
            txtTotal.Text = _TotalPagarUsd.ToString("N2");
            txtTasaCambio.Text = tasaDolar.ToString("N2"); // Asegúrate de tener este TextBox

            // 2. Limpiamos y agregamos la primera fila por defecto en Bolívares
            DGV.Rows.Clear();
            DGV.Rows.Add("Punto de Venta", _TotalPagarBs.ToString("N2"), "BS");

            ActivarBotonPago(btnpv);
            CalcularSaldos();
        }

        // --- LÓGICA DE CÁLCULO ---
        private void CalcularSaldos()
        {
            decimal totalPagadoEnBs = 0;
            decimal tasaActual = decimal.TryParse(txtTasaCambio.Text, out decimal t) ? t : tasaDolar;

            foreach (DataGridViewRow row in DGV.Rows)
            {
                if (row.Cells[1].Value == null) continue;

                decimal monto = Convert.ToDecimal(row.Cells[1].Value);
                string metodo = row.Cells[0].Value.ToString();

                // Si el método es de dólares, convertimos a Bs para sumar todo igual
                if (metodo.Contains("$") || metodo.Contains("Zelle"))
                    totalPagadoEnBs += (monto * tasaActual);
                else
                    totalPagadoEnBs += monto;
            }

            decimal diferenciaBs = _TotalPagarBs - totalPagadoEnBs;

            if (diferenciaBs > 0.1m) // Falta dinero
            {
                lblFaltanteBs.Text = diferenciaBs.ToString("N2");
                lblVueltoBs.Text = "0.00";
            }
            else // Pagó de más o completo
            {
                lblFaltanteBs.Text = "0.00";
                lblVueltoBs.Text = Math.Abs(diferenciaBs).ToString("N2");
            }
        }

        // --- EVENTOS DEL DGV PARA REACCIONAR A CAMBIOS MANUALES ---
        private void DGV_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            // Solo actuamos si se editó la columna del Monto (Índice 1)
            if (e.RowIndex >= 0 && e.ColumnIndex == 1)
            {
                DGV.CellValueChanged -= DGV_CellValueChanged;

                // 1. Recalculamos saldos
                CalcularSaldos();

                // 2. Verificamos faltante
                decimal faltante = decimal.TryParse(lblFaltanteBs.Text, out decimal f) ? f : 0;

                // 3. Auto-generar fila de saldo si el usuario bajó el monto
                if (faltante > 0.05m) // Margen pequeño para evitar basura de decimales
                {
                    // Solo añadimos si es la última fila editada para evitar bucles
                    if (e.RowIndex == DGV.Rows.Count - 1)
                    {
                        DGV.Rows.Add("Punto de Venta", faltante.ToString("N2"));
                        CalcularSaldos();
                    }
                }

                DGV.CellValueChanged += DGV_CellValueChanged;
            }
        }

        // --- MANEJO DE BOTONES DE MÉTODO DE PAGO ---
        private void ActivarBotonPago(BotonModerno botonActivo)
        {
            BotonModerno[] todosLosBotones = { btnpv, btnpm, btnebs, btned, btnca };
            foreach (var btn in todosLosBotones)
            {
                btn.BackColor = Color.FromArgb(37, 99, 235);
                btn.GrosorBorde = 0;
            }
            botonActivo.BackColor = Color.FromArgb(30, 58, 138);
            botonActivo.ColorBorde = Color.White;
            botonActivo.GrosorBorde = 2;
            metodoPagoActual = botonActivo.Text;
        }

        private void CambiarMetodoFilaSeleccionada(BotonModerno boton)
        {
            ActivarBotonPago(boton);

            if (DGV.CurrentRow != null)
            {
                DGV.CellValueChanged -= DGV_CellValueChanged; // Pausamos eventos

                string metodoAnterior = DGV.CurrentRow.Cells[0].Value?.ToString() ?? "";
                DGV.CurrentRow.Cells[0].Value = metodoPagoActual;

                if (DGV.CurrentRow.Cells[1].Value != null)
                {
                    decimal monto = Convert.ToDecimal(DGV.CurrentRow.Cells[1].Value);
                    decimal tasaActual = decimal.TryParse(txtTasaCambio.Text, out decimal t) ? t : tasaDolar;

                    // LÓGICA DE CONVERSIÓN INTELIGENTE
                    // Si el nuevo método es Dólar y veníamos de Bolívares (monto grande)
                    if ((metodoPagoActual.Contains("$") || metodoPagoActual.Contains("Zelle")) && monto > _TotalPagarUsd * 1.5m)
                    {
                        DGV.CurrentRow.Cells[1].Value = (monto / tasaActual).ToString("N2");
                    }
                    // Si el nuevo método es Bolívares y veníamos de Dólar (monto pequeño)
                    else if (!(metodoPagoActual.Contains("$") || metodoPagoActual.Contains("Zelle")) && monto <= _TotalPagarUsd * 1.1m)
                    {
                        DGV.CurrentRow.Cells[1].Value = (monto * tasaActual).ToString("N2");
                    }
                }

                CalcularSaldos();
                DGV.CellValueChanged += DGV_CellValueChanged;
            }
        }

        private void btnpv_Click(object sender, EventArgs e) => CambiarMetodoFilaSeleccionada((BotonModerno)sender);
        private void btnpm_Click(object sender, EventArgs e) => CambiarMetodoFilaSeleccionada((BotonModerno)sender);
        private void btnebs_Click(object sender, EventArgs e) => CambiarMetodoFilaSeleccionada((BotonModerno)sender);
        private void btned_Click(object sender, EventArgs e) => CambiarMetodoFilaSeleccionada((BotonModerno)sender);
        private void btnca_Click(object sender, EventArgs e) => CambiarMetodoFilaSeleccionada((BotonModerno)sender);

        // --- BOTÓN PARA AGREGAR OTRA FILA (PAGO MIXTO) ---
        private void btnAgregarPago_Click(object sender, EventArgs e)
        {
            // Solo agregamos si todavía falta dinero
            if (Convert.ToDecimal(lblFaltanteBs.Text) > 0)
            {
                // Agregamos la diferencia faltante en la nueva fila
                DGV.Rows.Add(metodoPagoActual, lblFaltanteBs.Text);
                CalcularSaldos();
            }
        }

        private void Imprimir_Click(object sender, EventArgs e)
        {
            if (Convert.ToDecimal(lblFaltanteBs.Text) > 0)
            {
                MessageBox.Show("Aún falta dinero por cobrar.", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void Cancelar_Click(object sender, EventArgs e) => this.Close();

        private void Total_Enter(object sender, EventArgs e)
        {

        }
    }

}