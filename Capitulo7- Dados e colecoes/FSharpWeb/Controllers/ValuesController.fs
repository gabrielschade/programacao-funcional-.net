namespace FSharpWeb.Controllers

open System
open System.Collections.Generic
open System.Linq
open System.Net.Http
open System.Web.Http
open Repositorios

type ValuesController() =
    inherit ApiController()
    let values = [|"value1";"value2"|]

    member this.Get() = 
        Repositorio.obterContexto().Inteiros.Dados