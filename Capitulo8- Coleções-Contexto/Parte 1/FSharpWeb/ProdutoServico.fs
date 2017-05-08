module ProdutoServico

open Operadores
open Dominio
open Persistencia
open Transporte.Filtros

let obterProdutos() = 
    obterContexto().Produtos

let atualizarTabelaProdutos funcaoParaObterNovosDados = 
    obterProdutos()
    |> EntidadeServico.atualizarTabela funcaoParaObterNovosDados
    

let filtrarTabelaProdutosPor filtro = 
    obterProdutos().Dados 
    |> List.filter filtro

let obterSemProdutoComId id (lista : Produto list) =
    lista 
    |> List.filter (fun produto -> produto.Id <> id)

let excluirProduto id = 
    atualizarTabelaProdutos (fun tabela -> obterSemProdutoComId id tabela.Dados)

let incluirProduto produto = 
    atualizarTabelaProdutos (fun tabela -> produto :: tabela.Dados)

let atualizarProduto produto = 
    let removeEAdiciona tabela = 
        produto :: (obterSemProdutoComId produto.Id tabela.Dados)

    atualizarTabelaProdutos (removeEAdiciona)

let obterTodos() = 
    obterProdutos().Dados

let obterPorId id = 
    obterProdutos().Dados 
    |> List.tryFind (fun produto -> produto.Id = id)

let obterPor (filtro : ProdutoFiltro) = 
    filtrarTabelaProdutosPor 
        (fun produto -> 
            produto.Descricao <~ filtro.Descricao
            && (filtro.PrecoMaximo = 0.0 || produto.Preco <= filtro.PrecoMaximo))
        
