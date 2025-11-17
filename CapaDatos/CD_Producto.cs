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
    public class CD_Producto
    {
        public List<Producto> Listar()
        {
            List<Producto> lista = new List<Producto>();

            using (MySqlConnection oconexion = Conexion.obtenerConexion())
            {
                try
                {
                    // Consulta con JOIN para unir producto (p) y categoria (c)
                    string query = @"
                        SELECT p.IdProducto, p.Codigo, p.Nombre, p.Descripcion,
                               c.IdCategoria, c.Descripcion as CategoriaDescripcion,
                               p.Stock, p.PrecioVenta, p.PrecioPromocion, p.estado
                        FROM producto p
                        INNER JOIN categoria c ON p.idcategoria = c.IdCategoria";

                    MySqlCommand cmd = new MySqlCommand(query, oconexion);
                    cmd.CommandType = CommandType.Text;

                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            lista.Add(new Producto()
                            {
                                IdProducto = Convert.ToInt32(reader["IdProducto"]),
                                Codigo = reader["Codigo"].ToString(),
                                Nombre = reader["Nombre"].ToString(),
                                Descripcion = reader["Descripcion"].ToString(),
                                // Creamos el objeto Categoria anidado
                                oCategoria = new Categoria()
                                {
                                    IdCategoria = Convert.ToInt32(reader["IdCategoria"]),
                                    Descripcion = reader["CategoriaDescripcion"].ToString()
                                },
                                Stock = Convert.ToInt32(reader["Stock"]),
                                PrecioVenta = Convert.ToDecimal(reader["PrecioVenta"]),
                                // Manejamos el valor NULO de PrecioPromocion
                                PrecioPromocion = reader["PrecioPromocion"] == DBNull.Value
                                                    ? (decimal?)null
                                                    : Convert.ToDecimal(reader["PrecioPromocion"]),
                                Estado = Convert.ToBoolean(reader["estado"])
                            });
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error al listar productos: " + ex.Message);
                    lista = new List<Producto>();
                }
            }
            return lista;
        }

        // --- MÉTODO 2: REGISTRAR ---
        public int Registrar(Producto obj, out string Mensaje)
        {
            int idproductogenerado = 0;
            Mensaje = string.Empty;

            try
            {
                using (MySqlConnection oconexion = Conexion.obtenerConexion())
                {
                    MySqlCommand cmd = new MySqlCommand("sp_RegistrarProducto", oconexion);

                    // Parámetros de ENTRADA
                    cmd.Parameters.AddWithValue("p_codigo", obj.Codigo);
                    cmd.Parameters.AddWithValue("p_nombre", obj.Nombre);
                    cmd.Parameters.AddWithValue("p_descripcion", obj.Descripcion);
                    cmd.Parameters.AddWithValue("p_idcategoria", obj.oCategoria.IdCategoria);
                    cmd.Parameters.AddWithValue("p_stock", obj.Stock);
                    cmd.Parameters.AddWithValue("p_precioventa", obj.PrecioVenta);

                    // Manejamos el valor NULO de PrecioPromocion
                    // Si es null, enviamos 0, el SP lo convertirá a NULL.
                    cmd.Parameters.AddWithValue("p_preciopromocion", obj.PrecioPromocion.HasValue ? obj.PrecioPromocion.Value : 0);

                    // Parámetros de SALIDA
                    cmd.Parameters.Add("p_IdResultado", MySqlDbType.Int32).Direction = ParameterDirection.Output;
                    cmd.Parameters.Add("p_Mensaje", MySqlDbType.VarChar, 500).Direction = ParameterDirection.Output;

                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.ExecuteNonQuery();

                    idproductogenerado = Convert.ToInt32(cmd.Parameters["p_IdResultado"].Value);
                    Mensaje = cmd.Parameters["p_Mensaje"].Value.ToString();
                }
            }
            catch (Exception ex)
            {
                idproductogenerado = 0;
                Mensaje = ex.Message;
            }
            return idproductogenerado;
        }

        // --- MÉTODO 3: EDITAR ---
        public bool Editar(Producto obj, out string Mensaje)
        {
            bool resultado = false;
            Mensaje = string.Empty;

            try
            {
                using (MySqlConnection oconexion = Conexion.obtenerConexion())
                {
                    MySqlCommand cmd = new MySqlCommand("sp_EditarProducto", oconexion);

                    // Parámetros de ENTRADA
                    cmd.Parameters.AddWithValue("p_idproducto", obj.IdProducto);
                    cmd.Parameters.AddWithValue("p_codigo", obj.Codigo);
                    cmd.Parameters.AddWithValue("p_nombre", obj.Nombre);
                    cmd.Parameters.AddWithValue("p_descripcion", obj.Descripcion);
                    cmd.Parameters.AddWithValue("p_idcategoria", obj.oCategoria.IdCategoria);
                    cmd.Parameters.AddWithValue("p_stock", obj.Stock);
                    cmd.Parameters.AddWithValue("p_precioventa", obj.PrecioVenta);

                    // Manejamos el valor NULO
                    cmd.Parameters.AddWithValue("p_preciopromocion", obj.PrecioPromocion.HasValue ? obj.PrecioPromocion.Value : 0);

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
        public bool Eliminar(int idproducto, out string Mensaje)
        {
            bool resultado = false;
            Mensaje = string.Empty;

            try
            {
                using (MySqlConnection oconexion = Conexion.obtenerConexion())
                {
                    MySqlCommand cmd = new MySqlCommand("sp_EliminarProducto", oconexion);

                    // Parámetros de ENTRADA
                    cmd.Parameters.AddWithValue("p_idproducto", idproducto);

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
