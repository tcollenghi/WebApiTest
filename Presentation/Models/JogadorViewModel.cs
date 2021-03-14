using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Presentation.Models
{
    public class JogadorViewModel
    {
        [Required(ErrorMessage = "Informe seu nome")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Informe um endereço de email válido.")]
        [DataType(DataType.EmailAddress, ErrorMessage = "Informe um endereço de email válido.")]
        public string email { get; set; }

        [Required(ErrorMessage = "Informe sua jogada")]
        public int Jogada { get; set; }
    }
}