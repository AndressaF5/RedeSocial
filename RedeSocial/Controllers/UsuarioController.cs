using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Dominio;
using System.Net.Http;
using System.Net.Http.Headers;
using Newtonsoft.Json;
using System.Security.Claims;
using Banco;
using System.Linq;

namespace RedeSocial.Controllers
{
    public class UsuarioController : Controller
    {
        RedeSocialDbContext _context = new RedeSocialDbContext(); 

        // GET: Usuario
        public async Task<IActionResult> Index()
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:44302/");
                var mediaType = new MediaTypeWithQualityHeaderValue("application/json");
                client.DefaultRequestHeaders.Accept.Add(mediaType);
                var response = client.GetAsync("api/UsuarioAPI").Result;
                List<Usuario> usuarios = new List<Usuario>();
                if (response.IsSuccessStatusCode)
                {
                    string json = await response.Content.ReadAsStringAsync();
                    usuarios = JsonConvert.DeserializeObject<List<Usuario>>(json);
                }

                return View(usuarios);
            }
        }

        // GET: Usuario/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri($"https://localhost:44302/{id}");
                var mediaType = new MediaTypeWithQualityHeaderValue("application/json");
                client.DefaultRequestHeaders.Accept.Add(mediaType);
                var response = client.GetAsync($"api/UsuarioAPI/{id}").Result;
                Usuario usuario = new Usuario();
                if (response.IsSuccessStatusCode)
                {
                    string json = await response.Content.ReadAsStringAsync();
                    usuario = JsonConvert.DeserializeObject<Usuario>(json);
                }
                if (usuario == null)
                {
                    return NotFound();
                }

                return View(usuario);
            }
        }

        // GET: Usuario/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Usuario/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nome,Sobrenome,NomeSocial,DataNascimento,CPF,Genero, Contato")] Usuario usuario)
        {
            if (ModelState.IsValid)
            {
                using (var client = new HttpClient())
                {
                    
                    var ApplicationUserId = User.FindFirst(ClaimTypes.NameIdentifier).Value;
                    var ApplicationUser = _context.Users.FirstOrDefault(u => u.Id == ApplicationUserId);
                    var usuarioLogado = _context.Usuarios.FirstOrDefault(u => u.IdentityUser.Id == ApplicationUserId);
                    usuario.IdentityUser = ApplicationUser;
                    if (usuarioLogado == null)
                    {
                        _context.Add(usuario);
                    }
                    else
                    {
                        usuarioLogado.Nome = usuario.Nome;
                        usuarioLogado.Sobrenome = usuario.Sobrenome;

                        _context.Entry(usuarioLogado).State = EntityState.Modified;
                    }
                    await _context.SaveChangesAsync();
                    return RedirectToAction("Index", "Home");
                }

            }
            return View(usuario);
        }

        // GET: Usuario/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:44302/");
                var mediaType = new MediaTypeWithQualityHeaderValue("application/json");
                client.DefaultRequestHeaders.Accept.Add(mediaType);
                var response = client.GetAsync($"api/UsuarioAPI/{id}").Result;
                Usuario usuario = new Usuario();
                if (response.IsSuccessStatusCode)
                {
                    string json = await response.Content.ReadAsStringAsync();
                    usuario = JsonConvert.DeserializeObject<Usuario>(json);
                }
                if (usuario == null)
                {
                    return NotFound();
                }
                return View(usuario);
            }
        }

        // POST: Usuario/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nome,Sobrenome,NomeSocial,DataNascimento,CPF,Genero")] Usuario usuario)
        {
            if (id != usuario.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    using (var client = new HttpClient())
                    {
                        client.BaseAddress = new Uri("https://localhost:44302/");
                        string stringData = JsonConvert.SerializeObject(usuario);
                        var contentData = new StringContent(stringData, System.Text.Encoding.UTF8, "application/json");
                        HttpResponseMessage response = client.PutAsync($"api/UsuarioAPI/{id}", contentData).Result;
                        ViewBag.Message = response.Content.ReadAsStringAsync().Result;
                    }
                }
                catch (DbUpdateConcurrencyException)
                {
                    return NotFound();
                }
                return RedirectToAction(nameof(Index));
            }
            return View(usuario);
        }

        // GET: Usuario/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:44302/");
                var mediaType = new MediaTypeWithQualityHeaderValue("application/json");
                client.DefaultRequestHeaders.Accept.Add(mediaType);
                var response = client.GetAsync($"api/UsuarioAPI/{id}").Result;
                Usuario usuario = new Usuario();
                if (response.IsSuccessStatusCode)
                {
                    string json = await response.Content.ReadAsStringAsync();
                    usuario = JsonConvert.DeserializeObject<Usuario>(json);
                }
                if (usuario == null)
                {
                    return NotFound();
                }
                return View(usuario);
            }
        }

        // POST: Usuario/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            using (var client = new HttpClient())
            {
                Usuario usuario = new Usuario();
                client.BaseAddress = new Uri("https://localhost:44302/");
                string stringData = JsonConvert.SerializeObject(usuario);
                var contentData = new StringContent(stringData, System.Text.Encoding.UTF8, "application/json");
                HttpResponseMessage response = client.DeleteAsync($"api/UsuarioAPI/{id}").Result;
                ViewBag.Message = response.Content.ReadAsStringAsync().Result;
            }
            return RedirectToAction(nameof(Index));
        }
    }
}
