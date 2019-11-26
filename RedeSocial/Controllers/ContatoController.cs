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
    public class ContatoController : Controller
    {
        private readonly RedeSocialDbContext _context;

        public ContatoController(RedeSocialDbContext context)
        {
            _context = context;
        }

        // GET: Contato
        public async Task<IActionResult> Index()
        {
            return View(await _context.Contatos.ToListAsync());
        }

        // GET: Contato/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var contato = await _context.Contatos
                .FirstOrDefaultAsync(m => m.Id == id);
            if (contato == null)
            {
                return NotFound();
            }

            return View(contato);
        }

        // GET: Contato/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Contato/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Telefone,Celular")] Contato contato)
        {
            if (ModelState.IsValid)
            {
                _context.Add(contato);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(contato);
        }

        // GET: Contato/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var contato = await _context.Contatos.FindAsync(id);
            if (contato == null)
            {
                return NotFound();
            }
            return View(contato);
        }

        // POST: Contato/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Telefone,Celular")] Contato contato)
        {
            if (id != contato.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(contato);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ContatoExists(contato.Id))
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
            return View(contato);
        }

        // GET: Contato/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var contato = await _context.Contatos
                .FirstOrDefaultAsync(m => m.Id == id);
            if (contato == null)
            {
                return NotFound();
            }

            return View(contato);
        }

        // POST: Contato/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var contato = await _context.Contatos.FindAsync(id);
            _context.Contatos.Remove(contato);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ContatoExists(int id)
        {
            return _context.Contatos.Any(e => e.Id == id);
        }
    }
}
