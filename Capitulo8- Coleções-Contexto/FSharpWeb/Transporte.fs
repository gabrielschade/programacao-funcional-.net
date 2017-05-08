namespace Transporte

module Filtros = 

    [<CLIMutable>]
    type ClienteFiltro = { 
        Nome : string
        CPF : string
        Idade : int 
    }

    [<CLIMutable>]
    type ProdutoFiltro = { 
        Descricao : string
        PrecoMaximo : double
    }
