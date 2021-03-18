using Repository.Models;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace Business
{
    public class GameResult
    {
        private const int numeroJogadas = 3;
        private const string pedra = "PEDRA";
        private const string tesoura = "TESOURA";
        private const string papel = "PAPEL";
        private const string empate = "Empate";

        public List<JogadasModel> Jogadas { get; set; }

        public GameResult()
        {
            Jogadas = new List<JogadasModel>();
        }

        public void AddJogada(string jogada, string nomeJogador, string email)
        {
            var jogadasModel = new JogadasModel(jogada, nomeJogador, email);
            Jogadas.Add(jogadasModel);
        }

        public string DeterminaVencedor()
        {
            var result = new List<JogadasModel>();
            if (Jogadas.Count > 1)
            {
                if (Jogadas.Where(p => p.Jogada.ToUpper() == pedra &&
                                       p.Jogada.ToUpper() == tesoura &&
                                       p.Jogada.ToUpper() == papel).ToList().Count > 0)

                    return empate;
                else
                {
                    if (Jogadas.Where(p => p.Jogada.ToUpper() == pedra &&
                                           p.Jogada.ToUpper() == tesoura &&
                                           p.Jogada.ToUpper() != papel).ToList().Count > 0)
                    {
                        return tesoura;
                    }
                    else
                    {
                        if (Jogadas.Where(p => p.Jogada.ToUpper() == pedra &&
                                               p.Jogada.ToUpper() != tesoura &&
                                               p.Jogada.ToUpper() == papel).ToList().Count > 0)
                        {
                            return papel;
                        }
                        else
                        {
                            return pedra;
                        }
                    }
                }
            }
            else
            {
                return "Aguardando outros jogadores";
            }
        }
    }
}