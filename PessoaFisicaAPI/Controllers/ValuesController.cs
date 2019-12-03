using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Dominio;
using System.Data.SqlClient;
using System.Data;

namespace PessoaFisicaAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        string connectionString = "Server=tcp:trabalhos.database.windows.net,1433;Initial Catalog=infnettrabalhos;Persist Security Info=False;User ID=andressafsilva;Password=Porcoaranh@007;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";

        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<PessoaFisica>> Get()
        {
            // Read

            var pessoaFisicas = new List<PessoaFisica>();

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
                            var pessoaFisica = new PessoaFisica();
                            pessoaFisica.Id = (int)reader["Id"];
                            pessoaFisica.Nome = reader["Nome"].ToString();
                            pessoaFisica.Sobrenome = reader["Sobrenome"].ToString();
                            pessoaFisica.NomeSocial = reader["NomeSocial"].ToString();
                            pessoaFisica.DataNascimento = (DateTime)reader["DataNascimento"];
                            pessoaFisica.CPF = reader["CPF"].ToString();
                            pessoaFisica.Genero = reader["Genero"].ToString();


                            pessoaFisicas.Add(pessoaFisica);

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

            return pessoaFisicas;
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<PessoaFisica> Get(int id)
        {
            // Details
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string sql = "SELEC Id, Nome, Sobrenome, NomeSocial, DataNascimento, CPF, Genero FROM Usuarios WHERE Id=@Id";
                SqlCommand cmd = new SqlCommand(sql, connection);
                cmd.Parameters.AddWithValue("@Id", id);
                PessoaFisica pessoaFisica = null;
                try
                {
                    connection.Open();
                    using (var reader = cmd.ExecuteReader(CommandBehavior.CloseConnection))
                    {
                        if (reader.HasRows)
                        {
                            if (reader.Read())
                            {
                                pessoaFisica = new PessoaFisica();
                                pessoaFisica.Id = (int)reader["Id"];
                                pessoaFisica.Nome = reader["Nome"].ToString();
                                pessoaFisica.Sobrenome = reader["Sobrenome"].ToString();
                                pessoaFisica.NomeSocial = reader["NomeSocial"].ToString();
                                pessoaFisica.DataNascimento = (DateTime)reader["DataNascimento"];
                                pessoaFisica.CPF = reader["CPF"].ToString();
                                pessoaFisica.Genero = reader["Genero"].ToString();
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
                return pessoaFisica;
            }
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] PessoaFisica pessoaFisica)
        {
            // Create
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string cmdText = "INSERT INTO Usuarios (Nome, Sobrenome, NomeSocial, DataNascimento, CPF, Genero) Values(@Nome, @Sobrenome, @NomeSocial, @DataNascimento, @CPF, @Genero)";
                SqlCommand cmd = new SqlCommand(cmdText, connection);
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("@Nome", pessoaFisica.Nome);
                cmd.Parameters.AddWithValue("@Sobrenome", pessoaFisica.Sobrenome);
                cmd.Parameters.AddWithValue("@NomeSocail", pessoaFisica.NomeSocial);
                cmd.Parameters.AddWithValue("@DataNascimento", pessoaFisica.DataNascimento);
                cmd.Parameters.AddWithValue("@CPF", pessoaFisica.CPF);
                cmd.Parameters.AddWithValue("@Genero", pessoaFisica.Genero);
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
        public void Put(int id, [FromBody] PessoaFisica pessoaFisica)
        {
            // Update
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string cmdText = "UPDATE Usuarios SET Nome=@Nome, Sobrenome=@Sobrenome, NomeSocial=@NomeSocial, DataNascimento=@DataNascimento, Genero=@Genero WHERE Id=@Id";
                SqlCommand cmd = new SqlCommand(cmdText, connection);
                cmd.Parameters.AddWithValue("Id", pessoaFisica.Id);
                cmd.Parameters.AddWithValue("Nome", pessoaFisica.Nome);
                cmd.Parameters.AddWithValue("Sobrenome", pessoaFisica.Sobrenome);
                cmd.Parameters.AddWithValue("NomeSocial", pessoaFisica.NomeSocial);
                cmd.Parameters.AddWithValue("DataNascimento", pessoaFisica.DataNascimento);
                cmd.Parameters.AddWithValue("CPF", pessoaFisica.CPF);
                cmd.Parameters.AddWithValue("Genero", pessoaFisica.Genero);

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
