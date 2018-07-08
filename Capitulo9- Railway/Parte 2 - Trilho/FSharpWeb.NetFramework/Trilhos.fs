module Trilhos

type Resultado<'a> =
    | Sucesso of 'a
    | Falha of string

let map funcao valor =
    match valor with
    | Sucesso n -> Sucesso (funcao n) 
    | Falha erro -> Falha erro

let (<!>) = map 

let apply funcao valor =
    match funcao, valor with
    | Sucesso f, Sucesso n -> Sucesso (f n)
    | _ , Falha erro -> Falha erro
    | Falha erro, _ -> Falha erro

let (<*>) = apply

let bind funcao valor =
    match valor with
    | Sucesso n -> funcao n
    | Falha erro -> Falha erro

let (|>=) valor funcao = 
    valor |> bind funcao

let (>>=) funcao1 funcao2 =
    funcao1 
    >> bind funcao2

    
    

