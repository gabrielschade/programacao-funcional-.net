module Optional

//type Option<'a> =
//    | Some of 'a
//    | None

let talvezUmaString = Some "Aprendendo tipos opcionais"
let talvezOutraString = None

match talvezUmaString with
    | Some texto -> printfn "%s" texto
    | None -> printfn "Valor inválido"

if talvezUmaString.IsSome
    then printfn "%s" talvezUmaString.Value
    else printfn "Valor inválido"

printfn "%s" talvezUmaString.Value

let testeComValor = Some "Testando valor nulo"
let testeSemValor = None

let lenght =
    match testeComValor with
    | Some texto -> texto.Length
    | None -> 0

let stringQueVeioDoCSharp = "Teste com string do C#"
let stringParaUsarNaAplicacao =
    match stringQueVeioDoCSharp with
    | null -> None
    | valor -> Some valor

let tres = 3
let talvezTres = Option.map (fun x -> x) (Some tres)