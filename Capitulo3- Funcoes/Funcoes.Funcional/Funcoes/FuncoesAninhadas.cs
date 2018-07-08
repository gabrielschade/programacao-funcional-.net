using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Funcoes
{
    class FuncoesAninhadas
    {
        public void EscreveSeNumeroEParOuImpar(int numero)
        {
            bool verificaSeONumeroEPar() => numero % 2 == 0;
            void escreveNumeroPar() => Console.WriteLine(string.Format("O número {0} é par", numero));
            void escreveNumeroImpar() => Console.WriteLine(string.Format("O número {0} é impar", numero));

            if (verificaSeONumeroEPar())
                escreveNumeroPar();
            else
                escreveNumeroImpar();
        }
    }
}