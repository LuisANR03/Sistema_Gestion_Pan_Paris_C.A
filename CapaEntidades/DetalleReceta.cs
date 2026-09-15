using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class DetalleReceta
    {
        public int IdIngrediente { get; set; }
        public string NombreIngrediente { get; set; }

        // El costo de 1 unidad del ingrediente (ej: 1 kg de harina)
        public decimal CostoUnitario { get; set; }

        // Lo que el usuario escribe que va a gastar (ej: 0.5 kg)
        public decimal CantidadRequerida { get; set; }

        // Se calcula solo: Multiplica el costo por la cantidad
        public decimal SubTotal
        {
            get { return CostoUnitario * CantidadRequerida; }
        }
    }
}