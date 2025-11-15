using Dato;
using Entidades;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos
{
    public class CD_rol
    {
        public List<Rol> Listar()
        {
            List<Rol> lista = new List<Rol>();

            using (MySqlConnection oconexion = Conexion.obtenerConexion())
            {
                try
                {
                    // --- 1. CONSULTA SQL ACTUALIZADA ---
                    // Ahora pide los 3 campos que define tu clase
                    string query = "SELECT IdRol, Descripcion  FROM rol";

                    MySqlCommand cmd = new MySqlCommand(query, oconexion);
                    cmd.CommandType = CommandType.Text;

                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                           
                            lista.Add(new Rol()
                            {
                                IdRol = Convert.ToInt32(reader["IdRol"]),
                                Descripcion = reader["Descripcion"].ToString(),
                                
                            });
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error al listar roles: " + ex.Message);
                    lista = new List<Rol>();
                }
            }
            return lista;
        }
    }
}
