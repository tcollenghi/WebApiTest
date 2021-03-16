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

        public GameResult()
        {
            Jogadas = new List<JogadasModel>();
        }

        public List<JogadasModel> Jogadas { get; set; }

        public string DeterminaVencedor()
        {
            var result = new List<JogadasModel>();
            if (Jogadas.Count == numeroJogadas)
            {
                if (Jogadas.Where(p => p.Jogada.ToUpper() == pedra &&
                                       p.Jogada.ToUpper() == tesoura &&
                                       p.Jogada.ToUpper() == papel).ToList().Count == numeroJogadas)

                    return empate;
                else
                {
                    if (Jogadas.Where(p => p.Jogada.ToUpper() == pedra &&
                                           p.Jogada.ToUpper() == tesoura &&
                                           p.Jogada.ToUpper() != papel).ToList().Count == numeroJogadas)
                    {
                        return tesoura;
                    }
                    else
                    {
                        if (Jogadas.Where(p => p.Jogada.ToUpper() == pedra &&
                                               p.Jogada.ToUpper() != tesoura &&
                                               p.Jogada.ToUpper() == papel).ToList().Count == numeroJogadas)
                        {
                            return papel;
                        }
                        else
                        {
                            return tesoura;
                        }
                    }
                }
            }
            else
            {
                return empate;
            }
        }
    }
}