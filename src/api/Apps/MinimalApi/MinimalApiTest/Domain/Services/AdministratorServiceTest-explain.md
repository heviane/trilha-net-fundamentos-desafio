# Explain: `AdministratorServiceTest.cs`

## `erro CS1503`

O erro `CS1503` que você está vendo acontece porque você está tentando criar uma instância do seu `DbContexto` passando um objeto de opções (`DbContextOptions`), mas o construtor do `DbContexto` espera receber um objeto de configuração (`IConfiguration`).

Isso revela um ponto crucial para tornar seu código testável: o `DbContext` não deveria depender diretamente de `IConfiguration`. A melhor prática é configurá-lo para receber `DbContextOptions` em seu construtor. Isso permite que você, na sua aplicação principal, injete as opções com a string de conexão do `appsettings.json` e, nos seus testes, injete as opções para usar um banco de dados em memória.

Para corrigir isso, vamos ajustar seu arquivo de teste para usar um banco de dados em memória, que é a abordagem ideal para testes unitários — é rápido, isolado e não depende de um banco de dados real ou de arquivos de configuração.

### Correções no Código

Vou fazer as seguintes alterações no seu arquivo **`AdministratorServiceTest.cs`**:

- **Método CreateDbContextTest**: Vou renomeá-lo para `CreateInMemoryDbContext` para ser mais descritivo e ajustá-lo para criar e retornar corretamente um DbContexto configurado para usar um banco de dados em memória.
- **Construtor da Entidade**: No seu teste, você está usando `new Administrator()`. No entanto, sua entidade Administrator não possui um construtor sem parâmetros. Vou ajustar para usar o construtor que espera email, password, etc.
- **Lógica do Teste**: Vou refatorar o teste `SaveAdministrator` para seguir o padrão **"Arrange, Act, Assert" (Organizar, Agir, Verificar)** de forma clara, removendo a chamada `TRUNCATE TABLE` (que não funciona com banco de dados em memória e não é necessária) e corrigindo a asserção final.

Como ficou a classe ÀdministratorServiceTest.cs:

```csharp
// Em /MinimalApiTest/Domain/Services/AdministratorServiceTest.cs
namespace MinimalApiTest.Domain.Services;

[TestClass]
public class AdministratorServiceTest
{
    private DbContexto CreateInMemoryDbContext()
    {
        var options = new DbContextOptionsBuilder<DbContexto>()
            .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString()) // Usa um nome de DB único para cada teste
            .Options;

        // Para que isso funcione, seu DbContexto precisa ter um construtor
        // que aceite DbContextOptions<DbContexto>
        // public DbContexto(DbContextOptions<DbContexto> options) : base(options) { }
        return new DbContexto(options);
    }

    [TestMethod]
    public void SaveAdministrator()
    {
        // Arrange (Organizar)
        var context = CreateInMemoryDbContext();
        var administratorService = new AdministratorService(context);

        var adm = new Administrator(
            email: "teste@teste.com.br",
            password: "123456",
            perfil: "Admin"
        );

        // Act (Agir)
        administratorService.Create(adm);

        // Assert (Verificar)
        // 1. Verifica se existe exatamente 1 administrador no banco de dados
        Assert.AreEqual(1, context.Administrators.Count());

        // 2. Busca o administrador salvo e verifica se os dados estão corretos
        var savedAdm = context.Administrators.FirstOrDefault();
        Assert.IsNotNull(savedAdm);
        Assert.AreEqual("teste@teste.com.br", savedAdm.Email);
        Assert.AreEqual("Admin", savedAdm.Perfil);
    }
}
```

> **Observação Importante**: Para que o código acima funcione, você precisará garantir que sua classe `DbContexto` tenha um construtor que aceite `DbContextOptions<DbContexto>`, como no exemplo abaixo:

```csharp
// Em /MinimalApi/Infrastructure/Db/DbContexto.cs
public class DbContexto : DbContext
{
    // Construtor para ser usado nos testes e na injeção de dependência
    public DbContexto(DbContextOptions<DbContexto> options) : base(options)
    {
    }

    // ... seus DbSets e configurações
}
```

> **PRONTO**: Após aplicar essas alterações, seu teste estará mais robusto, rápido e desacoplado de dependências externas, resolvendo o erro de compilação.
