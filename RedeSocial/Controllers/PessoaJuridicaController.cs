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
    public class PessoaJuridicaController : ControllerBase
    {
        private readonly RedeSocialDbContext _context;

        public PessoaJuridicaController(RedeSocialDbContext context)
        {
            _context = context;
        }

        // GET: api/PessoaJuridica
        [HttpGet]
        public IEnumerable<PessoaJuridica> GetPessoasJuridicas()
        {
            return _context.PessoasJuridicas;
        }

        // GET: api/PessoaJuridica/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetPessoaJuridica([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var pessoaJuridica = await _context.PessoasJuridicas.FindAsync(id);

            if (pessoaJuridica == null)
            {
                return NotFound();
            }

            return Ok(pessoaJuridica);
        }

        // PUT: api/PessoaJuridica/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPessoaJuridica([FromRoute] int id, [FromBody] PessoaJuridica pessoaJuridica)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != pessoaJuridica.Id)
            {
                return BadRequest();
            }

            _context.Entry(pessoaJuridica).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PessoaJuridicaExists(id))
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

        // POST: api/PessoaJuridica
        [HttpPost]
        public async Task<IActionResult> PostPessoaJuridica([FromBody] PessoaJuridica pessoaJuridica)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.PessoasJuridicas.Add(pessoaJuridica);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPessoaJuridica", new { id = pessoaJuridica.Id }, pessoaJuridica);
        }

        // DELETE: api/PessoaJuridica/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePessoaJuridica([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var pessoaJuridica = await _context.PessoasJuridicas.FindAsync(id);
            if (pessoaJuridica == null)
            {
                return NotFound();
            }

            _context.PessoasJuridicas.Remove(pessoaJuridica);
            await _context.SaveChangesAsync();

            return Ok(pessoaJuridica);
        }

        private bool PessoaJuridicaExists(int id)
        {
            return _context.PessoasJuridicas.Any(e => e.Id == id);
        }
    }
}