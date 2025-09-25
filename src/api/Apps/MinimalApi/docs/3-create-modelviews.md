# Criar Model Views

Modelos de visualizações para quando tiver quer retornar os dados em **JSON**.

1. Criar diretório `domain/ModelViews`

## 1. Criar Model View `Home.cs`

Aula: Criando rota Home respondendo por JSON.
Rota atual `app.MapGet("/", () => "Hello World!");` em `Program.cs`.

1. Criar uma instância menor **record** chamada `Home.cs`
Porque vai retorna somente uma estrutra de visualização.
2. No `Program.cs` alterar a rota principal "/" para executar a Home.cs

## 2. Criar Model View `ValidationErrors.cs`

1. Criar uma instância menor **struct** chamada `ValidationErrors.cs`.
2. No `Program.cs` incluir as validações dentro das rotas.
