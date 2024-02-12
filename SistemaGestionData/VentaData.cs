using System;
using Microsoft.Data.SqlClient;
using System.Collections.Generic;
using System.Linq;
using SistemaGestionEntities;
using System.Text;
using System.Threading.Tasks;

namespace SistemaGestionData
{
    internal class VentaData
    {
        public static List<Venta> ObtenerVenta(int idVenta)
        {
            List<Venta> ventasConIdIndicado = new List<Venta>();
            string connectionString = "Server=LAPTOP-93OIOE3K;Database=coderhouse;Trusted_Connection=True;";
            var query = "SELECT Id, Comentarios, IdUsuario FROM Venta WHERE Id=@IdVenta";
            using (SqlConnection conexion = new SqlConnection(connectionString))
            {
                conexion.Open();

                using (SqlCommand comando = new SqlCommand(query, conexion))
                {
                    var parametro = new SqlParameter();
                    parametro.ParameterName = "idVenta";
                    parametro.SqlDbType = System.Data.SqlDbType.Int;
                    parametro.Value = idVenta;

                    comando.Parameters.Add(parametro);

                    using (SqlDataReader reader = comando.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                var venta = new Venta();
                                venta.Id = Convert.ToInt32(reader["ID"]);
                                venta.Comentarios = reader["Comentarios"].ToString();
                                venta.IdUsuario = Convert.ToInt32(reader["IDUsuario"]);
                                ventasConIdIndicado.Add(venta);
                            }
                        }
                    }
                }
            }
            return ventasConIdIndicado;
        }

        public static List<Venta> ListarVentas()
        {
            List<Venta> listaDeVentas = new List<Venta>();
            string connectionString = "Server=LAPTOP-93OIOE3K;Database=coderhouse;Trusted_Connection=True;";
            var query = "SELECT Id, Comentarios, IdUsuario FROM Venta WHERE Id=@IdVenta";

            using (SqlConnection conexion = new SqlConnection(connectionString))
            {
                conexion.Open();

                using (SqlCommand comando = new SqlCommand(query, conexion))
                {
                    using (SqlDataReader reader = comando.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                var venta = new Venta();
                                venta.Id = Convert.ToInt32(reader["ID"]);
                                venta.Comentarios = reader["Comentarios"].ToString();
                                venta.IdUsuario = Convert.ToInt32(reader["IDUsuario"]);
                                listaDeVentas.Add(venta);
                            }
                        }
                    }
                }
            }
            return listaDeVentas;
        }

        public static void CrearVenta(Venta venta)
        {
            string connectionString = "Server=LAPTOP-93OIOE3K;Database=coderhouse;Trusted_Connection=True;";

            var query = "INSERT INTO Venta (Id, Comentarios, IdUsuario)" +
                "VALUES (@Id, @Comentarios, @IdUsuario)";

            using (SqlConnection conexion = new SqlConnection(connectionString))
            {
                conexion.Open();
                using (SqlCommand comando = new SqlCommand(query, conexion))
                {
                    comando.Parameters.Add(new SqlParameter("Id", System.Data.SqlDbType.Int) { Value = venta.Id });
                    comando.Parameters.Add(new SqlParameter("Comentarios", System.Data.SqlDbType.VarChar) { Value = venta.Comentarios });
                    comando.Parameters.Add(new SqlParameter("IdUsuario", System.Data.SqlDbType.VarChar) { Value = venta.IdUsuario });
                }
                conexion.Close();
            }
        }

        public static void ModificarVenta(Venta venta)
        {
            string connectionString = "Server=LAPTOP-93OIOE3K;Database=coderhouse;Trusted_Connection=True;";

            var query = "UPDATE Venta" +
                        " SET Id = @Id" +
                        ", Comentarios = @Comentarios" +
                        ", IdUsuario = @IdUsuario" +
                        "WHERE Id = @Id";

            using (SqlConnection conexion = new SqlConnection(connectionString))
            {
                conexion.Open();
                using (SqlCommand comando = new SqlCommand(query, conexion))
                {
                    comando.Parameters.Add(new SqlParameter("Id", System.Data.SqlDbType.Int) { Value = venta.Id });
                    comando.Parameters.Add(new SqlParameter("Comentarios", System.Data.SqlDbType.VarChar) { Value = venta.Comentarios });
                    comando.Parameters.Add(new SqlParameter("IdUsuario", System.Data.SqlDbType.VarChar) { Value = venta.IdUsuario });
                }
                conexion.Close();
            }
        }

        public static void EliminarVenta(Venta venta)
        {
            string connectionString = "Server=LAPTOP-93OIOE3K;Database=coderhouse;Trusted_Connection=True;";

            var query = "DELETE FROM Venta WHERE Id=@Id";

            using (SqlConnection conexion = new SqlConnection(connectionString))
            {
                conexion.Open();
                using (SqlCommand comando = new SqlCommand(query, conexion))
                {
                    comando.Parameters.Add(new SqlParameter("Id", System.Data.SqlDbType.Int) { Value = venta.Id });
                }
                conexion.Close();
            }
        }
    }
}
