module PeriodoDeTempo
open System

type Periodo = {DataInicial:DateTime; DataFinal:DateTime}

let adicionaDias periodo dias =
    { 
      DataInicial = periodo.DataInicial.AddDays(dias) 
      ; DataFinal=periodo.DataFinal.AddDays(dias)
    }




let verificarSeDataEstaEntreOPeriodo periodo (dataParaTestar:DateTime) = 
    dataParaTestar.CompareTo(periodo.DataInicial) >= 0 && 
    dataParaTestar.CompareTo(periodo.DataFinal) <= 0    
