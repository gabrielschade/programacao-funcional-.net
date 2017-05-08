module Dominio

type Cliente = {
    Id: int
    Nome: string
    Sobrenome: string
    CPF: string
    Idade: int
    Email: string
    Telefone: string
    Endereco: string
} 

type Produto = {
    Id: int
    Descricao: string
    Detalhes: string
    Preco: double
}

type Compra = {
    Id: int
}