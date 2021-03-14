using System;
using System.Collections.Generic;

using System.Text;
using Repository.Models;

namespace Services
{
    public class JogadasServices
    {
        public static List<JogadasModel> GetJogadas()
        {
            var listaJogadas = new List<JogadasModel>();
            SetJogadas(listaJogadas);
            return listaJogadas;
        }

        private static void SetJogadas(List<JogadasModel> listaJogadas)
        {
            listaJogadas.Add(new JogadasModel(1, "Pedra"));
            listaJogadas.Add(new JogadasModel(2, "Tesoura"));
            listaJogadas.Add(new JogadasModel(3, "Papel"));
        }
    }
}