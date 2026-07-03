using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidades
{
    public class ControlProduccion
    {
        public int IdControl { get; set; }
        public Producto oProducto { get; set; } // Referencia al objeto Producto completo
        public string FechaRegistro { get; set; }
        public int SugeridoIA { get; set; }
        public int EntradaHorno { get; set; }
        public int Merma { get; set; }

    }
}
