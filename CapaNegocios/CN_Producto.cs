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
        public int Registrar(Producto obj, int idUsuarioLogueado, out string Mensaje)
        {
            Mensaje = string.Empty;

            // --- Reglas de Negocio ---
            if (string.IsNullOrEmpty(obj.Codigo) || string.IsNullOrWhiteSpace(obj.Codigo))
            {
                Mensaje = "El código del producto no puede estar vacío.";
            }
            else if (string.IsNullOrEmpty(obj.Nombre) || string.IsNullOrWhiteSpace(obj.Nombre))
            {
                Mensaje = "El nombre del producto no puede estar vacío.";
            }
            else if (obj.oCategoria == null || obj.oCategoria.IdCategoria == 0)
            {
                Mensaje = "Debe seleccionar una categoría.";
            }
            // NUEVA REGLA: Validar que el costo de producción no sea negativo
            else if (obj.CostoProduccion < 0)
            {
                Mensaje = "El costo de producción no puede ser menor a cero.";
            }

            // Si hay un error, no continúa
            if (!string.IsNullOrEmpty(Mensaje))
            {
                return 0; // Retorna 0 (ID no generado)
            }

            // Si todo está bien, llama a la Capa de Datos pasando el usuario logueado
            return objetoCD_Producto.Registrar(obj, idUsuarioLogueado, out Mensaje);
        }

        // --- MÉTODO 3: EDITAR ---
        public bool Editar(Producto obj, int idUsuarioLogueado, out string Mensaje)
        {
            Mensaje = string.Empty;

            // --- Reglas de Negocio ---
            if (string.IsNullOrEmpty(obj.Codigo) || string.IsNullOrWhiteSpace(obj.Codigo))
            {
                Mensaje = "El código del producto no puede estar vacío.";
            }
            else if (string.IsNullOrEmpty(obj.Nombre) || string.IsNullOrWhiteSpace(obj.Nombre))
            {
                Mensaje = "El nombre del producto no puede estar vacío.";
            }
            else if (obj.oCategoria == null || obj.oCategoria.IdCategoria == 0)
            {
                Mensaje = "Debe seleccionar una categoría.";
            }
            // NUEVA REGLA: Validar que el costo de producción no sea negativo
            else if (obj.CostoProduccion < 0)
            {
                Mensaje = "El costo de producción no puede ser menor a cero.";
            }

            if (!string.IsNullOrEmpty(Mensaje))
            {
                return false; // Retorna 'false' (no se pudo editar)
            }

            // Si todo está bien, llama a la Capa de Datos pasando el usuario logueado
            return objetoCD_Producto.Editar(obj, idUsuarioLogueado, out Mensaje);
        }

        // --- MÉTODO 4: ELIMINAR ---
        public bool Eliminar(int idproducto, int idUsuarioLogueado, out string Mensaje)
        {
            Mensaje = string.Empty;
            if (idproducto == 0)
            {
                Mensaje = "No se ha seleccionado ningún producto.";
                return false;
            }

            // Llama a la Capa de Datos pasando el usuario logueado
            return objetoCD_Producto.Eliminar(idproducto, idUsuarioLogueado, out Mensaje);
        }
    }
}