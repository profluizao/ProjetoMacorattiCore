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





        public async Task<ActionResult> Details(int id)
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
                    return View(enderecos);
                }
                else
                {
                    return View();
                }
            }
        }
    }
}
