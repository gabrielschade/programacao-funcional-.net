namespace FSharpWeb.Controllers

open System
open System.Net.Http
open Transporte.Filtros
open Microsoft.AspNetCore.Mvc

[<Route("api/[controller]/[action]")>]
type ClienteController() =
    inherit Controller()

    [<HttpGet>]
    member this.ObterTodos() = 
       ClienteServico.obterTodos()

    [<HttpGet>]
    member this.ObterPorId(id) = 
       ClienteServico.obterPorId id

    [<HttpGet>]
    member this.ObterPor( [<FromQuery>] filtro) = 
       ClienteServico.obterPor filtro

    [<HttpPost>]
    member this.Salvar(cliente) =
        ClienteServico.incluirCliente cliente

    [<HttpPut>]
    member this.Atualizar(cliente) : IActionResult =
        try
            this.Ok (ClienteServico.atualizarCliente cliente) 
            :> IActionResult
        with
        | :? System.ArgumentException as erro-> 
            this.BadRequest(erro.Message) 
            :> IActionResult

    [<HttpDelete>]
    member this.Excluir(id) =
        ClienteServico.excluirCliente id