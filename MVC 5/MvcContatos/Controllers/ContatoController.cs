using MvcContatos.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace MvcContatos.Controllers
{
    public class ContatoController : Controller
    {
        private string Baseurl = "https://localhost:44353/";

        // GET: Contato
        public async Task<ActionResult> Index()
        {
            List<ContatoViewModel> contatos = new List<ContatoViewModel>();

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(Baseurl);
                client.DefaultRequestHeaders.Clear();
                var res = await client.GetAsync("api/contato");
                if (res.IsSuccessStatusCode)
                {
                    var contatoResponse = res.Content.ReadAsStringAsync().Result;
                    contatos = JsonConvert.DeserializeObject<List<ContatoViewModel>>(contatoResponse);
                }
                return View(contatos);
            }
        }

        // GET: Contato/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Contato/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Contato/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Contato/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Contato/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Contato/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Contato/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
