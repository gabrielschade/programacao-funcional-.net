open PeriodoDeTempo
open System

[<EntryPoint>]
let main argv = 
    let periodo = 
        { DataInicial= DateTime.Parse("20/08/2016"); 
          DataFinal =DateTime.Parse("31/08/2016");}

    let datasParaTeste =
        [|
            DateTime.Parse("18/08/2016")
            DateTime.Parse("22/08/2016")
            DateTime.Parse("01/09/2016")
        |]

    datasParaTeste 
    |> Array.map (verificarSeDataEstaEntreOPeriodo periodo)
    |> Array.iter (printfn "%b")

//    periodo <- adicionaDias periodo 2.0

    datasParaTeste 
    |> Array.map (verificarSeDataEstaEntreOPeriodo periodo)
    |> Array.iter (printfn "%b")
    Console.ReadKey() |> ignore
    0


