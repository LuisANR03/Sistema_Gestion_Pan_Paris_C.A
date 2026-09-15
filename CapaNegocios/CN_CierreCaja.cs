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

        // SE AÑADEN LOS 2 PARÁMETROS NUEVOS AQUÍ: idUsuarioLogueado y detalleCuadre
        public bool RegistrarCierre(CierreCaja obj, int idUsuarioLogueado, string detalleCuadre, out string Mensaje)
        {
            // Validaciones de negocio preventivas (Se mantiene intacta)
            if (obj.FondoInicial < 0)
            {
                Mensaje = "El fondo inicial no puede ser un monto negativo.";
                return false;
            }

            // Pasamos los nuevos parámetros a la Capa de Datos
            return objCierre.RegistrarCierre(obj, idUsuarioLogueado, detalleCuadre, out Mensaje);
        }

        // ==========================================
        // NUEVO MÉTODO PARA REPORTES DE RENTABILIDAD
        // ==========================================
        public CierreCaja ObtenerRentabilidadPorFechas(string fechaInicio, string fechaFin)
        {
            // Validación de negocio preventiva
            if (string.IsNullOrWhiteSpace(fechaInicio) || string.IsNullOrWhiteSpace(fechaFin))
            {
                return new CierreCaja(); // Retorna un objeto vacío si las fechas son nulas
            }

            // Pasamos la solicitud a la Capa de Datos
            return objCierre.ObtenerRentabilidadPorFechas(fechaInicio, fechaFin);
        }
    }
}