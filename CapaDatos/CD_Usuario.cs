using Entidades;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;

namespace Dato
{
    public class CD_Usuario
    {
        // --- MÉTODO PRIVADO PARA AUDITORÍA ---
        private void GuardarLog(MySqlConnection conexion, int idUsuarioLogueado, string accion, string tabla, string descripcion)
        {
            using (MySqlCommand cmdLog = new MySqlCommand("sp_RegistrarLog", conexion))
            {
                cmdLog.CommandType = CommandType.StoredProcedure;
                cmdLog.Parameters.AddWithValue("p_id_usuario", idUsuarioLogueado);
                cmdLog.Parameters.AddWithValue("p_accion", accion);
                cmdLog.Parameters.AddWithValue("p_tabla_afectada", tabla);
                cmdLog.Parameters.AddWithValue("p_descripcion", descripcion);
                cmdLog.ExecuteNonQuery();
            }
        }

        public bool CambiarClave(int idusuario, string nuevaclave, int idUsuarioLogueado, out string Mensaje)
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

                    cmd.Parameters.Add("p_Resultado", MySqlDbType.Int32).Direction = ParameterDirection.Output;
                    cmd.Parameters.Add("p_Mensaje", MySqlDbType.VarChar, 500).Direction = ParameterDirection.Output;

                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.ExecuteNonQuery();

                    resultado = Convert.ToInt32(cmd.Parameters["p_Resultado"].Value) == 1;
                    Mensaje = cmd.Parameters["p_Mensaje"].Value.ToString();

                    // --- AUDITORÍA ---
                    if (resultado)
                    {
                        GuardarLog(oconexion, idUsuarioLogueado, "UPDATE", "usuario", $"Se cambió la clave del usuario con ID: {idusuario}");
                    }
                }
            }
            catch (Exception ex)
            {
                resultado = false;
                Mensaje = ex.Message;
            }
            return resultado;
        }

        public Usuario Loguear(string cedula, string clave)
        {
            Usuario usuario_encontrado = null;

            using (MySqlConnection oconexion = Conexion.obtenerConexion())
            {
                try
                {
                    string query = "SELECT u.idusuario, u.cedula, u.Nombre, u.correo, u.estado, r.IdRol, r.Descripcion as RolDescripcion " +
                                   "FROM usuario u " +
                                   "INNER JOIN rol r ON u.idrol = r.IdRol " +
                                   "WHERE u.cedula = @cedula AND u.clave = @clave AND u.estado = 1";

                    MySqlCommand cmd = new MySqlCommand(query, oconexion);
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

                    // --- AUDITORÍA ---
                    if (usuario_encontrado != null)
                    {
                        GuardarLog(oconexion, usuario_encontrado.IdUsuario, "LOGIN", "usuario", $"El usuario {usuario_encontrado.Nombre} inició sesión en el sistema.");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error al loguear: " + ex.Message);
                    usuario_encontrado = null;
                }
            }
            return usuario_encontrado;
        }

        public int Registrar(Usuario obj, int idUsuarioLogueado, out string Mensaje)
        {
            int idusuariogenerado = 0;
            Mensaje = string.Empty;

            try
            {
                using (MySqlConnection oconexion = Conexion.obtenerConexion())
                {
                    MySqlCommand cmd = new MySqlCommand("sp_RegistrarUsuario", oconexion);
                    cmd.Parameters.AddWithValue("p_cedula", obj.Cedula);
                    cmd.Parameters.AddWithValue("p_nombre", obj.Nombre);
                    cmd.Parameters.AddWithValue("p_correo", obj.Correo);
                    cmd.Parameters.AddWithValue("p_clave", obj.Clave);
                    cmd.Parameters.AddWithValue("p_idrol", obj.oRol.IdRol);

                    cmd.Parameters.Add("p_IdUsuarioResultado", MySqlDbType.Int32).Direction = ParameterDirection.Output;
                    cmd.Parameters.Add("p_Mensaje", MySqlDbType.VarChar, 500).Direction = ParameterDirection.Output;

                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.ExecuteNonQuery();

                    idusuariogenerado = Convert.ToInt32(cmd.Parameters["p_IdUsuarioResultado"].Value);
                    Mensaje = cmd.Parameters["p_Mensaje"].Value.ToString();

                    // --- AUDITORÍA ---
                    if (idusuariogenerado > 0)
                    {
                        GuardarLog(oconexion, idUsuarioLogueado, "INSERT", "usuario", $"Se registró un nuevo usuario: {obj.Nombre} (Cédula: {obj.Cedula})");
                    }
                }
            }
            catch (Exception ex)
            {
                idusuariogenerado = 0;
                Mensaje = ex.Message;
            }

            return idusuariogenerado;
        }

        public bool Editar(Usuario obj, int idUsuarioLogueado, out string Mensaje)
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

                    cmd.Parameters.Add("p_Resultado", MySqlDbType.Int32).Direction = ParameterDirection.Output;
                    cmd.Parameters.Add("p_Mensaje", MySqlDbType.VarChar, 500).Direction = ParameterDirection.Output;

                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.ExecuteNonQuery();

                    resultado = Convert.ToBoolean(cmd.Parameters["p_Resultado"].Value);
                    Mensaje = cmd.Parameters["p_Mensaje"].Value.ToString();

                    // --- AUDITORÍA ---
                    if (resultado)
                    {
                        GuardarLog(oconexion, idUsuarioLogueado, "UPDATE", "usuario", $"Se editaron los datos del usuario: {obj.Nombre} (ID: {obj.IdUsuario})");
                    }
                }
            }
            catch (Exception ex)
            {
                resultado = false;
                Mensaje = ex.Message;
            }
            return resultado;
        }

        public bool Eliminar(int idusuario, int idUsuarioLogueado, out string Mensaje)
        {
            bool resultado = false;
            Mensaje = string.Empty;

            try
            {
                using (MySqlConnection oconexion = Conexion.obtenerConexion())
                {
                    MySqlCommand cmd = new MySqlCommand("sp_EliminarUsuario", oconexion);
                    cmd.Parameters.AddWithValue("p_idusuario", idusuario);

                    cmd.Parameters.Add("p_Resultado", MySqlDbType.Int32).Direction = ParameterDirection.Output;
                    cmd.Parameters.Add("p_Mensaje", MySqlDbType.VarChar, 500).Direction = ParameterDirection.Output;

                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.ExecuteNonQuery();

                    resultado = Convert.ToInt32(cmd.Parameters["p_Resultado"].Value) == 1;
                    Mensaje = cmd.Parameters["p_Mensaje"].Value.ToString();

                    // --- AUDITORÍA ---
                    if (resultado)
                    {
                        GuardarLog(oconexion, idUsuarioLogueado, "DELETE", "usuario", $"Se eliminó al usuario con ID: {idusuario}");
                    }
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
                    string query = "SELECT u.idusuario, u.cedula, u.Nombre, u.correo, u.clave, u.estado, r.IdRol, r.Descripcion as RolDescripcion " +
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
                                Clave = reader["clave"].ToString(),
                                Estado = Convert.ToBoolean(reader["estado"]),
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
                    Console.WriteLine("Error al listar: " + ex.Message);
                    lista = new List<Usuario>();
                }
            }
            return lista;
        }

        public List<Usuario> ListarVendedores()
        {
            List<Usuario> lista = new List<Usuario>();
            using (MySqlConnection oconexion = Conexion.obtenerConexion())
            {
                try
                {
                    string query = "SELECT u.idusuario, u.cedula, u.Nombre, u.correo, u.estado, r.IdRol, r.Descripcion as RolDescripcion " +
                                   "FROM usuario u " +
                                   "INNER JOIN rol r ON u.idrol = r.IdRol " +
                                   "WHERE r.Descripcion LIKE '%Vendedor%' AND u.estado = 1";

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
                                Estado = Convert.ToBoolean(reader["estado"]),
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