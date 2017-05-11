namespace Transporte

module Filtros = 

    [<CLIMutable>]
    type ClienteFiltro = { 
        Nome : string
        CPF : string
        Idade : int 
    }

    [<CLIMutable>]
    type ProdutoFiltro = { 
        Descricao : string
        PrecoMaximo : double
    }

module Respostas =
    open Dominio
    open Operadores

    type ClienteResposta = {
        Id: int
        NomeCompleto: string
        CPF: string
        Idade: int
        Telefone: string
        Endereco: string
    } with 
      static member 
        transformar (cliente:Cliente) =
        {
            Id = cliente.Id
            NomeCompleto = cliente.Nome ^ " " ^ cliente.Sobrenome
            CPF = cliente.CPF
            Idade = cliente.Idade
            Telefone = cliente.Telefone
            Endereco = cliente.Endereco
        } 

    type ProdutoResposta = {
        Id: int
        Descricao: string
        Detalhes: string
        Preco: double
    } with
      static member 
        transformar (produto: Produto) =
        {
            Id = produto.Id
            Descricao = produto.Descricao
            Detalhes = produto.Detalhes
            Preco = produto.Preco
        }

    type ItemCompraResposta = {
        Produto: ProdutoResposta
        Quantidade: double
        ValorTotal: double
    }

    type CompraResposta = {
        Id: int
        Cliente: ClienteResposta       
        Itens: ItemCompra list
        ValorTotal: double
    }