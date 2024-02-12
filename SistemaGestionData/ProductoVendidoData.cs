using System;
using Microsoft.Data.SqlClient;
using SistemaGestionEntities;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaGestionData
{
    internal class ProductoVendidoData
    {
        public static List<ProductoVendido> ObtenerProductoVendido(int idProductoVendido)
        {
            List<ProductoVendido> productosVendidosConIdIndicado = new List<ProductoVendido>();
            string connectionString = "Server=LAPTOP-93OIOE3K;Database=coderhouse;Trusted_Connection=True;";
            var query = "SELECT Id, IdProducto, Stock, IdVenta FROM ProductoVendido WHERE Id=@IdProducto";
            using (SqlConnection conexion = new SqlConnection(connectionString))
            {
                conexion.Open();

                using (SqlCommand comando = new SqlCommand(query, conexion))
                {
                    var parametro = new SqlParameter();
                    parametro.ParameterName = "IdProducto";
                    parametro.SqlDbType = System.Data.SqlDbType.Int;
                    parametro.Value = idProductoVendido;

                    comando.Parameters.Add(parametro);

                    using (SqlDataReader reader = comando.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                var productoVendido = new ProductoVendido();
                                productoVendido.Id = Convert.ToInt32(reader["Id"]);
                                productoVendido.IdProducto = Convert.ToInt32(reader["IdProducto"]);
                                productoVendido.Stock = (int)Convert.ToDecimal(reader["Stock"]);
                                productoVendido.IdVenta = Convert.ToInt32(reader["IdVenta"]);
                                productosVendidosConIdIndicado.Add(productoVendido);
                            }
                        }
                    }
                }
            }
            return productosVendidosConIdIndicado;
        }

        public static List<ProductoVendido> ListarProductosVendidos()
        {
            List<ProductoVendido> listaDeProductosVendidos = new List<ProductoVendido>();
            string connectionString = "Server=LAPTOP-93OIOE3K;Database=coderhouse;Trusted_Connection=True;";
            var query = "SELECT Id, IdProducto, Stock, IdVenta FROM ProductoVendido";

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
                                var productoVendido = new ProductoVendido();
                                productoVendido.Id = Convert.ToInt32(reader["Id"]);
                                productoVendido.IdProducto = Convert.ToInt32(reader["IdProducto"]);
                                productoVendido.Stock = (int)Convert.ToDecimal(reader["Stock"]);
                                productoVendido.IdVenta = Convert.ToInt32(reader["IdVenta"]);
                                listaDeProductosVendidos.Add(productoVendido);
                            }
                        }
                    }
                }
            }
            return listaDeProductosVendidos;
        }

        public static void CrearProductoVendido(ProductoVendido productoVendido)
        {
            string connectionString = "Server=LAPTOP-93OIOE3K;Database=coderhouse;Trusted_Connection=True;";

            var query = "INSERT INTO ProductoVendido (@Id, @IdProducto, @Stock, @IdVenta)" +
                "VALUES (@Id, @IdProducto, @Stock, @IdVenta)";

            using (SqlConnection conexion = new SqlConnection(connectionString))
            {
                conexion.Open();
                using (SqlCommand comando = new SqlCommand(query, conexion))
                {
                    //Reformular
                    comando.Parameters.Add(new SqlParameter("Id", System.Data.SqlDbType.Int) { Value = productoVendido.Id });
                    comando.Parameters.Add(new SqlParameter("IdProducto", System.Data.SqlDbType.Int) { Value = productoVendido.IdProducto }); ;
                    comando.Parameters.Add(new SqlParameter("Stock", System.Data.SqlDbType.Int) { Value = productoVendido.Stock });
                    comando.Parameters.Add(new SqlParameter("IdVenta", System.Data.SqlDbType.Int) { Value = productoVendido.IdVenta });
                }
                conexion.Close();
            }
        }

        public static void ModificarProductoVendido(ProductoVendido productoVendido)
        {
            string connectionString = "Server=LAPTOP-93OIOE3K;Database=coderhouse;Trusted_Connection=True;";

            var query = "UPDATE ProductoVendido" +
                        //reformular aca
                        " SET Id = @Id" +
                        ", IdProducto = @IdProducto" +
                        ", Stock = @Stock" +
                        ", IdVenta = @IdVenta" +
                        "WHERE Id = @Id";

            using (SqlConnection conexion = new SqlConnection(connectionString))
            {
                conexion.Open();
                using (SqlCommand comando = new SqlCommand(query, conexion))
                {
                    comando.Parameters.Add(new SqlParameter("Id", System.Data.SqlDbType.Int) { Value = productoVendido.Id });
                    comando.Parameters.Add(new SqlParameter("IdProducto", System.Data.SqlDbType.Int) { Value = productoVendido.IdProducto }); ;
                    comando.Parameters.Add(new SqlParameter("Stock", System.Data.SqlDbType.Int) { Value = productoVendido.Stock });
                    comando.Parameters.Add(new SqlParameter("IdVenta", System.Data.SqlDbType.Int) { Value = productoVendido.IdVenta });
                }
                conexion.Close();
            }
        }

        public static void EliminarProductoVendido(ProductoVendido productoVendido)
        {
            string connectionString = "Server=LAPTOP-93OIOE3K;Database=coderhouse;Trusted_Connection=True;";

            var query = "DELETE FROM ProductoVendido WHERE Id=@Id";

            using (SqlConnection conexion = new SqlConnection(connectionString))
            {
                conexion.Open();
                using (SqlCommand comando = new SqlCommand(query, conexion))
                {
                    comando.Parameters.Add(new SqlParameter("Id", System.Data.SqlDbType.Int) { Value = productoVendido.Id });
                }
                conexion.Close();
            }
        }
    }
}
