using CapaDatos;
using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocios
{
    public class CN_cliente
    {
        // Conexión con la Capa de Datos (el "Trabajador")
        private CD_cliente objetoCD_Cliente = new CD_cliente();

        // --- MÉTODO 1: LISTAR ---
        // Simplemente pasa la llamada
        public List<Cliente> Listar()
        {
            return objetoCD_Cliente.Listar();
        }

        // --- MÉTODO 2: REGISTRAR ---
        public int Registrar(Cliente obj, out string Mensaje)
        {
            Mensaje = string.Empty;

            // --- Reglas de Negocio ---
            if (string.IsNullOrEmpty(obj.Nombre) || string.IsNullOrWhiteSpace(obj.Nombre))
            {
                Mensaje = "El nombre del cliente no puede estar vacío.";
            }
            else if (string.IsNullOrEmpty(obj.Cedula) || string.IsNullOrWhiteSpace(obj.Cedula))
            {
                Mensaje = "La cédula del cliente no puede estar vacía.";
            }
            else if (string.IsNullOrEmpty(obj.Correo) || string.IsNullOrWhiteSpace(obj.Correo))
            {
                Mensaje = "El correo del cliente no puede estar vacío.";
            }

            // Si hay un error, no continúa
            if (!string.IsNullOrEmpty(Mensaje))
            {
                return 0; // Retorna 0 (ID no generado)
            }

            // Si todo está bien, llama a la Capa de Datos
            return objetoCD_Cliente.Registrar(obj, out Mensaje);
        }

        // --- MÉTODO 3: EDITAR ---
        public bool Editar(Cliente obj, out string Mensaje)
        {
            Mensaje = string.Empty;

            // --- Reglas de Negocio ---
            if (string.IsNullOrEmpty(obj.Nombre) || string.IsNullOrWhiteSpace(obj.Nombre))
            {
                Mensaje = "El nombre del cliente no puede estar vacío.";
            }
            else if (string.IsNullOrEmpty(obj.Cedula) || string.IsNullOrWhiteSpace(obj.Cedula))
            {
                Mensaje = "La cédula del cliente no puede estar vacía.";
            }
            else if (string.IsNullOrEmpty(obj.Correo) || string.IsNullOrWhiteSpace(obj.Correo))
            {
                Mensaje = "El correo del cliente no puede estar vacío.";
            }

            if (!string.IsNullOrEmpty(Mensaje))
            {
                return false; // Retorna 'false' (no se pudo editar)
            }

            // Si todo está bien, llama a la Capa de Datos
            return objetoCD_Cliente.Editar(obj, out Mensaje);
        }

        // --- MÉTODO 4: ELIMINAR ---
        public bool Eliminar(int idcliente, out string Mensaje)
        {
            Mensaje = string.Empty;
            if (idcliente == 0)
            {
                Mensaje = "No se ha seleccionado ningún cliente.";
                return false;
            }

            return objetoCD_Cliente.Eliminar(idcliente, out Mensaje);
        }
    }
}
