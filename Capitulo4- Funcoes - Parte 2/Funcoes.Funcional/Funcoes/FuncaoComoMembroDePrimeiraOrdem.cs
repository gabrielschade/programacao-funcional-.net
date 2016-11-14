using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Funcoes
{
    class FuncaoComoMembroDePrimeiraOrdem
    {
        void AtribuindoFuncoes()
        {
            Func<int, int> referenciaParaSomaCom5 = SomaCom5;
        }

        int SomaCom5 (int numero)
        {
            return numero + 5;
        }


    }
}
