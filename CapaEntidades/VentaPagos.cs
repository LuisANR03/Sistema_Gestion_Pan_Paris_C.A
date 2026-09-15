using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class VentaPagos
    {
        public int IdVentaPago { get; set; }
        public int IdVenta { get; set; }
        public int IdMetodoPago { get; set; }
        public decimal MontoRecibido { get; set; }
        public decimal MontoCambio { get; set; }

        public string DescripcionMetodo { get; set; }

        // Propiedad de navegación
        public MetodoPago MetodoPago { get; set; }
    }
}
