module OO

type IPessoa =
    abstract member Nome:string
    abstract member Sobrenome:string
    abstract member NomeCompleto:string

type Pessoa (nome:string, sobrenome:string) =
    member this.Nome = nome
    member this.Sobrenome = sobrenome 
    
let gabriel = Pessoa("Gabriel", "Schade")

//gabriel.Nome <- "Teste"

type PessoaComGetESet (nome:string, sobrenome:string) =
    let mutable _nome = nome
    let mutable _sobrenome = sobrenome;

    member this.Nome
        with get() = _nome
        and set value = _nome <- value

    member this.Sobrenome
        with get() = _sobrenome
        and set value = _sobrenome <- value

let gabriel2 = PessoaComGetESet("Gabriel", "Schade")
gabriel2.Sobrenome <- "Schade2"

type PessoaComAutoproperty (nome:string, sobrenome:string) =
    member val Nome = nome with get, set
    member val Sobrenome = sobrenome with get, set


type PessoaComIdade (idade:int) =
    let mutable _maioridade = false
    do
        _maioridade <- idade >= 18

    member val Idade = idade with get, set
    member val Maioridade = _maioridade with get

type PessoaComHeranca(nome:string, sobrenome:string, idade:int) =
    inherit PessoaComAutoproperty(nome, sobrenome)
    
    let mutable _maioridade = false

    do
        _maioridade <- idade >= 18

    member val Idade = idade with get, set
    member val Maioridade = _maioridade with get

let gabriel3 = PessoaComHeranca("Gabriel", "Schade", 26)

type PessoaComInterface (nome:string, sobrenome:string) =
    member val Nome = nome with get, set
    member val Sobrenome = sobrenome with get, set

    interface IPessoa with
        member this.Nome = nome
        member this.Sobrenome = sobrenome
        member this.NomeCompleto = sprintf "%s %s" nome sobrenome

let gabriel4 = PessoaComInterface("Gabriel", "Schade")
let nomeCompleto = (gabriel4 :> IPessoa).NomeCompleto