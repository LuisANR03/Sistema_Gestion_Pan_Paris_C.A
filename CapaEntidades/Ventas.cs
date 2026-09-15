using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Ventas
    {
        public int IdVenta { get; set; }
        public int IdUsuario { get; set; }
        public int IdVendedor { get; set; }
        public int IdCliente { get; set; }
        public string TipoDocumento { get; set; }
        public string NumeroDocumento { get; set; }
        public decimal SubTotal { get; set; }
        public decimal Impuesto { get; set; }
        public decimal MontoTotal { get; set; }
        public DateTime FechaVenta { get; set; }

        public string NumeroControl { get; set; }

        // Propiedades de navegación
        public Usuario Usuario { get; set; }
        public Vendedor Vendedor { get; set; }
        public Cliente Cliente { get; set; }
        public List<DetalleVenta> Detalles { get; set; }
        public List<VentaPagos> Pagos { get; set; }
    }
}
