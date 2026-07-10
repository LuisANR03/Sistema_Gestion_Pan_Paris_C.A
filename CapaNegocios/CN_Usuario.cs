using Dato;
using Entidades;
using System.Collections.Generic;

namespace CapaNegocios
{
    public class CN_Usuario
    {
        private CD_Usuario objetoCD_Usuario = new CD_Usuario();

        public List<Usuario> Listar()
        {
            return objetoCD_Usuario.Listar();
        }

        public Usuario Loguear(string cedula, string clave)
        {
            if (string.IsNullOrEmpty(cedula) || string.IsNullOrEmpty(clave))
            {
                return null;
            }
            return objetoCD_Usuario.Loguear(cedula, clave);
        }

        // --- MÉTODO 1: REGISTRAR (Se añadió idUsuarioLogueado) ---
        public int Registrar(Usuario obj, int idUsuarioLogueado, out string Mensaje)
        {
            Mensaje = string.Empty;

            if (string.IsNullOrEmpty(obj.Nombre) || string.IsNullOrWhiteSpace(obj.Nombre))
            {
                Mensaje = "El nombre del usuario no puede estar vacío.";
            }
            else if (string.IsNullOrEmpty(obj.Cedula) || string.IsNullOrWhiteSpace(obj.Cedula))
            {
                Mensaje = "La cédula del usuario no puede estar vacío.";
            }
            else if (string.IsNullOrEmpty(obj.Clave) || string.IsNullOrWhiteSpace(obj.Clave))
            {
                Mensaje = "La contraseña no puede estar vacía.";
            }

            if (!string.IsNullOrEmpty(Mensaje))
            {
                return 0;
            }

            // Pasamos el ID a la capa de datos
            return objetoCD_Usuario.Registrar(obj, idUsuarioLogueado, out Mensaje);
        }

        // --- MÉTODO 2: EDITAR (Se añadió idUsuarioLogueado) ---
        public bool Editar(Usuario obj, int idUsuarioLogueado, out string Mensaje)
        {
            Mensaje = string.Empty;

            if (string.IsNullOrEmpty(obj.Nombre) || string.IsNullOrWhiteSpace(obj.Nombre))
            {
                Mensaje = "El nombre del usuario no puede estar vacío.";
            }
            else if (string.IsNullOrEmpty(obj.Cedula) || string.IsNullOrWhiteSpace(obj.Cedula))
            {
                Mensaje = "La cédula del usuario no puede estar vacío.";
            }

            if (!string.IsNullOrEmpty(Mensaje))
            {
                return false;
            }

            // Pasamos el ID a la capa de datos
            return objetoCD_Usuario.Editar(obj, idUsuarioLogueado, out Mensaje);
        }

        // --- MÉTODO 3: CAMBIAR CLAVE (Se añadió idUsuarioLogueado) ---
        public bool CambiarClave(int idusuario, string nuevaclave, int idUsuarioLogueado, out string Mensaje)
        {
            if (string.IsNullOrEmpty(nuevaclave) || string.IsNullOrWhiteSpace(nuevaclave))
            {
                Mensaje = "La contraseña no puede estar vacía.";
                return false;
            }

            // Pasamos el ID a la capa de datos
            return objetoCD_Usuario.CambiarClave(idusuario, nuevaclave, idUsuarioLogueado, out Mensaje);
        }

        // --- MÉTODO 4: ELIMINAR (Se añadió idUsuarioLogueado) ---
        public bool Eliminar(int idusuario, int idUsuarioLogueado, out string Mensaje)
        {
            Mensaje = string.Empty;

            if (idusuario == 0)
            {
                Mensaje = "No se ha seleccionado ningún usuario.";
                return false;
            }

            // Pasamos el ID a la capa de datos
            return objetoCD_Usuario.Eliminar(idusuario, idUsuarioLogueado, out Mensaje);
        }

        public List<Usuario> ListarVendedores()
        {
            return objetoCD_Usuario.ListarVendedores();
        }
    }
}