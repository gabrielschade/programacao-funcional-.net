// Learn more about F# at http://fsharp.org
// See the 'F# Tutorial' project for more help.
open FSharp.Data
open System.IO
open Json 

type X = { Id : int ; AxisNumber:int}
[<EntryPoint>]
let main argv = 
    let json = File.ReadAllText(@"D:\Documentos\GitHub\programacao-funcional-.net\Capitulo6- Web\FSharpWeb\ConsoleApplication1\data.json")
    let valor = Json.unjson json
    printf "%i %i" valor.AxisNumber valor.Id
    let valor2 = { valor with Id = 10}
    let texto = Json.json valor2
    File.WriteAllText(@"D:\Documentos\GitHub\programacao-funcional-.net\Capitulo6- Web\FSharpWeb\ConsoleApplication1\data2.json",texto)
    printfn "%A" argv
    0 // return an integer exit code
