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

namespace Presentation.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private List<SelectListItem> listaJogadas = new List<SelectListItem>();

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

        public IActionResult Conclusao(JogadorViewModel model)
        {
            return View(model);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
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
                listaJogadas = await getOpcoesJogada(listaJogadas);
                ViewBag.ListaJogadas = listaJogadas;
                ViewBag.Error = "Jogada inválida";
                return View(model);
            }
        }

        [HttpGet]
        public async Task<IActionResult> Jogar()
        {
            ViewBag.Error = string.Empty;
            listaJogadas = await getOpcoesJogada(listaJogadas);
            ViewBag.ListaJogadas = listaJogadas;
            return View();
        }

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
    }
}