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
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        [HttpPost]
        public IActionResult Jogar(JogadorViewModel model)
        {
            ViewBag.Error = string.Empty;
            if (model.Jogada > 0)
            {
                RedirectToAction("Conclusao", "Home", model);
            }
            else
            {
                ViewBag.Error = "Jogada inválida";
                return View(model);
            }
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Jogar()
        {
            List<SelectListItem> listaJogadas = new List<SelectListItem>();
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync("https://localhost:44387/api/Jogadas"))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    listaJogadas = JsonConvert.DeserializeObject<List<SelectListItem>>(apiResponse);
                }
            }
            ViewBag.ListaJogadas = listaJogadas;
            return View();
        }
    }
}