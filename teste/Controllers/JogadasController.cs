using Microsoft.AspNetCore.Mvc;
using Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Controllers
{
    public class JogadasController : Controller
    {
        [HttpGet("/api/taxaJuros")]
        public string GetTaxaJuros()
        {
            //return db.Config.Where(p => p.ConfigKey == "TaxaJuros").FirstOrDefault().Value;
            return string.Empty;
        }

        [HttpGet("/api/Jogadas")]
        public IActionResult GetJogadas()
        {
            return Json(JogadasServices.GetJogadas());
        }
    }
}