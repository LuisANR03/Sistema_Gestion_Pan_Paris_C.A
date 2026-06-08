using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CapaNegocios; // Tu capa de negocio

namespace Llamen_a_Dios
{
    public partial class CierreCaja : Form
    {
        // Instanciamos la capa de negocio
        private CN_Venta objCN_Venta = new CN_Venta();

        public CierreCaja()
        {
            InitializeComponent();

            // ==============================================================
            // ENLAZAR EVENTOS AUTOMÁTICAMENTE
            // Esto hace que al teclear en cualquier caja física, se calcule todo
            // ==============================================================
            txtFisicoBs.TextChanged += new EventHandler(CajasFisicas_TextChanged);
            txtFisicoUsd.TextChanged += new EventHandler(CajasFisicas_TextChanged);
            txtFisicoPagoMovil.TextChanged += new EventHandler(CajasFisicas_TextChanged);
            txtFisicoTransferencia.TextChanged += new EventHandler(CajasFisicas_TextChanged);
            txtFisicoPuntoVenta.TextChanged += new EventHandler(CajasFisicas_TextChanged);
            txtFisicoZinly.TextChanged += new EventHandler(CajasFisicas_TextChanged);
            txtFisicoCashea.TextChanged += new EventHandler(CajasFisicas_TextChanged);
        }

        private void CierreCaja_Load(object sender, EventArgs e)
        {
            // Al abrir la ventana, cargamos lo que dice el sistema
            CargarTotalesDelSistema();
        }

        // ==============================================================
        // MÉTODO: CARGAR TOTALES DESDE LA BASE DE DATOS
        // ==============================================================
        private void CargarTotalesDelSistema()
        {
            // 1. Limpiar cajitas por si acaso
            txtSistemaBs.Text = "0.00";
            txtSistemaUsd.Text = "0.00";
            txtSistemaPagoMovil.Text = "0.00";
            txtSistemaTransferencia.Text = "0.00";
            txtSistemaPuntoVenta.Text = "0.00";
            txtSistemaZinly.Text = "0.00";
            txtSistemaCashea.Text = "0.00";

            try
            {
                // 2. Traer datos de la BD
                DataTable dtTotales = objCN_Venta.ObtenerTotalesCierreCaja();

                // 3. Repartir datos
                foreach (DataRow fila in dtTotales.Rows)
                {
                    string metodo = fila["MetodoPago"].ToString().ToUpper();
                    decimal total = Convert.ToDecimal(fila["TotalVendido"]);

                    switch (metodo)
                    {
                        case "EFECTIVO BS":
                            txtSistemaBs.Text = total.ToString("N2");
                            break;
                        case "EFECTIVO USD":
                            txtSistemaUsd.Text = total.ToString("N2");
                            break;
                        case "PAGO MOVIL":
                        case "PAGO MÓVIL":
                            txtSistemaPagoMovil.Text = total.ToString("N2");
                            break;
                        case "TRANSFERENCIA":
                        case "ZELLE": // En caso de que uses Zelle como transferencia
                            txtSistemaTransferencia.Text = total.ToString("N2");
                            break;
                        case "PUNTO DE VENTA":
                        case "PUNTO":
                            txtSistemaPuntoVenta.Text = total.ToString("N2");
                            break;
                        case "ZINLY":
                            txtSistemaZinly.Text = total.ToString("N2");
                            break;
                        case "CASHEA":
                            txtSistemaCashea.Text = total.ToString("N2");
                            break;
                    }
                }

                // 4. Calcular el arqueo por primera vez para sumar el Total del Sistema
                CalcularArqueo();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar ventas del sistema: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ==============================================================
        // EVENTO QUE SE DISPARA AL ESCRIBIR EN LAS CAJAS FÍSICAS
        // ==============================================================
        private void CajasFisicas_TextChanged(object sender, EventArgs e)
        {
            CalcularArqueo();
        }

        // ==============================================================
        // MÉTODO: CALCULAR ARQUEO (MATEMÁTICAS)
        // ==============================================================
        private void CalcularArqueo()
        {
            try
            {
                // --------------------------------------------------------
                // ¡IMPORTANTE! Aquí defino la tasa BCV manualmente. 
                // Debes reemplazar este 36.50m por la variable de tu sistema 
                // que guarda la tasa de cambio real de ese día.
                // --------------------------------------------------------
                decimal tasaBCV = 36.50m;
                if (tasaBCV <= 0) tasaBCV = 1m; // Evitar división por cero

                // Función interna para leer montos seguros
                // Solo tienes que agregarle "Moderno" al tipo de dato aquí:
                decimal LeerMonto(TextBoxModerno textBox)
                {
                    if (string.IsNullOrWhiteSpace(textBox.Text)) return 0m;

                    // Intenta convertir, si el usuario pone una letra por error devuelve 0
                    if (decimal.TryParse(textBox.Text, out decimal resultado)) return resultado;

                    return 0m;
                }

                // --- 1. SUMAR COLUMNA SISTEMA ---
                decimal sisBs = LeerMonto(txtSistemaBs) + LeerMonto(txtSistemaPagoMovil) +
                                LeerMonto(txtSistemaPuntoVenta) + LeerMonto(txtSistemaTransferencia);

                decimal sisUsd = LeerMonto(txtSistemaUsd) + LeerMonto(txtSistemaZinly) +
                                 LeerMonto(txtSistemaCashea);

                decimal totalSistema = (sisBs / tasaBCV) + sisUsd;
                txtTotalSis.Text = "$ " + totalSistema.ToString("N2");

                // --- 2. SUMAR COLUMNA FÍSICA ---
                decimal fisBs = LeerMonto(txtFisicoBs) + LeerMonto(txtFisicoPagoMovil) +
                                LeerMonto(txtFisicoPuntoVenta) + LeerMonto(txtFisicoTransferencia);

                decimal fisUsd = LeerMonto(txtFisicoUsd) + LeerMonto(txtFisicoZinly) +
                                 LeerMonto(txtFisicoCashea);

                decimal totalFisico = (fisBs / tasaBCV) + fisUsd;
                txtTotaldec.Text = "$ " + totalFisico.ToString("N2");

                // --- 3. CALCULAR DIFERENCIA ---
                decimal diferencia = totalFisico - totalSistema;

                if (diferencia == 0)
                {
                    txtcuadre.Text = "$ 0.00";
                    lblcuadre.Text = "CAJA CUADRADA EXACTA";
                    lblcuadre.ForeColor = Color.MediumSeaGreen;
                }
                else if (diferencia > 0)
                {
                    txtcuadre.Text = "+ $ " + diferencia.ToString("N2");
                    lblcuadre.Text = "SOBRANTE EN CAJA";
                    lblcuadre.ForeColor = Color.Goldenrod;
                }
                else
                {
                    txtcuadre.Text = "- $ " + Math.Abs(diferencia).ToString("N2");
                    lblcuadre.Text = "FALTANTE EN CAJA";
                    lblcuadre.ForeColor = Color.Crimson;
                }
            }
            catch
            {
                // Si el usuario borra todo o escribe un símbolo, ignoramos el cálculo momentáneamente
            }
        }
    }
}