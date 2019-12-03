using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Dominio;
using System.Data.SqlClient;
using System.Data;

namespace PessoaJuridicaAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PessoaJuridicaAPIController : ControllerBase
    {
        string connectionString = "Server=tcp:trabalhos.database.windows.net,1433;Initial Catalog=infnettrabalhos;Persist Security Info=False;User ID=andressafsilva;Password=Porcoaranh@007;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";

        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<PessoaJuridica>> Get()
        {
            // Read

            var pessoasJuridicas = new List<PessoaJuridica>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                var cmdText = "SELECT * FROM PessoasJuridicas";
                SqlCommand select = new SqlCommand(cmdText, connection);
                try
                {
                    connection.Open();
                    using (var reader = select.ExecuteReader(CommandBehavior.CloseConnection))
                    {
                        while (reader.Read())
                        {
                            var pessoaJuridica = new PessoaJuridica();
                            pessoaJuridica.Id = (int)reader["Id"];
                            pessoaJuridica.NomeEmpresa = reader["NomeEmpresa"].ToString();
                            pessoaJuridica.CNPJ = reader["CNPJ"].ToString();
                            pessoaJuridica.RazaoSocial = reader["RazaoSocial"].ToString();
                            pessoaJuridica.Endereco.Rua = reader["Rua"].ToString();
                            pessoaJuridica.Endereco.Bairro = reader["Bairro"].ToString();
                            pessoaJuridica.Endereco.Cidade = reader["Cidade"].ToString();
                            pessoaJuridica.Endereco.UF = reader["UF"].ToString();
                            pessoaJuridica.Endereco.CEP = reader["CEP"].ToString();
                            pessoaJuridica.Endereco.Complemento = reader["Complemento"].ToString();

                            pessoasJuridicas.Add(pessoaJuridica);

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

            return pessoasJuridicas;
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<PessoaJuridica> Get(int id)
        {
            // Details
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string sql = "SELEC Id, NomeEmpresa, CNPJ, RazaoSocial, Rua, Bairro, Cidade, UF, CEP, Complemento FROM PessoasJuridicas WHERE Id=@Id";
                SqlCommand cmd = new SqlCommand(sql, connection);
                cmd.Parameters.AddWithValue("@Id", id);
                PessoaJuridica pessoaJuridica = null;
                try
                {
                    connection.Open();
                    using (var reader = cmd.ExecuteReader(CommandBehavior.CloseConnection))
                    {
                        if (reader.HasRows)
                        {
                            if (reader.Read())
                            {
                                pessoaJuridica = new PessoaJuridica();
                                pessoaJuridica.Id = (int)reader["Id"];
                                pessoaJuridica.NomeEmpresa = reader["NomeEmpresa"].ToString();
                                pessoaJuridica.CNPJ = reader["CNPJ"].ToString();
                                pessoaJuridica.RazaoSocial = reader["RazaoSocial"].ToString();
                                pessoaJuridica.Endereco.Rua = reader["Rua"].ToString();
                                pessoaJuridica.Endereco.Bairro = reader["Bairro"].ToString();
                                pessoaJuridica.Endereco.Cidade = reader["Cidade"].ToString();
                                pessoaJuridica.Endereco.UF = reader["UF"].ToString();
                                pessoaJuridica.Endereco.CEP = reader["CEP"].ToString();
                                pessoaJuridica.Endereco.Complemento = reader["Complemento"].ToString();
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
                return pessoaJuridica;
            }
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] PessoaJuridica pessoaJuridica)
        {
            // Create

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string cmdText = "INSERT INTO PessoasJuridicas (NomeEmpresa, CNPJ, RazaoSocial, Rua, Bairro, Cidade, UF, CEP, Complemento) Values(@NomeEmpresa, @CNPJ, @RazaoSocial, @Rua, @Bairro, @Cidade, @UF, @CEP, @Complemento, @Rua, @Bairro, @Cidade, @UF, @CEP, @Complemento)";
                SqlCommand cmd = new SqlCommand(cmdText, connection);
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("@NomeEmpresa", pessoaJuridica.NomeEmpresa);
                cmd.Parameters.AddWithValue("@CNPJ", pessoaJuridica.CNPJ);
                cmd.Parameters.AddWithValue("@RazaoSocial", pessoaJuridica.RazaoSocial);
                cmd.Parameters.AddWithValue("@Rua", pessoaJuridica.Endereco.Rua);
                cmd.Parameters.AddWithValue("@Bairro", pessoaJuridica.Endereco.Bairro);
                cmd.Parameters.AddWithValue("@Cidade", pessoaJuridica.Endereco.Cidade);
                cmd.Parameters.AddWithValue("@UF", pessoaJuridica.Endereco.UF);
                cmd.Parameters.AddWithValue("@CEP", pessoaJuridica.Endereco.CEP);
                cmd.Parameters.AddWithValue("@Complemento", pessoaJuridica.Endereco.Complemento);
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
        public void Put(int id, [FromBody] PessoaJuridica pessoaJuridica)
        {
            // Update

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string cmdText = "UPDATE PessoasJuridicas SET NomeEmpresa=@NomeEmpresa, CNPJ=@CNPJ, RazaoSocial=@RazaoSocial, Rua=@Rua, Bairro=@Bairro, Cidade=@Cidade, UF=@UF, CEP=@CEP, Complemento=@Complemento WHERE Id=@Id";
                SqlCommand cmd = new SqlCommand(cmdText, connection);
                cmd.Parameters.AddWithValue("Id", pessoaJuridica.Id);
                cmd.Parameters.AddWithValue("NomeEmpresa", pessoaJuridica.NomeEmpresa);
                cmd.Parameters.AddWithValue("CNPJ", pessoaJuridica.CNPJ);
                cmd.Parameters.AddWithValue("RazaoSocial", pessoaJuridica.RazaoSocial);
                cmd.Parameters.AddWithValue("@Rua", pessoaJuridica.Endereco.Rua);
                cmd.Parameters.AddWithValue("@Bairro", pessoaJuridica.Endereco.Bairro);
                cmd.Parameters.AddWithValue("@Cidade", pessoaJuridica.Endereco.Cidade);
                cmd.Parameters.AddWithValue("@UF", pessoaJuridica.Endereco.UF);
                cmd.Parameters.AddWithValue("@CEP", pessoaJuridica.Endereco.CEP);
                cmd.Parameters.AddWithValue("@Complemento", pessoaJuridica.Endereco.Complemento);
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
                string cmdText = "DELETE PessoasJuridicas WHERE Id=@Id";
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
