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
        public ActionResult<IEnumerable<Oficina>> Get()
        {
            // Read

            var eventos = new List<Oficina>();

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
                            var evento = new Oficina();
                            evento.Id = (int)reader["Id"];
                            evento.NomeAtividade = reader["NomeAtividade"].ToString();
                            evento.Data = (DateTime)reader["Data"];
                            evento.Hora = (DateTime)reader["Hora"];
                            evento.Categoria = reader["Categoria"].ToString();
                            evento.Descricao = reader["Descricao"].ToString();
                            evento.NomeOficina = reader["NomeOficina"].ToString();
                            evento.QtdParticipantes = (int)reader["QtdParticipantes"];
                            evento.Endereco.Rua = reader["Rua"].ToString();
                            evento.Endereco.Bairro = reader["Bairro"].ToString();
                            evento.Endereco.Cidade = reader["Cidade"].ToString();
                            evento.Endereco.UF = reader["UF"].ToString();
                            evento.Endereco.CEP = reader["CEP"].ToString();
                            evento.Endereco.Complemento = reader["Complemento"].ToString();

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
        public ActionResult<Oficina> Get(int id)
        {
            // Details
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string sql = "SELEC Id, NomeAtividade, Data, Hora, Categoria, Descricao, NomeOficina, QtdParticipantes, Rua, Bairro, Cidade, UF, CEP, Complemento FROM Eventos WHERE Id=@Id";
                SqlCommand cmd = new SqlCommand(sql, connection);
                cmd.Parameters.AddWithValue("@Id", id);
                Oficina evento = null;
                try
                {
                    connection.Open();
                    using (var reader = cmd.ExecuteReader(CommandBehavior.CloseConnection))
                    {
                        if (reader.HasRows)
                        {
                            if (reader.Read())
                            {
                                evento = new Oficina();
                                evento.Id = (int)reader["Id"];
                                evento.NomeAtividade = reader["NomeAtividade"].ToString();
                                evento.Data = (DateTime)reader["Data"];
                                evento.Hora = (DateTime)reader["Hora"];
                                evento.Categoria = reader["Categoria"].ToString();
                                evento.Descricao = reader["Descricao"].ToString();
                                evento.NomeOficina = reader["NomeOficina"].ToString();
                                evento.QtdParticipantes = (int)reader["QtdParticipantes"];
                                evento.Endereco.Rua = reader["Rua"].ToString();
                                evento.Endereco.Bairro = reader["Bairro"].ToString();
                                evento.Endereco.Cidade = reader["Cidade"].ToString();
                                evento.Endereco.UF = reader["UF"].ToString();
                                evento.Endereco.CEP = reader["CEP"].ToString();
                                evento.Endereco.Complemento = reader["Complemento"].ToString();
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
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] Oficina evento)
        {
            // Create

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string cmdText = "INSERT INTO Usuario (NomeAtividade, Data, Hora, Categoria, Descricao, NomeOficina, QtdParticipantes, Rua, Bairro, Cidade, UF, CEP, Complemento) Values(@NomeAtividade, @Data, @Hora, @Categoria, @Descricao, @NomeOficina, @QtdParticipantes, @Rua, @Bairro, @Cidade, @UF, @CEP, @Complemento)";
                SqlCommand cmd = new SqlCommand(cmdText, connection);
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("@NomeAtividade", evento.NomeAtividade);
                cmd.Parameters.AddWithValue("@Data", evento.Data);
                cmd.Parameters.AddWithValue("@Hora", evento.Hora);
                cmd.Parameters.AddWithValue("@Categoria", evento.Categoria);
                cmd.Parameters.AddWithValue("@Descricao", evento.Descricao);
                cmd.Parameters.AddWithValue("@NomeOficina", evento.NomeOficina);
                cmd.Parameters.AddWithValue("@QtdParticipantes", evento.QtdParticipantes);
                cmd.Parameters.AddWithValue("@Rua", evento.Endereco.Rua);
                cmd.Parameters.AddWithValue("@Bairro", evento.Endereco.Bairro);
                cmd.Parameters.AddWithValue("@Cidade", evento.Endereco.Cidade);
                cmd.Parameters.AddWithValue("@UF", evento.Endereco.UF);
                cmd.Parameters.AddWithValue("@CEP", evento.Endereco.CEP);
                cmd.Parameters.AddWithValue("@Complemento", evento.Endereco.Complemento);
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
        public void Put(int id, [FromBody] Oficina evento)
        {
            // Update

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string cmdText = "UPDATE Eventos SET NomeAtividade=@NomeAtividade, Data=@Data, Hora=@Hora, Categoria=@Categoria, Descricao=@Descricao, NomeOficina=@NomeOficina, QtdParticipantes=@QtdParticipantes, Rua=@Rua, Bairro=@Bairro, Cidade=@Cidade, UF=@UF, CEP=@CEP, Complemento=@Complemento WHERE Id=@Id";
                SqlCommand cmd = new SqlCommand(cmdText, connection);
                cmd.Parameters.AddWithValue("Id", evento.Id);
                cmd.Parameters.AddWithValue("NomeAtividade", evento.NomeAtividade);
                cmd.Parameters.AddWithValue("Data", evento.Data);
                cmd.Parameters.AddWithValue("Hora", evento.Hora);
                cmd.Parameters.AddWithValue("Categoria", evento.Categoria);
                cmd.Parameters.AddWithValue("Descricao", evento.Descricao);
                cmd.Parameters.AddWithValue("NomeOficina", evento.NomeOficina);
                cmd.Parameters.AddWithValue("QtdParticipantes", evento.QtdParticipantes);
                cmd.Parameters.AddWithValue("@Rua", evento.Endereco.Rua);
                cmd.Parameters.AddWithValue("@Bairro", evento.Endereco.Bairro);
                cmd.Parameters.AddWithValue("@Cidade", evento.Endereco.Cidade);
                cmd.Parameters.AddWithValue("@UF", evento.Endereco.UF);
                cmd.Parameters.AddWithValue("@CEP", evento.Endereco.CEP);
                cmd.Parameters.AddWithValue("@Complemento", evento.Endereco.Complemento);
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
