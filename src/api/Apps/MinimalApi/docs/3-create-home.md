# Configurar a Home

Aula: Criando rota Home respondendo por JSON.
Rota atual `app.MapGet("/", () => "Hello World!");` em `Program.cs`.

1. Criar diretório `domain/ModelViews`
Modelos de visualizações para quando tiver quer retornar os dados em **JSON**.
2. Criar uma instância menor **struct** chamada `Home.cs`
Porque vai retorna somente uma estrutra de visualização.
3. No `Program.cs` alterar a rota principal "/" para executar a Home.cs
4.
