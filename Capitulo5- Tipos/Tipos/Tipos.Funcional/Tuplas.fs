module Tuplas

let inteiroEBool = 2, true

let tupla1 = 1, 2, 3
let item1, item2, item3 = tupla1

let tupla2 = 1, true, "Gabriel"
let item4, _, item5 = tupla2

let tupla3 = 3, false
let item6 = fst tupla3
let item7 = snd tupla3

let somarNumeroEInverterBool (numero, bool) =
    numero + 5, not bool

let tupla3Modificada = somarNumeroEInverterBool tupla3

let tupla4 = 1, 2, 3, false, "Teste"
let tupla5 = (+), false


let tupla6 = false, 2

let inverterTupla (x,y) = y,x
let tupla7 = inverterTupla tupla6

let soma numero1 numero2 = 
    numero1 + numero2

let somaTupla (numero1, numero2) =
    numero1 + numero2