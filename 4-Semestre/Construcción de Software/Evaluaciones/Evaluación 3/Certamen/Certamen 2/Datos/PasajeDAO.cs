using Microsoft.Data.SqlClient;
using StarOne.Core;
using System.Data;

namespace StarOne.Datos;

public class PasajeDAO
{
    public bool InsertarPasaje(Pasaje pasaje)
    {
        string query = @"INSERT INTO Pasajes (Nombre, Rut, Edad, NumeroVuelo, NumeroAsiento, Origen, Destino, ValorPasaje, ValorFinalConDescuento) VALUES (@Nombre, @Rut, @Edad, @NumeroVuelo, @NumeroAsiento, @Origen, @Destino, @ValorPasaje, @ValorFinalConDescuento)";

        using (SqlConnection conexion = ConexionBD.ObtenerConexion())
        using (SqlCommand cmd = new SqlCommand(query, conexion))
        {
            cmd.Parameters.AddWithValue("@Nombre", pasaje.NombreCompleto);
            cmd.Parameters.AddWithValue("@Rut", pasaje.Rut);
            cmd.Parameters.AddWithValue("@Edad", pasaje.Edad);
            cmd.Parameters.AddWithValue("@NumeroVuelo", pasaje.IDVuelo);
            cmd.Parameters.AddWithValue("@NumeroAsiento", pasaje.Asiento);
            cmd.Parameters.AddWithValue("@Origen", pasaje.Origen);
            cmd.Parameters.AddWithValue("@Destino", pasaje.Destino);
            cmd.Parameters.AddWithValue("@ValorPasaje", pasaje.PrecioBase);
            cmd.Parameters.AddWithValue("@ValorFinalConDescuento", pasaje.ValorFinal);

            return cmd.ExecuteNonQuery() > 0;
        }

    }

    public DataTable ObtenerPasajerosDesconectado()
    {
        DataTable dt = new DataTable();
        string query = "SELECT Nombre, Rut, Edad, Origen, Destino, NumeroAsiento AS Asiento, ValorPasaje, ValorFinalConDescuento AS Total FROM Pasajes";

        using (SqlConnection conexion = ConexionBD.ObtenerConexion())
        using (SqlDataAdapter adapter = new SqlDataAdapter(query, conexion))
        {
            adapter.Fill(dt);
        }
        return dt;
    }

    public DataTable BuscarPasajerosPorRutONombre(string filtro)
    {
        DataTable dt = new DataTable();
        string query = @"SELECT Id, Rut, Nombre, Edad, NumeroVuelo AS Vuelo, NumeroAsiento AS Asiento, Origen, Destino, ValorPasaje, ValorFinalConDescuento AS Total FROM Pasajes
                            FROM Pasajes 
                            WHERE Nombre LIKE @Filtro OR Rut LIKE @Filtro
                            ORDER BY Id ASC";

        using (SqlConnection conexion = ConexionBD.ObtenerConexion())
        using (SqlCommand cmd = new SqlCommand(query, conexion))
        {
            cmd.Parameters.AddWithValue("@Filtro", $"%{filtro}%");
            using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
            {
                adapter.Fill(dt);
            }
        }
        return dt;
    }

    public bool EliminarPasaje(int id)
    {
        string query = "DELETE FROM Pasajes WHERE Id = @Id";

        using (SqlConnection conexion = ConexionBD.ObtenerConexion())
        using (SqlCommand cmd = new SqlCommand(query, conexion))
        {
            cmd.Parameters.AddWithValue("@Id", id);
            return cmd.ExecuteNonQuery() > 0;
        }
    }
}
