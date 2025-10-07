# Synchrony vs. Asynchrony

Operações que acessam um banco de dados ou qualquer outra fonte de dados externa (I/O) devem ser assíncronas para não bloquear a thread da aplicação.

Isso é crucial em APIs para garantir escalabilidade e responsividade.

Os métodos devem retornar `Task` ou `Task<T>`.
Por convenção, métodos assíncronos devem ter o sufixo `Async` em seus nomes.
