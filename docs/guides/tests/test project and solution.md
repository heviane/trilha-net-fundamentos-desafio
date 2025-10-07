# Guia de Testes e Estrutura da Solução

## Passo 1: Criar uma Solução Dedicada

Para organizar o projeto e facilitar a adição de testes, criamos uma solução (`.sln`) específica para a `MinimalApi`.

```bash
dotnet new sln -h

# 1. Criar o arquivo de solução
dotnet new sln -n MinimalApi -o src/api/Apps/MinimalApi

# 2. Adicionar os projetos existentes à solução
dotnet sln src/api/Apps/MinimalApi/MinimalApi.sln add src/api/Apps/MinimalApi/MinimalApi/MinimalApi.csproj
```

## Passo 2: Criar o projeto de teste

O projeto de testes será criado em um diretório separado.

Dentro da Solução `/src/api/Apps/MinimalApi` execute os comandos:

```bash
# Visualizar todos os templates disponiveis
dotnet new list

# Criar o projeto de testes com o template "mstest"
dotnet new mstest -o MinimalApiTest

# Adicionar o projeto de testes à Solução
dotnet sln add MinimalApiTest/MinimalApiTest.csproj
```

Será adicionado ao projeto de testes uma referência ao projeto a ser testado:

Dentro do projeto de Testes `/src/api/Apps/MinimalApi/MinimalApiTest` execute os comandos:

```bash
# Adicionar a referencia ao projeto a ser testado no projeto de testes
dotnet add reference ../MinimalApi/MinimalApi.csproj
```

## Passo 3: Build

No diretório da solução:

```bash
# Build da aplicação completa
dotnet build
```

## Passo 4: Executar

No diretório do Projeto de Teste:

```bash
dotnet test
dotnet run test
```
