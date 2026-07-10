using System;

namespace Entidades
{
    public class Log
    {
        public int IdLog { get; set; }

        // Usamos un objeto Usuario para poder traer el nombre cuando hagamos un SELECT con INNER JOIN
        public Usuario oUsuario { get; set; }

        public string Accion { get; set; }
        public string TablaAfectada { get; set; }
        public string Descripcion { get; set; }

        // Usamos DateTime para guardar la fecha y hora exacta
        public DateTime FechaRegistro { get; set; }
    }
}