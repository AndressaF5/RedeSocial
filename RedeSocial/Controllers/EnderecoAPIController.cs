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
    public class EnderecoAPIController : ControllerBase
    {
        private readonly RedeSocialDbContext _context;

        public EnderecoAPIController(RedeSocialDbContext context)
        {
            _context = context;
        }

        // GET: api/EnderecoAPI
        [HttpGet]
        public IEnumerable<Endereco> GetEnderecos()
        {
            return _context.Enderecos;
        }

        // GET: api/EnderecoAPI/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetEndereco([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var endereco = await _context.Enderecos.FindAsync(id);

            if (endereco == null)
            {
                return NotFound();
            }

            return Ok(endereco);
        }

        // PUT: api/EnderecoAPI/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEndereco([FromRoute] int id, [FromBody] Endereco endereco)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != endereco.Id)
            {
                return BadRequest();
            }

            _context.Entry(endereco).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EnderecoExists(id))
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

        // POST: api/EnderecoAPI
        [HttpPost]
        public async Task<IActionResult> PostEndereco([FromBody] Endereco endereco)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Enderecos.Add(endereco);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetEndereco", new { id = endereco.Id }, endereco);
        }

        // DELETE: api/EnderecoAPI/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEndereco([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var endereco = await _context.Enderecos.FindAsync(id);
            if (endereco == null)
            {
                return NotFound();
            }

            _context.Enderecos.Remove(endereco);
            await _context.SaveChangesAsync();

            return Ok(endereco);
        }

        private bool EnderecoExists(int id)
        {
            return _context.Enderecos.Any(e => e.Id == id);
        }
    }
}