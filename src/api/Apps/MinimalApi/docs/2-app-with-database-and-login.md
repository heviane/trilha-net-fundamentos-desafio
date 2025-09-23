# Nova versão da App com Banco de Dados

## Passo 1: Implementação da Arquitetura para trabalhar com o Banco de Dados

Agora que você tem uma API funcional, o próximo passo é preparar a arquitetura para conectar um banco de dados real.

### O que foi feito até agora?

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
Isso tornará sua API funcional e muito mais próxima de uma aplicação real.

> **Prompt:** Como eu crio e aplico uma "migration" do Entity Framework para criar a tabela Administrators no banco de dados?

## Passo 2: Preparação do Banco de Dados

### 1: Instalar a Ferramenta de Linha de Comando do EF Core

Instale a ferramenta `dotnet-ef` globalmente. Você só precisa fazer isso uma vez na sua máquina.

```bash
dotnet tool install --global dotnet-ef
```

### 2: Criar a Migração

Agora, vamos pedir ao `EF Core` para comparar sua entidade `Administrator` com o banco de dados (que ainda não tem a tabela) e gerar o código C# necessário para criá-la.

Execute o seguinte comando no terminal, na pasta raiz do seu repositório:

```bash
dotnet ef migrations add InitialCreate --project src/api/Apps/MinimalApi
```

O que este comando faz?

- `dotnet ef migrations add`: É o comando para criar uma nova migração.
- `InitialCreate`: É o nome que demos a esta primeira migração.
- `--project src/api/Apps/MinimalApi`: Especifica qual projeto contém o DbContexto.
Após executar, você verá uma nova pasta **Migrations** dentro do projeto MinimalApi, contendo arquivos que descrevem como criar a tabela Administrators.

### 3: Aplicar a Migração ao Banco de Dados

O último passo é executar o "plano" que acabamos de criar contra o seu banco de dados MySQL.

Execute este comando, também na pasta raiz do repositório:

```bash
dotnet ef database update --project src/api/Apps/MinimalApi
```

O que este comando faz?

- `dotnet ef database update`: Pega a última migração que ainda não foi aplicada e a executa no banco de dados configurado na sua **appsettings.json**.

Após a execução, você pode verificar seu banco de dados MySQL. A tabela Administrators (e uma tabela de histórico de migrações chamada `__EFMigrationsHistory`) estarão lá!

> **PRONTO!** Sua API agora está pronta para ler e escrever na tabela Administrators.

### 4. Verificar o MySQL

Para verificar se a tabela foi criada, você pode se conectar ao cliente MySQL:

#### Conectar-se ao MySQL local

```bash
# Conecta usando a senha e seleciona o banco de dados
mysql -u root -p minimal_api_db
```

- **`-u`**: Significa usuário.
  - **root**: É o superusuário padrão do MySQL.
- **`-p`**: Significa senha.

> O erro **`zsh: command not found: mysql`** significa que o comando mysql não está disponível no seu terminal. Isso é esperado, quando o servidor MySQL estiver rodando dentro de um container Docker, e não diretamente na sua máquina.

#### Conectar-se ao MySQL no Docker

Para interagir com o MySQL que está dentro do container, você precisa usar o comando `docker exec`. Ele permite que você execute comandos dentro de um container em execução.

1. Verifique se o container MySQL está rodando: Você pode confirmar se o container está ativo com:

```bash
docker ps
```

Procure por um container com o nome **`minimalapi-mysql`** (definido no seu `docker-compose.yml`).

2. Execute o cliente MySQL dentro do container: Use o comando `docker exec` para iniciar o cliente mysql dentro do container.

```bash
docker exec -it minimalapi-mysql mysql -u root -p

# Este método não é recomendado porque sua senha fica registrada no histórico de comandos do terminal.
docker exec -it minimalapi-mysql mysql -u root -p'senha'
```

Vamos entender este comando:

- `docker exec`: Comando para executar algo dentro de um container.
- `-it`: Flags para modo interativo (-i) e alocar um pseudo-TTY (-t), o que permite que você digite comandos no console do MySQL.
- `minimalapi-mysql`: É o nome do seu container MySQL, conforme definido no docker-compose.yml.
- `mysql -u root -p`: Este é o comando que será executado dentro do container.
  - `mysql`: O cliente MySQL.
  - `-u root`: Conecta como o usuário root.
  - `-p`: Solicita a senha de forma interativa.

3. Digite a senha: Após executar o comando acima, o terminal irá pedir a senha:

```plaintext
Enter password:
```

Digite a senha que você configurou no docker-compose.yml e pressione Enter. A senha não será exibida enquanto você digita.

4. Interaja com o MySQL: Se a senha estiver correta, você estará conectado ao prompt do MySQL:

```plaintext
mysql>
```

#### Comandos SQL

Uma vez dentro do console do MySQL, execute os seguintes comandos SQL:

```sql
USE minimal_api_db;
SHOW TABLES;
desc Administrators;
exit;
```

> **PRONTO!**: Você deverá ver a tabela **Administrators** e **__EFMigrationsHistory** listadas.

### 5. Criar um Seed para cadastrar um administrador padrão inicial

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

> **PRONTO!**: Verifique no banco de dados, o usuário admin já estará criado.
> **OBS**: Os comandos acima servem para mySQL local ou docker.

### 6. Alterar o endpoint /login para trabalhar com os dados do banco de dados

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
