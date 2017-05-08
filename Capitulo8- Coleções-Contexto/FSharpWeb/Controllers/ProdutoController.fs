namespace FSharpWeb.Controllers

open System
open System.Net.Http
open System.Web.Http
open Transporte.Filtros


type ProdutoController() =
    inherit ApiController()

    [<HttpGet>]
    member this.ObterTodos() = 
       ProdutoServico.obterTodos()

    [<HttpGet>]
    member this.ObterPorId(id) = 
       ProdutoServico.obterPorId id

    [<HttpGet>]
    member this.ObterPor( [<FromUri>] filtro) = 
       ProdutoServico.obterPor filtro
   

    [<HttpPost>]
    member this.Salvar(produto) =
        ProdutoServico.incluirProduto produto

    [<HttpPut>]
    member this.Atualizar(produto) =
        ProdutoServico.atualizarProduto produto

    [<HttpDelete>]
    member this.Excluir(id) =
        ProdutoServico.excluirProduto id