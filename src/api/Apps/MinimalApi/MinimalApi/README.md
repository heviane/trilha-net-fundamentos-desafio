# MinimalApi API

<p align="center">
  <a href="https://github.com/heviane/trilha-net-fundamentos-desafio/actions/workflows/dotnet-ci.yml"><img alt="Build Status" src="https://img.shields.io/github/actions/workflow/status/heviane/trilha-net-fundamentos-desafio/dotnet-ci.yml?branch=main&style=for-the-badge&label=CI"></a>
  <img src="https://img.shields.io/badge/.NET-9.0-blueviolet?style=for-the-badge&logo=.net" alt=".NET 9.0">
  <a href="CHANGELOG.md"><img src="https://img.shields.io/badge/Changelog-Keep%20a%20Changelog-blue?style=for-the-badge" alt="Changelog"></a>
  <img src="https://img.shields.io/badge/Docs-Swagger-green?style=for-the-badge&logo=swagger" alt="Swagger">
</p>

`MinimalApi` é um projeto de API RESTful construído com **.NET 9**, demonstrando uma arquitetura limpa com funcionalidades essenciais como autenticação JWT, autorização baseada em perfis (`Roles`) e persistência de dados com **Entity Framework Core** e **MySQL**.

## ✨ Funcionalidades

- **Arquitetura**: API criada com o template **Minimal API**, organizada em camadas (Domínio, Infraestrutura, Aplicação) para separação de responsabilidades.
- **Autenticação e Autorização**:
  - Endpoint `POST /login` para autenticação de usuários.
  - Geração de **Tokens JWT** para acesso seguro aos endpoints.
  - Controle de acesso granular baseado em perfis (`Roles`) como `Admin` e `User`.
- **Documentação**: Geração automática de documentação interativa com **[Swagger (OpenAPI)](https://swagger.io/)**.
- **Persistência de Dados**:
  - Utiliza **Entity Framework Core** para mapeamento objeto-relacional.
  - Integração com banco de dados **MySQL 8.0**, gerenciado por **Docker Compose**.
  - Migrations e Seed de dados para inicialização do banco.

---

## 🛠️ Pré-requisitos

Para clonar e executar este projeto localmente, você precisará ter as seguintes ferramentas instaladas:

- [.NET SDK 9.0](https://dotnet.microsoft.com/en-us/download)
- [Git](https://git-scm.com/)
- Um editor de código como [Visual Studio Code](https://code.visualstudio.com/) com a extensão C# Dev Kit.

---

## 🚀 Como Executar

1. **Clone o repositório**:

```bash
# Clone o repositório
git clone https://github.com/heviane/trilha-net-fundamentos-desafio.git
# Navegue até a pasta do projeto
cd trilha-net-fundamentos-desafio/src/api/Apps/MinimalApi
```

1. **Instale as dependências:**:

```bash
dotnet restore
```

3. **Execute a aplicação**:

```bash
dotnet run
# OU
dotnet watch run
```

A API estará disponível em `https://localhost:XXXX` ou `http://localhost:YYYY`. A documentação do Swagger estará em `.../swagger`.

## 🐛 Como Depurar (Debug)

Este projeto está pré-configurado para depuração no Visual Studio Code. Pressione `F5` para iniciar a depuração, e o navegador abrirá automaticamente na página do Swagger.

---

## 🧪 Testes e 🐳 Docker

- Para informações sobre como adicionar e configurar testes unitários, consulte o **[Guia de Testes com xUnit e Coverlet](../../../../.github/TESTING_GUIDE.md)**.
- Para informações sobre como criar e executar a aplicação em um container, consulte o **[Guia de Conteinerização com Docker](../../../../.github/DOCKER_GUIDE.md)**.

---

### 🔭 Funcionalidades em análise para futuras implementações

Além dos padrões de qualidade, as seguintes funcionalidades estão no radar para serem exploradas em projetos futuros ou como evoluções dos desafios atuais:

- [ ] Garantir que a senha do Administrator seja armazenada de forma segura no banco de dados, em vez de texto puro.
- [ ] Desacoplar as classes de serviço do DbContext usando o padrão de repositório.
- [ ] Criar endpoint para cadastrar uma lista de veículos.
- [ ] Ajustar o endpoint getAll para retornar a qtde total de veiculos, qtde total de páginas.
