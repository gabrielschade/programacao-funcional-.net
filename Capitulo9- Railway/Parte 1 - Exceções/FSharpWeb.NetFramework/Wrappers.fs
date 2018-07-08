namespace Wrappers

module Json =
    open Newtonsoft.Json

    let serializar objeto =
        JsonConvert.SerializeObject(objeto)

    let desserializar<'a> json =
        JsonConvert.DeserializeObject<'a>(json)


module Arquivo =
    open System.IO  

    let salvar diretorio conteudo =
        File.WriteAllText(diretorio, conteudo)

    let abrir diretorio =
        File.ReadAllText(diretorio)

    let existe diretorio =
        File.Exists(diretorio)