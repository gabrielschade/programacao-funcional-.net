module FuncaoAltaOrdem

// Versão 1 do Código
//let imprimirNomes() =
//    let nomes = ["Gabriel"; "Rodrigo"; "Jhony"; "Luan"]
//    for nome in nomes do
//        printfn "Olá %s." nome

//let imprimirDobroDosNumeros numeros =
//    let numeros = [1..10]
//    for numero in numeros do
//        printfn "%i." ( numero * 2)


//Versão 2 do código
//let imprimirNomes nomes =
//    for nome in nomes do
//        printfn "Olá %s." nome
//
//let imprimirDobroDosNumeros numeros =
//    for numero in numeros do
//        printfn "%i." ( numero * 2)


let executarAcaoSobreElementos lista acao = lista |> List.iter acao
    
let imprimirNomes nomes = 
    executarAcaoSobreElementos nomes (printfn "Olá %s")    
    
let imprimirDobroDeUmNumero numero = 
    printfn "%i." ( numero * 2)

let multiplicarEimprimirNumero multiplicador numero = 
    printfn "%i." ( numero * multiplicador)

let imprimirDobroDosNumeros numeros = 
    executarAcaoSobreElementos numeros (imprimirDobroDeUmNumero)    

let imprimirDobroDosNumeros numeros = 
    executarAcaoSobreElementos numeros 
        (fun numero -> printfn "%i" (numero * 2) )    

let imprimirListaDeNumeros multiplicador numeros = 
    executarAcaoSobreElementos numeros 
        (fun numero -> 
             multiplicarEimprimirNumero multiplicador numero )    