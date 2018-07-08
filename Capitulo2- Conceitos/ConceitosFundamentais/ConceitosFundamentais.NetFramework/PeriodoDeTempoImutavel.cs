using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConceitosFundamentais
{
    public class PeriodoDeTempoImutavel
    {
        public DateTime DataInicial { get; }    
        public DateTime DataFinal { get; }

        public PeriodoDeTempoImutavel
            (DateTime dataInicial, DateTime dataFinal)
        {
            DataInicial = dataInicial;
            DataFinal = dataFinal;
        }

        public static bool VerificarSeDataEstaEntreOPeriodo
                (PeriodoDeTempoImutavel periodo
               , DateTime dataParaTestar)
        {
            return 
                dataParaTestar.CompareTo(periodo.DataInicial) >= 0
             && dataParaTestar.CompareTo(periodo.DataFinal) <= 0;
        }

        public static PeriodoDeTempoImutavel AdicionarDias
            (PeriodoDeTempoImutavel periodo
            , int dias)
        {
            return new PeriodoDeTempoImutavel
                    (periodo.DataInicial.AddDays(dias)
                   , periodo.DataFinal.AddDays(dias));
        }
    }
}
