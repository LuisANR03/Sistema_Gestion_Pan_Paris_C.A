using Entidades;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Llamen_a_Dios.Modales
{
    public partial class mdCobrar : Form
    {
        public decimal _TotalPagarUsd { get; set; }
        public decimal _TotalPagarBs { get; set; }
        private string metodoPagoActual = "Punto de Venta";
        private decimal tasaDolar = 620.50m; // Ajusta a tu tasa real o léela de tu sistema

        // ====================================================================
        // LISTA DE PAGOS A ENVIAR AL FORMULARIO PRINCIPAL
        // ====================================================================
        public List<VentaPagos> ListaPagosRealizados { get; set; } = new List<VentaPagos>();

        public mdCobrar()
        {
            InitializeComponent();
        }

        private void mdCobrar_Load(object sender, EventArgs e)
        {
            txtTotal.Text = _TotalPagarUsd.ToString("N2");
            txtTasaCambio.Text = tasaDolar.ToString("N2");

            // Inicializamos el label del IGTF en 0
            if (lblTotalIGTF != null) lblTotalIGTF.Text = "IGTF: $0.00";

            DGV.Rows.Clear();
            DGV.Rows.Add("Punto de Venta", _TotalPagarBs.ToString("N2"), "BS");

            ActivarBotonPago(btnpv);
            CalcularSaldos();
            ConfigurarAyudaVisual();
        }

        // ====================================================================
        // LÓGICA DE CÁLCULO (IGTF INTEGRADO)
        // ====================================================================
        private void CalcularSaldos()
        {
            decimal totalPagadoEnBs = 0;
            decimal totalSujetoAIGTFUsd = 0; // Acumulador de divisas para el IGTF
            decimal tasaActual = decimal.TryParse(txtTasaCambio.Text, out decimal t) ? t : tasaDolar;

            foreach (DataGridViewRow row in DGV.Rows)
            {
                if (row.Cells[1].Value == null || row.Cells[2].Value == null) continue;

                decimal monto = Convert.ToDecimal(row.Cells[1].Value);
                string metodo = row.Cells[0].Value.ToString().ToLower();
                string moneda = row.Cells[2].Value.ToString().ToUpper();

                // Verificamos si el pago es en dólares
                bool esDivisa = moneda == "USD" || metodo.Contains("usd") || metodo.Contains("$") || metodo.Contains("zelle");

                if (esDivisa)
                {
                    totalPagadoEnBs += (monto * tasaActual);
                    totalSujetoAIGTFUsd += monto; // Acumulamos el monto en divisa para sacarle el 3%
                }
                else
                {
                    totalPagadoEnBs += monto;
                }
            }

            // --- CÁLCULO DEL IGTF (3%) ---
            decimal montoIGTFUsd = totalSujetoAIGTFUsd * 0.03m;
            decimal montoIGTFBs = montoIGTFUsd * tasaActual;

            // --- NUEVOS TOTALES CON IMPUESTO INCLUIDO ---
            decimal nuevoTotalPagarUsd = _TotalPagarUsd + montoIGTFUsd;
            decimal nuevoTotalPagarBs = _TotalPagarBs + montoIGTFBs;

            // --- ACTUALIZAR LA ETIQUETA DINÁMICA DEL IGTF ---
            if (lblTotalIGTF != null)
            {
                if (montoIGTFUsd > 0)
                {
                    lblTotalIGTF.Text = $"Total + IGTF (3%): ${nuevoTotalPagarUsd:N2} (Impuesto: ${montoIGTFUsd:N2})";
                    lblTotalIGTF.ForeColor = Color.Red; // Para llamar la atención del cajero
                }
                else
                {
                    lblTotalIGTF.Text = "IGTF: $0.00";
                    lblTotalIGTF.ForeColor = Color.Black;
                }
            }

            // --- CÁLCULO DEL FALTANTE O VUELTO BASADO EN EL NUEVO TOTAL ---
            decimal diferenciaBs = nuevoTotalPagarBs - totalPagadoEnBs;

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
            if (e.RowIndex >= 0 && e.ColumnIndex == 1)
            {
                DGV.CellValueChanged -= DGV_CellValueChanged;

                CalcularSaldos();
                decimal faltante = decimal.TryParse(lblFaltanteBs.Text, out decimal f) ? f : 0;

                if (faltante > 0.05m)
                {
                    if (e.RowIndex == DGV.Rows.Count - 1)
                    {
                        DGV.Rows.Add("Punto de Venta", faltante.ToString("N2"), "BS");
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
                btn.BackColor = Color.FromArgb(196, 158, 87);
                btn.GrosorBorde = 0;
            }
            botonActivo.BackColor = Color.FromArgb(166, 114, 13);
            botonActivo.ColorBorde = Color.White;
            botonActivo.GrosorBorde = 2;
            metodoPagoActual = botonActivo.Text;
        }

        private void CambiarMetodoFilaSeleccionada(BotonModerno boton)
        {
            ActivarBotonPago(boton);

            if (DGV.CurrentRow != null)
            {
                // Apagamos el evento temporalmente para que no haya un bucle infinito
                DGV.CellValueChanged -= DGV_CellValueChanged;

                DGV.CurrentRow.Cells[0].Value = metodoPagoActual;

                string metodoActualMinuscula = metodoPagoActual.ToLower();

                // Identificamos desde antes si el nuevo método es de divisas
                bool nuevoMetodoEsUSD = metodoActualMinuscula.Contains("usd") ||
                                        metodoActualMinuscula.Contains("$") ||
                                        metodoActualMinuscula.Contains("zelle") ||
                                        metodoActualMinuscula.Contains("divisa");

                if (DGV.CurrentRow.Cells[1].Value != null && DGV.CurrentRow.Cells[2].Value != null)
                {
                    decimal montoActual = Convert.ToDecimal(DGV.CurrentRow.Cells[1].Value);
                    string monedaActual = DGV.CurrentRow.Cells[2].Value.ToString();
                    decimal tasaActual = decimal.TryParse(txtTasaCambio.Text, out decimal t) ? t : tasaDolar;

                    if (monedaActual == "BS" && nuevoMetodoEsUSD)
                    {
                        DGV.CurrentRow.Cells[1].Value = (montoActual / tasaActual).ToString("N2");
                        DGV.CurrentRow.Cells[2].Value = "USD";
                    }
                    else if (monedaActual == "USD" && !nuevoMetodoEsUSD)
                    {
                        DGV.CurrentRow.Cells[1].Value = (montoActual * tasaActual).ToString("N2");
                        DGV.CurrentRow.Cells[2].Value = "BS";
                    }
                }

                // 1. Calculamos saldos para que el sistema aplique el 3% de IGTF y actualice el label
                CalcularSaldos();

                // 2. NUEVA LÓGICA: Si es Dólar y quedó un faltante (por el IGTF), agregamos la fila
                if (nuevoMetodoEsUSD)
                {
                    decimal faltante = decimal.TryParse(lblFaltanteBs.Text, out decimal f) ? f : 0;

                    if (faltante > 0.05m) // Si hay dinero faltante (el IGTF)
                    {
                        // Añadimos el restante automáticamente. 
                        // Puedes cambiar "Pago Móvil" por "Punto de Venta" o "Efectivo BS" si prefieres otro por defecto.
                        DGV.Rows.Add("Pago Móvil", faltante.ToString("N2"), "BS");

                        // 3. Volvemos a calcular para que el faltante en pantalla vuelva a 0.00
                        CalcularSaldos();
                    }
                }

                // Volvemos a encender el evento del DataGridView
                DGV.CellValueChanged += DGV_CellValueChanged;
            }
        }

        private void btnpv_Click(object sender, EventArgs e) => CambiarMetodoFilaSeleccionada((BotonModerno)sender);
        private void btnpm_Click(object sender, EventArgs e) => CambiarMetodoFilaSeleccionada((BotonModerno)sender);
        private void btnebs_Click(object sender, EventArgs e) => CambiarMetodoFilaSeleccionada((BotonModerno)sender);
        private void btned_Click(object sender, EventArgs e) => CambiarMetodoFilaSeleccionada((BotonModerno)sender);
        private void btnca_Click(object sender, EventArgs e) => CambiarMetodoFilaSeleccionada((BotonModerno)sender);

        private void btnAgregarPago_Click(object sender, EventArgs e)
        {
            if (Convert.ToDecimal(lblFaltanteBs.Text) > 0)
            {
                DGV.Rows.Add(metodoPagoActual, lblFaltanteBs.Text, "BS");
                CalcularSaldos();
            }
        }

        // ====================================================================
        // CUANDO EL CAJERO LE DA A IMPRIMIR/COBRAR
        // ====================================================================
        private void Imprimir_Click(object sender, EventArgs e)
        {
            // Validamos que se haya cobrado todo, incluyendo el IGTF
            if (Convert.ToDecimal(lblFaltanteBs.Text) > 0)
            {
                MessageBox.Show("Aún falta dinero por cobrar.", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            ListaPagosRealizados.Clear();
            decimal vueltoRestante = Convert.ToDecimal(lblVueltoBs.Text);

            foreach (DataGridViewRow row in DGV.Rows)
            {
                if (row.Cells[1].Value == null) continue;

                string nombreMetodo = row.Cells[0].Value.ToString().ToLower();
                decimal monto = Convert.ToDecimal(row.Cells[1].Value);

                int idMetodo = 1;

                // Mapeo según tu BD
                if (nombreMetodo.Contains("punto")) idMetodo = 4;
                else if (nombreMetodo.Contains("móvil") || nombreMetodo.Contains("movil")) idMetodo = 3;
                else if (nombreMetodo.Contains("bs") || nombreMetodo.Contains("efectivo bs")) idMetodo = 2;
                else if (nombreMetodo.Contains("cashea")) idMetodo = 5;
                else if (nombreMetodo.Contains("zelle") || nombreMetodo.Contains("transferencia")) idMetodo = 6;

                decimal cambioParaEsteMetodo = 0;

                if ((idMetodo == 1 || idMetodo == 2) && vueltoRestante > 0)
                {
                    cambioParaEsteMetodo = vueltoRestante;
                    vueltoRestante = 0;
                }

                ListaPagosRealizados.Add(new VentaPagos
                {
                    IdMetodoPago = idMetodo,
                    MontoRecibido = monto,
                    MontoCambio = cambioParaEsteMetodo
                });
            }

            // Ya no enviamos el Número de Control desde aquí, lo generará el form padre.

            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        // ==============================================================
        // AYUDA VISUAL (ESTILO GLOBO) PARA EL MODAL DE COBRO
        // ==============================================================
        private void ConfigurarAyudaVisual()
        {
            ToolTip toolTipCobro = new ToolTip();

            // Estilo Globo idéntico al resto del sistema
            toolTipCobro.IsBalloon = true;
            toolTipCobro.ToolTipIcon = ToolTipIcon.Info;
            toolTipCobro.ToolTipTitle = "Módulo de Cobro";

            // Configuración de tiempos
            toolTipCobro.AutoPopDelay = 7000; // Un poco más de tiempo para que lean bien
            toolTipCobro.InitialDelay = 400;
            toolTipCobro.ReshowDelay = 300;
            toolTipCobro.ShowAlways = true;

            // --- TOOLTIPS PARA LOS MÉTODOS DE PAGO ---
            toolTipCobro.SetToolTip(this.btnpv, "Cambia el método de pago de la fila seleccionada a Punto de Venta (BS).");
            toolTipCobro.SetToolTip(this.btnpm, "Cambia el método de pago de la fila seleccionada a Pago Móvil (BS).");
            toolTipCobro.SetToolTip(this.btnebs, "Cambia el método de pago a Efectivo (BS).");
            toolTipCobro.SetToolTip(this.btned, "Cambia a Efectivo Divisa (USD). ¡Atención! Esto aplicará automáticamente el 3% de IGTF.");
            toolTipCobro.SetToolTip(this.btnca, "Selecciona Cashea como método de pago.");

            // --- TOOLTIPS PARA TABLA Y CONTROLES ---
            toolTipCobro.SetToolTip(this.DGV, "Puedes editar directamente el monto en la celda para hacer pagos mixtos.");

            // Verificamos si los botones existen antes de asignarles el ToolTip
            if (this.btnAgregarPago != null)
            {
                toolTipCobro.SetToolTip(this.btnAgregarPago, "Agrega una nueva fila con el monto exacto que falta por pagar.");
            }

            if (this.txtTasaCambio != null)
            {
                toolTipCobro.SetToolTip(this.txtTasaCambio, "Tasa de cambio del día utilizada para los cálculos.");
            }

            // --- TOOLTIPS PARA ACCIONES FINALES ---
            // Asegúrate de que tus controles en el diseño se llamen 'Imprimir' y 'Cancelar'
            if (this.Controls.ContainsKey("Imprimir"))
            {
                toolTipCobro.SetToolTip(this.Controls["Imprimir"], "Procesa el pago y registra la venta. Solo disponible si el faltante es 0.00.");
            }

            if (this.Controls.ContainsKey("Cancelar"))
            {
                toolTipCobro.SetToolTip(this.Controls["Cancelar"], "Cancela la operación y regresa al punto de venta.");
            }
        }

        private void Cancelar_Click(object sender, EventArgs e) => this.Close();

        private void Total_Enter(object sender, EventArgs e)
        {
        }
    }
}