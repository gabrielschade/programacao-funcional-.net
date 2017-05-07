namespace Servicos

open Dominio
open Persistencia

module ClienteServico =
    let obterClientes() =
        obterContexto().Clientes
    
    let rec excluirClienteComId id jaPercorridos (lista:Cliente list) =
           match lista with
                | head::tail when head.Id = id -> jaPercorridos @ tail
                | head::tail -> excluirClienteComId id (head::jaPercorridos) tail
                | [] -> jaPercorridos

    let atualizarTabelaClientes funcaoParaObterNovosDados =
        let tabela = obterClientes()
        let dados = funcaoParaObterNovosDados tabela
        salvarTabela {tabela with Dados = dados}

    let incluirCliente cliente =
        atualizarTabelaClientes (fun tabela -> cliente :: tabela.Dados)

    let atualizarCliente cliente =
        let removeEAdiciona tabela = 
           cliente :: (excluirClienteComId 
                        cliente.Id 
                        [] 
                        tabela.Dados)

        atualizarTabelaClientes (removeEAdiciona)

    let excluirCliente id =
        atualizarTabelaClientes (fun tabela -> 
            excluirClienteComId id [] tabela.Dados)