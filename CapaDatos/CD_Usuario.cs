using Dato;
using Entidades;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data; 

namespace Dato 
{
    public class CD_Usuario
    {
        public bool CambiarClave(int idusuario, string nuevaclave, out string Mensaje)
        {
            bool resultado = false;
            Mensaje = string.Empty;

            try
            {
                using (MySqlConnection oconexion = Conexion.obtenerConexion())
                {
                    MySqlCommand cmd = new MySqlCommand("sp_CambiarClave", oconexion);
                    cmd.Parameters.AddWithValue("p_idusuario", idusuario);
                    cmd.Parameters.AddWithValue("p_nuevaclave", nuevaclave);

                    // --- CORRECCIÓN AQUÍ ---
                    // 1. Cambiamos el tipo a Int32
                    cmd.Parameters.Add("p_Resultado", MySqlDbType.Int32).Direction = ParameterDirection.Output;
                    cmd.Parameters.Add("p_Mensaje", MySqlDbType.VarChar, 500).Direction = ParameterDirection.Output;

                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.ExecuteNonQuery();

                    // --- CORRECCIÓN AQUÍ ---
                    // 2. Leemos el resultado como INT y lo convertimos a bool
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

        public List<Usuario> Listar()
        {
            List<Usuario> lista = new List<Usuario>();

            using (MySqlConnection oconexion = Conexion.obtenerConexion())
            {
                try
                {
                    string query = "SELECT u.idusuario, u.cedula, u.Nombre, u.correo, u.estado, r.IdRol, r.Descripcion as RolDescripcion " +
                                   "FROM usuario u " +
                                   "INNER JOIN rol r ON u.idrol = r.IdRol";

                    MySqlCommand cmd = new MySqlCommand(query, oconexion);
                    cmd.CommandType = CommandType.Text;

                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            lista.Add(new Usuario()
                            {
                                IdUsuario = Convert.ToInt32(reader["idusuario"]),
                                Cedula = reader["cedula"].ToString(),
                                Nombre = reader["Nombre"].ToString(),
                                Correo = reader["correo"].ToString(),
                                Estado = reader["estado"] != DBNull.Value ? Convert.ToBoolean(reader["estado"]) : false,
                                oRol = new Rol()
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
                    Console.WriteLine("Error al listar usuarios: " + ex.Message);
                    lista = new List<Usuario>();
                }
            }
            return lista;
        }

        
        /// Busca un único usuario por sus credenciales para validar el login.
        public Usuario Loguear(string cedula, string clave)
        {
            Usuario usuario_encontrado = null;

            using (MySqlConnection oconexion = Conexion.obtenerConexion())
            {
                try
                {
                    // Consulta  para buscar un usuario que esté activo.
                    string query = "SELECT u.idusuario, u.cedula, u.Nombre, u.correo, u.estado, r.IdRol, r.Descripcion as RolDescripcion " +
                                   "FROM usuario u " +
                                   "INNER JOIN rol r ON u.idrol = r.IdRol " +
                                   "WHERE u.cedula = @cedula AND u.clave = @clave AND u.estado = 1";

                    MySqlCommand cmd = new MySqlCommand(query, oconexion);
                    // Usar parámetros es crucial para la seguridad (previene inyección SQL).
                    cmd.Parameters.AddWithValue("@cedula", cedula);
                    cmd.Parameters.AddWithValue("@clave", clave);
                    cmd.CommandType = CommandType.Text;

                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read()) 
                        {
                            usuario_encontrado = new Usuario()
                            {
                                IdUsuario = Convert.ToInt32(reader["idusuario"]),
                                Cedula = reader["cedula"].ToString(),
                                Nombre = reader["Nombre"].ToString(),
                                Correo = reader["correo"].ToString(),
                                Estado = Convert.ToBoolean(reader["estado"]),
                                oRol = new Rol()
                                {
                                    IdRol = Convert.ToInt32(reader["IdRol"]),
                                    Descripcion = reader["RolDescripcion"].ToString()
                                }
                            };
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error al loguear: " + ex.Message);
                    // En caso de error no devolver un usuario válido.
                    usuario_encontrado = null;
                }
            }
            return usuario_encontrado; // Devuelve el Usuario si lo encontró
        }
        public int Registrar(Usuario obj, out string Mensaje)
        {
            int idusuariogenerado = 0;
            Mensaje = string.Empty;

            try
            {
                using (MySqlConnection oconexion = Conexion.obtenerConexion())
                {
                    //  Llama al Stored Procedure
                    MySqlCommand cmd = new MySqlCommand("sp_RegistrarUsuario", oconexion);

                    //  Asigna los parámetros
                    cmd.Parameters.AddWithValue("p_cedula", obj.Cedula);
                    cmd.Parameters.AddWithValue("p_nombre", obj.Nombre);
                    cmd.Parameters.AddWithValue("p_correo", obj.Correo);
                    cmd.Parameters.AddWithValue("p_clave", obj.Clave);
                    cmd.Parameters.AddWithValue("p_idrol", obj.oRol.IdRol); // Asigna el IdRol del objeto

                    // Parámetros de salida
                    cmd.Parameters.Add("p_IdUsuarioResultado", MySqlDbType.Int32).Direction = ParameterDirection.Output;
                    cmd.Parameters.Add("p_Mensaje", MySqlDbType.VarChar, 500).Direction = ParameterDirection.Output;

                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.ExecuteNonQuery();

                    //  Obtiene los resultados del Stored Procedure
                    idusuariogenerado = Convert.ToInt32(cmd.Parameters["p_IdUsuarioResultado"].Value);
                    Mensaje = cmd.Parameters["p_Mensaje"].Value.ToString();
                }
            }
            catch (Exception ex)
            {
                idusuariogenerado = 0;
                Mensaje = ex.Message;
            }

            return idusuariogenerado;
        }
        public bool Editar(Usuario obj, out string Mensaje)
        {
            bool resultado = false;
            Mensaje = string.Empty;

            try
            {
                using (MySqlConnection oconexion = Conexion.obtenerConexion())
                {
                    MySqlCommand cmd = new MySqlCommand("sp_EditarUsuario", oconexion);
                    cmd.Parameters.AddWithValue("p_idusuario", obj.IdUsuario);
                    cmd.Parameters.AddWithValue("p_cedula", obj.Cedula);
                    cmd.Parameters.AddWithValue("p_nombre", obj.Nombre);
                    cmd.Parameters.AddWithValue("p_correo", obj.Correo);
                    cmd.Parameters.AddWithValue("p_idrol", obj.oRol.IdRol);
                    cmd.Parameters.AddWithValue("p_estado", obj.Estado);

                    // Parámetros de salida
                    cmd.Parameters.Add("p_Resultado", MySqlDbType.Int32).Direction = ParameterDirection.Output;
                    cmd.Parameters.Add("p_Mensaje", MySqlDbType.VarChar, 500).Direction = ParameterDirection.Output;

                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.ExecuteNonQuery();

                    resultado = Convert.ToBoolean(cmd.Parameters["p_Resultado"].Value);
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
        public bool Eliminar(int idusuario, out string Mensaje)
        {
            bool resultado = false;
            Mensaje = string.Empty;

            try
            {
                using (MySqlConnection oconexion = Conexion.obtenerConexion())
                {
                    MySqlCommand cmd = new MySqlCommand("sp_EliminarUsuario", oconexion);
                    cmd.Parameters.AddWithValue("p_idusuario", idusuario);

                    // Parámetros de salida (usando INT, como en CambiarClave)
                    cmd.Parameters.Add("p_Resultado", MySqlDbType.Int32).Direction = ParameterDirection.Output;
                    cmd.Parameters.Add("p_Mensaje", MySqlDbType.VarChar, 500).Direction = ParameterDirection.Output;

                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.ExecuteNonQuery();

                    // Leemos el resultado (1 = true, 0 = false)
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
        // --- MÉTODO NUEVO: LISTAR SOLO VENDEDORES ---
        public List<Usuario> ListarVendedores()
        {
            List<Usuario> lista = new List<Usuario>();

            using (MySqlConnection oconexion = Conexion.obtenerConexion())
            {
                try
                {
                    // Consulta filtrada: Solo usuarios activos (estado = 1) y con Rol 'Vendedor'
                    string query = "SELECT u.idusuario, u.cedula, u.Nombre, u.correo, u.estado, r.IdRol, r.Descripcion as RolDescripcion " +
                                   "FROM usuario u " +
                                   "INNER JOIN rol r ON u.idrol = r.IdRol " +
                                   "WHERE r.Descripcion = 'Vendedor' AND u.estado = 1";

                    MySqlCommand cmd = new MySqlCommand(query, oconexion);
                    cmd.CommandType = CommandType.Text;

                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            lista.Add(new Usuario()
                            {
                                IdUsuario = Convert.ToInt32(reader["idusuario"]),
                                Cedula = reader["cedula"].ToString(),
                                Nombre = reader["Nombre"].ToString(),
                                Correo = reader["correo"].ToString(),
                                Estado = reader["estado"] != DBNull.Value ? Convert.ToBoolean(reader["estado"]) : false,
                                oRol = new Rol()
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
                    Console.WriteLine("Error al listar vendedores: " + ex.Message);
                    lista = new List<Usuario>();
                }
            }
            return lista;
        }

    }
}