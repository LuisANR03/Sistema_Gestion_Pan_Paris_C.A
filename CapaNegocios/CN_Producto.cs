using CapaDatos;
using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocios
{
    public class CN_Producto
    {
        // Conexión con la Capa de Datos 
        private CD_Producto objetoCD_Producto = new CD_Producto();

        // --- MÉTODO 1: LISTAR ---
        
        public List<Producto> Listar()
        {
            return objetoCD_Producto.Listar();
        }

        // --- MÉTODO 2: REGISTRAR ---
        public int Registrar(Producto obj, out string Mensaje)
        {
            Mensaje = string.Empty;

            
            if (string.IsNullOrEmpty(obj.Codigo) || string.IsNullOrWhiteSpace(obj.Codigo))
            {
                Mensaje = "El código del producto no puede estar vacío.";
            }
            else if (string.IsNullOrEmpty(obj.Nombre) || string.IsNullOrWhiteSpace(obj.Nombre))
            {
                Mensaje = "El nombre del producto no puede estar vacío.";
            }
            else if (obj.oCategoria.IdCategoria == 0)
            {
                Mensaje = "Debe seleccionar una categoría.";
            }
            

            // Si hay un error, no continúa
            if (!string.IsNullOrEmpty(Mensaje))
            {
                return 0; // Retorna 0 (ID no generado)
            }

            // Si todo está bien, llama a la Capa de Datos
            return objetoCD_Producto.Registrar(obj, out Mensaje);
        }

        // --- MÉTODO 3: EDITAR ---
        public bool Editar(Producto obj, out string Mensaje)
        {
            Mensaje = string.Empty;

            
            if (string.IsNullOrEmpty(obj.Codigo) || string.IsNullOrWhiteSpace(obj.Codigo))
            {
                Mensaje = "El código del producto no puede estar vacío.";
            }
            else if (string.IsNullOrEmpty(obj.Nombre) || string.IsNullOrWhiteSpace(obj.Nombre))
            {
                Mensaje = "El nombre del producto no puede estar vacío.";
            }
            else if (obj.oCategoria.IdCategoria == 0)
            {
                Mensaje = "Debe seleccionar una categoría.";
            }

            if (!string.IsNullOrEmpty(Mensaje))
            {
                return false; // Retorna 'false' (no se pudo editar)
            }

            // Si todo está bien, llama a la Capa de Datos
            return objetoCD_Producto.Editar(obj, out Mensaje);
        }

        // --- MÉTODO 4: ELIMINAR ---
        public bool Eliminar(int idproducto, out string Mensaje)
        {
            Mensaje = string.Empty;
            if (idproducto == 0)
            {
                Mensaje = "No se ha seleccionado ningún producto.";
                return false;
            }

            return objetoCD_Producto.Eliminar(idproducto, out Mensaje);
        }
    }
}
