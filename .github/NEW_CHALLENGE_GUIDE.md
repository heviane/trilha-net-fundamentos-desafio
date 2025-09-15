# 🚀 Guia para Adicionar um Novo Desafio

Este documento serve como um guia passo a passo para adicionar um novo projeto de desafio a este repositório, garantindo que ele siga os padrões de qualidade e automação já estabelecidos.

## Pré-requisitos

- [.NET SDK](https://dotnet.microsoft.com/en-us/download) instalado.
- Familiaridade com a linha de comando.

---

## Passo a Passo

Vamos usar como exemplo a adição do desafio `SmartPhone`, que já está no radar do projeto.

### 1. Criação da Estrutura do Projeto

Primeiro, crie os projetos de console e de testes (xUnit) e adicione-os à solução para garantir que tudo esteja corretamente vinculado.

```bash
# 1. Crie o projeto principal (aplicação de console)
dotnet new console -n SmartPhone -o SmartPhone

# 2. Crie o projeto de testes
dotnet new xunit -n SmartPhone.Tests -o SmartPhone.Tests

# 3. Adicione ambos os projetos à solução (.sln)
dotnet sln add SmartPhone/SmartPhone.csproj
dotnet sln add SmartPhone.Tests/SmartPhone.Tests.csproj

# 4. Adicione a referência do projeto principal ao projeto de testes
dotnet add SmartPhone.Tests/SmartPhone.Tests.csproj reference SmartPhone/SmartPhone.csproj
```

### 2. Atualização das Automações (CI/CD)

Para que o novo projeto seja incluído nos processos de CI/CD, é crucial atualizar os arquivos de automação.

#### a) Dockerfile

Adicione os novos arquivos `.csproj` ao `Dockerfile` para que a imagem possa ser construída corretamente.

**Arquivo a ser incluido**: `Dockerfile`

```dockerfile
# Stage 1: Build
# Use the .NET SDK image to build the application
FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
WORKDIR /src

# Copy solution and project files to restore dependencies
# Copying them separately leverages Docker's layer caching.
# The build context is expected to be the repository root.
COPY ["trilha-net-fundamentos-desafio.sln", "."]
COPY ["SmartPhone/SmartPhone.csproj", "SmartPhone/"]
COPY ["SmartPhone.Tests/SmartPhone.Tests.csproj", "SmartPhone.Tests/"]

# Restore dependencies for the entire solution
RUN dotnet restore "trilha-net-fundamentos-desafio.sln"

# Copy the rest of the source code into the container
COPY . .

# Set the working directory to the project folder and publish
WORKDIR "/src/SmartPhone"
RUN dotnet publish "SmartPhone.csproj" -c Release -o /app/publish --no-restore

# Stage 2: Run
# Use the .NET runtime image for the final, smaller image
FROM mcr.microsoft.com/dotnet/runtime:9.0
WORKDIR /app
COPY --from=build /app/publish .
ENTRYPOINT ["dotnet", "SmartPhone.dll"]
```

#### b) Workflow de Release

Atualize o workflow `release-automation.yml` para que ele compile e anexe os executáveis do novo projeto às releases.

**Arquivo a ser modificado**: `.github/workflows/release-automation.yml`

```yaml
      - name: Build and Publish
        run: |
          # Publish self-contained executables for Linux, Windows, and macOS
          dotnet publish ./SmartPhone/SmartPhone.csproj -c Release -r linux-x64 --self-contained true -o ./dist/SmartPhone-linux-x64
          dotnet publish ./SmartPhone/SmartPhone.csproj -c Release -r win-x64 --self-contained true -o ./dist/SmartPhone-win-x64
          dotnet publish ./SmartPhone/SmartPhone.csproj -c Release -r osx-x64 --self-contained true -o ./dist/SmartPhone-osx-x64
 
      - name: Package Artifacts
        run: |

          (cd dist/SmartPhone-linux-x64 && zip -r ../../SmartPhone-linux-x64.zip .)
          (cd dist/SmartPhone-win-x64   && zip -r ../../SmartPhone-win-x64.zip .)
          (cd dist/SmartPhone-osx-x64   && zip -r ../../SmartPhone-osx-x64.zip .)
          
      - name: Create GitHub Release
        uses: softprops/action-gh-release@v2
        with:
          tag_name: ${{ github.ref_name }}
          name: ${{ github.ref_name }}
          body: ${{ steps.get_release_notes.outputs.notes }}
          prerelease: false
          files: |
             SmartPhone-linux-x64.zip
             SmartPhone-win-x64.zip
             SmartPhone-osx-x64.zip
```

### 3. Atualização da Documentação

Manter a documentação atualizada é fundamental para a clareza do projeto.

1. **README Principal**: Adicione o novo projeto à tabela de projetos e à seção de créditos no `README.md` principal.
2. **README do Projeto**: Crie um arquivo `README.md` dentro da pasta `SmartPhone/`. Use o `Parking/README.md` ou `Booking/README.md` como um template para manter a consistência. Não se esqueça de incluir a seção "Nota sobre a Origem do Desafio".

### 4. Desenvolvimento e Finalização

Com a estrutura pronta, você pode focar no desenvolvimento da solução para o desafio.

Após concluir o desenvolvimento e os testes:

1. **Atualize o `CHANGELOG.md`**: Documente a adição do novo projeto na seção `[Unreleased]`.
2. **Crie uma Nova Release**: Siga o processo de criar uma nova tag (ex: `v1.4.0`) para disparar o workflow de release, que irá publicar a nova versão com os artefatos do projeto `SmartPhone` incluídos.

---

Seguindo estes passos, você garante que cada novo desafio adicionado ao repositório mantenha o mesmo nível de qualidade e integração dos projetos existentes.
