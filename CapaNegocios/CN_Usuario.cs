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
        //Llama a la capa de datos para validar las credenciales de un usuario.
        
        // <param name="cedula">Cédula del usuario.</param>
        // <param name="clave">Clave del usuario.</param>
        // <returns>Devuelve el objeto Usuario si es válido, de lo contrario devuelve null.</returns>
        public Usuario Loguear(string cedula, string clave)
        {
            
            //no permite que los campos estén vacíos antes de consultar la BDD.
            if (string.IsNullOrEmpty(cedula) || string.IsNullOrEmpty(clave))
            {
                return null; // Si los campos están vacíos no se intenta loguear.
            }

            // Pasa la búsqueda a la capa de datos.
            return objetoCD_Usuario.Loguear(cedula, clave);
        }

        // --- MÉTODO 1: REGISTRAR ---
        public int Registrar(Usuario obj, out string Mensaje)
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

            
            return objetoCD_Usuario.Registrar(obj, out Mensaje);
        }

        // --- MÉTODO 2: EDITAR ---
        public bool Editar(Usuario obj, out string Mensaje)
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

           
            return objetoCD_Usuario.Editar(obj, out Mensaje);
        }

        // --- MÉTODO 3: CAMBIAR CLAVE ---
        public bool CambiarClave(int idusuario, string nuevaclave, out string Mensaje)
        {
            if (string.IsNullOrEmpty(nuevaclave) || string.IsNullOrWhiteSpace(nuevaclave))
            {
                Mensaje = "La contraseña no puede estar vacía.";
                return false;
            }

            
            return objetoCD_Usuario.CambiarClave(idusuario, nuevaclave, out Mensaje);
        }
        public bool Eliminar(int idusuario, out string Mensaje)
        {
            Mensaje = string.Empty;

            //No se puede eliminar un ID inválido
            if (idusuario == 0)
            {
                Mensaje = "No se ha seleccionado ningún usuario.";
                return false;
            }

            
            return objetoCD_Usuario.Eliminar(idusuario, out Mensaje);
        }
    }
}