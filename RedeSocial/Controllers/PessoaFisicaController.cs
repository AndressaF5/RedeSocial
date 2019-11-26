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
    public class PessoaFisicaController : Controller
    {
        private readonly RedeSocialDbContext _context;

        public PessoaFisicaController(RedeSocialDbContext context)
        {
            _context = context;
        }

        // GET: PessoaFisica
        public async Task<IActionResult> Index()
        {
            return View(await _context.PessoasFisicas.ToListAsync());
        }

        // GET: PessoaFisica/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pessoaFisica = await _context.PessoasFisicas
                .FirstOrDefaultAsync(m => m.Id == id);
            if (pessoaFisica == null)
            {
                return NotFound();
            }

            return View(pessoaFisica);
        }

        // GET: PessoaFisica/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: PessoaFisica/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nome,Sobrenome,NomeSocial,DataNascimento,CPF,Genero")] PessoaFisica pessoaFisica)
        {
            if (ModelState.IsValid)
            {
                _context.Add(pessoaFisica);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(pessoaFisica);
        }

        // GET: PessoaFisica/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pessoaFisica = await _context.PessoasFisicas.FindAsync(id);
            if (pessoaFisica == null)
            {
                return NotFound();
            }
            return View(pessoaFisica);
        }

        // POST: PessoaFisica/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nome,Sobrenome,NomeSocial,DataNascimento,CPF,Genero")] PessoaFisica pessoaFisica)
        {
            if (id != pessoaFisica.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(pessoaFisica);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PessoaFisicaExists(pessoaFisica.Id))
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
            return View(pessoaFisica);
        }

        // GET: PessoaFisica/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pessoaFisica = await _context.PessoasFisicas
                .FirstOrDefaultAsync(m => m.Id == id);
            if (pessoaFisica == null)
            {
                return NotFound();
            }

            return View(pessoaFisica);
        }

        // POST: PessoaFisica/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var pessoaFisica = await _context.PessoasFisicas.FindAsync(id);
            _context.PessoasFisicas.Remove(pessoaFisica);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PessoaFisicaExists(int id)
        {
            return _context.PessoasFisicas.Any(e => e.Id == id);
        }
    }
}
