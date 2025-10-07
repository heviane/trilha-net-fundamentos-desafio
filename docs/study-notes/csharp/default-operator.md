# Operador `default`

É um operador importante e muito comum em C# moderno, especialmente desde a introdução dos "tipos de referência anuláveis" (nullable reference types).

Vamos analisar o que ele significa.

## O que é default!?

Essa expressão é a combinação de duas coisas:

- **`default`**: É uma palavra-chave que retorna o valor padrão para qualquer tipo. Para tipos de referência como string, o valor padrão é null.
- **`! (Operador "null-forgiving")`**: Este é o ponto-chave. O ! é um operador que diz ao compilador: "Eu, o desenvolvedor, sei o que estou fazendo. Eu garanto que este valor não será nulo quando for usado, então, por favor, não me dê um aviso de compilação sobre um possível null aqui."

**EM RESUMO**: É uma forma de inicializar uma propriedade não anulável (string) com null para satisfazer o compilador, suprimindo o aviso de que a propriedade não foi inicializada.

Frameworks como **ASP.NET Core (para DTOs)** e **Entity Framework Core (para entidades)** funcionam dessa maneira: eles criam um objeto vazio e depois preenchem as propriedades. O `default!` é usado para "calar" o compilador nesse cenário.

## O Risco e uma Alternativa Mais Segura

O perigo do `default!` é que a "promessa" feita ao compilador pode ser quebrada. Se você esquecer de inicializar a propriedade, ela terá o valor `null` em tempo de execução, e qualquer tentativa de usá-la causará o temido `NullReferenceException`.

Uma abordagem mais segura e robusta, especialmente para entidades de domínio, é forçar a inicialização através de um **método construtor**. Isso garante que um objeto nunca possa existir em um estado inválido (sem e-mail ou senha).

## Research

- nullable reference types (tipos de referência anuláveis): ...
