module CompraServico

open Operadores
open Dominio
open Persistencia
open Transporte.Filtros
open Transporte.Respostas

let obterCompras() = 
    obterContexto().Compras

let atualizarTabelaCompras funcaoParaObterNovosDados = 
    obterCompras()
    |> EntidadeServico.atualizarTabela funcaoParaObterNovosDados

let obterProdutoDeUmItem 
    (produtos:ProdutoResposta list) 
    (itemCompra: ItemCompra) =
    produtos
    |> List.find (fun produto -> produto.Id = itemCompra.ProdutoId)

let obterProdutosIdDeUmaCompra (itens:ItemCompra list) =
    itens
    |> List.map (fun item -> item.ProdutoId)

let obterProdutosPorCompra =
    obterProdutosIdDeUmaCompra 
    >> ProdutoServico.obterPorListaId

let transformarItensDeUmaCompraEmResposta (compra: Compra) =
    let obterProdutoPorItem = 
        obterProdutosPorCompra compra.Itens
        |> obterProdutoDeUmItem

    compra.Itens
    |> List.map (fun item -> ItemCompraResposta.transformar obterProdutoPorItem item)


let obterClienteDeUmaCompra compra =
    ClienteServico.obterPorId compra.ClienteId
    |> Option.get  

let transformarCompraEmResposta =
    CompraResposta.transformar 
        obterClienteDeUmaCompra 
        transformarItensDeUmaCompraEmResposta

let transformarListaEmResposta =
    List.map (transformarCompraEmResposta)

let obterSemCompraComId id (lista : Compra list) =
    lista 
    |> List.filter (fun compra -> compra.Id <> id)

let obterIdsClientesDoFiltro (filtro:CompraFiltro) =
    {
        Nome = filtro.ClienteNome
        CPF = filtro.ClienteCPF
        Idade = 0
    }
    |> ClienteServico.obterPor
    |> List.map (fun cliente -> cliente.Id)

let obterIdsProdutosDoFiltro (filtro:CompraFiltro) =
    {
        Descricao = filtro.ProdutoDescricao
        PrecoMaximo = 0.0
    }
    |> ProdutoServico.obterPor
    |> List.map (fun produto -> produto.Id)

let obterDoBancoPorFiltro (filtro: CompraFiltro) =
    let filtrarPorCliente id =
        obterIdsClientesDoFiltro filtro
        |> List.exists (fun idLista -> idLista = id)

    let filtrarPorProduto (itens:ItemCompra list) =
        itens
        |> List.map(fun item -> item.ProdutoId)
        |> (><) (obterIdsProdutosDoFiltro filtro)
        |> List.length > 0

    obterCompras().Dados
    |> List.filter(fun compra -> 
        filtrarPorCliente compra.ClienteId
        && filtrarPorProduto compra.Itens
        && (filtro.ValorMinimo = 0.0 || compra.ValorTotal >= filtro.ValorMinimo ))
    

let obterDoBancoPorId id =
    obterCompras().Dados 
    |> List.tryFind (fun compra -> compra.Id = id)

let excluirCompraNoBanco id = 
    atualizarTabelaCompras (fun tabela -> obterSemCompraComId id tabela.Dados)

let incluirCompraNoBanco compra = 
    atualizarTabelaCompras (fun tabela -> compra :: tabela.Dados)

let atualizarCompraNoBanco compra = 
    let removeEAdiciona tabela = 
        compra :: (obterSemCompraComId compra.Id tabela.Dados)

    atualizarTabelaCompras (removeEAdiciona)

let obterTodosDoBanco() = 
    obterCompras().Dados

let incluirCompra =
    incluirCompraNoBanco
    >> transformarListaEmResposta

let atualizarCompra =
    atualizarCompraNoBanco
    >> transformarListaEmResposta

let excluirCompra =
    excluirCompraNoBanco
    >> transformarListaEmResposta 
 
let obterTodos =
    obterTodosDoBanco
    >> transformarListaEmResposta
  
let obterPor =
    obterDoBancoPorFiltro
    >> transformarListaEmResposta
   
let obterPorId = 
    obterDoBancoPorId
    >> Option.map (transformarCompraEmResposta)
    