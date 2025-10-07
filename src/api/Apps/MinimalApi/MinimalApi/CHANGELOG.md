# Changelog - MinimalApi

Todas as alterações notáveis a este projeto serão documentadas neste arquivo.

> O formato é baseado em [Keep a Changelog](https://keepachangelog.com/pt-BR/1.0.0/) e este projeto adere ao [Versionamento Semântico](https://semver.org/lang/pt-BR/).

---

## [0.1.0] - 2025-10-07

### Added

- **Arquitetura e Estrutura do Projeto**
  - Projeto criado com o template **.NET 9 Minimal API**.
  - Estrutura de pastas organizada para separar Domínio, Infraestrutura e Aplicação.
  - Adicionado suporte ao **Swagger (OpenAPI)** para documentação interativa da API.

- **Persistência de Dados com EF Core e MySQL**
  - **Docker**: Configurado `docker-compose.yml` para provisionar um banco de dados **MySQL 8.0**, garantindo um ambiente de desenvolvimento consistente e persistente.
  - **Entity Framework Core**:
    - Integrado o EF Core para mapeamento objeto-relacional (ORM).
    - Criada a entidade `Administrator` e o `DbContexto` para gerenciar a conexão com o banco.
  - **Migrations e Seed**:
    - Criada a migração inicial (`InitialCreate`) para gerar o schema do banco.
    - Implementado um **Seed** de dados (`HasData`) para popular a tabela `Administrators` com um usuário padrão.

- **Autenticação e Autorização**
  - **Endpoint de Login**: Implementado o endpoint `POST /login` para autenticar usuários.
  - **Camada de Serviço**: Criada a camada de serviço (`ServiceAdministrator`) para desacoplar a lógica de negócio dos endpoints.
  - **JWT (JSON Web Tokens)**: Adicionada geração de token JWT no login bem-sucedido, contendo claims de identificação.
  - **Autorização por Perfil (Role-based)**: Implementada autorização baseada em perfis (`Roles`) nos endpoints, utilizando o `ClaimTypes.Role` para controle de acesso granular (`Admin`, `User`).

- **Testes Automatizados**
  - **Projeto de Teste**: Criado o projeto `MinimalApiTest` com o framework **MSTest**.
  - **Testes de Unidade/Serviço**:
    - Implementados testes para a camada de serviço (`AdministratorServiceTest`).
    - Utilizado o provedor de banco de dados **em memória** do EF Core para testes rápidos e isolados.
  - **Testes de Integração/Persistência**:
    - Implementados testes (`AdministratorServiceTestDb`) que validam a integração com um banco de dados **MySQL real**, gerenciado pelo Docker.
    - Configurado `appsettings.testing.json` para gerenciar a string de conexão do ambiente de teste.
    - Implementado ciclo de vida de testes com `[TestInitialize]` e `[TestCleanup]` para garantir o isolamento (criação e destruição do banco a cada teste).
