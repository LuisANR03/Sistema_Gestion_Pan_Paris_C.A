using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidades
{
    // Clase secundaria para estructurar el Top de productos del gráfico
    public class ProductoTop
    {
        public string Nombre { get; set; }
        public int Cantidad { get; set; }
    }

    // Cambiado a public para que sea accesible por todas las capas
    public class Dashboard
    {
        public decimal TotalVentasMes { get; set; }
        public int AlertasStock { get; set; }
        public int TotalProductos { get; set; }

        // Lista para alimentar el Chart
        public List<ProductoTop> ListaTopProductos { get; set; }

        // Constructor para inicializar la lista
        public Dashboard()
        {
            ListaTopProductos = new List<ProductoTop>();
        }
    }
}