using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConceitosFundamentais
{
    class Program
    {
        static void Main(string[] args)
        {
            PeriodoDeTempo periodo = new PeriodoDeTempo();

            periodo.DataInicial = DateTime.Parse("20/08/2016");
            periodo.DataFinal = DateTime.Parse("31/08/2016");

            DateTime[] datasParaTeste = new DateTime[]
            {
                DateTime.Parse("18/08/2016"),
                DateTime.Parse("22/08/2016"),
                DateTime.Parse("01/09/2016")
            };

            foreach (DateTime dataParaTestar in datasParaTeste)
            {
                bool resultadoDaVerificacao =
                periodo.VerificarSeDataEstaEntreOPeriodo(dataParaTestar);
                Console.WriteLine(resultadoDaVerificacao);
            }

            Console.ReadKey();
        }





    }
}
