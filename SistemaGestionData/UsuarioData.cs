using System;
using Microsoft.Data.SqlClient;
using System.Collections.Generic;
using SistemaGestionEntities;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaGestionData
{
    internal class UsuarioData
    {
        public static List<Usuario> ObtenerUsuario(int idUsuario)
        {
            List<Usuario> usuariosConIdIndicado = new List<Usuario>();
            string connectionString = "Server=LAPTOP-93OIOE3K;Database=coderhouse;Trusted_Connection=True;";
            var query = "SELECT Id, Nombre, Apellido, NombreUsuario, Contrasenia, Mail FROM Usuario WHERE Id=@IdUsuario";
            using (SqlConnection conexion = new SqlConnection(connectionString))
            {
                conexion.Open();

                using (SqlCommand comando = new SqlCommand(query, conexion))
                {
                    var parametro = new SqlParameter();
                    parametro.ParameterName = "idUsuario";
                    parametro.SqlDbType = System.Data.SqlDbType.Int;
                    parametro.Value = idUsuario;

                    comando.Parameters.Add(parametro);

                    using (SqlDataReader reader = comando.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                var usuario = new Usuario();
                                usuario.Id = Convert.ToInt32(reader["ID"]);
                                usuario.Nombre = reader["Nombre"].ToString();
                                usuario.Apellido = reader["Apellido"].ToString();
                                usuario.NombreUsuario = reader["NombreUsuario"].ToString();
                                usuario.Contrasenia = reader["Contrasenia"].ToString();
                                usuario.Mail = reader["Mail"].ToString();
                                usuariosConIdIndicado.Add(usuario);
                            }
                        }
                    }
                }
            }
            return usuariosConIdIndicado;
        }

        public static List<Usuario> ListarUsuarios()
        {
            List<Usuario> listaDeUsuarios = new List<Usuario>();
            string connectionString = "Server=LAPTOP-93OIOE3K;Database=coderhouse;Trusted_Connection=True;";
            var query = "SELECT Id, Nombre, Apellido, NombreUsuario, Contrasenia, Mail FROM Usuario";

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
                                var usuario = new Usuario();
                                usuario.Id = Convert.ToInt32(reader["ID"]);
                                usuario.Nombre = reader["Nombre"].ToString();
                                usuario.Apellido = reader["Apellido"].ToString();
                                usuario.NombreUsuario = reader["NombreUsuario"].ToString();
                                usuario.Contrasenia = reader["Contrasenia"].ToString();
                                usuario.Mail = reader["Mail"].ToString();
                                listaDeUsuarios.Add(usuario);
                            }
                        }
                    }
                }
            }
            return listaDeUsuarios;
        }

        public static void CrearUsuario(Usuario usuario)
        {
            string connectionString = "Server=LAPTOP-93OIOE3K;Database=coderhouse;Trusted_Connection=True;";

            var query = "INSERT INTO Usuario (Id, Nombre, Apellido, NombreUsuario, Contrasenia, Mail)" +
                "VALUES (@Id, @Nombre, @Apellido, @NombreUsuario, @Contrasenia, @Mail)";

            using (SqlConnection conexion = new SqlConnection(connectionString))
            {
                conexion.Open();
                using (SqlCommand comando = new SqlCommand(query, conexion))
                {
                    comando.Parameters.Add(new SqlParameter("Id", System.Data.SqlDbType.Int) { Value = usuario.Id });
                    comando.Parameters.Add(new SqlParameter("Nombre", System.Data.SqlDbType.VarChar) { Value = usuario.Nombre });
                    comando.Parameters.Add(new SqlParameter("Apellido", System.Data.SqlDbType.VarChar) { Value = usuario.Apellido });
                    comando.Parameters.Add(new SqlParameter("NombreUsuario", System.Data.SqlDbType.VarChar) { Value = usuario.NombreUsuario });
                    comando.Parameters.Add(new SqlParameter("Contrasenia", System.Data.SqlDbType.VarChar) { Value = usuario.Contrasenia });
                    comando.Parameters.Add(new SqlParameter("Mail", System.Data.SqlDbType.VarChar) { Value = usuario.Mail });
                }
                conexion.Close();
            }
        }

        public static void ModificarUsuario(Usuario usuario)
        {
            string connectionString = "Server=LAPTOP-93OIOE3K;Database=coderhouse;Trusted_Connection=True;";

            var query = "UPDATE Usuario" +
                        " SET Nombre = @Nombre" +
                        ", Apellido = @Apellido" +
                        ", NombreUsuario = @NombreUsuario" +
                        ", Contrasenia = @Contrasenia" +
                        ", Mail = @Mail" +
                        "WHERE Id = @Id";

            using (SqlConnection conexion = new SqlConnection(connectionString))
            {
                conexion.Open();
                using (SqlCommand comando = new SqlCommand(query, conexion))
                {
                    comando.Parameters.Add(new SqlParameter("Id", System.Data.SqlDbType.Int) { Value = usuario.Id });
                    comando.Parameters.Add(new SqlParameter("Nombre", System.Data.SqlDbType.VarChar) { Value = usuario.Nombre });
                    comando.Parameters.Add(new SqlParameter("Apellido", System.Data.SqlDbType.VarChar) { Value = usuario.Apellido });
                    comando.Parameters.Add(new SqlParameter("NombreUsuario", System.Data.SqlDbType.VarChar) { Value = usuario.NombreUsuario });
                    comando.Parameters.Add(new SqlParameter("Contrasenia", System.Data.SqlDbType.VarChar) { Value = usuario.Contrasenia });
                    comando.Parameters.Add(new SqlParameter("Mail", System.Data.SqlDbType.VarChar) { Value = usuario.Mail });
                }
                conexion.Close();
            }
        }

        public static void EliminarUsuario(Usuario usuario)
        {
            string connectionString = "Server=LAPTOP-93OIOE3K;Database=coderhouse;Trusted_Connection=True;";

            var query = "DELETE FROM Usuario WHERE Id=@Id";

            using (SqlConnection conexion = new SqlConnection(connectionString))
            {
                conexion.Open();
                using (SqlCommand comando = new SqlCommand(query, conexion))
                {
                    comando.Parameters.Add(new SqlParameter("Id", System.Data.SqlDbType.Int) { Value = usuario.Id });
                }
                conexion.Close();
            }
        }
    }
}
