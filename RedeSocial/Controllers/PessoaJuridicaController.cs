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
    public class PessoaJuridicaController : Controller
    {
        // GET: PessoaJuridica
        public async Task<IActionResult> Index()
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://pessoajuridicaapi2019.azurewebsites.net");
                var mediaTyper = new MediaTypeWithQualityHeaderValue("api/ValuesController");
                client.DefaultRequestHeaders.Accept.Add(mediaTyper);
                var response = client.GetAsync("api/PessoaJuridicaAPI").Result;
                List<PessoaJuridica> pessoasJuridicas = new List<PessoaJuridica>();
                if (response.IsSuccessStatusCode)
                {
                    string json = await response.Content.ReadAsStringAsync();
                    pessoasJuridicas = JsonConvert.DeserializeObject<List<PessoaJuridica>>(json);
                }

                return View(pessoasJuridicas);
            }
        }

        // GET: PessoaJuridica/Details/5
        //public async Task<IActionResult> Details(int? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var pessoaJuridica = await _context.PessoasJuridicas
        //        .FirstOrDefaultAsync(m => m.Id == id);
        //    if (pessoaJuridica == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(pessoaJuridica);
        //}

        // GET: PessoaJuridica/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: PessoaJuridica/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,NomeEmpresa,CNPJ,RazaoSocial")] PessoaJuridica pessoaJuridica)
        {
            if (ModelState.IsValid)
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri("https://pessoajuridicaapi2019.azurewebsites.net");
                    string stringData = JsonConvert.SerializeObject(pessoaJuridica);
                    var contentData = new StringContent(stringData, System.Text.Encoding.UTF8, "api/ValuesController");
                    HttpResponseMessage response = client.PostAsync("api/PessoaJuridicaAPI", contentData).Result;
                    ViewBag.Message = response.Content.ReadAsStringAsync().Result;
                    return RedirectToAction(nameof(Index));
                }
            }
            return View(pessoaJuridica);
        }

        // GET: PessoaJuridica/Edit/5
        //public async Task<IActionResult> Edit(int? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var pessoaJuridica = await _context.PessoasJuridicas.FindAsync(id);
        //    if (pessoaJuridica == null)
        //    {
        //        return NotFound();
        //    }
        //    return View(pessoaJuridica);
        //}

        // POST: PessoaJuridica/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Edit(int id, [Bind("Id,NomeEmpresa,CNPJ,RazaoSocial")] PessoaJuridica pessoaJuridica)
        //{
        //    if (id != pessoaJuridica.Id)
        //    {
        //        return NotFound();
        //    }

        //    if (ModelState.IsValid)
        //    {
        //        try
        //        {
        //            _context.Update(pessoaJuridica);
        //            await _context.SaveChangesAsync();
        //        }
        //        catch (DbUpdateConcurrencyException)
        //        {
        //            if (!PessoaJuridicaExists(pessoaJuridica.Id))
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
        //    return View(pessoaJuridica);
        //}

        // GET: PessoaJuridica/Delete/5
        //public async Task<IActionResult> Delete(int? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var pessoaJuridica = await _context.PessoasJuridicas
        //        .FirstOrDefaultAsync(m => m.Id == id);
        //    if (pessoaJuridica == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(pessoaJuridica);
        //}

        // POST: PessoaJuridica/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> DeleteConfirmed(int id)
        //{
        //    var pessoaJuridica = await _context.PessoasJuridicas.FindAsync(id);
        //    _context.PessoasJuridicas.Remove(pessoaJuridica);
        //    await _context.SaveChangesAsync();
        //    return RedirectToAction(nameof(Index));
        //}

        //private bool PessoaJuridicaExists(int id)
        //{
        //    return _context.PessoasJuridicas.Any(e => e.Id == id);
        //}
    }
}
