module ProdutoServico

open Operadores
open Dominio
open Persistencia
open Transporte.Filtros
open Transporte.Respostas

let obterProdutos() = 
    obterContexto().Produtos

let transformarListaEmResposta =
    List.map (ProdutoResposta.transformar)

let atualizarTabelaProdutos funcaoParaObterNovosDados = 
    obterProdutos()
    |> EntidadeServico.atualizarTabela funcaoParaObterNovosDados
    

let filtrarTabelaProdutosPor filtro = 
    obterProdutos().Dados 
    |> List.filter filtro

let obterSemProdutoComId id (lista : Produto list) =
    lista 
    |> List.filter (fun produto -> produto.Id <> id)


let excluirProdutoDoBanco id = 
    atualizarTabelaProdutos (fun tabela -> obterSemProdutoComId id tabela.Dados)

let incluirProdutoNoBanco produto = 
    atualizarTabelaProdutos (fun tabela -> produto :: tabela.Dados)

let atualizarProdutoNoBanco produto = 
    let removeEAdiciona tabela = 
        produto :: (obterSemProdutoComId produto.Id tabela.Dados)

    atualizarTabelaProdutos (removeEAdiciona)

let obterTodosDoBanco() = 
    obterProdutos().Dados

let obterDoBancoPorId id = 
    obterProdutos().Dados 
    |> List.tryFind (fun produto -> produto.Id = id)

let obterDoBancoPorListaId ids =
    let buscarIdNaLista produtoId = 
        ids 
        |> List.exists (fun id -> id = produtoId )

    obterProdutos().Dados
    |> List.filter (fun produto -> buscarIdNaLista produto.Id )

let obterDoBancoPorFiltro (filtro : ProdutoFiltro) = 
    filtrarTabelaProdutosPor 
        (fun produto -> 
            produto.Descricao <~ filtro.Descricao
            && (filtro.PrecoMaximo = 0.0 || produto.Preco <= filtro.PrecoMaximo))

let incluirProduto =
    incluirProdutoNoBanco
    >> transformarListaEmResposta

let atualizarProduto =
    atualizarProdutoNoBanco
    >> transformarListaEmResposta

let excluirProduto =
    excluirProdutoDoBanco
    >> transformarListaEmResposta

let obterTodos =
    obterTodosDoBanco
    >> transformarListaEmResposta

let obterPorId =
    obterDoBancoPorId
    >> Option.map (ProdutoResposta.transformar)

let obterPorListaId =
    obterDoBancoPorListaId
    >> transformarListaEmResposta

let obterPor =
    obterDoBancoPorFiltro
    >> transformarListaEmResposta
        
