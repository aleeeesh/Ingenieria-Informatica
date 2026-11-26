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

            conexion.Open();
            return cmd.ExecuteNonQuery() > 0;
        }

    }

    public DataTable ObtenerPasajesDesconectado()
    {
        DataTable dt = new DataTable();

        string query = "SELECT IdPasaje, Nombre, Rut, Edad, Origen, Destino, NumeroAsiento AS Asiento, ValorPasaje, ValorFinalConDescuento AS Total FROM Pasajes ORDER BY IdPasaje ASC";

        using (SqlConnection conexion = ConexionBD.ObtenerConexion())
        using (SqlDataAdapter adapter = new SqlDataAdapter(query, conexion))
        {
            adapter.Fill(dt);
        }
        return dt;
    }

    public DataTable BuscarPasajesPorRutONombre(string filtro)
    {
        DataTable dt = new DataTable();

        string query = @"SELECT IdPasaje, Nombre, Rut, Edad, Origen, Destino, NumeroAsiento AS Asiento, ValorPasaje, ValorFinalConDescuento AS Total FROM Pasajes WHERE Nombre LIKE @Filtro OR Rut LIKE @Filtro ORDER BY IdPasaje ASC";

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
        string query = "DELETE FROM Pasajes WHERE IdPasaje = @IdPasaje";

        using (SqlConnection conexion = ConexionBD.ObtenerConexion())
        using (SqlCommand cmd = new SqlCommand(query, conexion))
        {
            cmd.Parameters.AddWithValue("@IdPasaje", id);

            conexion.Open();
            return cmd.ExecuteNonQuery() > 0;
        }
    }
}