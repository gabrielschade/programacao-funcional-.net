namespace FSharpWeb.Controllers

open Microsoft.AspNetCore.Mvc

[<Route("api/[controller]/[action]")>]
type ProdutoController() =
    inherit Controller()

    [<HttpGet>]
    member this.ObterTodos() = 
       ProdutoServico.obterTodos()

    [<HttpGet>]
    member this.ObterPorId(id) = 
       ProdutoServico.obterPorId id

    [<HttpGet>]
    member this.ObterPor( [<FromQuery>] filtro) = 
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