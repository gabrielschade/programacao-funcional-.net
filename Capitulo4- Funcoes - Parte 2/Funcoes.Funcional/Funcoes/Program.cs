using System;
using System.Collections.Generic;
using System.Linq;

namespace Funcoes
{
    class Program
    {
        static void Main(string[] args)
        {
            for (int i = 0; i < 11; i++)
                Console.WriteLine(Recursao.Fatorial(i));
            Console.ReadKey();
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
