using System;
using System.Diagnostics;
using System.Linq;
using System.Security.Claims;
using Banco;
using Microsoft.AspNetCore.Mvc;
using RedeSocial.Models;

namespace RedeSocial.Controllers
{
    public class HomeController : Controller
    {
        RedeSocialDbContext _context = new RedeSocialDbContext();
        public IActionResult Index()
        {
            try
            {
                var ApplicationUserId = User.FindFirst(ClaimTypes.NameIdentifier).Value;
                var ApplicationUser = _context.Users.FirstOrDefault(u => u.Id == ApplicationUserId);
                var usuarioLogado = _context.Usuarios.FirstOrDefault(u => u.IdentityUser.Id == ApplicationUserId);
                if (usuarioLogado == null)
                {
                    return RedirectToAction("Create", "Usuario");
                }
            }
            catch (Exception e)
            {
                return View();
            }

            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
