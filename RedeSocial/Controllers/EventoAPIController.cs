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
    public class EventoAPIController : ControllerBase
    {
        private readonly RedeSocialDbContext _context;

        public EventoAPIController(RedeSocialDbContext context)
        {
            _context = context;
        }

        // GET: api/EventoAPI
        [HttpGet]
        public IEnumerable<Evento> GetEventos()
        {
            return _context.Eventos;
        }

        // GET: api/EventoAPI/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetEvento([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var evento = await _context.Eventos.FindAsync(id);

            if (evento == null)
            {
                return NotFound();
            }

            return Ok(evento);
        }

        // PUT: api/EventoAPI/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEvento([FromRoute] int id, [FromBody] Evento evento)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != evento.Id)
            {
                return BadRequest();
            }

            _context.Entry(evento).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EventoExists(id))
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

        // POST: api/EventoAPI
        [HttpPost]
        public async Task<IActionResult> PostEvento([FromBody] Evento evento)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Eventos.Add(evento);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetEvento", new { id = evento.Id }, evento);
        }

        // DELETE: api/EventoAPI/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEvento([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var evento = await _context.Eventos.FindAsync(id);
            if (evento == null)
            {
                return NotFound();
            }

            _context.Eventos.Remove(evento);
            await _context.SaveChangesAsync();

            return Ok(evento);
        }

        private bool EventoExists(int id)
        {
            return _context.Eventos.Any(e => e.Id == id);
        }
    }
}