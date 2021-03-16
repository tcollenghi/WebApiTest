using Repository.Models;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace Business
{
    public class GameResult
    {
        public GameResult()
        {
            Jogadas = new List<JogadasModel>();
        }

        public List<JogadasModel> Jogadas { get; set; }

        public string DeterminaVencedor()
        {
            var result = new List<JogadasModel>();
            if (Jogadas.Count == 3)
            {
                if (Jogadas.Where(p => p.Jogada.ToUpper() == "PEDRA" &&
                                       p.Jogada.ToUpper() == "TESOURA" &&
                                       p.Jogada.ToUpper() == "PAPEL").ToList().Count == 3)

                    return "Empate";
                else
                {
                    if (Jogadas.Where(p => p.Jogada.ToUpper() == "PEDRA" &&
                                           p.Jogada.ToUpper() == "TESOURA" &&
                                           p.Jogada.ToUpper() != "PAPEL").ToList().Count == 3)
                    {
                        return "Tesoura";
                    }
                    else
                    {
                        if (Jogadas.Where(p => p.Jogada.ToUpper() == "PEDRA" &&
                                               p.Jogada.ToUpper() != "TESOURA" &&
                                               p.Jogada.ToUpper() == "PAPEL").ToList().Count == 3)
                        {
                            return "Papel";
                        }
                        else
                        {
                            return "Tesoura";
                        }
                    }
                }
            }
            else
            {
                return "Empate";
            }
        }
    }
}