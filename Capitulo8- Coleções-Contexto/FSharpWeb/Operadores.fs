module Operadores 

open System

let (^) string1 string2 =
    sprintf "%s%s" string1 string2

let (!!) string = String.IsNullOrEmpty string

let (<~) (string:string) substring = 
    (!! substring || string.Contains substring )

