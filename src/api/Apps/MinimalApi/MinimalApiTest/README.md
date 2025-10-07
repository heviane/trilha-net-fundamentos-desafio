# 🧪 MinimalApiTest

<p align="center">
  <a href="https://github.com/heviane/trilha-net-fundamentos-desafio/actions/workflows/dotnet-ci.yml"><img alt="Build Status" src="https://img.shields.io/github/actions/workflow/status/heviane/trilha-net-fundamentos-desafio/dotnet-ci.yml?branch=main&style=for-the-badge&label=CI"></a>
  <a href="../../../../.github/CONTRIBUTING.md"><img alt="Contributions Welcome" src="https://img.shields.io/badge/contributions-welcome-brightgreen.svg?style=for-the-badge"></a>
</p>

## 🎯 Sobre o Projeto

Este projeto contém todos os testes automatizados para a aplicação **MinimalApi**. Seu objetivo principal é garantir a qualidade, a corretude e a estabilidade da API, cobrindo as diferentes camadas da arquitetura com testes de unidade e de integração.

A estratégia de testes adotada visa validar tanto a lógica de negócio em isolamento quanto a integração real com a infraestrutura, como o banco de dados.

## 🛠️ Tecnologias e Ferramentas

- **[.NET 9](https://dotnet.microsoft.com/en-us/download)**: Plataforma de desenvolvimento.
- **[MSTest](https://learn.microsoft.com/pt-br/dotnet/core/testing/mstest-runner-intro)**: Framework para a escrita e execução dos testes.
- **[Entity Framework Core](https://learn.microsoft.com/pt-br/ef/core/)**: Utilizado para a interação com o banco de dados.
- **[MySQL (via Docker)](https://www.docker.com/products/docker-desktop/)**: Banco de dados real para os testes de integração.
- **[Docker Compose](https://docs.docker.com/compose/)**: Orquestração do ambiente de banco de dados.

---

## 🔬 Tipos de Testes

O projeto está organizado em dois tipos principais de testes:

### 1. Testes de Unidade / Serviço (Em Memória)

- **Localização**: `Domain/Services/AdministratorServiceTest.cs`
- **Objetivo**: Validar a lógica de negócio dos serviços de forma rápida e isolada.
- **Como funciona**: Utiliza o provedor de banco de dados em memória do Entity Framework Core (`UseInMemoryDatabase`) para simular o banco de dados, evitando a necessidade de uma infraestrutura externa.

### 2. Testes de Integração / Persistência

- **Localização**: `Domain/Services/AdministratorServiceTestDb.cs`
- **Objetivo**: Garantir que a aplicação se integra corretamente com o banco de dados MySQL. Valida o mapeamento de entidades, a execução de queries e a integridade dos dados.
- **Como funciona**: Conecta-se a uma instância real do MySQL, gerenciada pelo Docker, para simular o ambiente de produção.

---

## 🚀 Como Executar os Testes

Siga os passos abaixo para configurar o ambiente e rodar todos os testes.

### Pré-requisitos

- .NET SDK 9.0 ou superior.
- Docker e Docker Compose.

### 1. Iniciar o Ambiente de Banco de Dados

Os testes de integração dependem de um container Docker com o MySQL. Para iniciá-lo, navegue até a pasta do projeto `MinimalApi` e execute:

```bash
# A partir da pasta /src/api/Apps/MinimalApi/MinimalApi/
docker-compose up -d
```

Este comando irá iniciar o container `minimalapi-mysql` com as configurações definidas no `docker-compose.yml`.

### 2. Configurar a Conexão de Teste

O arquivo `appsettings.testing.json` neste projeto contém a string de conexão para o banco de dados de teste. Verifique se as credenciais correspondem às definidas no `docker-compose.yml`.

```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Server=localhost;Port=3306;Database=minimalapi_test_db;Uid=test_user;Pwd=test_password;"
  }
}
```

### 3. Executar os Testes

Com o ambiente Docker rodando, execute o seguinte comando na raiz do projeto `MinimalApiTest` ou na raiz do repositório:

```bash
dotnet test
```

Este comando irá compilar o projeto e executar todos os testes encontrados, exibindo um resumo dos resultados no final.
