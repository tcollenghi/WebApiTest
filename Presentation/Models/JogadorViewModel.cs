using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Presentation.Models
{
    public class JogadorViewModel
    {
        [Required]
        public string Nome { get; set; }

        [DataType(DataType.EmailAddress, ErrorMessage = "Informe um endereço de email válido.")]
        [Required]
        public string email { get; set; }

        [Required]
        public int Jogada { get; set; }
    }
}