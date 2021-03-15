using Api.Resources;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Services;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Controllers
{
    public class JogadasController : Controller
    {
        [HttpGet("/api/Hello")]
        public IActionResult SayHello()
        {
            return Ok("Hello");
        }

        [HttpGet("/api/Jogadas")]
        public IActionResult GetJogadas()
        {
            return Ok(GetJogadasList());
        }

        [HttpPost("/api/SetJogadas")]
        public IActionResult SetJogada(JogadaResource resource)
        {
            return Ok(GetJogadasList());
        }

        private List<SelectListItem> GetJogadasList()
        {
            List<SelectListItem> listaCombo = new List<SelectListItem>();
            JogadasServices.GetJogadas().ForEach(t => listaCombo.Add(new SelectListItem() { Text = t.Jogada, Value = t.id.ToString() }));
            listaCombo.Insert(0, new SelectListItem() { Text = "Selecione", Value = "0" });
            return listaCombo;
        }
    }
}