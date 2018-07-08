using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tipos
{
    public class Nulos
    {
        public int TesteComValor()
        {
            string texto = "Testando valor nulo";
            return texto.Length;
        }

        public int TesteComNulo()
        {
            string texto = null;
            return texto.Length;
        }
    }
}
