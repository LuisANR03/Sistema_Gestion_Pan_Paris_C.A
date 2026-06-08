using CapaDatos;
using CapaEntidades;
using System;

namespace CapaNegocios
{
    public class CN_CierreCaja
    {
        private CD_CierreCaja objCierre = new CD_CierreCaja();

        // AHORA RECIBE EL idUsuario PARA PASARLO A LA CAPA DE DATOS
        public CierreCaja CalcularTotalesDelDia(int idUsuario)
        {
            return objCierre.CalcularTotalesDelDia(idUsuario);
        }

        public bool RegistrarCierre(CierreCaja obj, out string Mensaje)
        {
            // Validaciones de negocio preventivas
            if (obj.FondoInicial < 0)
            {
                Mensaje = "El fondo inicial no puede ser un monto negativo.";
                return false;
            }

            return objCierre.RegistrarCierre(obj, out Mensaje);
        }
    }
}