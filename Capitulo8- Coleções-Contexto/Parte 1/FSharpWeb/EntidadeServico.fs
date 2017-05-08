module EntidadeServico

open Persistencia

let atualizarTabela funcaoParaObterNovosDados tabela = 
    let dados = funcaoParaObterNovosDados tabela
    salvarTabela { tabela with Dados = dados }