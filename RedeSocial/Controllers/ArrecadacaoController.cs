using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Dominio;
using System.Net.Http;
using System.Net.Http.Headers;
using Newtonsoft.Json;

namespace RedeSocial.Controllers
{
    public class ArrecadacaoController : Controller
    {
        // GET: Arrecadacao
        public async Task<IActionResult> Index()
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:44302/");
                var mediaType = new MediaTypeWithQualityHeaderValue("application/json");
                client.DefaultRequestHeaders.Accept.Add(mediaType);
                var response = client.GetAsync("api/ArrecadacaoAPI").Result;
                List<Arrecadacao> arrecadacoes = new List<Arrecadacao>();
                if (response.IsSuccessStatusCode)
                {
                    string json = await response.Content.ReadAsStringAsync();
                    arrecadacoes = JsonConvert.DeserializeObject<List<Arrecadacao>>(json);
                }

                return View(arrecadacoes);
            }
        }

        // GET: Arrecadacao/Details/5
        //public async Task<IActionResult> Details(int? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var arrecadacao = await _context.Arrecadacoes
        //        .FirstOrDefaultAsync(m => m.Id == id);
        //    if (arrecadacao == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(arrecadacao);
        //}

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
        public async Task<IActionResult> Create([Bind("Id,QtdParticipantes,QtdAlimento,MetaArrecadacao,PublicoAlvo")] Arrecadacao arrecadacao)
        {
            if (ModelState.IsValid)
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri("https://localhost:44302/");
                    string stringData = JsonConvert.SerializeObject(arrecadacao);
                    var contentData = new StringContent(stringData, System.Text.Encoding.UTF8, "applicationjson");
                    HttpResponseMessage response = client.PostAsync("api/ArrecadacaoAPI", contentData).Result;
                    ViewBag.Message = response.Content.ReadAsStringAsync().Result;
                    return RedirectToAction(nameof(Index));
                }
            }
            return View(arrecadacao);
        }

        // GET: Arrecadacao/Edit/5
        //public async Task<IActionResult> Edit(int? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var arrecadacao = await _context.Arrecadacoes.FindAsync(id);
        //    if (arrecadacao == null)
        //    {
        //        return NotFound();
        //    }
        //    return View(arrecadacao);
        //}

        // POST: Arrecadacao/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Edit(int id, [Bind("Id,QtdParticipantes,QtdAlimento,MetaArrecadacao,IdadePublicoAlvo")] Arrecadacao arrecadacao)
        //{
        //    if (id != arrecadacao.Id)
        //    {
        //        return NotFound();
        //    }

        //    if (ModelState.IsValid)
        //    {
        //        try
        //        {
        //            _context.Update(arrecadacao);
        //            await _context.SaveChangesAsync();
        //        }
        //        catch (DbUpdateConcurrencyException)
        //        {
        //            if (!ArrecadacaoExists(arrecadacao.Id))
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
        //    return View(arrecadacao);
        //}

        // GET: Arrecadacao/Delete/5
        //public async Task<IActionResult> Delete(int? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var arrecadacao = await _context.Arrecadacoes
        //        .FirstOrDefaultAsync(m => m.Id == id);
        //    if (arrecadacao == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(arrecadacao);
        //}

        //// POST: Arrecadacao/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> DeleteConfirmed(int id)
        //{
        //    var arrecadacao = await _context.Arrecadacoes.FindAsync(id);
        //    _context.Arrecadacoes.Remove(arrecadacao);
        //    await _context.SaveChangesAsync();
        //    return RedirectToAction(nameof(Index));
        //}

        //private bool ArrecadacaoExists(int id)
        //{
        //    return _context.Arrecadacoes.Any(e => e.Id == id);
        //}
    }
}
