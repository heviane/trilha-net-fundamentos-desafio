# Entity Framework: Migrations

As migrations são uma maneira de aplicar mudanças incrementais ao esquema do banco de dados, mantendo os dados existentes intactos.

## 1. Criar a Migration

```bash
# Na pasta raiz do repositório:
dotnet ef migrations add InitialCreate --project src/api/Apps/MinimalApi/MinimalApi

# Na pasta raiz do projeto:
dotnet ef migrations add InitialCreate
```

O que este comando faz?

- `dotnet ef migrations add`: É o comando para criar uma nova migração.
- `InitialCreate`: É o nome que demos a esta primeira
- `--project src/api/Apps/MinimalApi/MinimalApi`: Especifica qual projeto contém o DbContexto.

Após executar, você verá uma nova pasta **Migrations** dentro do projeto MinimalApi, contendo arquivos que descrevem como criar a tabela Administrators.

## 2. Aplicar a Migration

O último passo é executar o "plano" que acabamos de criar contra o seu banco de dados MySQL.

```bash
# Na pasta raiz do repositório:
dotnet ef database update --project src/api/Apps/MinimalApi/MinimalApi

# Na pasta raiz do projeto:
dotnet ef database update
```

O que este comando faz?

- `dotnet ef database update`: Pega a última migração que ainda não foi aplicada e a executa no banco de dados configurado na sua **appsettings.json**.
- Após a execução, você pode verificar seu banco de dados MySQL. As tabelas da sua aplicação (e uma tabela de histórico de migrações chamada `__EFMigrationsHistory`) estarão lá!

> **PRONTO!** Migrations concluídas. Agora verifique o banco de dados [Guia para conectar-se ao Banco de dados](../database/connect-to-MySQL-database.md).
> **OBS:** Se criar um novo container, ou um databse novo, deve-se aplicar as migrations novamente.
