module Json

open Newtonsoft.Json

/// Object to Json 
let internal json<'t> (myObj:'t) =   
         JsonConvert.SerializeObject(myObj)


/// Object from Json 
let internal unjson<'t> (jsonString:string)  : 't =  
        JsonConvert.DeserializeObject<'t>(jsonString)