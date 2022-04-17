using Microsoft.AspNetCore.Mvc;
using WebLocadora.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;


namespace WebLocadora.Controllers
{
    public class FilmeController : Controller
    {
        public ActionResult Index()
        {
            IEnumerable<Filme> filmes = null;

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:44376/api/");

                //HTTP GET
                var responseTask = client.GetAsync("Filmes");
                responseTask.Wait();
                var result = responseTask.Result;

                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<IList<Filme>>();
                    readTask.Wait();
                    filmes = readTask.Result;
                }
                else
                {
                    filmes = Enumerable.Empty<Filme>();
                    ModelState.AddModelError(string.Empty, "Erro no servidor. Contate o Administrador.");
                }
                return View(filmes);
            }
        }
        //    //Hosted web API REST Service base url
        //    string Baseurl = "http://localhost:5231/";
        //    public async Task<ActionResult> Index()
        //    {
        //        List<Cliente> ClienteInfo = new List<Cliente>();
        //        using (var client = new HttpClient())
        //        {
        //            //Passing service base url
        //            client.BaseAddress = new Uri(Baseurl);
        //            client.DefaultRequestHeaders.Clear();
        //            //Define request data format
        //            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        //            //Sending request to find web api REST service resource GetAllEmployees using HttpClient
        //            HttpResponseMessage Res = await client.GetAsync("api/Cliente/GetClientes");
        //            //Checking the response is successful or not which is sent using HttpClient
        //            if (Res.IsSuccessStatusCode)
        //            {
        //                //Storing the response details recieved from web api
        //                var ClienteResponse = Res.Content.ReadAsStringAsync().Result;
        //                //Deserializing the response recieved from web api and storing into the Employee list
        //                ClienteInfo = JsonConvert.DeserializeObject<List<Cliente>>(ClienteResponse);
        //            }
        //            //returning the employee list to view
        //            return View(ClienteInfo);
        //        }
        //    }
        //}    
    }
}

