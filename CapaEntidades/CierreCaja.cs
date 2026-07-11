using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidades
{
    public class CierreCaja
    {
        // ==========================================
        // DATOS GENERALES
        // ==========================================
        public int IdCierre { get; set; }
        public Usuario Cajero { get; set; } // Quien hace el cierre
        public DateTime FechaCierre { get; set; }
        public decimal FondoInicial { get; set; }
        public decimal TasaCambio { get; set; } // IMPORTANTE: Guardar la tasa del día

        // ==========================================
        // LO QUE CALCULÓ EL SISTEMA (CAJA AZUL)
        // ==========================================
        public decimal TotalEfectivoUSD { get; set; }
        public decimal TotalEfectivoBs { get; set; }
        public decimal TotalPagoMovil { get; set; }
        public decimal TotalPuntoVenta { get; set; }
        public decimal TotalCashea { get; set; }
        public decimal TotalZelle { get; set; }
        public decimal TotalZinly { get; set; } // Agregado por si a futuro el sistema lo suma

        public decimal TotalIGTF { get; set; }
        public decimal TotalVentas { get; set; } // Suma de todos los subtotales

        // ==========================================
        // LO QUE CONTÓ EL CAJERO (CAJA VERDE)
        // ==========================================
        public decimal FisicoEfectivoUSD { get; set; }
        public decimal FisicoEfectivoBs { get; set; }
        public decimal FisicoPagoMovil { get; set; }
        public decimal FisicoPuntoVenta { get; set; }
        public decimal FisicoTransferencia { get; set; } // Para Zelle físico
        public decimal FisicoZinly { get; set; }
        public decimal FisicoCashea { get; set; }

        // ==========================================
        // TOTALES FINALES Y CUADRE
        // ==========================================
        public decimal TotalSistemaCalculado { get; set; }
        public decimal TotalFisicoDeclarado { get; set; }
        public decimal DiferenciaCuadre { get; set; } // Faltante (-) o Sobrante (+)

        // ==========================================
        // RENTABILIDAD DEL DÍA (NUEVO)
        // ==========================================
        public decimal CostoTotalProduccion { get; set; }
        public decimal GananciaNeta { get; set; }

        public string Observaciones { get; set; }
        public string Estado { get; set; }
    }
}