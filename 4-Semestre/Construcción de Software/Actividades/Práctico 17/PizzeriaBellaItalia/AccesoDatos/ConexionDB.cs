using Microsoft.Data.SqlClient;

namespace PizzeriaBellaItalia.AccesoDatos
{
    public static class ConexionBD
    {
        // Cadena de conexión hacia la instancia local de SQL Express obtenida de VS 2026
        private static readonly string cadenaConexion =
            @"Server=.\SQLEXPRESS; Database=PizzeriaDB; Integrated Security=True; TrustServerCertificate=True;";

        /// <summary>
        /// Abre y retorna una conexión activa a SQL Server Express.
        /// </summary>
        public static SqlConnection ObtenerConexion()
        {
            SqlConnection conexion = new SqlConnection(cadenaConexion);
            conexion.Open();
            return conexion;
        }

        /// <summary>
        /// Prueba el estado del servicio de SQL Express e informa la disponibilidad.
        /// </summary>
        public static bool ProbarConexion()
        {
            try
            {
                using (SqlConnection conexion = ObtenerConexion())
                {
                    return conexion.State == System.Data.ConnectionState.Open;
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine($"[Error de Conexión SQL]: {ex.Message}");
                return false;
            }
        }
    }
}