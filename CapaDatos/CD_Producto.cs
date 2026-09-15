using CapaEntidades;
using Dato;
using Entidades;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;

namespace CapaDatos
{
    public class CD_Producto
    {
        // --- MÉTODO PRIVADO PARA AUDITORÍA (Modificado para soportar transacciones) ---
        private void GuardarLog(MySqlConnection conexion, int idUsuarioLogueado, string accion, string tabla, string descripcion, MySqlTransaction transaccion = null)
        {
            using (MySqlCommand cmdLog = new MySqlCommand("sp_RegistrarLog", conexion))
            {
                // Si estamos dentro de un guardado maestro-detalle, adjuntamos la transacción
                if (transaccion != null)
                {
                    cmdLog.Transaction = transaccion;
                }

                cmdLog.CommandType = CommandType.StoredProcedure;
                cmdLog.Parameters.AddWithValue("p_id_usuario", idUsuarioLogueado);
                cmdLog.Parameters.AddWithValue("p_accion", accion);
                cmdLog.Parameters.AddWithValue("p_tabla_afectada", tabla);
                cmdLog.Parameters.AddWithValue("p_descripcion", descripcion);
                cmdLog.ExecuteNonQuery();
            }
        }

        // --- MÉTODO 1: LISTAR PRODUCTOS ---
        public List<Producto> Listar()
        {
            List<Producto> lista = new List<Producto>();

            using (MySqlConnection oconexion = Conexion.obtenerConexion())
            {
                try
                {
                    string query = @"
                        SELECT p.IdProducto, p.Codigo, p.Nombre, p.Descripcion,
                               c.IdCategoria, c.Descripcion as CategoriaDescripcion,
                               p.Stock, p.PrecioVenta, p.PrecioPromocion, p.estado, p.costo_produccion
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
                                oCategoria = new Categoria()
                                {
                                    IdCategoria = Convert.ToInt32(reader["IdCategoria"]),
                                    Descripcion = reader["CategoriaDescripcion"].ToString()
                                },
                                Stock = Convert.ToInt32(reader["Stock"]),
                                PrecioVenta = Convert.ToDecimal(reader["PrecioVenta"]),
                                PrecioPromocion = reader["PrecioPromocion"] == DBNull.Value
                                                    ? (decimal?)null
                                                    : Convert.ToDecimal(reader["PrecioPromocion"]),
                                CostoProduccion = Convert.ToDecimal(reader["costo_produccion"]),
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

        // --- NUEVO MÉTODO: OBTENER RECETA DE UN PRODUCTO ---
        public List<DetalleReceta> ObtenerReceta(int idProducto)
        
            {
                List<DetalleReceta> lista = new List<DetalleReceta>();

                using (MySqlConnection oconexion = Conexion.obtenerConexion())
                {
                    try
                    {
                        // 1. QUITAMOS 'i.costo' DE LA CONSULTA
                        string query = @"
                SELECT r.idIngrediente, i.nombre, r.cantidad_requerida
                FROM receta r
                INNER JOIN ingrediente i ON r.idIngrediente = i.idIngrediente
                WHERE r.idProducto = @idProducto";

                        MySqlCommand cmd = new MySqlCommand(query, oconexion);
                        cmd.Parameters.AddWithValue("@idProducto", idProducto);
                        cmd.CommandType = CommandType.Text;

                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                lista.Add(new DetalleReceta()
                                {
                                    IdIngrediente = Convert.ToInt32(reader["idIngrediente"]),
                                    NombreIngrediente = reader["nombre"].ToString(),

                                    // 2. LO DEJAMOS EN CERO MANUALMENTE
                                    CostoUnitario = 0,

                                    CantidadRequerida = Convert.ToDecimal(reader["cantidad_requerida"])
                                });
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        // 3. MOSTRAMOS EL ERROR EN PANTALLA POR SI ACASO
                        System.Windows.Forms.MessageBox.Show("Error al consultar la receta en la BD: " + ex.Message, "Error Oculto", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
                    }
                }
                return lista;
            }

        // --- MÉTODO 2: REGISTRAR (MAESTRO - DETALLE CON TRANSACCIÓN) ---
        public int Registrar(Producto obj, int idUsuarioLogueado, out string Mensaje)
        {
            int idproductogenerado = 0;
            Mensaje = string.Empty;

            using (MySqlConnection oconexion = Conexion.obtenerConexion())
            {
                // Iniciamos la transacción
                using (MySqlTransaction transaccion = oconexion.BeginTransaction())
                {
                    try
                    {
                        // 1. REGISTRAR EL PRODUCTO
                        MySqlCommand cmd = new MySqlCommand("sp_RegistrarProducto", oconexion, transaccion);
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("p_codigo", obj.Codigo);
                        cmd.Parameters.AddWithValue("p_nombre", obj.Nombre);
                        cmd.Parameters.AddWithValue("p_descripcion", obj.Descripcion);
                        cmd.Parameters.AddWithValue("p_idcategoria", obj.oCategoria.IdCategoria);
                        cmd.Parameters.AddWithValue("p_stock", obj.Stock);
                        cmd.Parameters.AddWithValue("p_precioventa", obj.PrecioVenta);
                        cmd.Parameters.AddWithValue("p_costo_produccion", obj.CostoProduccion);
                        cmd.Parameters.AddWithValue("p_preciopromocion", obj.PrecioPromocion.HasValue ? obj.PrecioPromocion.Value : 0);

                        cmd.Parameters.Add("p_IdResultado", MySqlDbType.Int32).Direction = ParameterDirection.Output;
                        cmd.Parameters.Add("p_Mensaje", MySqlDbType.VarChar, 500).Direction = ParameterDirection.Output;

                        cmd.ExecuteNonQuery();

                        idproductogenerado = Convert.ToInt32(cmd.Parameters["p_IdResultado"].Value);
                        Mensaje = cmd.Parameters["p_Mensaje"].Value.ToString();

                        // 2. SI EL PRODUCTO SE REGISTRÓ BIEN, REGISTRAMOS SU RECETA
                        if (idproductogenerado > 0)
                        {
                            if (obj.DetallesReceta != null && obj.DetallesReceta.Count > 0)
                            {
                                foreach (DetalleReceta item in obj.DetallesReceta)
                                {
                                    string queryReceta = "INSERT INTO receta (idProducto, idIngrediente, cantidad_requerida) VALUES (@idProd, @idIng, @cant)";
                                    MySqlCommand cmdReceta = new MySqlCommand(queryReceta, oconexion, transaccion);
                                    cmdReceta.CommandType = CommandType.Text;
                                    cmdReceta.Parameters.AddWithValue("@idProd", idproductogenerado);
                                    cmdReceta.Parameters.AddWithValue("@idIng", item.IdIngrediente);
                                    cmdReceta.Parameters.AddWithValue("@cant", item.CantidadRequerida);
                                    cmdReceta.ExecuteNonQuery();
                                }
                            }

                            // 3. AUDITORÍA
                            GuardarLog(oconexion, idUsuarioLogueado, "INSERT", "producto", $"Se registró un nuevo producto: {obj.Nombre} (Código: {obj.Codigo})", transaccion);

                            // Confirmamos todos los cambios (Producto + Receta + Log)
                            transaccion.Commit();
                        }
                        else
                        {
                            // Si el SP devolvió 0 (ej. nombre duplicado), cancelamos todo
                            transaccion.Rollback();
                        }
                    }
                    catch (Exception ex)
                    {
                        // Si ocurre cualquier error en el proceso, deshacemos todo para evitar datos corruptos
                        transaccion.Rollback();
                        idproductogenerado = 0;
                        Mensaje = ex.Message;
                    }
                }
            }
            return idproductogenerado;
        }

        // --- MÉTODO 3: EDITAR (MAESTRO - DETALLE CON TRANSACCIÓN) ---
        public bool Editar(Producto obj, int idUsuarioLogueado, out string Mensaje)
        {
            bool resultado = false;
            Mensaje = string.Empty;

            using (MySqlConnection oconexion = Conexion.obtenerConexion())
            {
                using (MySqlTransaction transaccion = oconexion.BeginTransaction())
                {
                    try
                    {
                        // 1. ACTUALIZAR EL PRODUCTO
                        MySqlCommand cmd = new MySqlCommand("sp_EditarProducto", oconexion, transaccion);
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("p_idproducto", obj.IdProducto);
                        cmd.Parameters.AddWithValue("p_codigo", obj.Codigo);
                        cmd.Parameters.AddWithValue("p_nombre", obj.Nombre);
                        cmd.Parameters.AddWithValue("p_descripcion", obj.Descripcion);
                        cmd.Parameters.AddWithValue("p_idcategoria", obj.oCategoria.IdCategoria);
                        cmd.Parameters.AddWithValue("p_stock", obj.Stock);
                        cmd.Parameters.AddWithValue("p_precioventa", obj.PrecioVenta);
                        cmd.Parameters.AddWithValue("p_costo_produccion", obj.CostoProduccion);
                        cmd.Parameters.AddWithValue("p_preciopromocion", obj.PrecioPromocion.HasValue ? obj.PrecioPromocion.Value : 0);
                        cmd.Parameters.AddWithValue("p_estado", obj.Estado);

                        cmd.Parameters.Add("p_Resultado", MySqlDbType.Int32).Direction = ParameterDirection.Output;
                        cmd.Parameters.Add("p_Mensaje", MySqlDbType.VarChar, 500).Direction = ParameterDirection.Output;

                        cmd.ExecuteNonQuery();

                        resultado = Convert.ToInt32(cmd.Parameters["p_Resultado"].Value) == 1;
                        Mensaje = cmd.Parameters["p_Mensaje"].Value.ToString();

                        // 2. SI EL PRODUCTO SE ACTUALIZÓ, ACTUALIZAMOS LA RECETA
                        if (resultado)
                        {
                            // A. Borramos la receta anterior de este producto
                            MySqlCommand cmdDelete = new MySqlCommand("DELETE FROM receta WHERE idProducto = @idProd", oconexion, transaccion);
                            cmdDelete.Parameters.AddWithValue("@idProd", obj.IdProducto);
                            cmdDelete.ExecuteNonQuery();

                            // B. Insertamos la nueva receta
                            if (obj.DetallesReceta != null && obj.DetallesReceta.Count > 0)
                            {
                                foreach (DetalleReceta item in obj.DetallesReceta)
                                {
                                    string queryReceta = "INSERT INTO receta (idProducto, idIngrediente, cantidad_requerida) VALUES (@idProd, @idIng, @cant)";
                                    MySqlCommand cmdReceta = new MySqlCommand(queryReceta, oconexion, transaccion);
                                    cmdReceta.CommandType = CommandType.Text;
                                    cmdReceta.Parameters.AddWithValue("@idProd", obj.IdProducto);
                                    cmdReceta.Parameters.AddWithValue("@idIng", item.IdIngrediente);
                                    cmdReceta.Parameters.AddWithValue("@cant", item.CantidadRequerida);
                                    cmdReceta.ExecuteNonQuery();
                                }
                            }

                            // 3. AUDITORÍA
                            GuardarLog(oconexion, idUsuarioLogueado, "UPDATE", "producto", $"Se editaron los datos del producto: {obj.Nombre} (ID: {obj.IdProducto})", transaccion);

                            // Confirmamos cambios
                            transaccion.Commit();
                        }
                        else
                        {
                            transaccion.Rollback();
                        }
                    }
                    catch (Exception ex)
                    {
                        transaccion.Rollback();
                        resultado = false;
                        Mensaje = ex.Message;
                    }
                }
            }
            return resultado;
        }

        // --- MÉTODO 4: ELIMINAR (DESACTIVAR) ---
        public bool Eliminar(int idproducto, int idUsuarioLogueado, out string Mensaje)
        {
            bool resultado = false;
            Mensaje = string.Empty;

            try
            {
                using (MySqlConnection oconexion = Conexion.obtenerConexion())
                {
                    MySqlCommand cmd = new MySqlCommand("sp_EliminarProducto", oconexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("p_idproducto", idproducto);
                    cmd.Parameters.Add("p_Resultado", MySqlDbType.Int32).Direction = ParameterDirection.Output;
                    cmd.Parameters.Add("p_Mensaje", MySqlDbType.VarChar, 500).Direction = ParameterDirection.Output;

                    cmd.ExecuteNonQuery();

                    resultado = Convert.ToInt32(cmd.Parameters["p_Resultado"].Value) == 1;
                    Mensaje = cmd.Parameters["p_Mensaje"].Value.ToString();

                    if (resultado)
                    {
                        GuardarLog(oconexion, idUsuarioLogueado, "DELETE", "producto", $"Se eliminó el producto con ID: {idproducto}");
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