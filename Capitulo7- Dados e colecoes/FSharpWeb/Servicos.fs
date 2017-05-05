namespace Servicos

open Dominio
open Persistencia


module ClienteServico =
    let obterClientes() =
        obterContexto().Clientes
    
    let incluirCliente cliente =
        let tabela = obterClientes()
        let dados = cliente :: tabela.Dados
        atualizarDados dados tabela

    let excluirCliente id =
        let tabela = obterClientes()
        atualizarDados [
            for clienteDoBanco in tabela.Dados do
                if clienteDoBanco.Id <> id then
                    yield clienteDoBanco
                ] 
            tabela
    
    let excluirCliente2 id =
        let tabela = obterClientes()
        let rec loop jaPassados (restantes: Cliente list)=
            match restantes with
            | head::tail when head.Id = id -> jaPassados @ tail
            | head::tail -> loop (head::jaPassados) tail
            | [] -> jaPassados

        let lista = loop [] tabela.Dados
        atualizarDados lista tabela

module ProdutoServico =

    let obterProdutos() =
        obterContexto().Produtos

    let incluirProduto produto = 
        obterProdutos()
        |> atualizarDados produto