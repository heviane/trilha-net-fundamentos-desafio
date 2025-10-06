# Senha Segura no Banco de Dados

Como posso garantir que a senha do Administrator seja armazenada de forma segura no banco de dados, em vez de texto puro?

Essa é uma das preocupações de segurança mais importantes em qualquer aplicação que lida com autenticação. Armazenar senhas em texto puro é uma falha de segurança gravíssima.

A solução padrão e recomendada pela indústria é usar Hashing de Senha com Salt.

## O que é Hashing de Senha com Salt?

- Hashing: É um processo de mão única que transforma uma senha (ex: "123456") em uma string de caracteres aparentemente aleatória e de tamanho fixo (o "hash"). A parte crucial é que é computacionalmente inviável reverter o processo, ou seja, descobrir a senha original a partir do hash.
- Salt: É um valor aleatório gerado para cada usuário e combinado com a senha antes de fazer o hash. Isso garante que, mesmo que dois usuários tenham a mesma senha, seus hashes armazenados no banco de dados serão completamente diferentes. Isso protege contra ataques de "rainbow table" (tabelas com hashes pré-calculados).

A biblioteca mais popular e fácil de usar em .NET para isso é a **BCrypt.Net-Next**.

Vamos implementar essa segurança no seu projeto passo a passo.

## Passo 1: Instalar a Biblioteca BCrypt.Net-Next

No terminal, na pasta do seu projeto MinimalApi, execute o seguinte comando:

```bash
dotnet add package BCrypt.Net-Next --project src/api/Apps/MinimalApi
```

## Passo 2: Modificar a Entidade Administrator

A primeira mudança é na sua entidade. Não vamos mais armazenar a senha, mas sim o hash da senha. É uma boa prática renomear a propriedade para deixar isso claro e adicionar um método para verificação.

```csharp
/// <summary>
/// Hash da senha do administrador.
/// </summary>
[Required]
[StringLength(100)] // Hashes são mais longos que senhas em texto puro
public string PasswordHash { get; set; }

public Administrator(string id, string email, string passwordHash, string perfil)
{
    this.Id = id;
    this.Email = email;
    this.Password = password;
    this.PasswordHash = passwordHash;
    this.Perfil = perfil;
}

/// <summary>
/// Verifica se a senha fornecida corresponde ao hash armazenado.
/// </summary>
/// <param name="password">A senha em texto puro para verificar.</param>
/// <returns>True se a senha for válida, caso contrário, false.</returns>
public bool VerifyPassword(string password) => BCrypt.Net.BCrypt.Verify(password, this.PasswordHash);
```

### Resumo das mudanças:

- Renomeamos Password para PasswordHash para maior clareza.
- Aumentamos o StringLength para 100, pois os hashes do BCrypt são mais longos.
- Atualizamos o construtor para aceitar passwordHash.
- Adicionamos um método VerifyPassword que usa o BCrypt.Verify para comparar uma senha em texto puro com o hash armazenado.

## Passo 3: Atualizar o "Seed" do Banco de Dados

Agora, seu DbContexto não pode mais usar a senha "123456". Precisamos gerar um hash para ela e usá-lo no HasData.

Você pode gerar o hash rapidamente com um pequeno código temporário ou usando um REPL como o dotnet-script.

```csharp
// Código para gerar o hash
string passwordToHash = "123456";
string hash = BCrypt.Net.BCrypt.HashPassword(passwordToHash);
Console.WriteLine(hash); 
// Exemplo de saída: $2a$11$SomeRandomCharactersAndHash...
```

Agora, pegue o hash gerado e use-o no seu DbContexto.cs (o arquivo não foi fornecido, mas a lógica é esta):

```csharp
// Em DbContexto.cs
protected override void OnModelCreating(ModelBuilder modelBuilder)
{
    // O hash abaixo é um exemplo. Use o que você gerou.
    var adminPasswordHash = "$2a$11$f5.y.gC3gSgSjZ.j.j.j.uO.j.j.j.j.j.j.j.j.j.j.j.j.j.j.j";

    modelBuilder.Entity<Administrator>().HasData(
        new Administrator(
            "c1b8e9a8-5b1a-4b1a-9b0a-0b9b8e9a8c1b",
            "heviane@gmail.com",
            adminPasswordHash, // <-- Use o hash aqui!
            "Admin"
        )
    );
}
```

Depois de fazer essa alteração, você precisará criar e aplicar uma nova migration para que o banco de dados reflita a mudança de nome da coluna (Password -> PasswordHash) e os novos dados.

## Passo 4: Atualizar a Lógica de Login

Finalmente, no seu ServiceAdministrator (ou onde quer que a lógica de login esteja, conforme o arquivo 2-app-with-database-and-login.md), você deve usar o método VerifyPassword que criamos.

```csharp
public Administrator? Login(LoginDTO loginDTO)
{
    // 1. Encontre o administrador pelo e-mail no banco de dados
    var administrator = _context.Administrators.FirstOrDefault(a => a.Email == loginDTO.Email);

    // 2. Se o administrador não for encontrado, retorne null
    if (administrator == null)
    {
        return null;
    }

    // 3. Verifique se a senha está correta usando BCrypt
    // ANTES: if (administrator.Password == loginDTO.Password)
    if (administrator.VerifyPassword(loginDTO.Password))
    {
        // Senha correta!
        return administrator;
    }

    // Senha incorreta
    return null;
}
```

> **PRONTO!** Com essas mudanças, sua aplicação agora armazena senhas de forma segura, seguindo as melhores práticas do mercado.
> **Próximo passo:** Como posso implementar a criação de um novo administrador, garantindo que a senha seja "hasheada" antes de salvar?
