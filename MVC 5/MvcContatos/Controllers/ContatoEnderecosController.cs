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
    public class ContatoEnderecosController : Controller
    {
        private string Baseurl = "https://localhost:44353/";

        // GET: ContatoEnderecos
        public async Task<ActionResult> Index()
        {
            List<ContatoEnderecoViewModel> contatosComEndereco = new List<ContatoEnderecoViewModel>();
            List<ContatoViewModel> contatos = await this.ObterContatosAsync();
            foreach (var item in contatos)
            {
                List<EnderecoViewModel> enderecos = await this.ObterEnderecosAsync(item.ContatoId);
                if (enderecos != null)
                {
                }
                else
                {
                    ContatoEnderecoViewModel completo = new ContatoEnderecoViewModel();
                    completo.ContatoId = item.ContatoId;
                    completo.Email = item.Email;
                    completo.Nome = item.Nome;
                    completo.Telefone = item.Telefone;
                    completo.EnderecoViewModels = enderecos;
                    contatosComEndereco.Add(completo);
                }
            }
            return View(contatosComEndereco);
        }

        private async Task<List<ContatoViewModel>> ObterContatosAsync()
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
                return contatos;
            }
        }

        private async Task<List<EnderecoViewModel>> ObterEnderecosAsync(int id)
        {
            List<EnderecoViewModel> enderecos = new List<EnderecoViewModel>();
            using (var client = new HttpClient())
            {
                string paramUrl = string.Format("api/contato/{0}/enderecos", id);
                client.BaseAddress = new Uri(Baseurl);
                client.DefaultRequestHeaders.Clear();
                var res = await client.GetAsync(paramUrl);
                if (res.IsSuccessStatusCode)
                {
                    var enderecoResponse = res.Content.ReadAsStringAsync().Result;
                    enderecos = JsonConvert.DeserializeObject<List<EnderecoViewModel>>(enderecoResponse);
                }
                return enderecos;
            }
        }

        // GET: ContatoEnderecos/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: ContatoEnderecos/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ContatoEnderecos/Create
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

        // GET: ContatoEnderecos/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: ContatoEnderecos/Edit/5
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

        // GET: ContatoEnderecos/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ContatoEnderecos/Delete/5
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
