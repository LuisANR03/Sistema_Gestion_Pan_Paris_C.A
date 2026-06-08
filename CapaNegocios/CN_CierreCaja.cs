using CapaDatos;
using CapaEntidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocios
{
    public class CN_CierreCaja
    {
        private CD_CierreCaja objCierre = new CD_CierreCaja();

        public CierreCaja CalcularTotalesDelDia()
        {
            return objCierre.CalcularTotalesDelDia();
        }

        public bool RegistrarCierre(CierreCaja obj, out string Mensaje)
        {
            // Aquí en un futuro podrías poner reglas, por ejemplo:
            // if (obj.FondoInicial < 0) { Mensaje = "El fondo no puede ser negativo"; return false; }

            return objCierre.RegistrarCierre(obj, out Mensaje);
        }
    }
}

