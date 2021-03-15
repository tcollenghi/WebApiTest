using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Logging;
using Presentation.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Repository.Models;
using Newtonsoft.Json;
using System.Text;
using System.Net.Http.Headers;

namespace Presentation.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private List<SelectListItem> listaJogadas = new List<SelectListItem>();

        private static async Task<List<SelectListItem>> getOpcoesJogada(List<SelectListItem> listaJogadas)
        {
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync("https://localhost:44387/api/Jogadas"))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    listaJogadas = JsonConvert.DeserializeObject<List<SelectListItem>>(apiResponse);
                }
            }

            return listaJogadas;
        }

        private async Task getJogadas()
        {
            listaJogadas = await getOpcoesJogada(listaJogadas);
            ViewBag.ListaJogadas = listaJogadas;
        }

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public async Task<IActionResult> Conclusao(JogadorViewModel model)
        {
            var message = JsonConvert.SerializeObject(new
            {
                Nome = model.Nome,
                email = model.email,
                jogada = model.Jogada.ToString()
            });

            var jsonContent = message;
            var contentString = new StringContent(jsonContent, Encoding.UTF8, "application/json");
            contentString.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            using (var httpClient = new HttpClient())
            {
                var response = await httpClient.PostAsync("https://localhost:44387/api/SetJogada", contentString);
            }

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Jogar()
        {
            ViewBag.Error = string.Empty;
            await getJogadas();
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Jogar(JogadorViewModel model)
        {
            ViewBag.Error = string.Empty;
            if (model.Jogada > 0)
            {
                return RedirectToAction("Conclusao", "Home", model);
            }
            else
            {
                await getJogadas();
                ViewBag.Error = "Jogada inválida";
                return View(model);
            }
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}