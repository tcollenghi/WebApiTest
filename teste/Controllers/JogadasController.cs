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
        [HttpGet("/api/Hello")]
        public IActionResult SayHello()
        {
            return Ok("Hello");
        }

        [HttpGet("/api/Jogadas")]
        public IActionResult GetJogadas()
        {
            return Ok(JogadasServices.GetJogadas());
        }
    }
}