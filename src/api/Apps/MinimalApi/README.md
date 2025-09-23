# MinimalApi API

<p align="center">
  <img src="https://img.shields.io/badge/.NET-9.0-blueviolet?style=for-the-badge&logo=.net" alt=".NET 9.0">
  <a href="CHANGELOG.md"><img src="https://img.shields.io/badge/Changelog-Keep%20a%20Changelog-blue?style=for-the-badge" alt="Changelog"></a>
  <img src="https://img.shields.io/badge/Template-Minimal_API-blue?style=for-the-badge&logo=c-sharp" alt="Minimal API">
  <img src="https://img.shields.io/badge/Docs-Swagger-green?style=for-the-badge&logo=swagger" alt="Swagger">
</p>

`MinimalApi` é um projeto de API RESTful simples, construído com .NET. Seu objetivo é servir como exemplo de uma API com funcionalidades básicas, como endpoints, manipulação de DTOs e acesso a dados com Entity Framework Core.

## ✨ Funcionalidades

- **Arquitetura**: API criada a partir do template **Minimal API** do **.NET**.
  - Estrutura do Projeto:
    - infrastructure: conexão com banco de dados, etc.
    - domain: regras de negócio, etc.
      - entities: 
- **Endpoints**: Inclui exemplos de `GET` e `POST` com um DTO (`LoginDTO`).
- **Documentação**: Geração automática de documentação interativa com **[Swagger (OpenAPI)](https://swagger.io/)**.
- **Acesso a Dados**: Utiliza **Entity Framework Core** com um provedor de banco de dados em memória para um exemplo de autenticação.

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
