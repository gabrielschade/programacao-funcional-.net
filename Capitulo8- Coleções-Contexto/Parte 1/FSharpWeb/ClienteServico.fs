module ClienteServico

open Operadores
open Dominio
open Persistencia
open Transporte.Filtros

let obterClientes() = obterContexto().Clientes

let atualizarTabelaClientes funcaoParaObterNovosDados = 
    obterClientes()
    |> EntidadeServico.atualizarTabela funcaoParaObterNovosDados

let filtrarTabelaClientesPor filtro = 
    obterClientes().Dados 
    |> List.filter filtro

let obterSemClienteComId id (lista : Cliente list) = 
    lista 
    |> List.filter 
        (fun cliente -> cliente.Id <> id)

let excluirCliente id = 
    atualizarTabelaClientes 
        (fun tabela -> obterSemClienteComId id tabela.Dados)

let incluirCliente cliente = 
    atualizarTabelaClientes 
        (fun tabela -> cliente :: tabela.Dados)

let atualizarCliente cliente = 
    let removeEAdiciona tabela = 
        cliente :: (obterSemClienteComId cliente.Id tabela.Dados)

    atualizarTabelaClientes (removeEAdiciona)

let obterTodos() = obterClientes().Dados

let obterPorId id = 
    obterClientes().Dados 
    |> List.tryFind (fun cliente -> cliente.Id = id)

let obterPor filtro = 
    filtrarTabelaClientesPor 
        (fun cliente -> 
            (!!filtro.CPF || cliente.CPF = filtro.CPF) 
            && (cliente.Nome <~ filtro.Nome || cliente.Sobrenome <~ filtro.Nome) 
            && (filtro.Idade = 0 || cliente.Idade = filtro.Idade))
