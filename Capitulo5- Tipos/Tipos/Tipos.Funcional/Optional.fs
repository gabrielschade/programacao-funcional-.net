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