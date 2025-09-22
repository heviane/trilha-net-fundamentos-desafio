# 🚀 Guia para Adicionar um Novo Desáfio

Este documento serve como um guia passo a passo para adicionar um novo projeto de desáfio a este repositório, garantindo que ele siga os padrões de qualidade e automação já estabelecidos.

## 🛠️ Pré-requisitos

Para clonar e executar este projeto localmente, você precisará ter as seguintes ferramentas instaladas em sua máquina:

- [.NET SDK](https://dotnet.microsoft.com/en-us/download): Essencial para compilar e executar a aplicação e os testes.
- [Git](https://git-scm.com/): Necessário para clonar o repositório.
- Familiaridade com a linha de comando.

  ### Recomendado

  - Um editor de código como o [Visual Studio Code](https://code.visualstudio.com/) com a extensão [C# Dev Kit](https://marketplace.visualstudio.com/items?itemName=ms-dotnettools.csdevkit).
  - Um gerenciador de containers como o [Docker](https://www.docker.com/products/docker-desktop/) para construir e executar a aplicação via container.

---

## SIGA O PASSO A PASSO ABAIXO:

### Preparação do Ambiente

#### 1. Criação da Estrutura do Projeto (Console Application):

Crie o projeto principal e seu respectivo projeto de testes, vinculando ambos à solução.

```bash
# 1. Crie o projeto principal na estrutura de pastas correta
dotnet new console -n NewChallenge -o src/console/Apps/NewChallenge

# 2. Crie o projeto de testes com xUnit
dotnet new xunit -n NewChallenge.Tests -o src/console/Apps/NewChallenge.Tests

# 3. Adicione ambos os projetos à solução (.sln)
dotnet sln add src/console/Apps/NewChallenge/NewChallenge.csproj
dotnet sln add src/console/Apps/NewChallenge.Tests/NewChallenge.Tests.csproj

# 4. Adicione a referência do projeto principal ao projeto de testes
dotnet add src/console/Apps/NewChallenge.Tests/NewChallenge.Tests.csproj reference src/console/Apps/NewChallenge/NewChallenge.csproj
```

#### 2. Implemente a Conteinerização com Docker:

Siga as instruções do [Guia de Conteinerização com Docker](./DOCKER_GUIDE.md) para criar o `Dockerfile` e o `.dockerignore` do novo projeto.

#### 3. Implemente Testes Unitários e Cobertura de Testes:

Configure o projeto de testes conforme o [Guia de Testes com xUnit e Coverlet.](./TESTING_GUIDE.md)

#### 4. Atualização dos Workflows de Automação:

Adicione o novo projeto ao workflow de release para que ele seja incluído nos artefatos de build.

- **Arquivo**: `.github/workflows/release-automation.yml`
- **Ação**: Adicione uma nova etapa de `build` e `package` para o seu `NewChallenge`, seguindo o padrão dos projetos existentes.

> **Pronto!** Seu ambiente está configurado.

---

### Desenvolvimento da Solução

Com a estrutura pronta, você pode focar no desenvolvimento da solução para o desafio.
Manter a documentação atualizada é fundamental para a clareza e a visibilidade do projeto.

> **DICA!**: Use as documentações dos projetos existentes como exemplo de templates!

1. **`README.md` (Raiz)**: Adicione o novo projeto à tabela de projetos e à seção de créditos.
2. **`CHANGELOG.md`**: Documente a adição do novo desafio na seção `[Unreleased]`.
3. **`NewChallenge/README.md`**: Crie um `README.md` detalhado para o novo projeto. Não se esqueça de incluir a seção "Nota sobre a Origem do Desafio" e links para os guias centralizados.

### Finalização do Desafio

Após concluir o desenvolvimento e os testes, crie uma nova release seguindo o [Guia de Criação de Releases.](./RELEASING_GUIDE.md)

---

Seguindo estes passos, você garante que cada novo desafio adicionado ao repositório mantenha o mesmo nível de qualidade e integração dos projetos existentes.
