using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Dominio;
using System.Data.SqlClient;
using System.Data;

namespace EventoAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        string connectionString = "Server=tcp:trabalhos.database.windows.net,1433;Initial Catalog=infnettrabalhos;Persist Security Info=False;User ID=andressafsilva;Password=Porcoaranh@007;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";

        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<Evento>> Get()
        {
            // Read

            var eventos = new List<Evento>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                var cmdText = "SELECT * FROM Eventos";
                SqlCommand select = new SqlCommand(cmdText, connection);
                try
                {
                    connection.Open();
                    using (var reader = select.ExecuteReader(CommandBehavior.CloseConnection))
                    {
                        while (reader.Read())
                        {
                            var evento = new Evento();
                            evento.Id = (int)reader["Id"];
                            evento.NomeAtividade = reader["NomeAtividade"].ToString();
                            evento.Data = (DateTime)reader["Data"];
                            evento.Hora = (DateTime)reader["Hora"];
                            evento.Categoria = reader["Categoria"].ToString();
                            evento.Descricao = reader["Descricao"].ToString();

                            eventos.Add(evento);

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

            return eventos;
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<Evento> Get(int id)
        {
            // Details
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string sql = "SELEC Id, NomeAtividade, Data, Hora, Categoria, Descricao FROM Eventos WHERE Id=@Id";
                SqlCommand cmd = new SqlCommand(sql, connection);
                cmd.Parameters.AddWithValue("@Id", id);
                Evento evento = null;
                try
                {
                    connection.Open();
                    using (var reader = cmd.ExecuteReader(CommandBehavior.CloseConnection))
                    {
                        if (reader.HasRows)
                        {
                            if (reader.Read())
                            {
                                evento = new Evento();
                                evento.Id = (int)reader["Id"];
                                evento.NomeAtividade = reader["NomeAtividade"].ToString();
                                evento.Data = (DateTime)reader["Data"];
                                evento.Hora = (DateTime)reader["Hora"];
                                evento.Categoria = reader["Categoria"].ToString();
                                evento.Descricao = reader["Descricao"].ToString();
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
                return evento;
            }       

            //return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] Evento evento)
        {
            // Create

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string cmdText = "INSERT INTO Usuario (NomeAtividade, Data, Hora, Categoria, Descricao) Values(@NomeAtividade, @Data, @Hora, @Categoria, @Descricao)";
                SqlCommand cmd = new SqlCommand(cmdText, connection);
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("@Nome", evento.NomeAtividade);
                cmd.Parameters.AddWithValue("@Sobrenome", evento.Data);
                cmd.Parameters.AddWithValue("@Email", evento.Hora);
                cmd.Parameters.AddWithValue("@Telefone", evento.Categoria);
                cmd.Parameters.AddWithValue("@DataNascimento", evento.Descricao);
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
        public void Put(int id, [FromBody] Evento evento)
        {
            // Update

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string cmdText = "UPDATE Eventos SET NomeAtividade=@NomeAtividade, Data=@Data, Hora=@Hora, Categoria=@Categoria, Descricao=@Descricao WHERE Id=@Id";
                SqlCommand cmd = new SqlCommand(cmdText, connection);
                cmd.Parameters.AddWithValue("Id", evento.Id);
                cmd.Parameters.AddWithValue("Nome", evento.NomeAtividade);
                cmd.Parameters.AddWithValue("Sobrenome", evento.Data);
                cmd.Parameters.AddWithValue("Email", evento.Hora);
                cmd.Parameters.AddWithValue("Telefone", evento.Categoria);
                cmd.Parameters.AddWithValue("DataNascimento", evento.Descricao);
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
                string cmdText = "DELETE Eventos WHERE Id=@Id";
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
