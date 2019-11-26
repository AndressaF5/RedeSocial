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
    public class ArrecadacaoController : Controller
    {
        private readonly RedeSocialDbContext _context;

        public ArrecadacaoController(RedeSocialDbContext context)
        {
            _context = context;
        }

        // GET: Arrecadacao
        public async Task<IActionResult> Index()
        {
            return View(await _context.Arrecadacoes.ToListAsync());
        }

        // GET: Arrecadacao/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var arrecadacao = await _context.Arrecadacoes
                .FirstOrDefaultAsync(m => m.Id == id);
            if (arrecadacao == null)
            {
                return NotFound();
            }

            return View(arrecadacao);
        }

        // GET: Arrecadacao/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Arrecadacao/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,QtdParticipantes,QtdAlimento,MetaArrecadacao,IdadePublicoAlvo")] Arrecadacao arrecadacao)
        {
            if (ModelState.IsValid)
            {
                _context.Add(arrecadacao);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(arrecadacao);
        }

        // GET: Arrecadacao/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var arrecadacao = await _context.Arrecadacoes.FindAsync(id);
            if (arrecadacao == null)
            {
                return NotFound();
            }
            return View(arrecadacao);
        }

        // POST: Arrecadacao/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,QtdParticipantes,QtdAlimento,MetaArrecadacao,IdadePublicoAlvo")] Arrecadacao arrecadacao)
        {
            if (id != arrecadacao.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(arrecadacao);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ArrecadacaoExists(arrecadacao.Id))
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
            return View(arrecadacao);
        }

        // GET: Arrecadacao/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var arrecadacao = await _context.Arrecadacoes
                .FirstOrDefaultAsync(m => m.Id == id);
            if (arrecadacao == null)
            {
                return NotFound();
            }

            return View(arrecadacao);
        }

        // POST: Arrecadacao/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var arrecadacao = await _context.Arrecadacoes.FindAsync(id);
            _context.Arrecadacoes.Remove(arrecadacao);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ArrecadacaoExists(int id)
        {
            return _context.Arrecadacoes.Any(e => e.Id == id);
        }
    }
}
