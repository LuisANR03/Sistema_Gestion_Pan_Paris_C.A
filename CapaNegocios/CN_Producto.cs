using CapaDatos;
using CapaEntidades;
using Entidades;
using System;
using System.Collections.Generic;

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

        // --- NUEVO MÉTODO: OBTENER RECETA ---
        public List<DetalleReceta> ObtenerReceta(int idProducto)
        {
            return objetoCD_Producto.ObtenerReceta(idProducto);
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
            // Validar que el costo de producción no sea negativo
            else if (obj.CostoProduccion < 0)
            {
                Mensaje = "El costo de producción no puede ser menor a cero.";
            }

            // NUEVA REGLA: Validar receta si trae ingredientes
            if (obj.DetallesReceta != null && obj.DetallesReceta.Count > 0 && string.IsNullOrEmpty(Mensaje))
            {
                foreach (var item in obj.DetallesReceta)
                {
                    if (item.CantidadRequerida <= 0)
                    {
                        Mensaje = $"La cantidad para el ingrediente {item.NombreIngrediente} debe ser mayor a cero.";
                        break;
                    }
                }
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
            // Validar que el costo de producción no sea negativo
            else if (obj.CostoProduccion < 0)
            {
                Mensaje = "El costo de producción no puede ser menor a cero.";
            }

            // NUEVA REGLA: Validar receta si trae ingredientes
            if (obj.DetallesReceta != null && obj.DetallesReceta.Count > 0 && string.IsNullOrEmpty(Mensaje))
            {
                foreach (var item in obj.DetallesReceta)
                {
                    if (item.CantidadRequerida <= 0)
                    {
                        Mensaje = $"La cantidad para el ingrediente {item.NombreIngrediente} debe ser mayor a cero.";
                        break;
                    }
                }
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