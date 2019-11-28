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
        public ActionResult<IEnumerable<string>> Get()
        {
            //Read
            /*
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
                            arrecadacao.QtdParticipantes = (int)reader["QtdPerticipantes"];
                            arrecadacao.QtdAlimento = (float)reader["QtdAlimento"];
                            arrecadacao.MetaArrecadacao = (float)reader["MetaArrecadacao"];
                            arrecadacao.PublicoAlvo = (int)reader["PublicoAlvo"];

                            return new string[] { "Id", "QtdPerticipantes", "QtdAlimento", "MetaArrecadacao", "PublicoAlvo"};
                           
                        }
           
                    }
                }
                finally
                {
                    connection.Close();
                }*/


            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            // Details
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] string value)
        {
            //create
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
            //Update
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
