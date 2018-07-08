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

let converteBooleanoParaTexto valor =
    if valor 
        then "Sim" 
        else "Não"

let verificaSeONumeroEImpar valor =
    let resultado = numeroImpar valor
    converteBooleanoParaTexto resultado

let verificaSeONumeroEImparUsandoOperador =
    numeroImpar >> converteBooleanoParaTexto

let somaComTresEVerificaSeONumeroEImparUsandoOperador =
    somaCom3 >> numeroImpar >> converteBooleanoParaTexto

let compor funcao1 funcao2 parametro =
    funcao2 (funcao1 (parametro) )

let verificaSeONumeroEImparUsandoCompor =
    numeroImpar >> converteBooleanoParaTexto

let somaComTresEVerificaSeONumeroEImparUsandoCompor =
    somaCom3 >> numeroImpar >> converteBooleanoParaTexto

let somaDepoisMultiplica =
    compor ((+)1) ((*)2)

let somaDepoisMultiplicaUsandoOOperador valorParaSomar =
    (+)valorParaSomar >> (*)

let resultado = somaDepoisMultiplicaUsandoOOperador 1 1 2

let dobraDepoisSoma =
    (+) << (*)2