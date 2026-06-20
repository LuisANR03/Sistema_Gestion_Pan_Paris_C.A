using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Ingrediente
    {
        public int IdIngrediente { get; set; }
        public string Nombre { get; set; }
        public decimal StockActual { get; set; }
        public string UnidadMedida { get; set; }
        public decimal StockMinimo { get; set; }
        public bool Estado { get; set; }
    }
}