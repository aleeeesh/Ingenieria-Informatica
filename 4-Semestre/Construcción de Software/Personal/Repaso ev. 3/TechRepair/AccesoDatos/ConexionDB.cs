using Microsoft.Data.SqlClient;

namespace TechRepair.AccesoDatos
{
    public static class ConexionBD
    {
        private static readonly string cadenaConexion = $@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename={System.IO.Path.GetFullPath(AppDomain.CurrentDomain.BaseDirectory + @"..\..\..\AccesoDatos\TechRepairDB.mdf")};Integrated Security=True;Connect Timeout=30;Encrypt=False";
        public static SqlConnection ObtenerConexion()
        {
            SqlConnection conexion = new SqlConnection(cadenaConexion);
            conexion.Open();
            return conexion;
        }

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
                Console.WriteLine($"[Error SQL]: {ex.Message}");
                return false;
            }
        }
    }
}