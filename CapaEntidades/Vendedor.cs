using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Vendedor
    {
        public int IdVendedor { get; set; }
        public int IdUsuario { get; set; }
        public string NombreCompleto { get; set; }
        public string Cedula { get; set; }
        public decimal MetaVentas { get; set; }
        public decimal PorcentajeComision { get; set; }
        public DateTime FechaRegistro { get; set; }

        // Propiedad de navegación
        public Usuario Usuario { get; set; }
    }
}
