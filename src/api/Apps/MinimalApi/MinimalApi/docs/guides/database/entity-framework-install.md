# Instalação e Configurações do Entity Framework

...

## Instalar os Pacotes do Entity Framework

No terminal, na pasta raiz do repositório, execute os seguintes comandos para instalar os pacotes necessários:

```bash
dotnet add src/api/Apps/MinimalApi package Microsoft.EntityFrameworkCore
dotnet add src/api/Apps/MinimalApi package Microsoft.EntityFrameworkCore.Design
dotnet add src/api/Apps/MinimalApi package Pomelo.EntityFrameworkCore.MySql
```

## Instalar a Ferramenta de Linha de Comando do EF Core

Instale a ferramenta `dotnet-ef` globalmente. Você só precisa fazer isso uma vez na sua máquina.

```bash
dotnet tool install --global dotnet-ef
```

## Migrations

As migrations são uma maneira de aplicar mudanças incrementais ao esquema do banco de dados, mantendo os dados existentes intactos.

### Criar a Migração para o Banco de Dados

Execute o seguinte comando no terminal, na pasta raiz do seu repositório:

```bash
dotnet ef migrations add InitialCreate --project src/api/Apps/MinimalApi
```

O que este comando faz?

- `dotnet ef migrations add`: É o comando para criar uma nova migração.
- `InitialCreate`: É o nome que demos a esta primeira
- `--project src/api/Apps/MinimalApi`: Especifica qual projeto contém o DbContexto.

Após executar, você verá uma nova pasta **Migrations** dentro do projeto MinimalApi, contendo arquivos que descrevem como criar a tabela Administrators.

### Aplicar a Migração ao Banco de Dados

O último passo é executar o "plano" que acabamos de criar contra o seu banco de dados MySQL.

Execute este comando, também na pasta raiz do repositório:

```bash
dotnet ef database update --project src/api/Apps/MinimalApi
```

O que este comando faz?

- `dotnet ef database update`: Pega a última migração que ainda não foi aplicada e a executa no banco de dados configurado na sua **appsettings.json**.
- Após a execução, você pode verificar seu banco de dados MySQL. A tabela Administrators (e uma tabela de histórico de migrações chamada `__EFMigrationsHistory`) estarão lá!

> **PRONTO!** Migrations concluídas. Agora verifique o banco de dados [Guia para conectar-se ao Banco de dados](../database/connect-to-MySQL-database.md).
