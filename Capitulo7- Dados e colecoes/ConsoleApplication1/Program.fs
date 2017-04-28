// Learn more about F# at http://fsharp.org
// See the 'F# Tutorial' project for more help.

open FSharpWeb.Persistencia
open FSharpWeb.Persistencia.BancoDados

[<EntryPoint>]
let main argv = 
    let teste = {
        LocalArquivo = @"D:\Documentos\F#\oi.json"; 
        Entidade = 1}

    Wrappers.Json.serializar teste.Entidade
    |> Wrappers.Arquivo.salvar teste.LocalArquivo
    
    let entidade=
        Wrappers.Arquivo.abrir teste.LocalArquivo
        |> Wrappers.Json.desserializar

    printfn "%A" argv
    0 // return an integer exit code
