using Microsoft.Data.SqlClient;
using SistemaGestionEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaGestionData
{
    internal class ProductoData
    {
        public static List<Producto> ObtenerProducto(int idProducto)
        {
            List<Producto> productosConIdIndicado = new List<Producto>();
            string connectionString = "Server=LAPTOP-93OIOE3K;Database=coderhouse;Trusted_Connection=True;";
            var query = "SELECT Id, Descripcion, Costo, NombreProducto, PrecioVenta, Stock, IdUsuario FROM Producto WHERE Id=@IdProducto";
            using (SqlConnection conexion = new SqlConnection(connectionString))
            {
                conexion.Open();

                using (SqlCommand comando = new SqlCommand(query, conexion))
                {
                    var parametro = new SqlParameter();
                    parametro.ParameterName = "IdProducto";
                    parametro.SqlDbType = System.Data.SqlDbType.Int;
                    parametro.Value = idProducto;

                    comando.Parameters.Add(parametro);

                    using (SqlDataReader reader = comando.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                var producto = new Producto();
                                producto.Id = Convert.ToInt32(reader["Id"]);
                                producto.Descripcion = reader["Descripciones"].ToString();
                                producto.Costo = (double)Convert.ToDecimal(reader["Costo"]);
                                producto.PrecioVenta = (double)Convert.ToDecimal(reader["PrecioVenta"]);
                                producto.Stock = (int)Convert.ToDecimal(reader["Stock"]);
                                producto.IdUsuario = Convert.ToInt32(reader["IdUsuario"]);
                                productosConIdIndicado.Add(producto);
                            }
                        }
                    }
                }
            }
            return productosConIdIndicado;
        }

        public static List<Producto> ListarProductos()
        {
            List<Producto> listaDeProductos = new List<Producto>();
            string connectionString = "Server=LAPTOP-93OIOE3K;Database=coderhouse;Trusted_Connection=True;";
            var query = "SELECT Id, Descripcion, Costo, NombreProducto, PrecioVenta, Stock, IdUsuario FROM Producto";

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
                                var producto = new Producto();
                                producto.Id = Convert.ToInt32(reader["Id"]);
                                producto.Descripcion = reader["Descripciones"].ToString();
                                producto.Costo = (double)Convert.ToDecimal(reader["Costo"]);
                                producto.PrecioVenta = (double)Convert.ToDecimal(reader["PrecioVenta"]);
                                producto.Stock = (int)Convert.ToDecimal(reader["Stock"]);
                                producto.IdUsuario = Convert.ToInt32(reader["IdUsuario"]);
                                listaDeProductos.Add(producto);
                            }
                        }
                    }
                }
            }
            return listaDeProductos;
        }

        public static void CrearProducto(Producto producto)
        {
            string connectionString = "Server=LAPTOP-93OIOE3K;Database=coderhouse;Trusted_Connection=True;";

            var query = "INSERT INTO Producto (Descripcion, Costo, PrecioVenta, Stock, IdUsuario)" +
                "VALUES (@Descripcion, @Costo, @PrecioVenta, @Stock, @IdUsuario)";

            using (SqlConnection conexion = new SqlConnection(connectionString))
            {
                conexion.Open();
                using (SqlCommand comando = new SqlCommand(query, conexion))
                {
                    //Reformular
                    comando.Parameters.Add(new SqlParameter("Descripcion", System.Data.SqlDbType.VarChar) { Value = producto.Descripcion });
                    comando.Parameters.Add(new SqlParameter("Costo", System.Data.SqlDbType.Money) { Value = producto.Costo }); ;
                    comando.Parameters.Add(new SqlParameter("PrecioVenta", System.Data.SqlDbType.Money) { Value = producto.PrecioVenta });
                    comando.Parameters.Add(new SqlParameter("Stock", System.Data.SqlDbType.Int) { Value = producto.Stock });
                    comando.Parameters.Add(new SqlParameter("IdUsuario", System.Data.SqlDbType.VarChar) { Value = producto.IdUsuario });
                }
                conexion.Close();
            }
        }

        public static void ModificarProducto(Producto producto)
        {
            string connectionString = "Server=LAPTOP-93OIOE3K;Database=coderhouse;Trusted_Connection=True;";

            var query = "UPDATE Producto" +
                        //reformular aca
                        " SET Descripcion = @Descripcion" +
                        ", Costo = @Costo" +
                        ", PrecioVenta = @PrecioVenta" +
                        ", Stock = @Stock" +
                        ", IdUsuario = @IdUsuario" +
                        "WHERE Id = @Id";

            using (SqlConnection conexion = new SqlConnection(connectionString))
            {
                conexion.Open();
                using (SqlCommand comando = new SqlCommand(query, conexion))
                {
                    //reformular aca
                    comando.Parameters.Add(new SqlParameter("Id", System.Data.SqlDbType.Int) { Value = producto.Id });
                    comando.Parameters.Add(new SqlParameter("Descripcion", System.Data.SqlDbType.VarChar) { Value = producto.Descripcion });
                    comando.Parameters.Add(new SqlParameter("Costo", System.Data.SqlDbType.Money) { Value = producto.Costo }); ;
                    comando.Parameters.Add(new SqlParameter("PrecioVenta", System.Data.SqlDbType.Money) { Value = producto.PrecioVenta });
                    comando.Parameters.Add(new SqlParameter("Stock", System.Data.SqlDbType.Int) { Value = producto.Stock });
                    comando.Parameters.Add(new SqlParameter("IdUsuario", System.Data.SqlDbType.VarChar) { Value = producto.IdUsuario });
                }
                conexion.Close();
            }
        }

        public static void EliminarProducto(Producto producto)
        {
            string connectionString = "Server=LAPTOP-93OIOE3K;Database=coderhouse;Trusted_Connection=True;";

            var query = "DELETE FROM Producto WHERE Id=@Id";

            using (SqlConnection conexion = new SqlConnection(connectionString))
            {
                conexion.Open();
                using (SqlCommand comando = new SqlCommand(query, conexion))
                {
                    comando.Parameters.Add(new SqlParameter("Id", System.Data.SqlDbType.Int) { Value = producto.Id });
                }
                conexion.Close();
            }
        }
    }
}
