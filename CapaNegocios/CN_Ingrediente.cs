using System.Collections.Generic;
using CapaDatos;
using Entidades;

namespace CapaNegocios
{
    public class CN_Ingrediente
    {
        // Conexión con la Capa de Datos 
        private CD_Ingrediente objCD_Ingrediente = new CD_Ingrediente();

        // --- MÉTODO PARA LISTAR ---
        public List<Ingrediente> Listar()
        {
            return objCD_Ingrediente.Listar();
        }

        // ====================================================================
        // MÉTODO REGISTRAR CON VALIDACIONES DE NEGOCIO Y AUDITORÍA
        // ====================================================================
        public int Registrar(Ingrediente obj, int idUsuarioLogueado, out string mensaje)
        {
            mensaje = string.Empty;

            // Validar que el nombre no esté vacío
            if (string.IsNullOrEmpty(obj.Nombre) || string.IsNullOrWhiteSpace(obj.Nombre))
            {
                mensaje = "El nombre del ingrediente no puede estar vacío.";
                return 0;
            }

            // Validar que la unidad de medida no esté vacía
            if (string.IsNullOrEmpty(obj.UnidadMedida) || string.IsNullOrWhiteSpace(obj.UnidadMedida))
            {
                mensaje = "Debe especificar una unidad de medida (Kg, Litros, Unidades, etc.).";
                return 0;
            }

            // Validar que los stocks no sean negativos
            if (obj.StockActual < 0)
            {
                mensaje = "El stock actual no puede ser menor a cero.";
                return 0;
            }

            if (obj.StockMinimo < 0)
            {
                mensaje = "El stock mínimo de alerta no puede ser menor a cero.";
                return 0;
            }

            // Si pasa todas las validaciones de la panadería, va a la base de datos con el ID del usuario
            return objCD_Ingrediente.Registrar(obj, idUsuarioLogueado, out mensaje);
        }

        // ====================================================================
        // MÉTODO EDITAR CON VALIDACIONES DE NEGOCIO Y AUDITORÍA
        // ====================================================================
        public bool Editar(Ingrediente obj, int idUsuarioLogueado, out string mensaje)
        {
            mensaje = string.Empty;

            // Validar que el nombre no esté vacío
            if (string.IsNullOrEmpty(obj.Nombre) || string.IsNullOrWhiteSpace(obj.Nombre))
            {
                mensaje = "El nombre del ingrediente no puede estar vacío.";
                return false;
            }

            // Validar que la unidad de medida no esté vacía
            if (string.IsNullOrEmpty(obj.UnidadMedida) || string.IsNullOrWhiteSpace(obj.UnidadMedida))
            {
                mensaje = "Debe especificar una unidad de medida.";
                return false;
            }

            // Validar que los stocks no sean negativos
            if (obj.StockActual < 0)
            {
                mensaje = "El stock actual no puede ser menor a cero.";
                return false;
            }

            if (obj.StockMinimo < 0)
            {
                mensaje = "El stock mínimo de alerta no puede ser menor a cero.";
                return false;
            }

            // Si pasa todas las reglas de negocio, va a la base de datos con el ID del usuario
            return objCD_Ingrediente.Editar(obj, idUsuarioLogueado, out mensaje);
        }

        // ====================================================================
        // MÉTODO ELIMINAR CON AUDITORÍA
        // ====================================================================
        public bool Eliminar(int id, int idUsuarioLogueado, out string mensaje)
        {
            // El puente directo a la base de datos enviando el usuario que elimina
            return objCD_Ingrediente.Eliminar(id, idUsuarioLogueado, out mensaje);
        }
    }
}