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
            ExemploComPeriodoImutavel();
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
                    PeriodoDeTempoImutavel.VerificarSeDataEstaEntreOPeriodo(periodo,dataParaTestar);
                Console.WriteLine(resultadoDaVerificacao);
            }

            PeriodoDeTempoImutavel.AdicionarDias(periodo, 30);
            foreach (DateTime dataParaTestar in datasParaTeste)
            {
                bool resultadoDaVerificacao =
                    PeriodoDeTempoImutavel.VerificarSeDataEstaEntreOPeriodo(periodo, dataParaTestar);
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

        static void ExemploUsoDeDeclaracao(int numero)
        {
            int resultado = 0;
            bool numeroPar = numero % 2 == 0;

            if (numeroPar)
                resultado = 2;
            

            Console.WriteLine(resultado);
            Console.ReadKey();
        }

        static void ExemploUsoDeExpressao(int numero)
        {
            bool numeroPar = numero % 2 == 0;
            int resultado = numeroPar ? 2 : 0;
            Console.WriteLine(resultado);
            Console.ReadKey();
        }

    }
}
