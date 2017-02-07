module Records

type inteiroEBool = {valorInteiro:int ; valorBooleano:bool}

let inteiroEBool = { valorInteiro = 2 ; valorBooleano = true}

let {valorInteiro = inteiro ; valorBooleano = bool} = inteiroEBool

let recordTransformadoEmTupla = 
    inteiro,bool

let {valorBooleano = booleano} = inteiroEBool

let {valorInteiro = novoInteiro ; valorBooleano = novoBool} = inteiroEBool
let segundoInteiroEBool = {valorInteiro = novoInteiro + 10 ; valorBooleano = not novoBool}

let terceiroInteiroEBool = {inteiroEBool with valorBooleano = false}