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
    public class EnderecoController : Controller
    {
        // GET: Endereco
        public async Task<IActionResult> Index()
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://enderecoapi2019.azurewebsites.net");
                var mediaType = new MediaTypeWithQualityHeaderValue("api/ValuesController");
                client.DefaultRequestHeaders.Accept.Add(mediaType);
                var response = client.GetAsync("api/EnderecoAPI").Result;
                List<Evento> eventos = new List<Evento>();
                if (response.IsSuccessStatusCode)
                {
                    string json = await response.Content.ReadAsStringAsync();
                    eventos = JsonConvert.DeserializeObject<List<Evento>>(json);
                }

                return View(eventos);
            }
        }

        // GET: Endereco/Details/5
        //public async Task<IActionResult> Details(int? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var endereco = await _context.Enderecos
        //        .FirstOrDefaultAsync(m => m.Id == id);
        //    if (endereco == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(endereco);
        //}

        // GET: Endereco/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Endereco/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Rua,Bairro,Cidade,UF,CEP,Complemento")] Endereco endereco)
        {
            if (ModelState.IsValid)
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri("https://enderecoapi2019.azurewebsites.net");
                    string stringData = JsonConvert.SerializeObject(endereco);
                    var contentData = new StringContent(stringData, System.Text.Encoding.UTF8, "api/ValuesController");
                    HttpResponseMessage response = client.PostAsync("api/EnderecoAPI", contentData).Result;
                    ViewBag.Message = response.Content.ReadAsStringAsync().Result;
                    return RedirectToAction(nameof(Index));
                }
            }
            return View(endereco);
        }

        // GET: Endereco/Edit/5
        //public async Task<IActionResult> Edit(int? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var endereco = await _context.Enderecos.FindAsync(id);
        //    if (endereco == null)
        //    {
        //        return NotFound();
        //    }
        //    return View(endereco);
        //}

        // POST: Endereco/Edit/5
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Edit(int id, [Bind("Id,Rua,Bairro,Cidade,UF,CEP,Complemento")] Endereco endereco)
        //{
        //    if (id != endereco.Id)
        //    {
        //        return NotFound();
        //    }

        //    if (ModelState.IsValid)
        //    {
        //        try
        //        {
        //            _context.Update(endereco);
        //            await _context.SaveChangesAsync();
        //        }
        //        catch (DbUpdateConcurrencyException)
        //        {
        //            if (!EnderecoExists(endereco.Id))
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
        //    return View(endereco);
        //}

        // GET: Endereco/Delete/5
        //public async Task<IActionResult> Delete(int? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var endereco = await _context.Enderecos
        //        .FirstOrDefaultAsync(m => m.Id == id);
        //    if (endereco == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(endereco);
        //}

        // POST: Endereco/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> DeleteConfirmed(int id)
        //{
        //    var endereco = await _context.Enderecos.FindAsync(id);
        //    _context.Enderecos.Remove(endereco);
        //    await _context.SaveChangesAsync();
        //    return RedirectToAction(nameof(Index));
        //}

        //private bool EnderecoExists(int id)
        //{
        //    return _context.Enderecos.Any(e => e.Id == id);
        //}
    }
}
