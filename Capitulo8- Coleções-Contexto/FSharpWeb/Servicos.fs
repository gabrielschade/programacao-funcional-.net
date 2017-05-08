namespace Servicos

open Dominio
open Persistencia



module ClienteServico =
    let obterClientes() =
        obterContexto().Clientes
    
    let atualizarTabelaClientes funcaoParaObterNovosDados =
        let tabela = obterClientes()
        let dados = funcaoParaObterNovosDados tabela
        salvarTabela {tabela with Dados = dados}

    let filtrarClientesPor filtro lista =
        lista |> List.filter filtro

    let filtrarTabelaClientesPor filtro =
        obterClientes().Dados
        |> filtrarClientesPor filtro

    let excluirClienteComId id (lista:Cliente list) =
           lista
           |> filtrarClientesPor (fun cliente -> cliente.Id <> id)

    let excluirCliente id =
        atualizarTabelaClientes (fun tabela -> 
            excluirClienteComId id tabela.Dados)

    let incluirCliente cliente =
        atualizarTabelaClientes (fun tabela -> cliente :: tabela.Dados)

    let atualizarCliente cliente =
        let removeEAdiciona tabela = 
           cliente :: (excluirClienteComId 
                        cliente.Id 
                        tabela.Dados)

        atualizarTabelaClientes (removeEAdiciona)

    let obterTodos() =
        obterClientes().Dados

    let obterPorId id =
        filtrarTabelaClientesPor 
            (fun cliente -> cliente.Id = id)

    let obterPorNome nome =
        filtrarTabelaClientesPor
            (fun cliente -> cliente.Nome.Contains nome)