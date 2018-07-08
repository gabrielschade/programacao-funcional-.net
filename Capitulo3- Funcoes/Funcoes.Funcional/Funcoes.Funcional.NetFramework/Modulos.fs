namespace Modulos

[<RequireQualifiedAccess>]
module FuncoesDeEscrita =
    let escrever nome = printfn "seu nome é: %s" nome

[<RequireQualifiedAccess>]
module FuncoesDeEscritaDeNumeros =
    let escrever idade = printfn "sua idade é: %i" idade

module FuncoesDeEscritaUtilizandoOutrosModulos =
    let escrever nome idade =
        FuncoesDeEscrita.escrever nome
        FuncoesDeEscritaDeNumeros.escrever idade

namespace OutroNamespace
open Modulos

module FuncoesDeEscritaUtilizandoOutroNamespace =
    let escreverNomeEIdade nome idade =
        FuncoesDeEscrita.escrever nome
        FuncoesDeEscritaDeNumeros.escrever idade
