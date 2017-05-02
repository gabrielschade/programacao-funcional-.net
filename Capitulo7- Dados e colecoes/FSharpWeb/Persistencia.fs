module Persistencia

open Operadores
open Wrappers

type Tabela<'e> = {
    Arquivo: string
    Dados: 'e list
}

type Contexto = {
    Inteiros: Tabela<int>
    Textos: Tabela<string>
}

let salvarTabela tabela =
    Json.serializar tabela.Dados
    |> Arquivo.salvar tabela.Arquivo
    tabela

let carregarTabela<'e> arquivo =
    let dados = Arquivo.abrir arquivo
                |> Json.desserializar<'e list>
    {
        Arquivo = arquivo
        Dados = dados
    }
 
let inicializarTabela arquivo dadosIniciais =
    let tabela = {
        Arquivo = arquivo
        Dados = dadosIniciais
    }
    salvarTabela tabela

let criarTabelaParaAplicacao<'e> diretorioBase arquivo dadosIniciais =
    let arquivoCompleto = diretorioBase ^ arquivo
    match (Arquivo.existe arquivoCompleto) with
    | true -> carregarTabela<'e> arquivoCompleto
    | false -> inicializarTabela arquivoCompleto dadosIniciais

let inteirosIniciais =
    [
    for valor in 1..100 
        do 
        if valor % 2 = 0 then 
            yield valor
            yield valor * valor * valor
    ]

let inicializarContexto diretorioBase =
    {
        Inteiros = criarTabelaParaAplicacao diretorioBase "/Inteiros.json" 
                    inteirosIniciais
        Textos = criarTabelaParaAplicacao diretorioBase "/Textos.json" 
                    [ "teste" ; "texto"]
    }