using CapaDatos;
using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocios
{
        public class CN_Categoria
    {
        
            // Conexión con la Capa de Datos 
            private CD_Categoria objetoCD_Categoria = new CD_Categoria();

            // --- MÉTODO 1: LISTAR ---
            
            public List<Categoria> Listar()
            {
                return objetoCD_Categoria.Listar();
            }

            // --- MÉTODO 2: REGISTRAR ---
            public int Registrar(Categoria obj, out string Mensaje)
            {
                Mensaje = string.Empty;

                // --- Regla de Negocio ---
                if (string.IsNullOrEmpty(obj.Descripcion) || string.IsNullOrWhiteSpace(obj.Descripcion))
                {
                    Mensaje = "La descripción de la categoría no puede estar vacía.";
                }

                if (!string.IsNullOrEmpty(Mensaje))
                {
                    return 0; // Retorna 0 (ID no generado)
                }

                // Si todo está bien, llama a la Capa de Datos
                return objetoCD_Categoria.Registrar(obj, out Mensaje);
            }

            // --- MÉTODO 3: EDITAR ---
            public bool Editar(Categoria obj, out string Mensaje)
            {
                Mensaje = string.Empty;

                // --- Regla de Negocio ---
                if (string.IsNullOrEmpty(obj.Descripcion) || string.IsNullOrWhiteSpace(obj.Descripcion))
                {
                    Mensaje = "La descripción de la categoría no puede estar vacía.";
                }

                if (!string.IsNullOrEmpty(Mensaje))
                {
                    return false; // Retorna 'false' (no se pudo editar)
                }

                // Si todo está bien, llama a la Capa de Datos
                return objetoCD_Categoria.Editar(obj, out Mensaje);
            }

            // --- MÉTODO 4: ELIMINAR ---
            public bool Eliminar(int idcategoria, out string Mensaje)
            {
                Mensaje = string.Empty;
                if (idcategoria == 0)
                {
                    Mensaje = "No se ha seleccionado ninguna categoría.";
                    return false;
                }

                return objetoCD_Categoria.Eliminar(idcategoria, out Mensaje);
            }
        }
    }

