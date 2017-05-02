namespace Repositorios

open Persistencia

module Repositorio =
    open System.Configuration

    let diretorioTabelas = 
        ConfigurationManager.AppSettings.Get("DiretorioTabelas")
    
    let obterContexto() = 
        inicializarContexto diretorioTabelas





//let contexto = inicializarContexto @"D:\Documentos\GitHub\programacao-funcional-.net\Capitulo7- Dados e colecoes\FSharpWeb\Dados"