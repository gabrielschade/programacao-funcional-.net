using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrimeiraAplicacao
{
    public class Calculadora
    {
        public int ElevaNumeroAoQuadrado(int numero)
        {
            return numero * numero;
        }

        public int SomaQuadradoDosNumerosAteDez()
        {
            return Enumerable.Range(1, 10)
                             .Select(ElevaNumeroAoQuadrado)
                             .Sum();
        }
    }
}
