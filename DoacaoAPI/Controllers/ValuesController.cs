using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Dominio;
using System.Data.SqlClient;
using System.Data;

namespace DoacaoAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        string connectionString = "Server=tcp:trabalhos.database.windows.net,1433;Initial Catalog=infnettrabalhos;Persist Security Info=False;User ID=andressafsilva;Password=Porcoaranh@007;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";

        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<Doacao>> Get()
        {
            // Read
            var doacoes = new List<Doacao>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                var cmdText = "SELECT * FROM Doacoes";
                var select = new SqlCommand(cmdText, connection);
                try
                {
                    connection.Open();
                    using (var reader = select.ExecuteReader(CommandBehavior.CloseConnection))
                    {
                        while (reader.Read())
                        {
                            var doacao = new Doacao();
                            doacao.Id = (int)reader["Id"];
                            doacao.ValorDoacao = (float)reader["ValorDoacao"];
                            doacao.MetaArrecadacao = (float)reader["MetaArrecadacao"];
                            doacao.ValorArrecadado = (float)reader["ValorArrecadado"];

                            doacoes.Add(doacao);
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

                return doacoes;
            }
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<Doacao> Get(int id)
        {
            // Details

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string sql = "SELECT Id, ValorDoacao, MetaArrecadacao, ValorArrecadado WHERE Doacoes Id=@Id";
                SqlCommand cmd = new SqlCommand(sql, connection);
                cmd.Parameters.AddWithValue("@Id", id);
                Doacao doacao = null;
                try
                {
                    connection.Open();
                    using (var reader = cmd.ExecuteReader(CommandBehavior.CloseConnection))
                    {
                        if (reader.HasRows)
                        {
                            if (reader.Read())
                            {
                                doacao = new Doacao();
                                doacao.Id = (int)reader["Id"];
                                doacao.ValorDoacao = (float)reader["ValorDoacao"];
                                doacao.MetaArrecadacao = (float)reader["MetaArrecadacao"];
                                doacao.ValorArrecadado = (float)reader["ValorArrecadado"];
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

                return doacao;
            }
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] Doacao doacao)
        {
            // Create

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string cmdText = "INSERT INTO Doacoes (ValorDoacao, MetaArrecadacao, ValorArrecadado) VALUES (@ValorDoacao, @MetaArrecadacao, @ValorArrecadado)";
                SqlCommand cmd = new SqlCommand(cmdText, connection);
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("ValorDoacao", doacao.ValorDoacao);
                cmd.Parameters.AddWithValue("MetaArrecadacao", doacao.MetaArrecadacao);
                cmd.Parameters.AddWithValue("ValorArrecadado", doacao.ValorArrecadado);
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
        public void Put(int id, [FromBody] Doacao doacao)
        {
            // Update

            using (SqlConnection connetcion = new SqlConnection(connectionString))
            {
                string cmdText = "UPDATE Doacoes SET ValorDoacao=@ValorDoacao, MetaArrecadacao=@MetaArrecadacao, ValorArrecadado=@ValorArrecadado WHERE Id=@Id";
                SqlCommand cmd = new SqlCommand(cmdText, connetcion);
                cmd.Parameters.AddWithValue("ValorDoacao", doacao.ValorDoacao);
                cmd.Parameters.AddWithValue("MetaArrecadacao", doacao.MetaArrecadacao);
                cmd.Parameters.AddWithValue("ValorArrecadado", doacao.ValorArrecadado);
                try
                {
                    connetcion.Open();
                    cmd.ExecuteNonQuery();
                }
                catch (Exception e)
                {
                    throw e;
                }
                finally
                {
                    connetcion.Close();
                }
            }
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string cmdText = "DELETE Doacoes WHERE Id=@Id";
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
