# Changelog

Todas as alterações notáveis a este projeto serão documentadas neste arquivo.

> O formato é baseado em [Keep a Changelog](https://keepachangelog.com/pt-BR/1.0.0/) e este projeto adere ao [Versionamento Semântico](https://semver.org/lang/pt-BR/).

---

## [Unreleased]

### Added

- **Estrutura de Projeto e Testes**:
  - Criada uma solução (`.sln`) dedicada para a `MinimalApi` para isolar seus projetos (API, Domain, Infrastructure).
  - Adicionado um projeto de testes (`MinimalApi.Tests`) utilizando o template `mstest`, configurado para testar a aplicação.
  - Implementados testes de unidade para a entidade `Administrator`, validando a criação e o estado inicial do objeto.
  - Implementado teste de serviço para `ServiceAdministrator`, validando a funcionalidade de criação de um administrador em um banco de dados em memória.

- **Projeto e Estrutura Inicial**:
  - Criado novo projeto de API RESTful com o template **Minimal API** do **.NET 9**.
  - Adicionado endpoint `GET /` para verificação inicial da API.
  - Integrado **Swagger (OpenAPI)** para geração de documentação interativa.
  - Configurado o `launch.json` do VS Code para iniciar o Swagger automaticamente durante a depuração.

- **Persistência de Dados com EF Core e MySQL**:
  - **Docker**: Adicionado `docker-compose.yml` para provisionar um banco de dados **MySQL 8.0** em um container, com volumes para persistência de dados.
  - **Entity Framework Core**:
    - Configurado o EF Core para acesso a dados, incluindo a string de conexão no `appsettings.json`.
    - Criada a entidade `Administrator` para representar o usuário e o `DbContexto` para gerenciar a sessão com o banco.
  - **Migrations e Seed**:
    - Utilizada a ferramenta `dotnet-ef` para criar uma migração que gera a tabela `Administrators` no banco de dados.
    - Implementado um **Seed** de dados (`HasData`) para popular a tabela com um usuário administrador padrão na primeira migração.

- **Funcionalidade de Autenticação**:
  - **Camada de Serviço**: Criada a interface `IServiceAdministrator` e a implementação `ServiceAdministrator` para desacoplar a lógica de negócio do endpoint.
  - **Endpoint de Login**: Implementado o endpoint `POST /login` que recebe um `LoginDTO` e utiliza a camada de serviço para autenticar as credenciais do administrador contra o banco de dados.
  
- **Autorização por Perfil (Role-based)**:
  - Adicionada autorização baseada em perfis (`Roles`) nos endpoints.
  - Incluído o `ClaimTypes.Role` no token JWT para diferenciar os acessos de `Admin` e `User`, permitindo um controle de acesso granular.
