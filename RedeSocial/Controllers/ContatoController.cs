using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Banco;
using Dominio;
using System.Net.Http;
using System.Net.Http.Headers;
using Newtonsoft.Json;

namespace RedeSocial.Controllers
{
    public class ContatoController : Controller
    {
        // GET: Contato
        public async Task<IActionResult> Index()
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://contatoapi2019.azurewebsites.net");
                var mediaType = new MediaTypeWithQualityHeaderValue("api/ValuesController");
                client.DefaultRequestHeaders.Accept.Add(mediaType);
                var response = client.GetAsync("api/ContatoAPI").Result;
                List<Contato> contatos = new List<Contato>();
                if (response.IsSuccessStatusCode)
                {
                    string json = await response.Content.ReadAsStringAsync();
                    contatos = JsonConvert.DeserializeObject<List<Contato>>(json);
                }

                return View(contatos);
            }
        }

        // GET: Contato/Details/5
        //public async Task<IActionResult> Details(int? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var contato = await _context.Contatos
        //        .FirstOrDefaultAsync(m => m.Id == id);
        //    if (contato == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(contato);
        //}

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
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri("https://contatoapi2019.azurewebsites.net");
                    string stringData = JsonConvert.SerializeObject(contato);
                    var contentData = new StringContent(stringData, System.Text.Encoding.UTF8, "api/ValuesController");
                    HttpResponseMessage response = client.PostAsync("api/ContatoAPI", contentData).Result;
                    ViewBag.Message = response.Content.ReadAsStringAsync().Result;
                    return RedirectToAction(nameof(Index));
                }
            }
            return View(contato);
        }

        // GET: Contato/Edit/5
        //public async Task<IActionResult> Edit(int? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var contato = await _context.Contatos.FindAsync(id);
        //    if (contato == null)
        //    {
        //        return NotFound();
        //    }
        //    return View(contato);
        //}

        // POST: Contato/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Edit(int id, [Bind("Id,Telefone,Celular")] Contato contato)
        //{
        //    if (id != contato.Id)
        //    {
        //        return NotFound();
        //    }

        //    if (ModelState.IsValid)
        //    {
        //        try
        //        {
        //            _context.Update(contato);
        //            await _context.SaveChangesAsync();
        //        }
        //        catch (DbUpdateConcurrencyException)
        //        {
        //            if (!ContatoExists(contato.Id))
        //            {
        //                return NotFound();
        //            }
        //            else
        //            {
        //                throw;
        //            }
        //        }
        //        return RedirectToAction(nameof(Index));
        //    }
        //    return View(contato);
        //}

        // GET: Contato/Delete/5
        //public async Task<IActionResult> Delete(int? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var contato = await _context.Contatos
        //        .FirstOrDefaultAsync(m => m.Id == id);
        //    if (contato == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(contato);
        //}

        // POST: Contato/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> DeleteConfirmed(int id)
        //{
        //    var contato = await _context.Contatos.FindAsync(id);
        //    _context.Contatos.Remove(contato);
        //    await _context.SaveChangesAsync();
        //    return RedirectToAction(nameof(Index));
        //}

        //private bool ContatoExists(int id)
        //{
        //    return _context.Contatos.Any(e => e.Id == id);
        //}
    }
}
