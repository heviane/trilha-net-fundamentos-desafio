# Warnings

Esses avisos (warnings) são gerados pelo compilador do C# para te ajudar a escrever um código mais seguro e robusto, especialmente para evitar erros de "referência nula" (`NullReferenceException`) em tempo de execução.

## Análise e Correção dos Avisos

A maioria dos avisos está relacionada ao recurso de `Nullable Reference Types` do C#.
Eles indicam locais onde uma variável que pode ser nula está sendo usada como se nunca fosse nula.

### 1. Aviso no DbContexto.cs (CS8618)

```plaintext
warning CS8618: Non-nullable field '_configurationAppSettings' must contain a non-null value when exiting constructor.
```

- **Problema**: Você tem um campo chamado `_configurationAppSettings` na sua classe DbContexto que não pode ser nulo. No entanto, você adicionou um novo construtor que recebe DbContextOptions (para os testes) e este construtor não inicializa o campo `_configurationAppSettings`.

- **Solução**: A maneira mais limpa de resolver isso é tornar o campo _configurationAppSettings anulável (nullable), já que ele só é necessário quando a aplicação principal está em execução, e não nos testes.

```csharp
private readonly IConfiguration _configurationAppSettings;
```

Para:

```csharp
private readonly IConfiguration? _configurationAppSettings;
```

Adicionar o **`?`** informa ao compilador que este campo pode, intencionalmente, ser nulo.

### 2. Avisos no Program.cs (CS8601, CS8602, CS8604)

Esses avisos ocorrem porque você está passando valores que podem ser nulos (como `administratorDTO.Email`) para métodos ou construtores que esperam valores não nulos.

- **Problema**: Suas classes DTO (AdministratorDTO, LoginDTO) provavelmente têm propriedades como public string? Email { get; set; }. Quando você as passa para o construtor new Administrator(email, password, perfil), que espera string (não nulo), o compilador avisa sobre o risco.

- **Solução**: Vamos adicionar verificações para garantir que os valores não são nulos antes de usá-los. Isso não só resolve os avisos, mas também torna sua API mais segura contra dados inválidos.

Aqui estão as alterações para o seu arquivo `Program.cs`:

```csharp
    // =========== Geração do Token JWT*
    var claims = new List<Claim>() //new[]
    {
        new System.Security.Claims.Claim("Email", administrator.Email ?? string.Empty),
        new System.Security.Claims.Claim("Perfil", administrator.Perfil ?? string.Empty),
        new System.Security.Claims.Claim(ClaimTypes.Role, administrator.Perfil ?? string.Empty),
    };

    // =========== Criação de Administrador

    // Validação simples dos dados recebidos
    if (string.IsNullOrEmpty(administratorDTO.Email) || string.IsNullOrEmpty(administratorDTO.Password))
    {
        if (string.IsNullOrEmpty(administratorDTO.Email))
            messages.Messages.Add("Email is required.");
        if (string.IsNullOrEmpty(administratorDTO.Password))
            messages.Messages.Add("Password is required.");
    }

    if (administratorDTO.Perfil == null || !Enum.IsDefined(typeof(UserPerfil), administratorDTO.Perfil))
    {
        // Mapeia os dados do DTO para a entidade Administrator
        var administrator = new Administrator(
            administratorDTO.Email!, // O '!' informa ao compilador que confiamos que não é nulo aqui
            administratorDTO.Password!,
            administratorDTO.Perfil.ToString()!
        );

        serviceAdministrator.Create(administrator);
        {
            Id = administrator.Id,
            Email = administrator.Email,
            Perfil = administrator.Perfil
        };
    }

    // =========== Mapeamento para AdministratorModelView
    adms.Add(new AdministratorModelView
    {
        Id = administrator.Id,
        Email = administrator.Email!,
        Perfil = administrator.Perfil!
    });

    // Retorna a lista de administradores com status 200 OK
    return administrator != null ? Results.Ok(new AdministratorModelView
    {
        Id = administrator.Id,
        Email = administrator.Email!,
        Perfil = administrator.Perfil!
    }) : Results.NotFound();
```

#### Resumo das Mudanças no `Program.cs`

- **Geração do Token JWT**: Adicionei `?? string.Empty` para garantir que, mesmo se Email ou Perfil fossem nulos (o que não deveria acontecer), não passaríamos um valor nulo para Claim.
- **Criação de Administrador**:
  - Melhorei a validação para garantir que Email e Password não sejam nulos ou vazios.
  - Usei o operador `! (null-forgiving)` ao chamar o construtor `new Administrator(...)`. Isso diz ao compilador: "Eu já verifiquei, e garanto que administratorDTO.Email não é nulo neste ponto".
- **Mapeamento para `AdministratorModelView`**: Também usei o operador `!` para garantir ao compilador que as propriedades do administrador recuperado do banco não serão nulas ao criar o `ModelView`.

> **PRONTO!** Após aplicar essas correções, seu projeto deve compilar sem avisos, e seu código estará mais seguro contra referências nulas.
