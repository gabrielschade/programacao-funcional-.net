namespace FSharpWeb.Controllers

open System
open System.Net.Http
open System.Web.Http
open Servicos

type ClienteController() =
    inherit ApiController()

    [<HttpGet>]
    member this.ObterTodos() = 
       ClienteServico.obterTodos()

    [<HttpGet>]
    member this.ObterPorId(id) = 
       ClienteServico.obterPorId id

    [<HttpGet>]
    member this.ObterPorNome(nome) = 
       ClienteServico.obterPorNome nome

    [<HttpPost>]
    member this.Salvar(cliente) =
        ClienteServico.incluirCliente cliente

    [<HttpPut>]
    member this.Atualizar(cliente) =
        ClienteServico.atualizarCliente cliente

    [<HttpDelete>]
    member this.Excluir(id) =
        ClienteServico.excluirCliente id