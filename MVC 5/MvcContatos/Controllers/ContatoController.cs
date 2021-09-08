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





        public ActionResult Details(int id)
        {
            ContatoViewModel contato = null;
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(this.Baseurl);
                var responseTask = client.GetAsync("api/contato/" + id.ToString());
                responseTask.Wait();
                var result = responseTask.Result;

                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<ContatoViewModel>();
                    readTask.Wait();
                    contato = readTask.Result;
                }
                else
                {
                    throw new Exception();
                }
            }
            return View(contato);
        }





        public ActionResult Create()
        {
            return View();
        }


        [HttpPost]
        public ActionResult Create(ContatoViewModel contato)
        {
            try
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(this.Baseurl);
                    //HTTP POST
                    var postTask = client.PostAsJsonAsync<ContatoViewModel>("api/contato", contato);
                    postTask.Wait();
                    var result = postTask.Result;

                    if (result.IsSuccessStatusCode)
                    {
                        return RedirectToAction("Index");
                    }
                    else
                    {
                        throw new Exception();
                    }
                }
            }
            catch
            {
                ModelState.AddModelError(string.Empty, "Erro no Servidor. Contacte o Administrador.");
                return View(contato);
            }
        }





        public ActionResult Edit(int id)
        {
            ContatoViewModel contato = null;
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(this.Baseurl);
                var responseTask = client.GetAsync("api/contato/" + id.ToString());
                responseTask.Wait();
                var result = responseTask.Result;

                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<ContatoViewModel>();
                    readTask.Wait();
                    contato = readTask.Result;
                }
                else
                {
                    throw new Exception();
                }
            }
            return View(contato);
        }

        [HttpPost]
        public ActionResult Edit(ContatoViewModel contato)
        {
            try
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(this.Baseurl);
                    var putTask = client.PutAsJsonAsync<ContatoViewModel>("api/contato", contato);
                    putTask.Wait();
                    var result = putTask.Result;

                    if (result.IsSuccessStatusCode)
                    {
                        return RedirectToAction("Index");
                    }
                    else
                    {
                        return View(contato);
                    }
                }
            }
            catch
            {
                return View();
            }
        }





        public ActionResult Delete(int id)
        {
            try
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(this.Baseurl);
                    var deleteTask = client.DeleteAsync("api/contato/" + id.ToString());
                    deleteTask.Wait();
                    var result = deleteTask.Result;

                    if (result.IsSuccessStatusCode)
                    {
                        return RedirectToAction("Index");
                    }
                    else
                    {
                        throw new Exception();
                    }
                }
            }
            catch
            {
                return View();
            }
        }

        //[HttpDelete]
        //public ActionResult Delete(ContatoViewModel contato)
        //{
        //    try
        //    {
        //        using (var client = new HttpClient())
        //        {
        //            client.BaseAddress = new Uri(this.Baseurl);
        //            var deleteTask = client.DeleteAsync("api/contato/" + contato.ContatoId.ToString());
        //            deleteTask.Wait();
        //            var result = deleteTask.Result;

        //            if (result.IsSuccessStatusCode)
        //            {
        //                return RedirectToAction("Index");
        //            }
        //            else
        //            {
        //                throw new Exception();
        //            }
        //        }
        //    }
        //    catch
        //    {
        //        return View(contato);
        //    }
        //}
    }
}
