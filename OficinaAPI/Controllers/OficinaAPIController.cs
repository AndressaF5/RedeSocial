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
    public class OficinaAPIController : ControllerBase
    {
        string connectionString = "Server=tcp:trabalhos.database.windows.net,1433;Initial Catalog=infnettrabalhos;Persist Security Info=False;User ID=andressafsilva;Password=Porcoaranh@007;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";

        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<Oficina>> Get()
        {
            // Read

            var oficinas = new List<Oficina>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                var cmdText = "SELECT * FROM Oficinas";
                SqlCommand select = new SqlCommand(cmdText, connection);
                try
                {
                    connection.Open();
                    using (var reader = select.ExecuteReader(CommandBehavior.CloseConnection))
                    {
                        while (reader.Read())
                        {
                            var oficina = new Oficina();
                            oficina.Id = (int)reader["Id"];
                            oficina.NomeOficina = reader["NomeOficina"].ToString();
                            oficina.QtdParticipantes = (int)reader["QtdParticipante"];

                            oficinas.Add(oficina);

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

            return oficinas;
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<Oficina> Get(int id)
        {
            // Details
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string sql = "SELEC Id, NomeOficina, QtdParticipante FROM Oficinas WHERE Id=@Id";
                SqlCommand cmd = new SqlCommand(sql, connection);
                cmd.Parameters.AddWithValue("@Id", id);
                Oficina oficina = null;
                try
                {
                    connection.Open();
                    using (var reader = cmd.ExecuteReader(CommandBehavior.CloseConnection))
                    {
                        if (reader.HasRows)
                        {
                            if (reader.Read())
                            {
                                oficina = new Oficina();
                                oficina.Id = (int)reader["Id"];
                                oficina.NomeOficina = reader["NomeOficina"].ToString();
                                oficina.QtdParticipantes = (int)reader["QtdParticipantes"];
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
                return oficina;
            }
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] Oficina oficina)
        {
            // Create

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string cmdText = "INSERT INTO Oficinas (NomeOficina, QtdParticipantes) Values(@NomeOficina ,@QtdParticipantes)";
                SqlCommand cmd = new SqlCommand(cmdText, connection);
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("@NomeOficina", oficina.NomeOficina);
                cmd.Parameters.AddWithValue("@QtdParticipantes", oficina.QtdParticipantes);
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
        public void Put(int id, [FromBody] Oficina oficina)
        {
            // Update

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string cmdText = "UPDATE Oficinas SET NomeOficina=@NomeOficina, QtdParticipantes=@QtdParticipantes WHERE Id=@Id";
                SqlCommand cmd = new SqlCommand(cmdText, connection);
                cmd.Parameters.AddWithValue("Id", oficina.Id);
                cmd.Parameters.AddWithValue("NomeOficina", oficina.NomeOficina);
                cmd.Parameters.AddWithValue("QtdParticipantes", oficina.QtdParticipantes);
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
                string cmdText = "DELETE Oficinas WHERE Id=@Id";
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
