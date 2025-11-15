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
    public class CD_permisos
    {
        public List<Permisos> Listar(int idUsuario)
        {
            List<Permisos> lista = new List<Permisos>();

            using (MySqlConnection oconexion = Conexion.obtenerConexion())
            {
                try
                {
                    // --- 1. CONSULTA SQL ACTUALIZADA ---
                    // Añadimos p.IdPermisos y p.FechaRegistro para llenar tu objeto
                    string query = "SELECT p.IdPermisos, p.nombre_menu, p.FechaRegistro, r.IdRol, r.Descripcion as RolDescripcion " +
                                   "FROM permisos p " +
                                   "INNER JOIN rol r ON p.idrol = r.IdRol " +
                                   "INNER JOIN usuario u ON r.IdRol = u.idrol " +
                                   "WHERE u.idusuario = @idUsuario";

                    MySqlCommand cmd = new MySqlCommand(query, oconexion);
                    cmd.Parameters.AddWithValue("@idUsuario", idUsuario);
                    cmd.CommandType = CommandType.Text;

                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            // --- 2. CREACIÓN DEL OBJETO CORREGIDA ---
                            // Ahora coincide exactamente con tu clase "Permisos.cs"
                            lista.Add(new Permisos()
                            {
                                IdPermisos = Convert.ToInt32(reader["IdPermisos"]),
                                NombreMenu = reader["nombre_menu"].ToString(),
                                FechaRegistro = Convert.ToDateTime(reader["FechaRegistro"]),
                                IdRol = Convert.ToInt32(reader["IdRol"]), // Llenamos el IdRol
                                Rol = new Rol() // Llenamos el objeto Rol (con 'R' mayúscula)
                                {
                                    IdRol = Convert.ToInt32(reader["IdRol"]),
                                    Descripcion = reader["RolDescripcion"].ToString()
                                }
                            });
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error al listar permisos: " + ex.Message);
                    lista = new List<Permisos>();
                }
            }
            return lista;
        }
    }
}
