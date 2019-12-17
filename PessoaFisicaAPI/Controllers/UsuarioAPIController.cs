using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Dominio;
using System.Data.SqlClient;
using System.Data;

namespace UsuarioAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioAPIController : ControllerBase
    {
        string connectionString = "Server=tcp:trabalhos.database.windows.net,1433;Initial Catalog=infnettrabalhos;Persist Security Info=False;User ID=andressafsilva;Password=Porcoaranh@007;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";

        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<Usuario>> Get()
        {
            // Read

            var usuarios = new List<Usuario>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                var cmdText = "SELECT * FROM Usuarios";
                SqlCommand select = new SqlCommand(cmdText, connection);
                try
                {
                    connection.Open();
                    using (var reader = select.ExecuteReader(CommandBehavior.CloseConnection))
                    {
                        while (reader.Read())
                        {
                            var usuario = new Usuario();
                            usuario.Id = (int)reader["Id"];
                            usuario.Nome = reader["Nome"].ToString();
                            usuario.Sobrenome = reader["Sobrenome"].ToString();
                            usuario.NomeSocial = reader["NomeSocial"].ToString();
                            usuario.DataNascimento = (DateTime)reader["DataNascimento"];
                            usuario.CPF = reader["CPF"].ToString();
                            usuario.Genero = reader["Genero"].ToString();

                            usuarios.Add(usuario);

                        }
                    }
                }
                catch (Exception e)
                {
                    throw e;
                }
                finally
                {
                    connection.Close();
                }
            }

            return usuarios;
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<Usuario> Get(int id)
        {
            // Details
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string sql = "SELECT Id, Nome, Sobrenome, NomeSocial, DataNascimento, CPF, Genero FROM Usuarios WHERE Id=@Id";
                SqlCommand cmd = new SqlCommand(sql, connection);
                cmd.Parameters.AddWithValue("@Id", id);
                Usuario usuario = null;
                try
                {
                    connection.Open();
                    using (var reader = cmd.ExecuteReader(CommandBehavior.CloseConnection))
                    {
                        if (reader.HasRows)
                        {
                            if (reader.Read())
                            {
                                usuario = new Usuario();
                                usuario.Id = (int)reader["Id"];
                                usuario.Nome = reader["Nome"].ToString();
                                usuario.Sobrenome = reader["Sobrenome"].ToString();
                                usuario.NomeSocial = reader["NomeSocial"].ToString();
                                usuario.DataNascimento = (DateTime)reader["DataNascimento"];
                                usuario.CPF = reader["CPF"].ToString();
                                usuario.Genero = reader["Genero"].ToString();
                            }
                        }
                    }
                }
                catch (Exception e)
                {
                    throw e;
                }
                finally
                {
                    connection.Close();
                }
                return usuario;
            }
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] Usuario usuario)
        {
            // Create
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string cmdText = "INSERT INTO Usuarios (Nome, Sobrenome, NomeSocial, DataNascimento, CPF, Genero) Values(@Nome, @Sobrenome, @NomeSocial, @DataNascimento, @CPF, @Genero)";
                SqlCommand cmd = new SqlCommand(cmdText, connection);
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("@Nome", usuario.Nome);
                cmd.Parameters.AddWithValue("@Sobrenome", usuario.Sobrenome);
                cmd.Parameters.AddWithValue("@NomeSocial", usuario.NomeSocial);
                cmd.Parameters.AddWithValue("@DataNascimento", usuario.DataNascimento);
                cmd.Parameters.AddWithValue("@CPF", usuario.CPF);
                cmd.Parameters.AddWithValue("@Genero", usuario.Genero);
                try
                {
                    connection.Open();
                    cmd.ExecuteNonQuery();
                }
                catch (Exception e)
                {
                    throw e;
                }
                finally
                {
                    connection.Close();
                }
            }
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Usuario usuario)
        {
            // Update
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string cmdText = "UPDATE Usuarios SET Nome=@Nome, Sobrenome=@Sobrenome, NomeSocial=@NomeSocial, DataNascimento=@DataNascimento, Genero=@Genero WHERE Id=@Id";
                SqlCommand cmd = new SqlCommand(cmdText, connection);
                cmd.Parameters.AddWithValue("Id", usuario.Id);
                cmd.Parameters.AddWithValue("Nome", usuario.Nome);
                cmd.Parameters.AddWithValue("Sobrenome", usuario.Sobrenome);
                cmd.Parameters.AddWithValue("NomeSocial", usuario.NomeSocial);
                cmd.Parameters.AddWithValue("DataNascimento", usuario.DataNascimento);
                cmd.Parameters.AddWithValue("CPF", usuario.CPF);
                cmd.Parameters.AddWithValue("Genero", usuario.Genero);

                try
                {
                    connection.Open();
                    cmd.ExecuteNonQuery();
                }
                catch (Exception e)
                {
                    throw e;
                }
            }
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string cmdText = "DELETE Usuarios WHERE Id=@Id";
                SqlCommand cmd = new SqlCommand(cmdText, connection);
                cmd.Parameters.AddWithValue("Id", id);
                try
                {
                    connection.Open();
                    cmd.ExecuteNonQuery();
                }
                catch (Exception e)
                {
                    throw e;
                }
            }
        }
    }
}
