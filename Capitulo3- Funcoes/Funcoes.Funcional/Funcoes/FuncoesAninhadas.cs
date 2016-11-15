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
            Func<bool> verificaSeONumeroEPar = () => numero % 2 == 0;
            Action escreveNumeroPar = 
                () => Console.WriteLine(string.Format("O número {0} é par", numero));

            Action escreveNumeroImpar =
                () => Console.WriteLine(string.Format("O número {0} é impar", numero));

            if (verificaSeONumeroEPar())
                escreveNumeroPar();
            else
                escreveNumeroImpar();
        }
    }
}