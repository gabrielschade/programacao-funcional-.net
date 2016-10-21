using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Funcoes
{
    class Program
    {
        static void Main(string[] args)
        {
            ObterNumerosParesDeUmaLista();
        }

        private static void ObterNumerosParesDeUmaLista()
        {
            IEnumerable<int> numerosPares;
            IEnumerable<int> numeros = Enumerable.Range(0, 10);
            numerosPares = numeros.Where(VerificadorNumeroPar.NumeroEPar);
        }
    }
}
