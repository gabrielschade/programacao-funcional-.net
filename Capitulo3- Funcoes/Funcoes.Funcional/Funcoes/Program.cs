using System;
using System.Collections.Generic;
using System.Linq;

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

            Func<int, bool> metodoParaFiltrar = VerificadorNumeroPar.NumeroEPar;
            Func<int, bool> metodoParaFiltrarViaLambda = numero => numero % 2 == 0;

            numerosPares = numeros.Where(metodoParaFiltrar);
            numerosPares = numeros.Where(metodoParaFiltrarViaLambda);
            numerosPares = numeros.Where(numero => numero % 2 == 0);
        }
    }
}
