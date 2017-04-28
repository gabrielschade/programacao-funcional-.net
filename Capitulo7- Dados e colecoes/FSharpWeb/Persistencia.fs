module Persistencia

open Operadores

type Tabela<'e> = {
    Arquivo: string
    Dados: 'e list
}

type Contexto = {
    Inteiros: Tabela<int>
    Textos: Tabela<string>
}

let inicializarTabela diretorioBase arquivo dadosIniciais =
    {
        Arquivo = diretorioBase ^ arquivo
        Dados = dadosIniciais
    }

//let x = inicializarTabela<int> "a" "b" List.empty
//    let y = "a"  "b"
    
//let salvar<'e> (entidade: 'e) =
//    FSharpWeb.Util.Wrappers.Json.serializar entidade
//    |> Arquivo.salvar "C:"