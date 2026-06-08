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
using CapaEntidades;

namespace Llamen_a_Dios
{
    public partial class CierreCaja : Form
    {
        // 1. Instanciamos nuestra capa de negocio específica
        private CN_CierreCaja objCN_Cierre = new CN_CierreCaja();

        // CORRECCIÓN: Le ponemos CapaEntidades delante para que no se confunda con el Formulario
        private CapaEntidades.CierreCaja totalesSistema = new CapaEntidades.CierreCaja();

        public CierreCaja()
        {
            InitializeComponent();

            // ==============================================================
            // ENLAZAR EVENTOS AUTOMÁTICAMENTE
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
            CargarTotalesDelSistema();
        }

        // ==============================================================
        // MÉTODO: CARGAR TOTALES DESDE NUESTRA ENTIDAD
        // ==============================================================
        private void CargarTotalesDelSistema()
        {
            try
            {
                // OJO: Reemplaza '1' por tu variable global del usuario logueado en tu sistema.
                int idUsuarioActual = 2;

                // Traemos el objeto con los totales correspondientes al usuario
                totalesSistema = objCN_Cierre.CalcularTotalesDelDia(idUsuarioActual);

                // Repartimos los montos directo a las cajas de texto
                txtSistemaBs.Text = totalesSistema.TotalEfectivoBs.ToString("N2");
                txtSistemaUsd.Text = totalesSistema.TotalEfectivoUSD.ToString("N2");
                txtSistemaPagoMovil.Text = totalesSistema.TotalPagoMovil.ToString("N2");
                txtSistemaPuntoVenta.Text = totalesSistema.TotalPuntoVenta.ToString("N2");
                txtSistemaCashea.Text = totalesSistema.TotalCashea.ToString("N2");

                // Mapeamos Zelle en la caja de transferencia del sistema
                txtSistemaTransferencia.Text = totalesSistema.TotalZelle.ToString("N2");
                txtSistemaZinly.Text = "0.00";

                // Calcular el arqueo matemático por primera vez
                CalcularArqueo();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar ventas del sistema: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CajasFisicas_TextChanged(object sender, EventArgs e)
        {
            CalcularArqueo();
        }

        // ==============================================================
        // MÉTODO: CALCULAR ARQUEO (Tus matemáticas intactas)
        // ==============================================================
        private void CalcularArqueo()
        {
            try
            {
                decimal tasaBCV = 36.50m; // Recuerda cambiarlo por la variable de tu sistema
                if (tasaBCV <= 0) tasaBCV = 1m;

                decimal LeerMonto(TextBoxModerno textBox)
                {
                    if (string.IsNullOrWhiteSpace(textBox.Text)) return 0m;
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
                // Ignorar error momentáneo mientras el usuario tipea
            }
        }

        // ==============================================================
        // EVENTO: GUARDAR CIERRE DEFINITIVO (CON EXPLICITACIÓN DE ENTIDAD)
        // ==============================================================
        private void btnGuardarCierre_Click(object sender, EventArgs e)
        {
            // Confirmación para evitar cierres accidentales
            DialogResult result = MessageBox.Show("¿Está seguro de que desea realizar el cierre de caja definitivo? Esto finalizará su turno.",
                                                "Confirmar Cierre", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.No) return;

            // CORRECCIÓN CLAVE: Agregamos 'CapaEntidades.' para que sepa qué objeto instanciar
            CapaEntidades.CierreCaja objCierreFinal = new CapaEntidades.CierreCaja();

            // Asignamos el objeto de usuario (Cajero) mapeado en la CapaEntidades
            objCierreFinal.Cajero = new Usuario() { IdUsuario = 2 };

            // Por defecto iniciamos con 0.00 de fondo o lo vinculas a una caja si la tienes
            objCierreFinal.FondoInicial = 0.00m;

            // Pasamos los totales del sistema que recuperamos al cargar la pantalla
            objCierreFinal.TotalEfectivoUSD = totalesSistema.TotalEfectivoUSD;
            objCierreFinal.TotalEfectivoBs = totalesSistema.TotalEfectivoBs;
            objCierreFinal.TotalPagoMovil = totalesSistema.TotalPagoMovil;
            objCierreFinal.TotalPuntoVenta = totalesSistema.TotalPuntoVenta;
            objCierreFinal.TotalCashea = totalesSistema.TotalCashea;
            objCierreFinal.TotalZelle = totalesSistema.TotalZelle;
            objCierreFinal.TotalIGTF = totalesSistema.TotalIGTF;
            objCierreFinal.TotalVentas = totalesSistema.TotalVentas;

            // Agregamos las notas de cuadre automáticamente basadas en tus etiquetas dinámicas
            objCierreFinal.Observaciones = "Cierre efectuado. Cuadre: " + txtcuadre.Text + " - " + lblcuadre.Text;

            string mensaje = string.Empty;

            // Invocamos la lógica de negocio para procesar el registro en la BD
            bool exito = objCN_Cierre.RegistrarCierre(objCierreFinal, out mensaje);

            if (exito)
            {
                MessageBox.Show("¡Cierre de caja registrado exitosamente!", "Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            else
            {
                MessageBox.Show("No se pudo guardar el cierre: " + mensaje, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}