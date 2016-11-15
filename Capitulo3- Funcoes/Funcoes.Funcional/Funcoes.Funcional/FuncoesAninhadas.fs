

module FuncoesAninhadas

let escreveSeNumeroEParOuImpar numero =
    let verificaSeONumeroEPar() = numero % 2 = 0
    let escreveNumeroPar() = printfn "O número %i é par" numero
    let escreveNumeroImpar() = printfn "O número %i é impar" numero

    if verificaSeONumeroEPar() then
        escreveNumeroPar()
    else
        escreveNumeroImpar()

