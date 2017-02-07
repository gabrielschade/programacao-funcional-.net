module DiscriminatedUnions

type InteiroOuBool =
    | Inteiro of int
    | Bool of bool

type Pessoa = { Nome:string ; Idade:int }

type DiscriminatedComplexo =
    | IntOuBool of InteiroOuBool
    | PessoaDoDiscriminated of Pessoa
    | Tupla of int * string

//type DiscriminatedAninhadoComProblema =
//    | OutroDiscriminatedAninhado of | Inteiro of int | Bool of bool
//
//type DiscriminatedComRecordComProblema =
//    | Pessoa of { Nome:string ; Idade:int }

type Resultado = 
    | Sucesso
    | Erros of string list

type RespostaDoUsuario =
    | Sim
    | Nao

type Cor =
    | Vermelho
    | Verde
    | Azul

let inteiroDoDiscriminated = Inteiro 1
let boolDoDiscriminated = Bool false
let intOuBool = IntOuBool inteiroDoDiscriminated
let pessoa = PessoaDoDiscriminated { Nome="Gabriel" ; Idade = 26 }
let tupla = Tupla (3, "Gabriel")
let resultadoDeSucesso = Sucesso
let resultadoComErros = Erros ["Inválido"]

let escreveInteiroOuBool inteiroOuBooleano =
    match inteiroOuBooleano with
    | Inteiro valorInteiro -> printfn "%i" valorInteiro
    | Bool valorBooleano -> printfn "%b" valorBooleano

escreveInteiroOuBool boolDoDiscriminated
escreveInteiroOuBool inteiroDoDiscriminated

//Abordagem 1
//type Cliente = { Id:int ; Nome:string ; Sobrenome: string }
//
//let criarCliente id nome sobrenome =
//    { Id = id ; Nome = nome; Sobrenome = sobrenome }
//    
//let id = 1
//let nome = "Gabriel"
//let sobrenome = "Schade"
//
//let cliente1 = criarCliente id nome sobrenome
//let cliente2 = criarCliente id sobrenome nome

//Abordagem 2
//type IdentificadorCliente = int
//type Nome = string
//type Sobrenome = string
//
//type Cliente = { Id:IdentificadorCliente ; Nome:Nome ; Sobrenome: Sobrenome }
//
//let criarCliente id (nome:Nome) (sobrenome:Sobrenome) =
//    { Id = id ; Nome = nome; Sobrenome = sobrenome }
//    
//let id = 1
//let nome = "Gabriel"
//let sobrenome = "Schade"
//
//let cliente1 = criarCliente id nome sobrenome
//let cliente2 = criarCliente id sobrenome nome

//Abordagem 3
type Nome = | Nome of string
type Sobrenome = | Sobrenome of string

type Cliente = { Id:int ; Nome:Nome ; Sobrenome: Sobrenome }

let criarCliente id nome sobrenome =
    { Id = id ; Nome = nome; Sobrenome = sobrenome }
    
let id = 1
let nome = Nome "Gabriel"
let sobrenome = Sobrenome "Schade"

let cliente1 = criarCliente id nome sobrenome
let clienteQueNaoCompila = criarCliente id sobrenome nome