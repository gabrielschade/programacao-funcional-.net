using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConceitosFundamentais
{
    public class PeriodoDeTempo
    {
        public DateTime DataInicial { get; set; }
        public DateTime DataFinal { get; set; }

        public bool VerificarSeDataEstaEntreOPeriodo
            (DateTime dataParaTestar)
        {
            return dataParaTestar.CompareTo(DataInicial) >= 0
                    && dataParaTestar.CompareTo(DataFinal) <= 0;
        }

        public void AdicionarDias(int dias)
        {
            DataInicial.AddDays(dias);
            DataFinal.AddDays(dias);
        }
    }
}
