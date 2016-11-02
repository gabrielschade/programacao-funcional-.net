using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Funcoes
{
    public static class FuncaoAltaOrdem
    {
        public static void ExecutarAcaoSobreElementos<TipoElemento>(List<TipoElemento> lista, Action<TipoElemento> acao)
        {
            lista.ForEach(acao);
        }

        public static void ImprimirNomes(List<string> nomes)
        {
            ExecutarAcaoSobreElementos(nomes, Console.WriteLine);
        }

        public static Action<int> MultiplicarEimprimirNumero(int multiplicador)
        {
            Action<int> imprimirNumero = 
                (numero) => Console.WriteLine(numero * multiplicador);
            return imprimirNumero;
        }

        public static void ImprimirNumeros(List<int> numeros, int multiplicador)
        {
            Action<int> multiplicaEDepoisEImprimi = 
                MultiplicarEimprimirNumero(multiplicador);

            ExecutarAcaoSobreElementos(numeros, multiplicaEDepoisEImprimi);
        }

        public static void Program()
        {
            Action<int> multiplicaPor5EDepoisImprimi = MultiplicarEimprimirNumero(5);
            Action<int> multiplicaPor3EDepoisImprimi = MultiplicarEimprimirNumero(3);
            int numeroQueSeraMultiplicado = 10;

            multiplicaPor5EDepoisImprimi(numeroQueSeraMultiplicado);
            multiplicaPor3EDepoisImprimi(numeroQueSeraMultiplicado);
        }
    }
}
