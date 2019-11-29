using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Dominio;
using System.Data.SqlClient;
using System.Data;

namespace ArrecadacaoAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        string connectionString = "Server=tcp:trabalhos.database.windows.net,1433;Initial Catalog=infnettrabalhos;Persist Security Info=False;User ID=andressafsilva;Password=Porcoaranh@007;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";

        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<Arrecadacao>> Get()
        {
            //Read

            var arrecadacoes = new List<Arrecadacao>();

            using (var connection = new SqlConnection(connectionString))
            {
                var cmdText = "SELECT * FROM Arrecadacoes";
                var select = new SqlCommand(cmdText, connection);

                try
                {
                    connection.Open();
                    using (var reader = select.ExecuteReader(CommandBehavior.CloseConnection))
                    {
                        while (reader.Read())
                        {
                            var arrecadacao = new Arrecadacao();
                            arrecadacao.Id = (int)reader["Id"];
                            arrecadacao.QtdParticipantes = (int)reader["QtdParticipantes"];
                            arrecadacao.QtdAlimento = (float)reader["QtdAlimento"];
                            arrecadacao.MetaArrecadacao = (float)reader["MetaArrecadacao"];
                            arrecadacao.PublicoAlvo = (int)reader["PublicoAlvo"];

                            arrecadacoes.Add(arrecadacao);

                        }

                    }
                }
                finally
                {
                    connection.Close();
                }

            }
            return arrecadacoes;
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<Arrecadacao> Get(int id)
        {
            // Details

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string sql = "SELECT Id, QtdParticipantes, QtdAlimento, MetaArrecadacao, PublicoAlvo FROM Arrecadacoes Where Id=@Id";
                SqlCommand cmd = new SqlCommand(sql, connection);
                cmd.Parameters.AddWithValue("@Id", id);
                Arrecadacao arrecadacao = null;

                try
                {
                    connection.Open();
                    using (var reader = cmd.ExecuteReader(CommandBehavior.CloseConnection))
                    {
                        if (reader.HasRows)
                        {
                            if (reader.Read())
                            {
                                arrecadacao = new Arrecadacao();
                                arrecadacao.Id = (int)reader["Id"];
                                arrecadacao.QtdParticipantes = (int)reader["QtdParticipantes"];
                                arrecadacao.QtdAlimento = (float)reader["QtdAlimento"];
                                arrecadacao.MetaArrecadacao = (float)reader["MetaArrecadacao"];
                                arrecadacao.PublicoAlvo = (int)reader["PublicoAlvo"];
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
                return arrecadacao;
            }
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] Arrecadacao arrecadacao)
        {
            //create

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string cmdTex = "INSERT INTO Arrecadacao (QtdParticipantes, QtdAlimento, MetaArrecadacao) VALUES(@QtdParticipantes, @QtdAlimento, @MetaArrecadacao)";
                SqlCommand cmd = new SqlCommand(cmdTex, connection);
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("@QtdParticipantes", arrecadacao.QtdParticipantes);
                cmd.Parameters.AddWithValue("@QtdAlimento", arrecadacao.QtdAlimento);
                cmd.Parameters.AddWithValue("@MetaArrecadacao", arrecadacao.MetaArrecadacao);
                cmd.Parameters.AddWithValue("@PublicoAlvo", arrecadacao.PublicoAlvo);

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
        public void Put(int id, [FromBody] Arrecadacao arrecadacao)
        {
            //Update

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string cmdText = "UPDATE Usuario SET Nome=@Nome, Sobrenome=@Sobrenome, Email=@Email, Telefone=@Telefone, DataNascimento=@DataNascimento WHERE Id=@Id";
                SqlCommand cmd = new SqlCommand(cmdText, connection);
                cmd.Parameters.AddWithValue("Id", arrecadacao.Id);
                cmd.Parameters.AddWithValue("Nome", arrecadacao.QtdParticipantes);
                cmd.Parameters.AddWithValue("Sobrenome", arrecadacao.QtdAlimento);
                cmd.Parameters.AddWithValue("Email", arrecadacao.MetaArrecadacao);
                cmd.Parameters.AddWithValue("Telefone", arrecadacao.PublicoAlvo);
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
                string cmdText = "DELETE Arrecadacoes WHERE Id=@Id";
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
