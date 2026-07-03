using CapaDatos;
using CapaEntidades;
using Entidades;
using System.Collections.Generic;

namespace CapaNegocio
{
    public class CN_Produccion
    {
        private CD_Produccion objCapaDato = new CD_Produccion();

        public List<Producto> ObtenerProductosParaProduccion()
        {
            // Más adelante aquí podemos poner validaciones, por ahora solo pasamos la lista
            return objCapaDato.ObtenerProductosParaProduccion();
        }

        public Dictionary<int, int> ObtenerSugerenciasIA()
        {
            return objCapaDato.ObtenerSugerenciasIA();
        }

        public bool RegistrarProduccion(List<ControlProduccion> lista, out string mensaje)
        {
            mensaje = string.Empty;

            // Validación de negocio: Asegurar que no nos envíen una lista vacía
            if (lista.Count == 0)
            {
                mensaje = "No hay productos en la lista para registrar.";
                return false;
            }

            // Validar que no existan valores negativos ingresados por error
            foreach (ControlProduccion cp in lista)
            {
                if (cp.EntradaHorno < 0 || cp.Merma < 0)
                {
                    mensaje = "Las cantidades de horneado o mermas no pueden ser números negativos.";
                    return false;
                }
            }

            return objCapaDato.RegistrarProduccion(lista);
        }

    }
}