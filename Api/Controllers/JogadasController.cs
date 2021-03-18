using Api.Resources;
using Business;
using Microsoft.AspNetCore.Http;
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
        private const string aguardandoJogador = "Aguardando Jogador";
        private List<JogadaResource> ListaJogadas = new List<JogadaResource>();
        private GameResult gameResult = new GameResult();

        [HttpGet("/api/Hello")]
        public IActionResult SayHello()
        {
            return Ok("Hello");
        }

        [HttpGet("/api/jogadas")]
        public IActionResult GetJogadas()
        {
            return Ok(GetJogadasList());
        }

        [HttpPost("/api/setJogadas")]
        public IActionResult SetJogada([FromBody] JogadaResource resource)
        {
            var jogadaResource = new JogadaResource(resource.Nome, resource.Email, resource.Jogada);
            ListaJogadas.Add(jogadaResource);
            HttpContext.Session.SetString(resource.Email, resource.Jogada);
            return Ok();
        }

        [HttpGet("/api/verResultado")]
        public IActionResult VerResultado()
        {
            foreach (var item in HttpContext.Session.Keys)
            {
                gameResult.AddJogada(HttpContext.Session.GetString(item), item, string.Empty);
            }

            if (HttpContext.Session.Keys.Count() > 1)
            {
                var jogadaVencedora = gameResult.DeterminaVencedor();
                var result = HttpContext.Session.GetString(jogadaVencedora);
                return Ok(jogadaVencedora);
            }
            else
            {
                return Ok(aguardandoJogador);
            }
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