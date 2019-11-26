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
    public class PessoaFisicaController : ControllerBase
    {
        private readonly RedeSocialDbContext _context;

        public PessoaFisicaController(RedeSocialDbContext context)
        {
            _context = context;
        }

        // GET: api/PessoaFisica
        [HttpGet]
        public IEnumerable<PessoaFisica> GetPessoasFisicas()
        {
            return _context.PessoasFisicas;
        }

        // GET: api/PessoaFisica/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetPessoaFisica([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var pessoaFisica = await _context.PessoasFisicas.FindAsync(id);

            if (pessoaFisica == null)
            {
                return NotFound();
            }

            return Ok(pessoaFisica);
        }

        // PUT: api/PessoaFisica/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPessoaFisica([FromRoute] int id, [FromBody] PessoaFisica pessoaFisica)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != pessoaFisica.Id)
            {
                return BadRequest();
            }

            _context.Entry(pessoaFisica).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PessoaFisicaExists(id))
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

        // POST: api/PessoaFisica
        [HttpPost]
        public async Task<IActionResult> PostPessoaFisica([FromBody] PessoaFisica pessoaFisica)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.PessoasFisicas.Add(pessoaFisica);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPessoaFisica", new { id = pessoaFisica.Id }, pessoaFisica);
        }

        // DELETE: api/PessoaFisica/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePessoaFisica([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var pessoaFisica = await _context.PessoasFisicas.FindAsync(id);
            if (pessoaFisica == null)
            {
                return NotFound();
            }

            _context.PessoasFisicas.Remove(pessoaFisica);
            await _context.SaveChangesAsync();

            return Ok(pessoaFisica);
        }

        private bool PessoaFisicaExists(int id)
        {
            return _context.PessoasFisicas.Any(e => e.Id == id);
        }
    }
}