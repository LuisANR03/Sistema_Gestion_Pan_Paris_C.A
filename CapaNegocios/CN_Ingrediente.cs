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

        // Aquí agregaremos validaciones para Registrar() y Editar() más adelante
    }
}