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

        // ====================================================================
        // MÉTODO PARA REGISTRAR (INSERTAR) UN NUEVO INGREDIENTE
        // ====================================================================
        public int Registrar(Ingrediente obj, int idUsuarioLogueado, out string mensaje)
        {
            int idAutogenerado = 0;
            mensaje = string.Empty;

            using (MySqlConnection oconexion = Conexion.obtenerConexion())
            {
                try
                {
                    // Insertamos y pedimos que nos devuelva el ID que se acaba de generar
                    string query = @"
                        INSERT INTO ingrediente (nombre, stock_actual, unidad_medida, stock_minimo, estado) 
                        VALUES (@nombre, @stock_actual, @unidad_medida, @stock_minimo, @estado);
                        SELECT LAST_INSERT_ID();";

                    MySqlCommand cmd = new MySqlCommand(query, oconexion);
                    cmd.Parameters.AddWithValue("@nombre", obj.Nombre);
                    cmd.Parameters.AddWithValue("@stock_actual", obj.StockActual);
                    cmd.Parameters.AddWithValue("@unidad_medida", obj.UnidadMedida);
                    cmd.Parameters.AddWithValue("@stock_minimo", obj.StockMinimo);
                    cmd.Parameters.AddWithValue("@estado", obj.Estado);
                    cmd.CommandType = CommandType.Text;

                    // ExecuteScalar nos devuelve la primera columna de la primera fila (el LAST_INSERT_ID)
                    idAutogenerado = Convert.ToInt32(cmd.ExecuteScalar());

                    // --- AUDITORÍA ---
                    if (idAutogenerado > 0)
                    {
                        GuardarLog(oconexion, idUsuarioLogueado, "INSERT", "ingrediente", $"Se registró un nuevo ingrediente: {obj.Nombre}");
                    }
                }
                catch (Exception ex)
                {
                    idAutogenerado = 0;
                    mensaje = ex.Message;
                }
            }
            return idAutogenerado;
        }

        // ====================================================================
        // MÉTODO PARA EDITAR (ACTUALIZAR) UN INGREDIENTE EXISTENTE
        // ====================================================================
        public bool Editar(Ingrediente obj, int idUsuarioLogueado, out string mensaje)
        {
            bool respuesta = false;
            mensaje = string.Empty;

            using (MySqlConnection oconexion = Conexion.obtenerConexion())
            {
                try
                {
                    string query = @"
                        UPDATE ingrediente 
                        SET nombre = @nombre, 
                            stock_actual = @stock_actual, 
                            unidad_medida = @unidad_medida, 
                            stock_minimo = @stock_minimo, 
                            estado = @estado 
                        WHERE idIngrediente = @idIngrediente;";

                    MySqlCommand cmd = new MySqlCommand(query, oconexion);
                    cmd.Parameters.AddWithValue("@idIngrediente", obj.IdIngrediente);
                    cmd.Parameters.AddWithValue("@nombre", obj.Nombre);
                    cmd.Parameters.AddWithValue("@stock_actual", obj.StockActual);
                    cmd.Parameters.AddWithValue("@unidad_medida", obj.UnidadMedida);
                    cmd.Parameters.AddWithValue("@stock_minimo", obj.StockMinimo);
                    cmd.Parameters.AddWithValue("@estado", obj.Estado);
                    cmd.CommandType = CommandType.Text;

                    // ExecuteNonQuery devuelve el número de filas afectadas. Si es mayor a 0, fue exitoso.
                    respuesta = cmd.ExecuteNonQuery() > 0;

                    // --- AUDITORÍA ---
                    if (respuesta)
                    {
                        GuardarLog(oconexion, idUsuarioLogueado, "UPDATE", "ingrediente", $"Se editaron los datos del ingrediente: {obj.Nombre} (ID: {obj.IdIngrediente})");
                    }
                }
                catch (Exception ex)
                {
                    respuesta = false;
                    mensaje = ex.Message;
                }
            }
            return respuesta;
        }

        // ====================================================================
        // MÉTODO PARA ELIMINAR UN INGREDIENTE
        // ====================================================================
        public bool Eliminar(int id, int idUsuarioLogueado, out string mensaje)
        {
            bool respuesta = false;
            mensaje = string.Empty;

            using (MySqlConnection oconexion = Conexion.obtenerConexion())
            {
                try
                {
                    // Eliminación física de la base de datos
                    string query = "DELETE FROM ingrediente WHERE idIngrediente = @idIngrediente;";

                    MySqlCommand cmd = new MySqlCommand(query, oconexion);
                    cmd.Parameters.AddWithValue("@idIngrediente", id);
                    cmd.CommandType = CommandType.Text;

                    respuesta = cmd.ExecuteNonQuery() > 0;

                    // --- AUDITORÍA ---
                    if (respuesta)
                    {
                        GuardarLog(oconexion, idUsuarioLogueado, "DELETE", "ingrediente", $"Se eliminó el ingrediente con ID: {id}");
                    }
                }
                catch (Exception ex)
                {
                    respuesta = false;
                    mensaje = ex.Message;
                }
            }
            return respuesta;
        }
    }
}