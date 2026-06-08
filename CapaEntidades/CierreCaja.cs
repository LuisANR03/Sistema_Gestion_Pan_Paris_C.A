using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidades
{
    public class CierreCaja
    {
        public int IdCierre { get; set; }
        public Usuario Cajero { get; set; } // Quien hace el cierre
        public DateTime FechaCierre { get; set; }
        public decimal FondoInicial { get; set; }

        // Totales por método de pago
        public decimal TotalEfectivoUSD { get; set; }
        public decimal TotalEfectivoBs { get; set; }
        public decimal TotalPagoMovil { get; set; }
        public decimal TotalPuntoVenta { get; set; }
        public decimal TotalCashea { get; set; }
        public decimal TotalZelle { get; set; }

        public decimal TotalIGTF { get; set; }
        public decimal TotalVentas { get; set; } // Suma de todos los subtotales
        public string Observaciones { get; set; }
        public string Estado { get; set; }
    }
}
