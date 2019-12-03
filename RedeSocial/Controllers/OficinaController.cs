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
    public class OficinaController : Controller
    {
        // GET: Oficina
        public async Task<IActionResult> Index()
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://oficinaapi2019.azurewebsites.net");
                var mediaType = new MediaTypeWithQualityHeaderValue("api/ValuesController");
                client.DefaultRequestHeaders.Accept.Add(mediaType);
                var response = client.GetAsync("api/OficinaAPI").Result;
                List<Oficina> oficinas = new List<Oficina>();
                if (response.IsSuccessStatusCode)
                {
                    string json = await response.Content.ReadAsStringAsync();
                    oficinas = JsonConvert.DeserializeObject<List<Oficina>>(json);
                }

                return View(oficinas);
            }
        }

        // GET: Oficina/Details/5
        //public async Task<IActionResult> Details(int? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var oficina = await _context.Oficinas
        //        .FirstOrDefaultAsync(m => m.Id == id);
        //    if (oficina == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(oficina);
        //}

        // GET: Oficina/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Oficina/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,QtdPrticipantes,NomeAtividade,Data,Hora,Categoria,Descricao")] Oficina oficina)
        {
            if (ModelState.IsValid)
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri("https://oficinaapi2019.azurewebsites.net");
                    string stringData = JsonConvert.SerializeObject(oficina);
                    var contentData = new StringContent(stringData, System.Text.Encoding.UTF8, "api/ValuesController");
                    HttpResponseMessage response = client.PostAsync("api/OficinaAPI", contentData).Result;
                    ViewBag.Message = response.Content.ReadAsStringAsync().Result;
                    return RedirectToAction(nameof(Index));
                }
            }
            return View(oficina);
        }

        // GET: Oficina/Edit/5
        //public async Task<IActionResult> Edit(int? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var oficina = await _context.Oficinas.FindAsync(id);
        //    if (oficina == null)
        //    {
        //        return NotFound();
        //    }
        //    return View(oficina);
        //}

        // POST: Oficina/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Edit(int id, [Bind("Id,QtdPrticipantes,NomeAtividade,Data,Hora,Categoria,Descricao")] Oficina oficina)
        //{
        //    if (id != oficina.Id)
        //    {
        //        return NotFound();
        //    }

        //    if (ModelState.IsValid)
        //    {
        //        try
        //        {
        //            _context.Update(oficina);
        //            await _context.SaveChangesAsync();
        //        }
        //        catch (DbUpdateConcurrencyException)
        //        {
        //            if (!OficinaExists(oficina.Id))
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
        //    return View(oficina);
        //}

        // GET: Oficina/Delete/5
        //public async Task<IActionResult> Delete(int? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var oficina = await _context.Oficinas
        //        .FirstOrDefaultAsync(m => m.Id == id);
        //    if (oficina == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(oficina);
        //}

        // POST: Oficina/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> DeleteConfirmed(int id)
        //{
        //    var oficina = await _context.Oficinas.FindAsync(id);
        //    _context.Oficinas.Remove(oficina);
        //    await _context.SaveChangesAsync();
        //    return RedirectToAction(nameof(Index));
        //}

        //private bool OficinaExists(int id)
        //{
        //    return _context.Oficinas.Any(e => e.Id == id);
        //}
    }
}
