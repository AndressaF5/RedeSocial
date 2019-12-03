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
    public class EventoController : Controller
    {
        // GET: Evento
        public async Task<IActionResult> Index()
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://eventoapi2019.azurewebsites.net");
                var mediaType = new MediaTypeWithQualityHeaderValue("api/ValuesController");
                client.DefaultRequestHeaders.Accept.Add(mediaType);
                var response = client.GetAsync("api/EventoAPI").Result;
                List<Evento> eventos = new List<Evento>();
                if (response.IsSuccessStatusCode)
                {
                    string json = await response.Content.ReadAsStringAsync();
                    eventos = JsonConvert.DeserializeObject<List<Evento>>(json);
                }

                return View(eventos);
            }
        }

        // GET: Evento/Details/5
        //public async Task<IActionResult> Details(int? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var evento = await _context.Eventos
        //        .FirstOrDefaultAsync(m => m.Id == id);
        //    if (evento == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(evento);
        //}

        // GET: Evento/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Evento/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,NomeAtividade,Data,Hora,Categoria,Descricao")] Evento evento)
        {
            if (ModelState.IsValid)
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri("https://eventoapi2019.azurewebsites.net");
                    string stringData = JsonConvert.SerializeObject(evento);
                    var contentData = new StringContent(stringData, System.Text.Encoding.UTF8, "api/ValuesController");
                    HttpResponseMessage response = client.PostAsync("api/EventoAPI", contentData).Result;
                    ViewBag.Message = response.Content.ReadAsStringAsync().Result;
                    return RedirectToAction(nameof(Index));
                }
            }
            return View(evento);
        }

        // GET: Evento/Edit/5
        //public async Task<IActionResult> Edit(int? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var evento = await _context.Eventos.FindAsync(id);
        //    if (evento == null)
        //    {
        //        return NotFound();
        //    }
        //    return View(evento);
        //}

        // POST: Evento/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Edit(int id, [Bind("Id,NomeAtividade,Data,Hora,Categoria,Descricao")] Evento evento)
        //{
        //    if (id != evento.Id)
        //    {
        //        return NotFound();
        //    }

        //    if (ModelState.IsValid)
        //    {
        //        try
        //        {
        //            _context.Update(evento);
        //            await _context.SaveChangesAsync();
        //        }
        //        catch (DbUpdateConcurrencyException)
        //        {
        //            if (!EventoExists(evento.Id))
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
        //    return View(evento);
        //}

        // GET: Evento/Delete/5
        //public async Task<IActionResult> Delete(int? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var evento = await _context.Eventos
        //        .FirstOrDefaultAsync(m => m.Id == id);
        //    if (evento == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(evento);
        //}

        // POST: Evento/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> DeleteConfirmed(int id)
        //{
        //    var evento = await _context.Eventos.FindAsync(id);
        //    _context.Eventos.Remove(evento);
        //    await _context.SaveChangesAsync();
        //    return RedirectToAction(nameof(Index));
        //}

        //private bool EventoExists(int id)
        //{
        //    return _context.Eventos.Any(e => e.Id == id);
        //}
    }
}
