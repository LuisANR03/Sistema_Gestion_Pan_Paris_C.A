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
    public class CD_Categoria
    {
        public List<Categoria> Listar()
        {
            List<Categoria> lista = new List<Categoria>();

            using (MySqlConnection oconexion = Conexion.obtenerConexion())
            {
                try
                {
                    
                    string query = "SELECT IdCategoria, Descripcion, estado FROM categoria";

                    MySqlCommand cmd = new MySqlCommand(query, oconexion);
                    cmd.CommandType = CommandType.Text;

                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            lista.Add(new Categoria()
                            {
                                IdCategoria = Convert.ToInt32(reader["IdCategoria"]),
                                Descripcion = reader["Descripcion"].ToString(),
                                Estado = Convert.ToBoolean(reader["estado"])
                            });
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error al listar categorías: " + ex.Message);
                    lista = new List<Categoria>();
                }
            }
            return lista;
        }

       
        public int Registrar(Categoria obj, out string Mensaje)
        {
            int idcategoriagenerado = 0;
            Mensaje = string.Empty;

            try
            {
                using (MySqlConnection oconexion = Conexion.obtenerConexion())
                {
                    MySqlCommand cmd = new MySqlCommand("sp_RegistrarCategoria", oconexion);

                    // Parámetros de ENTRADA
                    cmd.Parameters.AddWithValue("p_descripcion", obj.Descripcion);

                    // Parámetros de SALIDA
                    cmd.Parameters.Add("p_IdResultado", MySqlDbType.Int32).Direction = ParameterDirection.Output;
                    cmd.Parameters.Add("p_Mensaje", MySqlDbType.VarChar, 500).Direction = ParameterDirection.Output;

                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.ExecuteNonQuery();

                    idcategoriagenerado = Convert.ToInt32(cmd.Parameters["p_IdResultado"].Value);
                    Mensaje = cmd.Parameters["p_Mensaje"].Value.ToString();
                }
            }
            catch (Exception ex)
            {
                idcategoriagenerado = 0;
                Mensaje = ex.Message;
            }
            return idcategoriagenerado;
        }

        // --- MÉTODO 3: EDITAR ---
        public bool Editar(Categoria obj, out string Mensaje)
        {
            bool resultado = false;
            Mensaje = string.Empty;

            try
            {
                using (MySqlConnection oconexion = Conexion.obtenerConexion())
                {
                    MySqlCommand cmd = new MySqlCommand("sp_EditarCategoria", oconexion);

                    // Parámetros de ENTRADA
                    cmd.Parameters.AddWithValue("p_idcategoria", obj.IdCategoria);
                    cmd.Parameters.AddWithValue("p_descripcion", obj.Descripcion);
                    cmd.Parameters.AddWithValue("p_estado", obj.Estado);

                    // Parámetros de SALIDA
                    cmd.Parameters.Add("p_Resultado", MySqlDbType.Int32).Direction = ParameterDirection.Output;
                    cmd.Parameters.Add("p_Mensaje", MySqlDbType.VarChar, 500).Direction = ParameterDirection.Output;

                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.ExecuteNonQuery();

                    resultado = Convert.ToInt32(cmd.Parameters["p_Resultado"].Value) == 1;
                    Mensaje = cmd.Parameters["p_Mensaje"].Value.ToString();
                }
            }
            catch (Exception ex)
            {
                resultado = false;
                Mensaje = ex.Message;
            }
            return resultado;
        }

        // --- MÉTODO 4: ELIMINAR (DESACTIVAR) ---
        public bool Eliminar(int idcategoria, out string Mensaje)
        {
            bool resultado = false;
            Mensaje = string.Empty;

            try
            {
                using (MySqlConnection oconexion = Conexion.obtenerConexion())
                {
                    MySqlCommand cmd = new MySqlCommand("sp_EliminarCategoria", oconexion);

                    // Parámetros de ENTRADA
                    cmd.Parameters.AddWithValue("p_idcategoria", idcategoria);

                    // Parámetros de SALIDA
                    cmd.Parameters.Add("p_Resultado", MySqlDbType.Int32).Direction = ParameterDirection.Output;
                    cmd.Parameters.Add("p_Mensaje", MySqlDbType.VarChar, 500).Direction = ParameterDirection.Output;

                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.ExecuteNonQuery();

                    resultado = Convert.ToInt32(cmd.Parameters["p_Resultado"].Value) == 1;
                    Mensaje = cmd.Parameters["p_Mensaje"].Value.ToString();
                }
            }
            catch (Exception ex)
            {
                resultado = false;
                Mensaje = ex.Message;
            }
            return resultado;
        }
    }
}
