using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tipos
{
    public static class ControleFluxo
    {
        public static int Fatorial(int numeroParaCalcularFatorial)
        {
            int acumulador = numeroParaCalcularFatorial;
            for (int numero = numeroParaCalcularFatorial - 1; numero >= 1; numero--)
                acumulador = acumulador * numero;
            return acumulador;
        }

        public static int FatorialRecursivo ( int numero)
        {
            return numero == 0 || numero == 1 ? 1
                   : numero == 2 ? 2
                   : numero * FatorialRecursivo(numero - 1);
        }
    }
}
