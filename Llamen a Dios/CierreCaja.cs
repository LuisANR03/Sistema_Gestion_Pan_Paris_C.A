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

        // Le ponemos CapaEntidades delante para que no se confunda con el Formulario
        private CapaEntidades.CierreCaja totalesSistema = new CapaEntidades.CierreCaja();

        public CierreCaja()
        {
            InitializeComponent();

            // ==============================================================
            // ENLAZAR EVENTOS AUTOMÁTICAMENTE
            // ==============================================================
            // Un solo manejador de eventos centralizado para todo el Arqueo Físico
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
                int idUsuarioActual = 2; // OJO: Reemplaza por tu variable global del usuario

                totalesSistema = objCN_Cierre.CalcularTotalesDelDia(idUsuarioActual);

                // Repartimos los montos directo a las cajas de texto del Sistema (Formato estándar)
                txtSistemaBs.Text = totalesSistema.TotalEfectivoBs.ToString("N2");
                txtSistemaUsd.Text = totalesSistema.TotalEfectivoUSD.ToString("N2");
                txtSistemaPagoMovil.Text = totalesSistema.TotalPagoMovil.ToString("N2");
                txtSistemaPuntoVenta.Text = totalesSistema.TotalPuntoVenta.ToString("N2");
                txtSistemaCashea.Text = totalesSistema.TotalCashea.ToString("N2");

                // Mapeamos Zelle en la caja de transferencia del sistema
                txtSistemaTransferencia.Text = totalesSistema.TotalZelle.ToString("N2");
                txtSistemaZinly.Text = "0.00";

                // Calculamos el arqueo inicial con los datos limpios
                CalcularArqueo();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar ventas del sistema: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Este es el detonante que se ejecuta cada vez que el usuario teclea en el área verde
        private void CajasFisicas_TextChanged(object sender, EventArgs e)
        {
            CalcularArqueo();
        }

        // ==============================================================
        // MÉTODO: CALCULAR ARQUEO (Matemática y Estética Corregidas)
        // ==============================================================
        private void CalcularArqueo()
        {
            try
            {
                decimal tasaBCV = 36.50m; // Recuerda cambiarlo por la variable global de tu sistema
                if (tasaBCV <= 0) tasaBCV = 1m;

                // Función local ultra segura para leer TextBox (Soporta comas y puntos de forma universal)
                decimal LeerMonto(TextBoxModerno textBox)
                {
                    if (string.IsNullOrWhiteSpace(textBox.Text)) return 0m;

                    string textoLimpio = textBox.Text.Trim().Replace(".", ""); // Quitamos separadores de miles
                    textoLimpio = textoLimpio.Replace(",", ".");             // Forzamos el punto decimal

                    if (decimal.TryParse(textoLimpio, System.Globalization.NumberStyles.Any, System.Globalization.CultureInfo.InvariantCulture, out decimal resultado))
                    {
                        return resultado;
                    }
                    return 0m;
                }

                // --- 1. SUMAR COLUMNA SISTEMA (Moneda por Moneda) ---
                // Solo lo que es ESTRICTAMENTE Bolívares (Bs)
                decimal sisBs = LeerMonto(txtSistemaBs) +
                                LeerMonto(txtSistemaPagoMovil) +
                                LeerMonto(txtSistemaPuntoVenta);

                // Solo lo que es ESTRICTAMENTE Dólares (USD / Pasarelas)
                decimal sisUsd = LeerMonto(txtSistemaUsd) +
                                 LeerMonto(txtSistemaTransferencia) + // Zelle es USD
                                 LeerMonto(txtSistemaZinly) +         // Zinly es USD
                                 LeerMonto(txtSistemaCashea);         // Cashea es USD

                // Convertimos la bolsa de Bs a Dólares y sumamos los dólares puros
                decimal totalSistema = (sisBs / tasaBCV) + sisUsd;
                txtTotalSis.Text = "$ " + totalSistema.ToString("N2");

                // --- 2. SUMAR COLUMNA FÍSICA (Moneda por Moneda) ---
                // Solo lo que el cajero contó en Bolívares (Bs)
                decimal fisBs = LeerMonto(txtFisicoBs) +
                                LeerMonto(txtFisicoPagoMovil) +
                                LeerMonto(txtFisicoPuntoVenta);

                // Solo lo que el cajero contó en Dólares (USD / Pasarelas)
                decimal fisUsd = LeerMonto(txtFisicoUsd) +
                                 LeerMonto(txtFisicoTransferencia) +
                                 LeerMonto(txtFisicoZinly) +
                                 LeerMonto(txtFisicoCashea);

                // Convertimos el total del conteo físico a Dólares
                decimal totalFisico = (fisBs / tasaBCV) + fisUsd;
                txtTotaldec.Text = "$ " + totalFisico.ToString("N2");

                // --- 3. CALCULAR DIFERENCIA, ESTÉTICA Y COLORES ---
                decimal diferencia = totalFisico - totalSistema;

                // Margen de tolerancia mínimo para variaciones infinitesimales por redondeo
                if (Math.Abs(diferencia) < 0.01m)
                {
                    txtcuadre.Text = "$ 0.00";
                    txtcuadre.ForeColor = Color.MediumSeaGreen;
                    lblcuadre.Text = "CAJA CUADRADA EXACTA";
                    lblcuadre.ForeColor = Color.MediumSeaGreen;
                }
                else if (diferencia > 0)
                {
                    txtcuadre.Text = "+ $ " + diferencia.ToString("N2");
                    txtcuadre.ForeColor = Color.Goldenrod; // Color Oro / Naranja para Sobrantes
                    lblcuadre.Text = "SOBRANTE EN CAJA";
                    lblcuadre.ForeColor = Color.Goldenrod;
                }
                else
                {
                    txtcuadre.Text = "- $ " + Math.Abs(diferencia).ToString("N2");
                    txtcuadre.ForeColor = Color.Crimson; // Color Carmesí / Rojo para Faltantes
                    lblcuadre.Text = "FALTANTE EN CAJA";
                    lblcuadre.ForeColor = Color.Crimson;
                }
            }
            catch
            {
                // Previene excepciones visuales mientras el operador limpia o edita los campos
            }
        }

        // ==============================================================
        // EVENTO: GUARDAR CIERRE DEFINITIVO
        // ==============================================================
        private void btnGuardarCierre_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("¿Está seguro de que desea realizar el cierre de caja definitivo? Esto finalizará su turno.",
                                                "Confirmar Cierre", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.No) return;

            CapaEntidades.CierreCaja objCierreFinal = new CapaEntidades.CierreCaja();

            objCierreFinal.Cajero = new Usuario() { IdUsuario = 2 }; // Cambiar por tu ID dinámico
            objCierreFinal.FondoInicial = 0.00m;

            objCierreFinal.TotalEfectivoUSD = totalesSistema.TotalEfectivoUSD;
            objCierreFinal.TotalEfectivoBs = totalesSistema.TotalEfectivoBs;
            objCierreFinal.TotalPagoMovil = totalesSistema.TotalPagoMovil;
            objCierreFinal.TotalPuntoVenta = totalesSistema.TotalPuntoVenta;
            objCierreFinal.TotalCashea = totalesSistema.TotalCashea;
            objCierreFinal.TotalZelle = totalesSistema.TotalZelle;
            objCierreFinal.TotalIGTF = totalesSistema.TotalIGTF;
            objCierreFinal.TotalVentas = totalesSistema.TotalVentas;

            objCierreFinal.Observaciones = "Cierre efectuado. Cuadre: " + txtcuadre.Text + " - " + lblcuadre.Text;

            string mensaje = string.Empty;

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

        private void btnProcesarCierre_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("¿Está seguro de que desea realizar el cierre de caja definitivo? Esto finalizará su turno.",
                                            "Confirmar Cierre", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

    if (result == DialogResult.No) return;

    try
    {
        // Función local rápida para limpiar el formato "$ 1.234,56" antes de mandar a la BDD
        decimal LimpiarMontoDecimal(string texto)
        {
            if (string.IsNullOrWhiteSpace(texto)) return 0m;
            string limpio = texto.Replace("$", "").Replace("+", "").Replace("-", "").Trim();
            limpio = limpio.Replace(".", ""); 
            limpio = limpio.Replace(",", "."); 
            
            if (decimal.TryParse(limpio, System.Globalization.NumberStyles.Any, System.Globalization.CultureInfo.InvariantCulture, out decimal res))
                return res;
            return 0m;
        }

        CapaEntidades.CierreCaja objCierreFinal = new CapaEntidades.CierreCaja();

        // 1. Datos de Control
        objCierreFinal.Cajero = new Usuario() { IdUsuario = 2 }; // Cambiar por tu ID dinámico
        objCierreFinal.FondoInicial = 0.00m;
        // NOTA: Si en tu entidad tienes una propiedad para la Tasa, agrégala aquí (ej. objCierreFinal.TasaCambio = 36.50m;)

        // 2. Lo que calculó el SISTEMA (Caja Azul)
        objCierreFinal.TotalEfectivoUSD = totalesSistema.TotalEfectivoUSD;
        objCierreFinal.TotalEfectivoBs = totalesSistema.TotalEfectivoBs;
        objCierreFinal.TotalPagoMovil = totalesSistema.TotalPagoMovil;
        objCierreFinal.TotalPuntoVenta = totalesSistema.TotalPuntoVenta;
        objCierreFinal.TotalCashea = totalesSistema.TotalCashea;
        objCierreFinal.TotalZelle = totalesSistema.TotalZelle;
        objCierreFinal.TotalIGTF = totalesSistema.TotalIGTF;
        objCierreFinal.TotalVentas = totalesSistema.TotalVentas;

        // 3. Lo que contó el CAJERO físicamente (Caja Verde)
        // OJO: Si tu clase CapaEntidades.CierreCaja no tiene estas variables creadas, 
        // vas a tener que ir a crearles los { get; set; } en la CapaEntidades.
        objCierreFinal.FisicoEfectivoBs = LimpiarMontoDecimal(txtFisicoBs.Text);
        objCierreFinal.FisicoEfectivoUSD = LimpiarMontoDecimal(txtFisicoUsd.Text);
        objCierreFinal.FisicoPagoMovil = LimpiarMontoDecimal(txtFisicoPagoMovil.Text);
        objCierreFinal.FisicoPuntoVenta = LimpiarMontoDecimal(txtFisicoPuntoVenta.Text);
        objCierreFinal.FisicoTransferencia = LimpiarMontoDecimal(txtFisicoTransferencia.Text);
        objCierreFinal.FisicoZinly = LimpiarMontoDecimal(txtFisicoZinly.Text);
        objCierreFinal.FisicoCashea = LimpiarMontoDecimal(txtFisicoCashea.Text);

        // 4. Totales Finales
        objCierreFinal.TotalSistemaCalculado = LimpiarMontoDecimal(txtTotalSis.Text);
        objCierreFinal.TotalFisicoDeclarado = LimpiarMontoDecimal(txtTotaldec.Text);
        objCierreFinal.DiferenciaCuadre = LimpiarMontoDecimal(txtcuadre.Text);
        
        if (txtcuadre.Text.Contains("-")) 
        {
            objCierreFinal.DiferenciaCuadre = -objCierreFinal.DiferenciaCuadre;
        }

        objCierreFinal.Observaciones = "Cierre efectuado. Cuadre: " + txtcuadre.Text + " - " + lblcuadre.Text;

        // 5. Envío a la Capa de Negocio
        string mensaje = string.Empty;
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
    catch (Exception ex)
    {
        MessageBox.Show("Error de formato antes de guardar: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
    }
        }

        private void txtFisicoBs__TextChanged(object sender, EventArgs e)
        {
            CalcularArqueo();
        }

        private void txtFisicoUsd__TextChanged(object sender, EventArgs e)
        {
            CalcularArqueo();
        }

        private void txtFisicoPagoMovil__TextChanged(object sender, EventArgs e)
        {
            CalcularArqueo();
        }

        private void txtFisicoTransferencia__TextChanged(object sender, EventArgs e)
        {
            CalcularArqueo();   

        } 

        private void txtFisicoPuntoVenta__TextChanged(object sender, EventArgs e)
        {
            CalcularArqueo();
        }

        private void txtFisicoZinly__TextChanged(object sender, EventArgs e)
        {
            CalcularArqueo();
        }

        private void txtFisicoCashea__TextChanged(object sender, EventArgs e)
        {
            CalcularArqueo();
        }
    }
    
}