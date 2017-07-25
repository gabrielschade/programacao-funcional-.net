# Saindo do C# e começando no F#.

Este repositório contém os exemplos utilizados no meu livro de programação funcional em .NET, claro que recomendo comprá-lo, mas há algumas coisas que você já pode saber agora.

## Introdução

Uma breve introdução sobre os exemplos e sobre o paradigma funcional, **não haverão atalhos**. Não existe uma forma razoável de "traduzir" código em C# (ou Java, se preferir) para o F#. Simplesmente porque eles representam duas formas diferentes de se programar, cada uma com um paradigma e uma gama de conceitos completamente diferentes entre si.

Aprender programação funcional expande os horizontes de sua visão como programador e eu acredito fortemente que irá lhe auxiliar a pensar na solução dos problemas de forma diferente. E este motivo: **pensar de forma diferente** é o que torna a programação funcional tão interessante.

## Conceitos principais

Em F# não existem classes, portanto, sem objetos! Você também não possuirá variáveis! E nem deve realizar declarações (*statements*)!

Calma, não é tão aterrorizante quanto parece e todas as coisas ditas acima não são totalmente verdade. Na verdade em F# existem classes, objetos, variáveis e você pode realizar atribuições. Mas o fato de você poder fazer isso, não significa que você *deve* fazer isso.

O F# funciona na plataforma .NET portanto ele pode ser integrado a um projeto C# para a criação de um projeto híbrido, por isso existe na linguagem todo o suporte para criação de classes, variáveis e tudo mais que você já conhece.

No entanto, é fortemente recomendado, principalmente no início que você tente realizar solucionar seus problemas com uma abordagem puramente funcional.

Mas se perdemos todas estas funcionalidades da linguagem, o que usar no lugar?

1. **Valores imutáveis** ao invés de variáveis;
1. **Expressões** ao invés de *statements*;
1. **Tipos e Funções** ao invés de classes e objetos.

## Show me the code!

Veja o código abaixo em F#

``` fsharp
let elevarAoQuadrado numero = 
    numero * numero

let elevarListaAoQuadrado numeros =
    numeros
    |> List.map elevarAoQuadrado
``` 

Agora vamos para uma implementação muito similar em C#

``` csharp
public int ElevarAoQuadrado(int numero)
{
    return numero * numero;
}

public List<int> ElevarListaAoQuadrado(List<int> numeros)
{
     for(int indice=0; indice < numeros.Count; indice++)
         numeros[indice] = ElevarAoQuadrado(numeros[indice]);
 
     return numeros;
 
}
```

A primeira coisa que você pode notar é: F# é naturalmente mais sucinto que C#. 

F# dispensa completamente o uso de ponto e vírgula para delimitar linhas, chaves para delimitar escopos e parênteses para a maior parte dos casos, com exceção a utilização deles para definir prioridade de resolução de expressões.

Para definir seus escopos e determinar a quebra de linhas é utilizado o próprio espaçamento, portanto, mantenha seu código indentado!

Neste ponto você pode argumentar que há uma solução melhor em C# para resolver este problema: "Você nem sabe o que está fazendo, era só utilizar LINQ!"

Bom, se essa era a resposta que você esperava:

``` csharp
public IEnumerable<int> ElevarListaAoQuadrado(IEnumerable<int> numeros)
{
     return numeros.Select(ElevarAoQuadrado);
}
```
Eu **concordo** totalmente que esta é uma solução melhor, inclusive toda a biblioteca LINQ utiliza conceitos de **programação funcional**. Por isso o código se tornou mais parecido.

## Considerações finais

Existem muito mais diferenças entre o paradigma funcional e o paradigma orientado a objetos e cada novo conceito dito aqui é explicado com muito mais calma e cuidado no livro. Claro que existem muitos conteúdos de qualidade que você também **deve** consumir.

* https://docs.microsoft.com/en-us/dotnet/fsharp/
* http://fsharpforfunandprofit.com/
* https://docs.microsoft.com/en-us/dotnet/fsharp/tour
