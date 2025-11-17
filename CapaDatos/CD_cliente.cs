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
        // --- MÉTODO 1: LISTAR ---
        // para traer todos los clientes.
        public List<Cliente> Listar()
        {
            List<Cliente> lista = new List<Cliente>();

            using (MySqlConnection oconexion = Conexion.obtenerConexion())
            {
                try
                {
                    string query = "SELECT IdCliente, cedula, Nombre, correo, telefono, direccion, estado FROM cliente";

                    MySqlCommand cmd = new MySqlCommand(query, oconexion);
                    cmd.CommandType = CommandType.Text;

                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            lista.Add(new Cliente()
                            {
                                IdCliente = Convert.ToInt32(reader["IdCliente"]),
                                Cedula = reader["cedula"].ToString(),
                                Nombre = reader["Nombre"].ToString(),
                                Correo = reader["correo"].ToString(),
                                // Manejamos nulos para campos opcionales
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
        public int Registrar(Cliente obj, out string Mensaje)
        {
            int idclientegenerado = 0;
            Mensaje = string.Empty;

            try
            {
                using (MySqlConnection oconexion = Conexion.obtenerConexion())
                {
                    MySqlCommand cmd = new MySqlCommand("sp_RegistrarCliente", oconexion);

                    // Parámetros de ENTRADA
                    cmd.Parameters.AddWithValue("p_cedula", obj.Cedula);
                    cmd.Parameters.AddWithValue("p_nombre", obj.Nombre);
                    cmd.Parameters.AddWithValue("p_correo", obj.Correo);
                    cmd.Parameters.AddWithValue("p_telefono", obj.Telefono);
                    cmd.Parameters.AddWithValue("p_direccion", obj.Direccion);

                    // Parámetros de SALIDA
                    cmd.Parameters.Add("p_IdClienteResultado", MySqlDbType.Int32).Direction = ParameterDirection.Output;
                    cmd.Parameters.Add("p_Mensaje", MySqlDbType.VarChar, 500).Direction = ParameterDirection.Output;

                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.ExecuteNonQuery();

                    idclientegenerado = Convert.ToInt32(cmd.Parameters["p_IdClienteResultado"].Value);
                    Mensaje = cmd.Parameters["p_Mensaje"].Value.ToString();
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
        public bool Editar(Cliente obj, out string Mensaje)
        {
            bool resultado = false;
            Mensaje = string.Empty;

            try
            {
                using (MySqlConnection oconexion = Conexion.obtenerConexion())
                {
                    MySqlCommand cmd = new MySqlCommand("sp_EditarCliente", oconexion);

                    // Parámetros de ENTRADA
                    cmd.Parameters.AddWithValue("p_idcliente", obj.IdCliente);
                    cmd.Parameters.AddWithValue("p_cedula", obj.Cedula);
                    cmd.Parameters.AddWithValue("p_nombre", obj.Nombre);
                    cmd.Parameters.AddWithValue("p_correo", obj.Correo);
                    cmd.Parameters.AddWithValue("p_telefono", obj.Telefono);
                    cmd.Parameters.AddWithValue("p_direccion", obj.Direccion);
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
        public bool Eliminar(int idcliente, out string Mensaje)
        {
            bool resultado = false;
            Mensaje = string.Empty;

            try
            {
                using (MySqlConnection oconexion = Conexion.obtenerConexion())
                {
                    MySqlCommand cmd = new MySqlCommand("sp_EliminarCliente", oconexion);

                    // Parámetros de ENTRADA
                    cmd.Parameters.AddWithValue("p_idcliente", idcliente);

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
