namespace FSharpWeb.Controllers

open System
open System.Net.Http
open System.Web.Http
open Transporte.Filtros


type CompraController() =
    inherit ApiController()

    [<HttpGet>]
    member this.ObterTodos() = 
       CompraServico.obterTodos()

    [<HttpGet>]
    member this.ObterPorId(id) = 
       CompraServico.obterPorId id

    [<HttpGet>]
    member this.ObterPor(  [<FromUri>]  filtro) =
        CompraServico.obterPor filtro

    [<HttpPost>]
    member this.Salvar(compra) =
        CompraServico.incluirCompra compra

    [<HttpPut>]
    member this.Atualizar(compra) =
        CompraServico.atualizarCompra compra

    [<HttpDelete>]
    member this.Excluir(id) =
        CompraServico.excluirCompra id