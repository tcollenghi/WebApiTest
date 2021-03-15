using System;
using System.Collections.Generic;
using System.Text;

namespace Business
{
    public class GameResult
    {
        public int NumeroJogadas { get; set; }

        public string DeterminaVencedor()
        {
            if (NumeroJogadas == 3)
            {
                return "Nenhum vencedor ainda";
            }
            else
            {
                return "Nenhum vencedor ainda";
            }
        }
    }
}