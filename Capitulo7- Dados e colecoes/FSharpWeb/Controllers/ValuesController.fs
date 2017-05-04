namespace FSharpWeb.Controllers

open System
open System.Collections.Generic
open System.Linq
open System.Net.Http
open System.Web.Http

type ValuesController() =
    inherit ApiController()

    member this.Get() = 
       let contexto = Persistencia.obterContexto()
       contexto.Clientes.Dados