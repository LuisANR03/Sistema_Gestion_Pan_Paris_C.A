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
    public class CD_cliente
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

        // --- MÉTODO 1: LISTAR ---
        public List<Cliente> Listar()
        {
            List<Cliente> lista = new List<Cliente>();

            using (MySqlConnection oconexion = Conexion.obtenerConexion())
            {
                try
                {
                    // SE AGREGÓ: tipo_documento a la consulta
                    string query = "SELECT IdCliente, tipo_documento, cedula, Nombre, correo, telefono, direccion, estado FROM cliente";

                    MySqlCommand cmd = new MySqlCommand(query, oconexion);
                    cmd.CommandType = CommandType.Text;

                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            lista.Add(new Cliente()
                            {
                                IdCliente = Convert.ToInt32(reader["IdCliente"]),
                                TipoDocumento = reader["tipo_documento"].ToString(), // SE AGREGÓ ESTA LÍNEA
                                Cedula = reader["cedula"].ToString(),
                                Nombre = reader["Nombre"].ToString(),
                                Correo = reader["correo"].ToString(),
                                Telefono = reader["telefono"] == DBNull.Value ? null : reader["telefono"].ToString(),
                                Direccion = reader["direccion"] == DBNull.Value ? null : reader["direccion"].ToString(),
                                Estado = Convert.ToBoolean(reader["estado"])
                            });
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error al listar clientes: " + ex.Message);
                    lista = new List<Cliente>();
                }
            }
            return lista;
        }

        // --- MÉTODO 2: REGISTRAR ---
        public int Registrar(Cliente obj, int idUsuarioLogueado, out string Mensaje)
        {
            int idclientegenerado = 0;
            Mensaje = string.Empty;

            try
            {
                using (MySqlConnection oconexion = Conexion.obtenerConexion())
                {
                    MySqlCommand cmd = new MySqlCommand("sp_RegistrarCliente", oconexion);

                    // SE AGREGÓ EL PARÁMETRO p_tipo_documento
                    cmd.Parameters.AddWithValue("p_tipo_documento", obj.TipoDocumento);
                    cmd.Parameters.AddWithValue("p_cedula", obj.Cedula);
                    cmd.Parameters.AddWithValue("p_nombre", obj.Nombre);
                    cmd.Parameters.AddWithValue("p_correo", obj.Correo);
                    cmd.Parameters.AddWithValue("p_telefono", obj.Telefono);
                    cmd.Parameters.AddWithValue("p_direccion", obj.Direccion);

                    cmd.Parameters.Add("p_IdClienteResultado", MySqlDbType.Int32).Direction = ParameterDirection.Output;
                    cmd.Parameters.Add("p_Mensaje", MySqlDbType.VarChar, 500).Direction = ParameterDirection.Output;

                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.ExecuteNonQuery();

                    idclientegenerado = Convert.ToInt32(cmd.Parameters["p_IdClienteResultado"].Value);
                    Mensaje = cmd.Parameters["p_Mensaje"].Value.ToString();

                    // --- AUDITORÍA ---
                    if (idclientegenerado > 0)
                    {
                        GuardarLog(oconexion, idUsuarioLogueado, "INSERT", "cliente", $"Se registró un nuevo cliente: {obj.Nombre} (Documento: {obj.TipoDocumento}-{obj.Cedula})");
                    }
                }
            }
            catch (Exception ex)
            {
                idclientegenerado = 0;
                Mensaje = ex.Message;
            }
            return idclientegenerado;
        }

        // --- MÉTODO 3: EDITAR ---
        public bool Editar(Cliente obj, int idUsuarioLogueado, out string Mensaje)
        {
            bool resultado = false;
            Mensaje = string.Empty;

            try
            {
                using (MySqlConnection oconexion = Conexion.obtenerConexion())
                {
                    MySqlCommand cmd = new MySqlCommand("sp_EditarCliente", oconexion);

                    cmd.Parameters.AddWithValue("p_idcliente", obj.IdCliente);
                    // SE AGREGÓ EL PARÁMETRO p_tipo_documento
                    cmd.Parameters.AddWithValue("p_tipo_documento", obj.TipoDocumento);
                    cmd.Parameters.AddWithValue("p_cedula", obj.Cedula);
                    cmd.Parameters.AddWithValue("p_nombre", obj.Nombre);
                    cmd.Parameters.AddWithValue("p_correo", obj.Correo);
                    cmd.Parameters.AddWithValue("p_telefono", obj.Telefono);
                    cmd.Parameters.AddWithValue("p_direccion", obj.Direccion);
                    cmd.Parameters.AddWithValue("p_estado", obj.Estado);

                    cmd.Parameters.Add("p_Resultado", MySqlDbType.Int32).Direction = ParameterDirection.Output;
                    cmd.Parameters.Add("p_Mensaje", MySqlDbType.VarChar, 500).Direction = ParameterDirection.Output;

                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.ExecuteNonQuery();

                    resultado = Convert.ToInt32(cmd.Parameters["p_Resultado"].Value) == 1;
                    Mensaje = cmd.Parameters["p_Mensaje"].Value.ToString();

                    // --- AUDITORÍA ---
                    if (resultado)
                    {
                        GuardarLog(oconexion, idUsuarioLogueado, "UPDATE", "cliente", $"Se editaron los datos del cliente: {obj.Nombre} (ID: {obj.IdCliente})");
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

        // --- MÉTODO 4: ELIMINAR ---
        public bool Eliminar(int idcliente, int idUsuarioLogueado, out string Mensaje)
        {
            bool resultado = false;
            Mensaje = string.Empty;

            try
            {
                using (MySqlConnection oconexion = Conexion.obtenerConexion())
                {
                    MySqlCommand cmd = new MySqlCommand("sp_EliminarCliente", oconexion);

                    cmd.Parameters.AddWithValue("p_idcliente", idcliente);

                    cmd.Parameters.Add("p_Resultado", MySqlDbType.Int32).Direction = ParameterDirection.Output;
                    cmd.Parameters.Add("p_Mensaje", MySqlDbType.VarChar, 500).Direction = ParameterDirection.Output;

                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.ExecuteNonQuery();

                    resultado = Convert.ToInt32(cmd.Parameters["p_Resultado"].Value) == 1;
                    Mensaje = cmd.Parameters["p_Mensaje"].Value.ToString();

                    // --- AUDITORÍA ---
                    if (resultado)
                    {
                        GuardarLog(oconexion, idUsuarioLogueado, "DELETE", "cliente", $"Se eliminó al cliente con ID: {idcliente}");
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
    }
}