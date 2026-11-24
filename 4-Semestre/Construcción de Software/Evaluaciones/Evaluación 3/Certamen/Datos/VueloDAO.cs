using Microsoft.Data.SqlClient;
using System.Data;

namespace StarOne.Datos
{
    public class VueloDAO
    {

        public DataTable ObtenerVuelosDesconectado()
        {
            DataTable dt = new DataTable();
            string query = "SELECT IdVuelo, Codigo, Origen, Destino, Fecha, Hora, PrecioBase FROM Vuelos";

            using (SqlConnection conexion = ConexionBD.ObtenerConexion())
            using (SqlDataAdapter adapter = new SqlDataAdapter(query, conexion))
            {
                adapter.Fill(dt);
            }
            return dt;
        }
    }
}