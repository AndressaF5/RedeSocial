using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Banco;
using Dominio;

namespace RedeSocial.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArrecadacaoAPIController : ControllerBase
    {
        private readonly RedeSocialDbContext _context;

        public ArrecadacaoAPIController(RedeSocialDbContext context)
        {
            _context = context;
        }

        // GET: api/Arrecadacao
        [HttpGet]
        public IEnumerable<Arrecadacao> GetArrecadacoes()
        {
            return _context.Arrecadacoes;
        }

        // GET: api/Arrecadacao/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetArrecadacao([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var arrecadacao = await _context.Arrecadacoes.FindAsync(id);

            if (arrecadacao == null)
            {
                return NotFound();
            }

            return Ok(arrecadacao);
        }

        // PUT: api/Arrecadacao/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutArrecadacao([FromRoute] int id, [FromBody] Arrecadacao arrecadacao)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != arrecadacao.Id)
            {
                return BadRequest();
            }

            _context.Entry(arrecadacao).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ArrecadacaoExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Arrecadacao
        [HttpPost]
        public async Task<IActionResult> PostArrecadacao([FromBody] Arrecadacao arrecadacao)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Arrecadacoes.Add(arrecadacao);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetArrecadacao", new { id = arrecadacao.Id }, arrecadacao);
        }

        // DELETE: api/Arrecadacao/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteArrecadacao([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var arrecadacao = await _context.Arrecadacoes.FindAsync(id);
            if (arrecadacao == null)
            {
                return NotFound();
            }

            _context.Arrecadacoes.Remove(arrecadacao);
            await _context.SaveChangesAsync();

            return Ok(arrecadacao);
        }

        private bool ArrecadacaoExists(int id)
        {
            return _context.Arrecadacoes.Any(e => e.Id == id);
        }
    }
}