module Composicao

open Operadores


let dobrarValoresDeUmaLista() =
    let lista = [0..10]
    let listaComValoresMenoresQue5 = 
        List.filter (fun numero -> numero < 5) lista
    List.map multiplicaPor2 listaComValoresMenoresQue5

let dobrarValoresDeUmaListaComOperador() =
    [0..10]
    |> List.filter (fun numero -> numero < 5)
    |> List.map multiplicaPor2

let variasOperacoes valor1 valor2=
    valor1 + valor2 
    |> somaCom10 
    |> somaCom2 
    |> multiplicaPor2

let exemploInverso valor1 valor2 =
    somaCom10 <| valor1 + valor2

let numeroImparOperadorInverso valor =
    let numeroPar numero = numero % 2 = 0
    not <| numeroPar valor
 
let numeroImparParenteses valor =
    let numeroPar numero = numero % 2 = 0
    not (numeroPar valor)
        
let numeroImpar valor =
    let numeroPar numero = numero % 2 = 0
    numeroPar valor |> not