using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Funcoes
{
    public static class Recursao
    {
        public static int Fatorial(int numero)
        {
            if (numero == 0 || numero == 1)
                return 1;
            else
                return numero * Fatorial(numero - 1);
        }

        public static int FatorialUtilizandoExpressao(int numero)
        {
            return numero == 0 || numero == 1 ? 1 
                    : numero * Fatorial(numero - 1);
        }
    }
}
