module Configuracoes

open Microsoft.Extensions.Configuration
open System.IO

let construtor = new ConfigurationBuilder()
let construtorDiretorio = construtor.SetBasePath(Directory.GetCurrentDirectory())
let arquivoJson = construtorDiretorio.AddJsonFile("appsettings.json")
let configuracao = arquivoJson.Build()

let obterConfiguracao (nomeConfiguracao:string) = 
    configuracao.[nomeConfiguracao]

let diretorioTabelas = obterConfiguracao "DiretorioTabelas"