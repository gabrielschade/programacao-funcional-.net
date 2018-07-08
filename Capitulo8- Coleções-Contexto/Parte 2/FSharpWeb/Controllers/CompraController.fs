namespace FSharpWeb.Controllers

open Microsoft.AspNetCore.Mvc

[<Route("api/[controller]/[action]")>]
type CompraController() =
    inherit Controller()

    [<HttpGet>]
    member this.ObterTodos() = 
       CompraServico.obterTodos()

    [<HttpGet>]
    member this.ObterPorId(id) = 
       CompraServico.obterPorId id

    [<HttpGet>]
    member this.ObterPor(  [<FromQuery>]  filtro) =
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