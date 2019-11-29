using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Dominio;
using System.Data.SqlClient;
using System.Data;

namespace ContatoAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        string connectionString = "Server=tcp:trabalhos.database.windows.net,1433;Initial Catalog=infnettrabalhos;Persist Security Info=False;User ID=andressafsilva;Password=Porcoaranh@007;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";

        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<Contato>> Get()
        {
            // Read

            var contatos = new List<Contato>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                var cmdText = "SELECT * FROM Contatos";
                var select = new SqlCommand(cmdText, connection);
                try
                {
                    connection.Open();
                    using (var reader = select.ExecuteReader(CommandBehavior.CloseConnection))
                    {
                        while (reader.Read())
                        {
                            var contato = new Contato();
                            contato.Id = (int)reader["Id"];
                            contato.Telefone = reader["Telefone"].ToString();
                            contato.Celular = reader["Celular"].ToString();

                            contatos.Add(contato);
                        }
                    }
                }
                finally
                {
                    connection.Close();
                }
            }

            return contatos;
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<Contato> Get(int id)
        {
            // Details
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string sql = "SELECT Id, Telefone, Celular FROM Contato WHERE = Id=@Id";
                SqlCommand cmd = new SqlCommand(sql, connection);
                cmd.Parameters.AddWithValue("@Id", id);
                Contato contato = null;
                try
                {
                    connection.Open();
                    using (var reader = cmd.ExecuteReader(CommandBehavior.CloseConnection))
                    {
                        if (reader.HasRows)
                        {
                            if (reader.Read())
                            {
                                contato = new Contato();
                                contato.Id = (int)reader["Id"];
                                contato.Telefone = reader["Telefone"].ToString();
                                contato.Celular = reader["Celular"].ToString();
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

                return contato;
            }
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] Contato contato)
        {
            // Create

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string cmdText = "INSERT INTO Contato (Telefone, Celular) VALUES (@Telefone, @Celular)";
                SqlCommand cmd = new SqlCommand(cmdText, connection);
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("@Telefone", contato.Telefone);
                cmd.Parameters.AddWithValue("@Celular", contato.Celular);
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
        public void Put(int id, [FromBody] Contato contato)
        {
            // Update

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string cmdText = "UPDATE Contato SET Telefone=@Telefone, Celular=@Celular WHERE Id=@Id";
                SqlCommand cmd = new SqlCommand(cmdText, connection);
                cmd.Parameters.AddWithValue("Id", contato.Id);
                cmd.Parameters.AddWithValue("Telefone", contato.Telefone);
                cmd.Parameters.AddWithValue("Celular", contato.Celular);
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

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string cmdText = "DELETE Contato WHERE Id=@Id";
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
                finally
                {
                    connection.Close();
                }
            }
        }
    }
}
