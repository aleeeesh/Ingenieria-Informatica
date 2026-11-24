using Microsoft.Data.SqlClient;
using System.Data;
using TechRepair.Dominio;

namespace TechRepair.AccesoDatos
{
    public class OrdenServicioDAO
    {
        public bool InsertarOrden(OrdenServicio orden)
        {
            string query = @"INSERT INTO OrdenesServicio (Cliente, Telefono, TipoEquipo, ServicioBase, LimpiezaProfunda, CambioPasta, InstalacionSoftware, RespaldoDatos, EsDomicilio, EsClienteFrecuente, TotalPagar) VALUES (@Cliente, @Telefono, @TipoEquipo, @ServicioBase, @LimpiezaProfunda, @CambioPasta, @InstalacionSoftware, @RespaldoDatos, @EsDomicilio, @EsClienteFrecuente, @TotalPagar)";

            using (SqlConnection conexion = ConexionBD.ObtenerConexion())
            using (SqlCommand cmd = new SqlCommand(query, conexion))
            {
                cmd.Parameters.AddWithValue("@Cliente", orden.Cliente);
                cmd.Parameters.AddWithValue("@Telefono", orden.Telefono);
                cmd.Parameters.AddWithValue("@TipoEquipo", orden.TipoEquipo);
                cmd.Parameters.AddWithValue("@ServicioBase", orden.ServicioBase);
                cmd.Parameters.AddWithValue("@LimpiezaProfunda", orden.LimpiezaProfunda);
                cmd.Parameters.AddWithValue("@CambioPasta", orden.CambioPasta);
                cmd.Parameters.AddWithValue("@InstalacionSoftware", orden.InstalacionSoftware);
                cmd.Parameters.AddWithValue("@RespaldoDatos", orden.RespaldoDatos);
                cmd.Parameters.AddWithValue("@EsDomicilio", orden.EsDomicilio);
                cmd.Parameters.AddWithValue("@EsClienteFrecuente", orden.EsClienteFrecuente);
                cmd.Parameters.AddWithValue("@TotalPagar", Convert.ToInt32(orden.CalcularTotalPagar()));

                return cmd.ExecuteNonQuery() > 0;
            }
        }

        public DataTable ObtenerOrdenesDataTable()
        {
            DataTable dt = new DataTable();
            string query = "SELECT Id, Cliente, Telefono, TipoEquipo AS Equipo, ServicioBase AS Servicio, TotalPagar AS Total, FechaIngreso FROM OrdenesServicio ORDER BY Id ASC";

            using (SqlConnection conexion = ConexionBD.ObtenerConexion())
            using (SqlDataAdapter adapter = new SqlDataAdapter(query, conexion))
            {
                adapter.Fill(dt);
            }
            return dt;
        }

        public DataTable BuscarOrdenesPorCliente(string filtroCliente)
        {
            DataTable dt = new DataTable();
            string query = @"SELECT Id, Cliente, Telefono, TipoEquipo AS Equipo, ServicioBase AS Servicio, TotalPagar AS Total, FechaIngreso
                            FROM OrdenesServicio 
                            WHERE Cliente LIKE @Filtro 
                            ORDER BY Id ASC";

            using (SqlConnection conexion = ConexionBD.ObtenerConexion())
            using (SqlCommand cmd = new SqlCommand(query, conexion))
            {
                cmd.Parameters.AddWithValue("@Filtro", $"%{filtroCliente}%");
                using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                {
                    adapter.Fill(dt);
                }
            }
            return dt;
        }

        public OrdenServicio? ObtenerOrdenPorId(int id)
        {
            string query = "SELECT Id, Cliente, Telefono, TipoEquipo AS Equipo, ServicioBase AS Servicio, LimpiezaProfunda, CambioPasta, InstalacionSoftware, RespaldoDatos, EsDomicilio, EsClienteFrecuente, TotalPagar AS Total, FechaIngreso FROM OrdenesServicio WHERE Id = @Id";

            using (SqlConnection conexion = ConexionBD.ObtenerConexion())
            using (SqlCommand cmd = new SqlCommand(query, conexion))
            {
                cmd.Parameters.AddWithValue("@Id", id);
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        return new OrdenServicio
                        {
                            Id = Convert.ToInt32(reader["Id"]),
                            Cliente = reader["Cliente"].ToString() ?? "",
                            Telefono = reader["Telefono"].ToString() ?? "",
                            TipoEquipo = reader["Equipo"].ToString() ?? "",
                            ServicioBase = reader["Servicio"].ToString() ?? "",
                            LimpiezaProfunda = Convert.ToBoolean(reader["LimpiezaProfunda"]),
                            CambioPasta = Convert.ToBoolean(reader["CambioPasta"]),
                            InstalacionSoftware = Convert.ToBoolean(reader["InstalacionSoftware"]),
                            RespaldoDatos = Convert.ToBoolean(reader["RespaldoDatos"]),
                            EsDomicilio = Convert.ToBoolean(reader["EsDomicilio"]),
                            EsClienteFrecuente = Convert.ToBoolean(reader["EsClienteFrecuente"]),
                            TotalPagar = Convert.ToInt32(reader["Total"])
                        };
                    }
                }
            }
            return null;
        }

        public bool ActualizarOrden(OrdenServicio orden)
        {
            string query = @"UPDATE OrdenesServicio 
                            SET Cliente = @Cliente, 
                                Telefono = @Telefono, 
                                TipoEquipo = @TipoEquipo,
                                ServicioBase = @ServicioBase,
                                LimpiezaProfunda = @LimpiezaProfunda,
                                CambioPasta = @CambioPasta,
                                InstalacionSoftware = @InstalacionSoftware,
                                RespaldoDatos = @RespaldoDatos,
                                EsDomicilio = @EsDomicilio,
                                EsClienteFrecuente = @EsClienteFrecuente,
                                TotalPagar = @TotalPagar 
                            WHERE Id = @Id";

            using (SqlConnection conexion = ConexionBD.ObtenerConexion())
            using (SqlCommand cmd = new SqlCommand(query, conexion))
            {
                cmd.Parameters.AddWithValue("@Id", orden.Id);
                cmd.Parameters.AddWithValue("@Cliente", orden.Cliente);
                cmd.Parameters.AddWithValue("@Telefono", orden.Telefono);
                cmd.Parameters.AddWithValue("@TipoEquipo", orden.TipoEquipo);
                cmd.Parameters.AddWithValue("@ServicioBase", orden.ServicioBase);
                cmd.Parameters.AddWithValue("@LimpiezaProfunda", orden.LimpiezaProfunda);
                cmd.Parameters.AddWithValue("@CambioPasta", orden.CambioPasta);
                cmd.Parameters.AddWithValue("@InstalacionSoftware", orden.InstalacionSoftware);
                cmd.Parameters.AddWithValue("@RespaldoDatos", orden.RespaldoDatos);
                cmd.Parameters.AddWithValue("@EsDomicilio", orden.EsDomicilio);
                cmd.Parameters.AddWithValue("@EsClienteFrecuente", orden.EsClienteFrecuente);
                cmd.Parameters.AddWithValue("@TotalPagar", Convert.ToInt32(orden.CalcularTotalPagar()));

                return cmd.ExecuteNonQuery() > 0;
            }
        }

        public bool EliminarOrden(int id)
        {
            string query = "DELETE FROM OrdenesServicio WHERE Id = @Id";

            using (SqlConnection conexion = ConexionBD.ObtenerConexion())
            using (SqlCommand cmd = new SqlCommand(query, conexion))
            {
                cmd.Parameters.AddWithValue("@Id", id);
                return cmd.ExecuteNonQuery() > 0;
            }
        }
    }
}