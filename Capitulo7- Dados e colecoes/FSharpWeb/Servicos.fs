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

    let atualizarClientes funcaoParaObterNovosDados =
        let tabela = obterClientes()
        let dados = funcaoParaObterNovosDados tabela
        salvarTabela {tabela with Dados = dados}

    let incluirCliente cliente =
        atualizarClientes (fun tabela -> cliente :: tabela.Dados)

    let excluirCliente id =
        atualizarClientes (fun tabela -> 
            excluirClienteComId id [] tabela.Dados)