using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConceitosFundamentais
{
    public class PeriodoDeTempoImutavel
    {
        public DateTime DataInicial { get; private set; }
        public DateTime DataFinal { get; private set; }

        public PeriodoDeTempoImutavel(DateTime dataInicial, DateTime dataFinal)
        {
            DataInicial = dataInicial;
            DataFinal = dataFinal;
        }
        
        public bool VerificarSeDataEstaEntreOPeriodo(DateTime dataParaTestar)
        {
            return dataParaTestar.CompareTo(DataInicial) >= 0
                    && dataParaTestar.CompareTo(DataFinal) <= 0;
        }
    }
}
