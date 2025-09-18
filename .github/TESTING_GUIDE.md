# 🧪 Guia de Testes com xUnit e Coverlet


<p align="center">
  <img src="https://img.shields.io/badge/Framework-xUnit-blue?style=for-the-badge" alt="Framework xUnit">
  <img src="https://img.shields.io/badge/Coverage-Coverlet-blueviolet?style=for-the-badge" alt="Coverage with Coverlet">
</p>

Este documento é o guia central para a criação, configuração e execução de testes unitários neste repositório. O objetivo é garantir a qualidade e a consistência em todos os projetos de desafio.

## Filosofia de Testes

A qualidade do software é um pilar fundamental deste projeto. Para isso, adotamos as seguintes práticas:

1. **Isolamento**: Cada projeto de aplicação (ex: `SmartPhone`) deve ter seu próprio projeto de testes (ex: `SmartPhone.Tests`). Isso mantém o código de produção limpo e separado do código de teste.
2. **Testabilidade**: O código da aplicação deve ser escrito de forma a ser testável. Isso geralmente envolve a **Separação de Responsabilidades (SoC)**, onde a lógica de negócio é desacoplada da interface do usuário (como o `Console`).
3. **Padrão AAA**: Todos os testes devem seguir o padrão **Arrange-Act-Assert** para garantir clareza e manutenibilidade.

   - **Arrange**: Prepara o cenário. Criamos os objetos a serem testados e definimos as variáveis necessárias.
   - **Act**: Executa a ação. Chamamos o método que queremos testar.
   - **Assert**: Verifica o resultado. Usamos os métodos do xUnit (como `Assert.Equal`, `Assert.Throws`) para confirmar se o resultado foi o esperado.

> **Pronto!** Seu projeto de testes está concluído.
---

## 1. Criando e Configurando um Novo Projeto de Testes

A forma mais recomendada e padrão no ecossistema .NET é criar um projeto de testes separado dentro da sua solução. Isso mantém o código de teste isolado do código da sua aplicação, o que é uma excelente prática.

Ao adicionar um novo desafio (ex: `NewChallenge`), siga estes passos para configurar os testes:

### a. Criar o Projeto de Testes com xUnit

Use o CLI do .NET para criar um projeto de testes padrão.

```bash
# Cria uma nova pasta NewChallenge.Tests com um projeto xUnit
dotnet new xunit -n NewChallenge.Tests -o NewChallenge.Tests
```

### b. Vincular os Projetos à Solução

Adicione o novo projeto de testes à solução (`.sln`) e crie uma referência do projeto de testes para o projeto da aplicação.

```bash
# Adiciona o projeto de testes à solução
dotnet sln add NewChallenge.Tests/NewChallenge.Tests.csproj

# Adiciona a referência do projeto da aplicação ao projeto de testes
dotnet add NewChallenge.Tests/NewChallenge.Tests.csproj reference NewChallenge/NewChallenge.csproj
```

### c. Configurar Cobertura de Testes

Para medir a eficácia dos testes, configuramos o `Coverlet`.

```bash
# Navegue até a pasta do novo projeto de testes
cd NewChallenge.Tests

# Adicione o pacote do coletor de cobertura
dotnet add package coverlet.collector
```

Crie um arquivo `coveragesettings.runsettings` na raiz do projeto de testes (`NewChallenge.Tests/`) para excluir arquivos que não fazem parte da lógica de negócio (como `Program.cs`).

```xml
<!-- NewChallenge.Tests/coveragesettings.runsettings -->
<?xml version="1.0" encoding="utf-8" ?>
<RunSettings>
  <DataCollectionRunSettings>
    <DataCollectors>
      <DataCollector friendlyName="XPlat code coverage">
        <Configuration>
          <Format>cobertura</Format>
          <ExcludeByFile>**/Program.cs</ExcludeByFile>
        </Configuration>
      </DataCollector>
    </DataCollectors>
  </DataCollectionRunSettings>
</RunSettings>
```

Finalmente, crie um arquivo `.gitignore` para ignorar os artefatos de build e relatórios.

```gitignore
# NewChallenge.Tests/.gitignore
# Pastas de build do .NET
bin/
obj/

# Resultados de Testes e Cobertura
TestResults/
coveragereport/
```

> **Pronto!** Seu ambiente de testes está configurado e alinhado com os padrões do repositório.

---

## 2. Executando os Testes

Você pode executar os testes de um projeto específico ou de toda a solução.

### a. Execução Padrão

Navegue até a pasta do projeto de testes (ou a raiz da solução) e execute:

```bash
# Executa todos os testes encontrados
dotnet test
```

### b. Modo de Observação (Watch Mode)

Para uma experiência de desenvolvimento mais fluida, use o modo de observação. Ele executará os testes automaticamente sempre que uma alteração for salva.

```bash
# Navegue até a pasta do projeto de testes
cd NewChallenge.Tests
dotnet watch test
```

---

## 3. Gerando Relatórios de Cobertura

A análise de cobertura nos mostra quais partes do nosso código estão sendo exercitadas pelos testes.

### a. Instalar o Gerador de Relatórios (Uma única vez)

Instale o `ReportGenerator` como uma ferramenta global do .NET. Se você já o instalou antes, pode pular este passo.

```bash
dotnet tool install -g dotnet-reportgenerator-globaltool
```

### b. Gerar e Visualizar o Relatório

Para gerar o relatório, execute a sequência de comandos abaixo a partir da pasta do projeto de testes (ex: `SmartPhone.Tests/`).

1. **Execute os testes coletando dados de cobertura:**

    ```bash
    dotnet test --settings coveragesettings.runsettings --collect:"XPlat Code Coverage"
    ```

2. **Gere o relatório HTML:**

    ```bash
    reportgenerator -reports:"TestResults/**/coverage.cobertura.xml" -targetdir:"coveragereport" -reporttypes:Html
    ```

3. **Visualize o resultado:**
    Abra o arquivo `coveragereport/index.html` no seu navegador.

### c. Comando Completo (Limpar e Executar)

Para garantir um relatório limpo, use este comando único que limpa artefatos antigos, executa os testes e gera o novo relatório.

```bash
# Execute a partir da pasta do projeto de testes (ex: SmartPhone.Tests/)

# macOS / Linux
dotnet clean && rm -rf TestResults coveragereport && dotnet test --settings coveragesettings.runsettings --collect:"XPlat Code Coverage" && reportgenerator -reports:"TestResults/**/coverage.cobertura.xml" -targetdir:"coveragereport" -reporttypes:Html

# Windows (PowerShell)
dotnet clean; if (Test-Path -Path "TestResults") { Remove-Item -Recurse -Force "TestResults" }; if (Test-Path -Path "coveragereport") { Remove-Item -Recurse -Force "coveragereport" }; dotnet test --settings coveragesettings.runsettings --collect:"XPlat Code Coverage"; reportgenerator -reports:"TestResults/**/coverage.cobertura.xml" -targetdir:"coveragereport" -reporttypes:Html
```

> **Nota Importante**: As pastas `coveragereport/` e `TestResults/` são artefatos gerados e não devem ser enviadas para o repositório Git. O arquivo `.gitignore` local cuida disso.
