module VerificadorNumeroPar

let numeroEPar numero = numero % 2 = 0

let obterNumerosParesDeUmaLista =
    [0..10]
    |> List.filter numeroEPar

