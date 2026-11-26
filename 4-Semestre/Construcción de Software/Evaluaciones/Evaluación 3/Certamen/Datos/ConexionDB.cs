using Microsoft.Data.SqlClient;

namespace StarOne.Datos;

public static class ConexionBD
{
    public static string ObtenerCadenaConexion()
    {
        // AppDomain.CurrentDomain.BaseDirectory apunta a la carpeta de ejecución (bin/Debug/net10.0/)
        string rutaBase = AppDomain.CurrentDomain.BaseDirectory;

        // Apunta a la subcarpeta BaseDatos/StarOneDB.mdf
        string rutaArchivoMdf = Path.Combine(rutaBase, "BaseDatos", "StarOneDB.mdf");
        SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder
        {
            DataSource = @"(LocalDB)\MSSQLLocalDB", // O @".\SQLEXPRESS" según el motor usado
            AttachDBFilename = rutaArchivoMdf,
            IntegratedSecurity = true,
            ConnectTimeout = 30
        };


        return builder.ConnectionString;
    }
        
    public static SqlConnection ObtenerConexion()
    {
        return new SqlConnection(ObtenerCadenaConexion());
    }

    public static bool ProbarConexion()
    {
        try
        {
            using (SqlConnection conexion = ObtenerConexion())
            {
                conexion.Open();
                return true; // Conexión establecida correctamente
            }
        }
        catch (SqlException)
        {
            return false; // Error específico de SQL Server o archivo .mdf no encontrado
        }
        catch (Exception)
        {
            return false; // Error general de ruta o driver
        }
    }
}

