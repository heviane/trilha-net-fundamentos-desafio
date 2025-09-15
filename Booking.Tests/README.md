# Projeto de Testes para Sistema de Hospedagem

<p align="center">
  <img src="https://img.shields.io/badge/Testes-Passing-brightgreen?style=for-the-badge" alt="Testes Passando">
  <img src="https://img.shields.io/badge/Framework-xUnit-blue?style=for-the-badge" alt="Framework xUnit">
</p>

Este projeto contém os testes unitários para a aplicação `Booking`. O objetivo é garantir a qualidade e a robustez da lógica de negócio, validando as regras implementadas na classe `Reserva`.

A forma mais recomendada e padrão no ecossistema .NET é criar um projeto de testes separado dentro da sua solução. Isso mantém o código de teste isolado do código da sua aplicação, o que é uma excelente prática.

## Passo a passo para implementar testes

1. **Garantir a testabilidade do código**, se houver necessidade.
   - A melhor prática é separar as responsabilidades, ou seja, separar a lógica de negócio das interações do usuário.
   - Essa separação de conceitos (SoC) é um pilar da boa arquitetura de software e torna o código não só testável, mas também mais fácil de manter e reutilizar no futuro.
2. **Criar o projeto de testes** com o framework **xUnit**, um dos mais modernos e populares para .NET.
3. **Escrever os testes** unitários seguindo o padrão **"Arrange-Act-Assert"**.
4. **Executar os testes** de forma única ou em modo de observação (Watch Mode).

### 1. Garantir a testabilidade do código

A classe `Reserva.cs` já foi projetada com a separação de responsabilidades em mente, tornando-a diretamente testável sem a necessidade de refatoração.

### 2. Criar o projeto de testes

- Criar o projeto de testes com o framework **xUnit**:

```bash
# Isso cria uma nova pasta Booking.Tests com um projeto de testes já configurado.
dotnet new xunit -n Booking.Tests -o Booking.Tests
```

- Adicionar os projetos à solução:

```bash
dotnet sln add Booking/Booking.csproj
dotnet sln add Booking.Tests/Booking.Tests.csproj
```

- Adicionar referência do projeto principal no projeto de testes:
O projeto de testes precisa "conhecer" o código da sua aplicação para poder testá-lo.

```bash
dotnet add Booking.Tests/Booking.Tests.csproj reference Booking/Booking.csproj
```

> **Pronto!** Seu ambiente está configurado.

### 3. Escrever os testes

Foi criada uma classe de testes `Booking.Tests/ReservaTests.cs` para a classe `Booking/Models/Reserva.cs`.

Cada teste segue o padrão Arrange, Act, Assert:

- **Arrange**: Prepara o cenário. Criamos os objetos a serem testados (`Reserva`, `Suite`, `Pessoa`) e definimos as variáveis necessárias.
- **Act**: Executa a ação. Chamamos o método que queremos testar (ex: `CadastrarHospedes`, `CalcularValorDiaria`).
- **Assert**: Verifica o resultado. Usamos os métodos do xUnit (como `Assert.Equal`, `Assert.Throws`) para confirmar se o resultado foi o esperado.

> **Pronto!** Seu projeto de testes está concluído.

### 4. Como Executar os Testes 🚀

Navegue até a pasta raiz da solução (`trilha-net-fundamentos-desafio`) ou para a pasta deste projeto (`Booking.Tests`) e execute um dos seguintes comandos:

#### Execução Única

Para compilar o projeto e rodar todos os testes uma vez:

```bash
dotnet test
```

#### Execução em Modo de Observação (Watch Mode)

Para uma experiência de desenvolvimento mais fluida, você pode rodar os testes em "modo de observação". Eles serão executados automaticamente sempre que uma alteração for salva no código-fonte ou nos testes.

```bash
dotnet watch test
```

#### Saída Esperada

A saída esperada é um resumo indicando que todos os testes passaram. O número total de testes pode variar dependendo dos casos de teste (`[InlineData]`) definidos.

```plaintext
Passed!  - Failed:     0, Passed:     7, Skipped:     0, Total:     7
```
