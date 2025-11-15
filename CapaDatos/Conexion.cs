using MySql.Data.MySqlClient;
using System;
using System.Configuration;


namespace Dato
{
    public class Conexion
    {
        public static MySqlConnection obtenerConexion()
        {
            try
            {
                string cadena = ConfigurationManager.ConnectionStrings["cadena_conexion"].ConnectionString;
                MySqlConnection conexion = new MySqlConnection(cadena);
                conexion.Open();
                return conexion;
            }
            catch (Exception ex)
            {
                // En lugar de mostrar un mensaje, lanza el error hacia la capa que llamó.
                throw ex;
            }
        }
    }
}