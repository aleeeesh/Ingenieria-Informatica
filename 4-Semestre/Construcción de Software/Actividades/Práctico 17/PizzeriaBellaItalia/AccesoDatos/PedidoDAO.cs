using Microsoft.Data.SqlClient;
using PizzeriaBellaItalia.Dominio;
using System.Data;

namespace PizzeriaBellaItalia.AccesoDatos
{
    public class PedidoDAO
    {
        /// <summary>
        /// CREATE: Inserta un nuevo pedido de pizza en SQL Server Express.
        /// </summary>
        public bool InsertarPedido(PedidoPizza pedido)
        {
            string query = @"INSERT INTO Pedidos (Cliente, Telefono, TamanoNombre, TotalPagar) 
                            VALUES (@Cliente, @Telefono, @TamanoNombre, @TotalPagar)";

            using (SqlConnection conexion = ConexionBD.ObtenerConexion())
            using (SqlCommand cmd = new SqlCommand(query, conexion))
            {
                cmd.Parameters.AddWithValue("@Cliente", pedido.Cliente);
                cmd.Parameters.AddWithValue("@Telefono", pedido.Telefono);
                cmd.Parameters.AddWithValue("@TamanoNombre", pedido.TamanoNombre);
                cmd.Parameters.AddWithValue("@TotalPagar", pedido.TotalPagar);

                return cmd.ExecuteNonQuery() > 0;
            }
        }

        /// <summary>
        /// READ: Obtiene todos los pedidos registrados en un DataTable (Modelo Desconectado).
        /// </summary>
        public DataTable ObtenerPedidosDataTable()
        {
            DataTable dt = new DataTable();
            string query = "SELECT Id, Cliente, Telefono, TamanoNombre AS Tamaño, TotalPagar AS Total, FechaRegistro FROM Pedidos ORDER BY Id ASC";

            using (SqlConnection conexion = ConexionBD.ObtenerConexion())
            using (SqlDataAdapter adapter = new SqlDataAdapter(query, conexion))
            {
                adapter.Fill(dt);
            }
            return dt;
        }

        /// <summary>
        /// READ: Busca pedidos filtrando por el nombre del cliente de forma dinámica (LIKE).
        /// </summary>
        public DataTable BuscarPedidosPorCliente(string filtroCliente)
        {
            DataTable dt = new DataTable();
            string query = @"SELECT Id, Cliente, Telefono, TamanoNombre AS Tamaño, TotalPagar AS Total, FechaRegistro 
                            FROM Pedidos 
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

        /// <summary>
        /// READ: Obtiene un pedido específico por su ID primario.
        /// </summary>
        public PedidoPizza? ObtenerPedidoPorId(int id)
        {
            string query = "SELECT Id, Cliente, Telefono, TamanoNombre, TotalPagar FROM Pedidos WHERE Id = @Id";

            using (SqlConnection conexion = ConexionBD.ObtenerConexion())
            using (SqlCommand cmd = new SqlCommand(query, conexion))
            {
                cmd.Parameters.AddWithValue("@Id", id);
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        return new PedidoPizza
                        {
                            Id = Convert.ToInt32(reader["Id"]),
                            Cliente = reader["Cliente"].ToString() ?? "",
                            Telefono = reader["Telefono"].ToString() ?? "",
                            TamanoNombre = reader["TamanoNombre"].ToString() ?? "",
                            TotalPagar = Convert.ToInt32(reader["TotalPagar"])
                        };
                    }
                }
            }
            return null;
        }

        /// <summary>
        /// UPDATE: Modifica los datos de un pedido existente.
        /// </summary>
        public bool ActualizarPedido(PedidoPizza pedido)
        {
            string query = @"UPDATE Pedidos 
                            SET Cliente = @Cliente, 
                                Telefono = @Telefono, 
                                TamanoNombre = @TamanoNombre, 
                                TotalPagar = @TotalPagar 
                            WHERE Id = @Id";

            using (SqlConnection conexion = ConexionBD.ObtenerConexion())
            using (SqlCommand cmd = new SqlCommand(query, conexion))
            {
                cmd.Parameters.AddWithValue("@Id", pedido.Id);
                cmd.Parameters.AddWithValue("@Cliente", pedido.Cliente);
                cmd.Parameters.AddWithValue("@Telefono", pedido.Telefono);
                cmd.Parameters.AddWithValue("@TamanoNombre", pedido.TamanoNombre);
                cmd.Parameters.AddWithValue("@TotalPagar", pedido.TotalPagar);

                return cmd.ExecuteNonQuery() > 0;
            }
        }

        /// <summary>
        /// DELETE: Elimina un registro de pedido por su ID.
        /// </summary>
        public bool EliminarPedido(int id)
        {
            string query = "DELETE FROM Pedidos WHERE Id = @Id";

            using (SqlConnection conexion = ConexionBD.ObtenerConexion())
            using (SqlCommand cmd = new SqlCommand(query, conexion))
            {
                cmd.Parameters.AddWithValue("@Id", id);
                return cmd.ExecuteNonQuery() > 0;
            }
        }
    }
}