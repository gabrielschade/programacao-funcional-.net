module OO

type Pessoa (nome:string, sobrenome:string) =
    member this.Nome = nome
    member this.Sobrenome = sobrenome 
    
let gabriel = Pessoa("Gabriel", "Schade")

gabriel.Nome <- "Teste"

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