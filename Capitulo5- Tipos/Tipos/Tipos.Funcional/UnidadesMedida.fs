module UnidadesMedida

[<Measure>] type grama
[<Measure>] type quilo
[<Measure>] type tonelada

let peso1 = 500<grama>
let peso2 = 10<quilo>
let peso3 = 1<tonelada>

[<Measure>] type km
[<Measure>] type m

[<Measure>] type h
[<Measure>] type s

let velocidadeDoCarro = 130<km/h>
let velocidadeDoSom = 340.29<m/s>

[<Measure>] type velocidade = km/h
[<Measure>] type velocidade2 = m/s