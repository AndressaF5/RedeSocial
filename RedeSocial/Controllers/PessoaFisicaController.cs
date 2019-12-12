using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Dominio;
using System.Net.Http;
using System.Net.Http.Headers;
using Newtonsoft.Json;

namespace RedeSocial.Controllers
{
    public class PessoaFisicaController : Controller
    {
        // GET: PessoaFisica
        public async Task<IActionResult> Index()
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:44302/");
                var mediaType = new MediaTypeWithQualityHeaderValue("application/json");
                client.DefaultRequestHeaders.Accept.Add(mediaType);
                var response = client.GetAsync("api/PessoaFisicaAPI").Result;
                List<PessoaFisica> pessoasFisicas = new List<PessoaFisica>();
                if (response.IsSuccessStatusCode)
                {
                    string json = await response.Content.ReadAsStringAsync();
                    pessoasFisicas = JsonConvert.DeserializeObject<List<PessoaFisica>>(json);
                }

                return View(pessoasFisicas);
            }
        }

        // GET: PessoaFisica/Details/5
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
                var response = client.GetAsync($"api/PessoaFisicaAPI/{id}").Result;
                PessoaFisica pessoaFisica = new PessoaFisica();
                if (response.IsSuccessStatusCode)
                {
                    string json = await response.Content.ReadAsStringAsync();
                    pessoaFisica = JsonConvert.DeserializeObject<PessoaFisica>(json);
                }
                if (pessoaFisica == null)
                {
                    return NotFound();
                }

                return View(pessoaFisica);
            }
        }

        // GET: PessoaFisica/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: PessoaFisica/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nome,Sobrenome,NomeSocial,DataNascimento,CPF,Genero")] PessoaFisica pessoaFisica)
        {
            if (ModelState.IsValid)
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri("https://localhost:44302/");
                    string stringData = JsonConvert.SerializeObject(pessoaFisica);
                    var contentData = new StringContent(stringData, System.Text.Encoding.UTF8, "application/json");
                    HttpResponseMessage response = client.PostAsync("api/PessoaFisicaAPI", contentData).Result;
                    ViewBag.Message = response.Content.ReadAsStringAsync().Result;
                    return RedirectToAction(nameof(Index));
                }

            }
            return View(pessoaFisica);
        }

        // GET: PessoaFisica/Edit/5
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
                var response = client.GetAsync($"api/PessoaFisicaAPI/{id}").Result;
                PessoaFisica pessoaFisica = new PessoaFisica();
                if (response.IsSuccessStatusCode)
                {
                    string json = await response.Content.ReadAsStringAsync();
                    pessoaFisica = JsonConvert.DeserializeObject<PessoaFisica>(json);
                }
                if (pessoaFisica == null)
                {
                    return NotFound();
                }

                if (pessoaFisica == null)
                {
                    return NotFound();
                }
                return View(pessoaFisica);
            }
        }

        // POST: PessoaFisica/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nome,Sobrenome,NomeSocial,DataNascimento,CPF,Genero")] PessoaFisica pessoaFisica)
        {
            if (id != pessoaFisica.Id)
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
                        string stringData = JsonConvert.SerializeObject(pessoaFisica);
                        var contentData = new StringContent(stringData, System.Text.Encoding.UTF8, "application/json");
                        HttpResponseMessage response = client.PutAsync($"api/PessoaFisicaAPI/{id}", contentData).Result;
                        ViewBag.Message = response.Content.ReadAsStringAsync().Result;
                    }
                }
                catch (DbUpdateConcurrencyException)
                {
                    return NotFound();
                }
                return RedirectToAction(nameof(Index));
            }
            return View(pessoaFisica);
        }

        // GET: PessoaFisica/Delete/5
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
                var response = client.GetAsync($"api/PessoaFisicaAPI/{id}").Result;
                PessoaFisica pessoaFisica = new PessoaFisica();
                if (response.IsSuccessStatusCode)
                {
                    string json = await response.Content.ReadAsStringAsync();
                    pessoaFisica = JsonConvert.DeserializeObject<PessoaFisica>(json);
                }
                if (pessoaFisica == null)
                {
                    return NotFound();
                }

                if (pessoaFisica == null)
                {
                    return NotFound();
                }
                return View(pessoaFisica);
            }
        }

        // POST: PessoaFisica/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            using (var client = new HttpClient())
            {
                PessoaFisica pessoaFisica = new PessoaFisica();
                client.BaseAddress = new Uri("https://localhost:44302/");
                string stringData = JsonConvert.SerializeObject(pessoaFisica);
                var contentData = new StringContent(stringData, System.Text.Encoding.UTF8, "application/json");
                HttpResponseMessage response = client.DeleteAsync($"api/PessoaFisicaAPI/{id}").Result;
                ViewBag.Message = response.Content.ReadAsStringAsync().Result;
            }
            return RedirectToAction(nameof(Index));
        }
    }
}
