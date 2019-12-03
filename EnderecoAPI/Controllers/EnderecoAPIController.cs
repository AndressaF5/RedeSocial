using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Dominio;
using System.Data.SqlClient;
using System.Data;

namespace EnderecoAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EnderecoAPIController : ControllerBase
    {
        string connectionString = "Server=tcp:trabalhos.database.windows.net,1433;Initial Catalog=infnettrabalhos;Persist Security Info=False;User ID=andressafsilva;Password=Porcoaranh@007;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";

        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<Endereco>> Get()
        {
            // Read
            var enderecos = new List<Endereco>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                var cmdText = "SELECT * FROM Enderecos";
                var select = new SqlCommand(cmdText, connection);
                try
                {
                    connection.Open();
                    using (var reader = select.ExecuteReader(CommandBehavior.CloseConnection))
                    {
                        while (reader.Read())
                        {
                            var endereco = new Endereco();
                            endereco.Id = (int)reader["Id"];
                            endereco.Rua = reader["Rua"].ToString();
                            endereco.Bairro = reader["Bairro"].ToString();
                            endereco.Cidade = reader["Cidade"].ToString();
                            endereco.UF = reader["UF"].ToString();
                            endereco.CEP = reader["CEP"].ToString();
                            endereco.Complemento = reader["Complemento"].ToString();

                            enderecos.Add(endereco);
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

                return enderecos;
            }
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<Endereco> Get(int id)
        {
            // Details

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string sql = "SELECT Id, Rua, Bairro, Cidade, UF, CEP, Complemento WHERE Enderecos Id=@Id";
                SqlCommand cmd = new SqlCommand(sql, connection);
                cmd.Parameters.AddWithValue("@Id", id);
                Endereco endereco = null;
                try
                {
                    connection.Open();
                    using (var reader = cmd.ExecuteReader(CommandBehavior.CloseConnection))
                    {
                        if (reader.HasRows)
                        {
                            if (reader.Read())
                            {
                                endereco = new Endereco();
                                endereco.Id = (int)reader["Id"];
                                endereco.Rua = reader["Rua"].ToString();
                                endereco.Bairro = reader["Bairro"].ToString();
                                endereco.Cidade = reader["Cidade"].ToString();
                                endereco.UF = reader["UF"].ToString();
                                endereco.CEP = reader["CEP"].ToString();
                                endereco.Complemento = reader["Complemento"].ToString();
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

                return endereco;
            }
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] Endereco endereco)
        {
            // Create

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string cmdText = "INSERT INTO Enderecos (Rua, Bairro, Cidade, UF, CEP, Complemento) VALUES (@Rua, @Bairro, @Cidade, @UF, @CEP, @Complemento)";
                SqlCommand cmd = new SqlCommand(cmdText, connection);
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("Rua", endereco.Rua);
                cmd.Parameters.AddWithValue("Bairro", endereco.Cidade);
                cmd.Parameters.AddWithValue("UF", endereco.UF);
                cmd.Parameters.AddWithValue("CEP", endereco.CEP);
                cmd.Parameters.AddWithValue("Complemento", endereco.Complemento);

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
        public void Put(int id, [FromBody] Endereco endereco)
        {
            // Update

            using (SqlConnection connetcion = new SqlConnection(connectionString))
            {
                string cmdText = "UPDATE Doacoes SET Rua=@Rua, Bairro=@Bairro, Cidade=@Cidade, UF=@UF, CEP=@CEP, Complemento=@Complemento";
                SqlCommand cmd = new SqlCommand(cmdText, connetcion);
                cmd.Parameters.AddWithValue("Rua", endereco.Rua);
                cmd.Parameters.AddWithValue("Bairro", endereco.Bairro);
                cmd.Parameters.AddWithValue("Cidade", endereco.Cidade);
                cmd.Parameters.AddWithValue("UF", endereco.UF);
                cmd.Parameters.AddWithValue("CEP", endereco.CEP);
                cmd.Parameters.AddWithValue("Complemento", endereco.Complemento);
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
                string cmdText = "DELETE Enderecos WHERE Id=@Id";
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
