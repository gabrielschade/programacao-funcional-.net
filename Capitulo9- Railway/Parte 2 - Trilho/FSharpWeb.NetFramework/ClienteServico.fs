module ClienteServico

open Operadores
open Trilhos
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
    | Some clienteExistente -> cliente |> Sucesso
    | None -> Falha ("Cliente não cadastrado no banco de dados")

let verificaNomeOuSobrenomeEmBranco (cliente:Cliente) =
    match cliente with
    | cliente when !!cliente.Nome || !!cliente.Sobrenome-> 
        Falha "É necessário preencher o nome e o sobrenome"
    | _ -> cliente |> Sucesso

let verificaFormatoEmail (cliente:Cliente) =
    match cliente with
    | cliente when cliente.Email <~ "@" -> cliente |> Sucesso
    | _ -> Falha "E-mail com formato incorreto"

let verificaFormatoCPF (cliente:Cliente) =
    match cliente with
    | cliente when cliente.CPF.Length = 14 -> cliente |> Sucesso
    | _ -> Falha "CPF com formato incorreto"

let incluirCliente =
    incluirClienteNoBanco
    >> transformarListaEmResposta

let atualizarCliente =
    verificaSeClienteExiste
    >>= verificaNomeOuSobrenomeEmBranco
    >>= verificaFormatoEmail
    >>= verificaFormatoCPF
    >> (<!>) transformarInicialNomeEmMaiusculo
    >> (<!>) atualizarClienteNoBanco
    >> (<!>) transformarListaEmResposta

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