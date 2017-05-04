module Persistencia

open Operadores
open Wrappers
open Dominio

type Tabela<'e> = {
    Arquivo: string
    Dados: 'e list
}

type Contexto = {
    Clientes: Tabela<Cliente>
    Produtos: Tabela<Produto>
    Compras: Tabela<Compra>
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

let clientesIniciais=
    [
        {
            Id = 1
            Idade = 23
            Nome = "Joãozinho"
            Sobrenome = "Silva"
            CPF = "021231231"
            Email = "teste"
            Telefone = "2131"
            Endereco = "Rua de testes"
        }
    ]

let obterContexto() =
    let diretorioBase = Configuracoes.diretorioTabelas
    {
        Clientes = criarTabelaParaAplicacao 
                        diretorioBase 
                        "/Clientes.json" 
                        clientesIniciais

        Produtos = criarTabelaParaAplicacao 
                        diretorioBase 
                        "/Produtos.json" 
                        []
                                    
        Compras = criarTabelaParaAplicacao 
                        diretorioBase 
                        "/Compras.json" 
                        []
    }


