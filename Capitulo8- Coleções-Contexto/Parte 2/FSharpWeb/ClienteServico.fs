module ClienteServico

open Operadores
open Dominio
open Persistencia
open Transporte.Filtros
open Transporte.Respostas

let obterClientes() = 
    obterContexto().Clientes

let transformarListaEmResposta =
    List.map (ClienteResposta.transformar)

let atualizarTabelaClientes funcaoParaObterNovosDados = 
    obterClientes()
    |> EntidadeServico.atualizarTabela funcaoParaObterNovosDados


let filtrarTabelaClientesPor filtro = 
    obterClientes().Dados
    |> (List.filter filtro)

let obterSemClienteComId id (lista : Cliente list) = 
    lista 
    |> List.filter 
        (fun cliente -> cliente.Id <> id)

let obterDoBancoPorFiltro (filtro: ClienteFiltro) = 
    filtrarTabelaClientesPor 
        (fun cliente -> 
            (!!filtro.CPF || cliente.CPF = filtro.CPF) 
            && (cliente.Nome <~ filtro.Nome || cliente.Sobrenome <~ filtro.Nome) 
            && (filtro.Idade = 0 || cliente.Idade = filtro.Idade))

let obterDoBancoPorId id =
    obterClientes().Dados 
    |> List.tryFind (fun cliente -> cliente.Id = id)

let obterTodosDoBanco() =
    obterClientes().Dados

let excluirClienteDoBanco id =
    atualizarTabelaClientes 
        (fun tabela -> obterSemClienteComId id tabela.Dados)


let incluirClienteNoBanco cliente = 
    atualizarTabelaClientes 
        (fun tabela -> cliente :: tabela.Dados)

let atualizarClienteNoBanco cliente = 
    let removeEAdiciona tabela = 
        cliente :: (obterSemClienteComId cliente.Id tabela.Dados)

    atualizarTabelaClientes (removeEAdiciona)

let incluirCliente =
    incluirClienteNoBanco
    >> transformarListaEmResposta

let atualizarCliente =
    atualizarClienteNoBanco
    >> transformarListaEmResposta

let excluirCliente = 
    excluirClienteDoBanco
    >> transformarListaEmResposta

let obterTodos() = 
    obterTodosDoBanco
    >> transformarListaEmResposta

let obterPorId = 
    obterDoBancoPorId
    >> Option.map (ClienteResposta.transformar)

let obterPor = 
    obterDoBancoPorFiltro
    >> transformarListaEmResposta