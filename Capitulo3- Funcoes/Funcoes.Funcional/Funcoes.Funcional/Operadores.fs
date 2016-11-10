module Operadores

//Versão tradicional
//let somaCom3 numero = numero + 3

let somaCom3 = (+) 3

let somaCom = (+)

let somaCom10 = somaCom 10
let somaCom2 = somaCom 2

let multiplicaPor = (*)

let multiplicaPor2 = multiplicaPor 2
let multiplicaPor4 = multiplicaPor 4

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