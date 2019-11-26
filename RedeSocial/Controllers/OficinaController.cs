using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Banco;
using Dominio;

namespace RedeSocial.Controllers
{
    public class OficinaController : Controller
    {
        private readonly RedeSocialDbContext _context;

        public OficinaController(RedeSocialDbContext context)
        {
            _context = context;
        }

        // GET: Oficina
        public async Task<IActionResult> Index()
        {
            return View(await _context.Oficinas.ToListAsync());
        }

        // GET: Oficina/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var oficina = await _context.Oficinas
                .FirstOrDefaultAsync(m => m.Id == id);
            if (oficina == null)
            {
                return NotFound();
            }

            return View(oficina);
        }

        // GET: Oficina/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Oficina/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,QtdPrticipantes,NomeAtividade,Data,Hora,Categoria,Descricao")] Oficina oficina)
        {
            if (ModelState.IsValid)
            {
                _context.Add(oficina);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(oficina);
        }

        // GET: Oficina/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var oficina = await _context.Oficinas.FindAsync(id);
            if (oficina == null)
            {
                return NotFound();
            }
            return View(oficina);
        }

        // POST: Oficina/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,QtdPrticipantes,NomeAtividade,Data,Hora,Categoria,Descricao")] Oficina oficina)
        {
            if (id != oficina.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(oficina);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!OficinaExists(oficina.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(oficina);
        }

        // GET: Oficina/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var oficina = await _context.Oficinas
                .FirstOrDefaultAsync(m => m.Id == id);
            if (oficina == null)
            {
                return NotFound();
            }

            return View(oficina);
        }

        // POST: Oficina/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var oficina = await _context.Oficinas.FindAsync(id);
            _context.Oficinas.Remove(oficina);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool OficinaExists(int id)
        {
            return _context.Oficinas.Any(e => e.Id == id);
        }
    }
}
