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
    public class DoacaoAPIController : ControllerBase
    {
        private readonly RedeSocialDbContext _context;

        public DoacaoAPIController(RedeSocialDbContext context)
        {
            _context = context;
        }

        // GET: api/DoacaoAPI
        [HttpGet]
        public IEnumerable<Doacao> GetDoacoes()
        {
            return _context.Doacoes;
        }

        // GET: api/DoacaoAPI/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetDoacao([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var doacao = await _context.Doacoes.FindAsync(id);

            if (doacao == null)
            {
                return NotFound();
            }

            return Ok(doacao);
        }

        // PUT: api/DoacaoAPI/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDoacao([FromRoute] int id, [FromBody] Doacao doacao)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != doacao.Id)
            {
                return BadRequest();
            }

            _context.Entry(doacao).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DoacaoExists(id))
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

        // POST: api/DoacaoAPI
        [HttpPost]
        public async Task<IActionResult> PostDoacao([FromBody] Doacao doacao)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Doacoes.Add(doacao);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetDoacao", new { id = doacao.Id }, doacao);
        }

        // DELETE: api/DoacaoAPI/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDoacao([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var doacao = await _context.Doacoes.FindAsync(id);
            if (doacao == null)
            {
                return NotFound();
            }

            _context.Doacoes.Remove(doacao);
            await _context.SaveChangesAsync();

            return Ok(doacao);
        }

        private bool DoacaoExists(int id)
        {
            return _context.Doacoes.Any(e => e.Id == id);
        }
    }
}