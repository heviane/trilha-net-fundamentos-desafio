# Anotações de Estudos Sobre CSharp

## `Guid.NewGuid()`

É um inicializador de propriedade. Cria um **Globally Unique Identifier (Identificador Globalmente Único)**.
Pense nisso como gerar um número de série de 128 bits que é estatisticamente único no universo.
A chance de gerar dois GUIDs iguais é astronomicamente pequena.

**EM RESUMO**: Essa linha de código cria uma propriedade `Id` que, automaticamente, recebe um identificador de texto único e aleatório toda vez que um novo objeto Administrator é criado. É uma maneira excelente e muito comum de garantir que cada objeto (que pode representar uma linha em um banco de dados, por exemplo) tenha uma chave primária única sem que você precise se preocupar em gerá-la manualmente.

## `init`

Indica que a propriedade pode ser atribuída apenas durante a inicialização do objeto (Imutabilidade).
Isso permite que o valor seja definido apenas durante a criação do objeto, e depois se torna somente leitura.

**EM RESUMO**: Com init, você ainda pode criar um administrador (`new Administrator { Email = "..." }`), mas qualquer tentativa de fazer `admin.Id = "novo-id";` depois que ele foi criado resultará em um erro de compilação, protegendo a integridade do seu objeto.
