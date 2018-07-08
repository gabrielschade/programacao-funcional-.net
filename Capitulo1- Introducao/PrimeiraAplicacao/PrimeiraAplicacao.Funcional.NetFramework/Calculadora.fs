module Calculadora

let elevaNumeroAoQuadrado numero = numero * numero

let SomaQuadradoDosNumerosAteDez =  
    [1..10] 
    |> List.map elevaNumeroAoQuadrado 
    |> List.sum