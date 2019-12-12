using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Dominio;
using System.Net.Http;
using System.Net.Http.Headers;
using Newtonsoft.Json;
using Microsoft.EntityFrameworkCore;

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
                var response = client.GetAsync($"api/ArrecadacaoAPI/{id}").Result;
                Arrecadacao arrecadacao = new Arrecadacao();
                if (response.IsSuccessStatusCode)
                {
                    string json = await response.Content.ReadAsStringAsync();
                    arrecadacao = JsonConvert.DeserializeObject<Arrecadacao>(json);
                }
                if (arrecadacao == null)
                {
                    return NotFound();
                }

                return View(arrecadacao);
            }            
        }

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
                var response = client.GetAsync($"api/ArrecadacaoAPI/{id}").Result;
                Arrecadacao arrecadacao = new Arrecadacao();
                if (response.IsSuccessStatusCode)
                {
                    string json = await response.Content.ReadAsStringAsync();
                    arrecadacao = JsonConvert.DeserializeObject<Arrecadacao>(json);
                }
                if (arrecadacao == null)
                {
                    return NotFound();
                }
                return View(arrecadacao);
            }
        }

        // POST: Arrecadacao/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,QtdParticipantes,QtdAlimento,MetaArrecadacao,IdadePublicoAlvo")] Arrecadacao arrecadacao)
        {
            if (id != arrecadacao.Id)
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
                        string stringData = JsonConvert.SerializeObject(arrecadacao);
                        var contentData = new StringContent(stringData, System.Text.Encoding.UTF8, "application/json");
                        HttpResponseMessage response = client.PutAsync($"api/ArrecadacaoAPI/{id}", contentData).Result;
                        ViewBag.Message = response.Content.ReadAsStringAsync().Result;
                    }
                }
                catch (DbUpdateConcurrencyException)
                {
                    return NotFound();
                }
                return RedirectToAction(nameof(Index));
            }
            return View(arrecadacao);
        }

        // GET: Arrecadacao/Delete/5
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
                var response = client.GetAsync($"api/ArrecadacaoAPI/{id}").Result;
                Arrecadacao arrecadacao = new Arrecadacao();
                if (response.IsSuccessStatusCode)
                {
                    string json = await response.Content.ReadAsStringAsync();
                    arrecadacao = JsonConvert.DeserializeObject<Arrecadacao>(json);
                }
                if (arrecadacao == null)
                {
                    return NotFound();
                }
                return View(arrecadacao);
            }
        }

        //// POST: Arrecadacao/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            using (var client = new HttpClient())
            {
                Arrecadacao arrecadacao = new Arrecadacao();
                client.BaseAddress = new Uri("https://localhost:44302/");
                string stringData = JsonConvert.SerializeObject(arrecadacao);
                var contentData = new StringContent(stringData, System.Text.Encoding.UTF8, "application/json");
                HttpResponseMessage response = client.DeleteAsync($"api/ArrecadacaoAPI/{id}").Result;
                ViewBag.Message = response.Content.ReadAsStringAsync().Result;
            }
            return RedirectToAction(nameof(Index));
        }
    }
}
