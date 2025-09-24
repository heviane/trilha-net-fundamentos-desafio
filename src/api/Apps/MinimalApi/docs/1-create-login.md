# Create Login

## O que foi feito até agora?

1. **Endpoint /login**: Você criou um endpoint simples que aceita um email e senha, e retorna se sucesso ou erro.
2. **Entidade Administrator**: Você criou uma entidade `Administrator` que representa um administrador no sistema.
3. **DbContexto**: Você criou um `DbContexto` que sabe como se conectar ao seu banco de dados MySQL.

> **Arquitetura**: [Onion Architecture](./onion-architecture.jpg) e [Clean Architecture](./clean-architecture.jpg).

### O próximo passo lógico

Conectar as peças que você já criou. Você já tem:

- Um endpoint /login com lógica "hardcoded".
- Uma entidade Administrator.
- Um DbContexto que sabe como se conectar ao seu banco de dados MySQL.

O próximo passo é fazer o endpoint /login usar o DbContexto para autenticar um Administrator real do banco de dados, em vez de usar credenciais fixas no código.

## Criar um Seed para cadastrar um administrador padrão inicial

O que é um Seed?

Um Seed é um conjunto de dados iniciais que você pode inserir no banco de dados automaticamente quando a aplicação é iniciada.
Isso é útil para garantir que você tenha dados básicos para trabalhar, como um usuário administrador padrão.

1. Na classe `DbContexto.cs`, adicione o seguinte método:

```csharp
protected override void OnModelCreating(ModelBuilder modelBuilder)
{
    modelBuilder.Entity<Administrator>().HasData(
        new Administrator(
            "c1b8e9a8-5b1a-4b1a-9b0a-0b9b8e9a8c1b",
            "heviane@gmail.com",
            "123456",
            "Admin"
        )
    );
}
```

2. No terminal:

```bash
# 1. Remova a migração anterior que não funcionou
dotnet ef migrations remove --project src/api/Apps/MinimalApi

# 2. Crie a migração novamente (agora com o Id fixo)
dotnet ef migrations add SeedAdministrator --project src/api/Apps/MinimalApi

# 3. Aplique a nova e correta migração ao banco de dados
dotnet ef database update --project src/api/Apps/MinimalApi
```

## Alterar o endpoint /login para trabalhar com os dados do banco de dados

1. Criar uma interface em domain/interfaces/IServiceAdministrator.cs
2. Criar uma classe de serviço em domain/services/ServiceAdministrator.cs
3. No `Program.cs`, adicione:

```Csharp
// Adicionar o serviço de autenticação ao escopo do builder
builder.Services.AddScoped<IServiceAdministrator, ServiceAdministrator>();

app.MapPost("/login", (LoginDTO loginDTO, IServiceAdministrator serviceAdministrator) =>
{
    if (serviceAdministrator.Login(loginDTO) != null)
    {
        return Results.Ok("Login successful!");
    }
    else
    {
        return Results.Unauthorized();
    }
});
```
