using System;
using System.Collections.Generic;
using CapaDatos;     // Referencia a tu Capa Datos
using CapaEntidades; // Referencia a tu Capa Entidades

namespace CapaNegocio
{
    public class CN_Dashboard
    {
        // Instanciamos la clase de la Capa de Datos
        private CD_Dashboard objCapaDatos = new CD_Dashboard();

        public Dashboard ObtenerMetricas()
        {
            // Aquí podrías aplicar reglas de negocio si hiciera falta.
            // Por ahora, solicitamos los datos directamente a la Capa Datos.
            return objCapaDatos.ObtenerMetricas();
        }
    }
}