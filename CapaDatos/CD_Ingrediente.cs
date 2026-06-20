using Dato;
using Entidades;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;

namespace CapaDatos
{
    public class CD_Ingrediente
    {
        // --- MÉTODO PARA LISTAR TODOS LOS INGREDIENTES ---
        public List<Ingrediente> Listar()
        {
            List<Ingrediente> lista = new List<Ingrediente>();

            using (MySqlConnection oconexion = Conexion.obtenerConexion())
            {
                try
                {
                    // Consulta simple para traer todo el inventario de materia prima
                    string query = @"
                        SELECT idIngrediente, nombre, stock_actual, unidad_medida, stock_minimo, estado 
                        FROM ingrediente";

                    MySqlCommand cmd = new MySqlCommand(query, oconexion);
                    cmd.CommandType = CommandType.Text;

                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            lista.Add(new Ingrediente()
                            {
                                IdIngrediente = Convert.ToInt32(reader["idIngrediente"]),
                                Nombre = reader["nombre"].ToString(),
                                StockActual = Convert.ToDecimal(reader["stock_actual"]),
                                UnidadMedida = reader["unidad_medida"].ToString(),
                                StockMinimo = Convert.ToDecimal(reader["stock_minimo"]),
                                Estado = Convert.ToBoolean(reader["estado"])
                            });
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error al listar ingredientes: " + ex.Message);
                    lista = new List<Ingrediente>();
                }
            }
            return lista;
        }

        // Más adelante, aquí agregaremos los métodos Registrar(), Editar() y Eliminar()
    }
}