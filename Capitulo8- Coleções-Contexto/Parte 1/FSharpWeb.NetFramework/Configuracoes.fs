module Configuracoes

open System.Configuration

let obterConfiguracao (nomeConfiguracao:string) = 
    ConfigurationManager.AppSettings.Get(nomeConfiguracao)

let diretorioTabelas = obterConfiguracao "DiretorioTabelas"