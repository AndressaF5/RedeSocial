﻿using System;
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
    public class DoacaoController : Controller
    {
        // GET: Doacao
        public async Task<IActionResult> Index()
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://doacaoapi2019.azurewebsites.net");
                var mediaType = new MediaTypeWithQualityHeaderValue("api/ValuesController");
                client.DefaultRequestHeaders.Accept.Add(mediaType);
                var response = client.GetAsync("api/DoacaoAPI").Result;
                List<Doacao> doacoes = new List<Doacao>();
                if (response.IsSuccessStatusCode)
                {
                    string json = await response.Content.ReadAsStringAsync();
                    doacoes = JsonConvert.DeserializeObject<List<Doacao>>(json);
                }

                return View(doacoes);
            }
        }

        // GET: Doacao/Details/5
        //public async Task<IActionResult> Details(int? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var doacao = await _context.Doacoes
        //        .FirstOrDefaultAsync(m => m.Id == id);
        //    if (doacao == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(doacao);
        //}

        // GET: Doacao/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Doacao/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,ValorDoacao,MetaArrecadacao,ValorArrecadado")] Doacao doacao)
        {
            if (ModelState.IsValid)
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri("https://doacaoapi2019.azurewebsites.net");
                    string stringData = JsonConvert.SerializeObject(doacao);
                    var contentData = new StringContent(stringData, System.Text.Encoding.UTF8, "api/ValuesController");
                    HttpResponseMessage response = client.PostAsync("api/DoacaoAPI", contentData).Result;
                    ViewBag.Message = response.Content.ReadAsStringAsync().Result;
                    return RedirectToAction(nameof(Index));
                }
            }
            return View(doacao);
        }

        // GET: Doacao/Edit/5
        //public async Task<IActionResult> Edit(int? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var doacao = await _context.Doacoes.FindAsync(id);
        //    if (doacao == null)
        //    {
        //        return NotFound();
        //    }
        //    return View(doacao);
        //}

        // POST: Doacao/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Edit(int id, [Bind("Id,ValorDoacao,MetaArrecadacao,ValorArrecadacao")] Doacao doacao)
        //{
        //    if (id != doacao.Id)
        //    {
        //        return NotFound();
        //    }

        //    if (ModelState.IsValid)
        //    {
        //        try
        //        {
        //            _context.Update(doacao);
        //            await _context.SaveChangesAsync();
        //        }
        //        catch (DbUpdateConcurrencyException)
        //        {
        //            if (!DoacaoExists(doacao.Id))
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
        //    return View(doacao);
        //}

        // GET: Doacao/Delete/5
        //public async Task<IActionResult> Delete(int? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var doacao = await _context.Doacoes
        //        .FirstOrDefaultAsync(m => m.Id == id);
        //    if (doacao == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(doacao);
        //}

        // POST: Doacao/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> DeleteConfirmed(int id)
        //{
        //    var doacao = await _context.Doacoes.FindAsync(id);
        //    _context.Doacoes.Remove(doacao);
        //    await _context.SaveChangesAsync();
        //    return RedirectToAction(nameof(Index));
        //}

        //private bool DoacaoExists(int id)
        //{
        //    return _context.Doacoes.Any(e => e.Id == id);
        //}
    }
}
