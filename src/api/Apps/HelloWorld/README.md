# HelloWorld API

<p align="center">
  <img src="https://img.shields.io/badge/.NET-9.0-blueviolet?style=for-the-badge&logo=.net" alt=".NET 9.0">
  <img src="https://img.shields.io/badge/Template-Minimal_API-blue?style=for-the-badge&logo=c-sharp" alt="Minimal API">
  <img src="https://img.shields.io/badge/Docs-Swagger-green?style=for-the-badge&logo=swagger" alt="Swagger">
</p>

`HelloWorld` é um projeto de API RESTful simples, construído com .NET e o template de Minimal API. Seu principal objetivo é servir como um exemplo base e validar a estrutura de automação e documentação para futuros projetos de API neste repositório.

## ✨ Funcionalidades

- **Arquitetura**: API criada a partir do template **Minimal API** do **.NET**.
- **Documentação**: Geração automática de documentação interativa com **[Swagger (OpenAPI)](https://swagger.io/)**.

---

## 🛠️ Pré-requisitos

Para clonar e executar este projeto localmente, você precisará ter as seguintes ferramentas instaladas:

- [.NET SDK 9.0](https://dotnet.microsoft.com/en-us/download)
- [Git](https://git-scm.com/)
- Um editor de código como [Visual Studio Code](https://code.visualstudio.com/) com a extensão C# Dev Kit.
- Adicionar pacote `dotnet add package Swashbuckle.AspNetCore` para uso do **[Swagger (OpenAPI)](https://swagger.io/)**.

---

## 🚀 Como Executar

1. **Clone o repositório**:

```bash
git clone https://github.com/heviane/trilha-net-fundamentos-desafio.git
cd trilha-net-fundamentos-desafio
```

2. **Navegue até a pasta do projeto**:

```bash
cd src/api/Apps/HelloWorld
```

3. **Execute a aplicação**:

```bash
dotnet run
# OU
dotnet watch run
```

A API estará disponível em `https://localhost:XXXX` ou `http://localhost:YYYY`. A documentação do Swagger estará em `.../swagger`.

## 🐛 Como Depurar (Debug)

Este projeto está pré-configurado para depuração no Visual Studio Code.

1. Abra a pasta do repositório no VS Code.
2. Abra qualquer arquivo do projeto `HelloWorld` (como `Program.cs`).
3. Pressione `F5` para iniciar a depuração. O VS Code usará a configuração de `launch.json` e abrirá o navegador na página do Swagger automaticamente.

## 🧪 Testes e 🐳 Docker

- Para informações sobre como adicionar e configurar testes unitários, consulte o **[Guia de Testes com xUnit e Coverlet](../../../../.github/TESTING_GUIDE.md)**.
- Para informações sobre como criar e executar a aplicação em um container, consulte o **[Guia de Conteinerização com Docker](../../../../.github/DOCKER_GUIDE.md)**.
