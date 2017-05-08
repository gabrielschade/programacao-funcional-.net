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

let criarTabelaParaAplicacao<'e> 
        diretorioBase arquivo dadosIniciais =
    
    let arquivoCompleto = diretorioBase ^ arquivo
    let arquivoExiste = Arquivo.existe arquivoCompleto
    match arquivoExiste with
    | true -> carregarTabela<'e> arquivoCompleto
    | false -> inicializarTabela arquivoCompleto dadosIniciais

let clientesIniciais=
    [
        {
            Id = 1
            Idade = 23
            Nome = "Joãozinho"
            Sobrenome = "Silva"
            CPF = "021.231.231-21"
            Email = "joaozinho@teste.com"
            Telefone = "99887766"
            Endereco = "Rua do joãozinho"
        };
        {
            Id = 2
            Idade = 21
            Nome = "Mariazinha"
            Sobrenome = "Souza"
            CPF = "123.321.123-21"
            Email = "mariazinha@teste.com"
            Telefone = "99881122"
            Endereco = "Rua da mariazinha"
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

        