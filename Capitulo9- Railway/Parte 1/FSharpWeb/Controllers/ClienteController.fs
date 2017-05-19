namespace FSharpWeb.Controllers

open System
open System.Net.Http
open System.Web.Http
open Transporte.Filtros


type ClienteController() =
    inherit ApiController()

    [<HttpGet>]
    member this.ObterTodos() = 
       ClienteServico.obterTodos()

    [<HttpGet>]
    member this.ObterPorId(id) = 
       ClienteServico.obterPorId id

    [<HttpGet>]
    member this.ObterPor( [<FromUri>] filtro) = 
       ClienteServico.obterPor filtro

    [<HttpPost>]
    member this.Salvar(cliente) =
        ClienteServico.incluirCliente cliente

    [<HttpPut>]
    member this.Atualizar(cliente) =
        ClienteServico.atualizarCliente cliente

    [<HttpDelete>]
    member this.Excluir(id) =
        ClienteServico.excluirCliente id