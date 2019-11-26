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
    public class OficinaAPIController : ControllerBase
    {
        private readonly RedeSocialDbContext _context;

        public OficinaAPIController(RedeSocialDbContext context)
        {
            _context = context;
        }

        // GET: api/OficinaAPI
        [HttpGet]
        public IEnumerable<Oficina> GetOficinas()
        {
            return _context.Oficinas;
        }

        // GET: api/OficinaAPI/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetOficina([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var oficina = await _context.Oficinas.FindAsync(id);

            if (oficina == null)
            {
                return NotFound();
            }

            return Ok(oficina);
        }

        // PUT: api/OficinaAPI/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutOficina([FromRoute] int id, [FromBody] Oficina oficina)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != oficina.Id)
            {
                return BadRequest();
            }

            _context.Entry(oficina).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!OficinaExists(id))
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

        // POST: api/OficinaAPI
        [HttpPost]
        public async Task<IActionResult> PostOficina([FromBody] Oficina oficina)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Oficinas.Add(oficina);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetOficina", new { id = oficina.Id }, oficina);
        }

        // DELETE: api/OficinaAPI/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOficina([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var oficina = await _context.Oficinas.FindAsync(id);
            if (oficina == null)
            {
                return NotFound();
            }

            _context.Oficinas.Remove(oficina);
            await _context.SaveChangesAsync();

            return Ok(oficina);
        }

        private bool OficinaExists(int id)
        {
            return _context.Oficinas.Any(e => e.Id == id);
        }
    }
}