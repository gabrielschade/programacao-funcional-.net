module Trilhos

type Resultado<'a> =
    | Sucesso of 'a
    | Falha of string

let map funcao valor =
    match valor with
    | Sucesso n -> Sucesso (funcao n) 
    | Falha erro -> Falha erro

let (<!>) = map 

let apply fOpt xOpt = 
    match fOpt,xOpt with
    | Some f, Some x -> Some (f x)
    | _ -> None

let resultOption =  
    let (<*>) = apply
    (Some (+)) <*> (Some 2) <*> (Some 3)

let teste =
    let x = apply (Some (+))
    let y = x (Some 5)
    let z = apply (y)
    let v = z (Some 3)
    v

    
