using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Banco;
using Dominio;
using System.Security.Claims;

namespace RedeSocial.Controllers
{
    public class AmizadeController : Controller
    {
        RedeSocialDbContext _context = new RedeSocialDbContext();

        public Usuario VerificaUsuario()
        {
            Usuario usuario = new Usuario();

            var ApplicationUserId = User.FindFirst(ClaimTypes.NameIdentifier).Value;
            var ApplicationUser = _context.Users.FirstOrDefault(u => u.Id == ApplicationUserId);
            var usuarioLogado = _context.Usuarios.FirstOrDefault(u => u.IdentityUser.Id == ApplicationUserId);
            usuario.IdentityUser = ApplicationUser;

            return usuarioLogado;
        }

        // GET: Amizade
        public async Task<IActionResult> Index()
        {
            var amizade = new Amizade();
            var usuarioLogado = VerificaUsuario();
            var UsuarioA = usuarioLogado;
            foreach (var item in _context.Amizades)
            {
                if (usuarioLogado != null)
                {
                    ViewData["UsuarioIdB"] = new SelectList(_context.Usuarios, "Id", "Nome");
                }
                else
                {
                    VerificaUsuario();
                }

            }

            var Amizades = _context.Amizades.Where(a => a.UsuarioIdA == UsuarioA.Id).Include(a => a.UsuarioA).Include(a => a.UsuarioB);
            return View(Amizades);
        }

        // GET: Amizade/Details/5
        public async Task<IActionResult> Details(int? id, int id2)
        {
            var usuarioLogado = VerificaUsuario();
            var UsuarioIdA = usuarioLogado;
            //if (id == null & id2 == null)
            //{
            //    return NotFound();
            //}

            var amizade = await _context.Amizades
                .Include(a => a.UsuarioA)
                .Include(a => a.UsuarioB)
                .FirstOrDefaultAsync(m => m.UsuarioIdA == id & m.UsuarioIdB == id2);
            if (amizade == null)
            {
                return NotFound();
            }

            return View(amizade);
        }

        // GET: Amizade/Create
        public IActionResult Create()
        {
            ViewData["UsuarioIdA"] = new SelectList(_context.Usuarios, "Id", "Nome");
            ViewData["UsuarioIdB"] = new SelectList(_context.Usuarios, "Id", "Nome");
            return View();
        }

        // POST: Amizade/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("UsuarioIdA,UsuarioIdB")] Amizade amizade)
        {
            var usuarioLogado = VerificaUsuario();
            var UsuarioIdA = usuarioLogado.Id;
            amizade.UsuarioIdA = UsuarioIdA;


            if (ModelState.IsValid)
            {
                _context.Add(amizade);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["UsuarioIdA"] = new SelectList(_context.Usuarios, "Id", "Nome", amizade.UsuarioIdA);
            ViewData["UsuarioIdB"] = new SelectList(_context.Usuarios, "Id", "Nome", amizade.UsuarioIdB);
            return View(amizade);
        }

        // GET: Amizade/Edit/5
        public async Task<IActionResult> Edit(int? id, int id2)
        {
            var amizade = await _context.Amizades.FindAsync(id, id2);
            if (amizade == null)
            {
                return NotFound();
            }
            ViewData["UsuarioIdA"] = new SelectList(_context.Usuarios, "Id", "Nome", amizade.UsuarioIdA);
            ViewData["UsuarioIdB"] = new SelectList(_context.Usuarios, "Id", "Nome", amizade.UsuarioIdB);
            return View(amizade);
        }

        // POST: Amizade/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("UsuarioIdA,UsuarioIdB")] Amizade amizade)
        {
            var usuarioLogado = VerificaUsuario();
            var UsuarioIdA = usuarioLogado;

            if (id != amizade.UsuarioIdA)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(amizade);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AmizadeExists(amizade.UsuarioIdA))
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
            ViewData["UsuarioIdA"] = new SelectList(_context.Usuarios, "Id", "Nome", amizade.UsuarioIdA);
            ViewData["UsuarioIdB"] = new SelectList(_context.Usuarios, "Id", "Nome", amizade.UsuarioIdB);
            return View(amizade);
        }

        // GET: Amizade/Delete/5
        public async Task<IActionResult> Delete(int? id, int id2)
        {
            //if (id == null & id2 == null)
            //{
            //    return NotFound();
            //}

            var amizade = await _context.Amizades
                .Include(a => a.UsuarioA)
                .Include(a => a.UsuarioB)
                .FirstOrDefaultAsync(m => m.UsuarioIdA == id & m.UsuarioIdB == id2);
            if (amizade == null)
            {
                return NotFound();
            }

            return View(amizade);
        }

        // POST: Amizade/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int UsuarioIdA, int UsuarioIdB)
        {
            var usuarioLogado = VerificaUsuario();

            var amizade = await _context.Amizades.FindAsync(UsuarioIdA, UsuarioIdB);
            _context.Amizades.Remove(amizade);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AmizadeExists(int id)
        {
            return _context.Amizades.Any(e => e.UsuarioIdA == id);
        }
    }
}
