using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Resources
{
    public class JogadaResource
    {
        public JogadaResource()
        {
        }

        public JogadaResource(string nome, string email, string jogada)
        {
            this.Nome = nome;
            this.Email = email;
            this.Jogada = jogada;
        }

        public string Nome { get; set; }
        public string Email { get; set; }

        public string Jogada { get; set; }
    }
}