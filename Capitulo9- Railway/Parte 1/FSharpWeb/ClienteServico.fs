module ClienteServico

open Operadores
open Dominio
open Persistencia
open Transporte.Filtros
open Transporte.Respostas
open System.Globalization

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

let primeiraLetraMaiuscula nome =
    CultureInfo.CurrentCulture
               .TextInfo
               .ToTitleCase nome

let transformarInicialNomeEmMaiusculo 
    (cliente:Cliente) =
       { 
        cliente with 
            Nome = primeiraLetraMaiuscula cliente.Nome
       }

let verificaSeClienteExiste (cliente:Cliente) =
    let clienteDoBanco = obterDoBancoPorId cliente.Id
    match clienteDoBanco with
    | Some clienteExistente -> cliente
    | None -> raise (new System.Collections.Generic.KeyNotFoundException())

let verificaNomeOuSobrenomeEmBranco (cliente:Cliente) =
    match cliente with
    | cliente when !!cliente.Nome -> 
        invalidArg "Nome" "É necessário preencher"

    | cliente when !!cliente.Sobrenome -> 
        invalidArg "Sobrenome" "É necessário preencher"

    | _ -> cliente

let verificaFormatoEmail (cliente:Cliente) =
    match cliente with
    | cliente when cliente.Email <~ "@" -> cliente
    | _ -> raise (new System.FormatException("Email em formato incorreto"))

let verificaFormatoCPF (cliente:Cliente) =
    match cliente with
    | cliente when cliente.CPF.Length = 14 -> cliente
    | _ -> raise (new System.FormatException("CPF em formato incorreto"))

let incluirCliente =
    incluirClienteNoBanco
    >> transformarListaEmResposta

let atualizarCliente =
    verificaSeClienteExiste
    >> verificaNomeOuSobrenomeEmBranco
    >> verificaFormatoEmail
    >> verificaFormatoCPF
    >> transformarInicialNomeEmMaiusculo
    >> atualizarClienteNoBanco
    >> transformarListaEmResposta

let excluirCliente = 
    excluirClienteDoBanco
    >> transformarListaEmResposta

let obterTodos = 
    obterTodosDoBanco
    >> transformarListaEmResposta

let obterPorId = 
    obterDoBancoPorId
    >> Option.map (ClienteResposta.transformar)

let obterPor = 
    obterDoBancoPorFiltro
    >> transformarListaEmResposta