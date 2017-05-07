namespace FSharpWeb.Controllers

open System
open System.Net.Http
open System.Web.Http
open Servicos

type ClienteController() =
    inherit ApiController()

    [<HttpGet>]
    member this.ObterTodos() = 
       Persistencia.obterContexto().Clientes.Dados

    [<HttpPost>]
    member this.Salvar(cliente) =
        ClienteServico.incluirCliente cliente

    [<HttpPut>]
    member this.Atualizar(cliente) =
        ClienteServico.atualizarCliente cliente

    [<HttpDelete>]
    member this.Excluir(id) =
        Servicos.ClienteServico.excluirCliente id