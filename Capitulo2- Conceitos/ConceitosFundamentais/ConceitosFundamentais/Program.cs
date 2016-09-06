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
            ExemploDeProblemaPorAlteracaoDeEstado();
        }

        static void ExemploComPeriodoImutavel()
        {
            PeriodoDeTempoImutavel periodo = 
                new PeriodoDeTempoImutavel( DateTime.Parse("20/08/2016")
                                          , DateTime.Parse("31/08/2016") );

            DateTime[] datasParaTeste = new DateTime[]
            {
                DateTime.Parse("18/08/2016"),
                DateTime.Parse("22/08/2016"),
                DateTime.Parse("01/09/2016")
            };

            Console.WriteLine("Resultado antes da alteração:");
            foreach (DateTime dataParaTestar in datasParaTeste)
            {
                bool resultadoDaVerificacao =
                periodo.VerificarSeDataEstaEntreOPeriodo(dataParaTestar);
                Console.WriteLine(resultadoDaVerificacao);
            }

            Console.ReadKey();
        }

        static void ExemploDeAcoplamentoTemporalNaCriacaoDoObjeto()
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

        static void ExemploDeProblemaPorAlteracaoDeEstado()
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

            Console.WriteLine("Resultado antes da alteração:");
            foreach (DateTime dataParaTestar in datasParaTeste)
            {
                bool resultadoDaVerificacao =
                periodo.VerificarSeDataEstaEntreOPeriodo(dataParaTestar);
                Console.WriteLine(resultadoDaVerificacao);
            }

            periodo.DataFinal = DateTime.MaxValue;
            Console.WriteLine("Resultado após a alteração:");
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
