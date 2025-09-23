# Anotações de Estudos

## Sobre CSharp

### `Guid.NewGuid()`

É um inicializador de propriedade. Cria um **Globally Unique Identifier (Identificador Globalmente Único)**.
Pense nisso como gerar um número de série de 128 bits que é estatisticamente único no universo.
A chance de gerar dois GUIDs iguais é astronomicamente pequena.

**EM RESUMO**: Essa linha de código cria uma propriedade `Id` que, automaticamente, recebe um identificador de texto único e aleatório toda vez que um novo objeto Administrator é criado. É uma maneira excelente e muito comum de garantir que cada objeto (que pode representar uma linha em um banco de dados, por exemplo) tenha uma chave primária única sem que você precise se preocupar em gerá-la manualmente.

### `init`

Indica que a propriedade pode ser atribuída apenas durante a inicialização do objeto (Imutabilidade).
Isso permite que o valor seja definido apenas durante a criação do objeto, e depois se torna somente leitura.

**EM RESUMO**: Com init, você ainda pode criar um administrador (`new Administrator { Email = "..." }`), mas qualquer tentativa de fazer `admin.Id = "novo-id";` depois que ele foi criado resultará em um erro de compilação, protegendo a integridade do seu objeto.

### `default`

É um operador importante e muito comum em C# moderno, especialmente desde a introdução dos "tipos de referência anuláveis" (nullable reference types).

Vamos analisar o que ele significa.

#### O que é default!?

Essa expressão é a combinação de duas coisas:

- **`default`**: É uma palavra-chave que retorna o valor padrão para qualquer tipo. Para tipos de referência como string, o valor padrão é null.
- **`! (Operador "null-forgiving")`**: Este é o ponto-chave. O ! é um operador que diz ao compilador: "Eu, o desenvolvedor, sei o que estou fazendo. Eu garanto que este valor não será nulo quando for usado, então, por favor, não me dê um aviso de compilação sobre um possível null aqui."

**EM RESUMO**: É uma forma de inicializar uma propriedade não anulável (string) com null para satisfazer o compilador, suprimindo o aviso de que a propriedade não foi inicializada.

Frameworks como **ASP.NET Core (para DTOs)** e **Entity Framework Core (para entidades)** funcionam dessa maneira: eles criam um objeto vazio e depois preenchem as propriedades. O `default!` é usado para "calar" o compilador nesse cenário.

##### O Risco e uma Alternativa Mais Segura

O perigo do `default!` é que a "promessa" feita ao compilador pode ser quebrada. Se você esquecer de inicializar a propriedade, ela terá o valor `null` em tempo de execução, e qualquer tentativa de usá-la causará o temido `NullReferenceException`.

Uma abordagem mais segura e robusta, especialmente para entidades de domínio, é forçar a inicialização através de um **método construtor**. Isso garante que um objeto nunca possa existir em um estado inválido (sem e-mail ou senha).

## Research

- nullable reference types (tipos de referência anuláveis): ...
