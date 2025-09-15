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

**Arquivo a ser modificado**: `Parking/Dockerfile`

```diff
--- a/Parking/Dockerfile
+++ b/Parking/Dockerfile
@@ -8,6 +8,8 @@
 COPY ["Booking.Tests/Booking.Tests.csproj", "Booking.Tests/"]
 COPY ["Parking/Parking.csproj", "Parking/"]
 COPY ["Parking.Tests/Parking.Tests.csproj", "Parking.Tests/"]
+COPY ["SmartPhone/SmartPhone.csproj", "SmartPhone/"]
+COPY ["SmartPhone.Tests/SmartPhone.Tests.csproj", "SmartPhone.Tests/"]
 
 # Restore dependencies for the entire solution
 RUN dotnet restore "trilha-net-fundamentos-desafio.sln"
```

#### b) Workflow de Release

Atualize o workflow `release-automation.yml` para que ele compile e anexe os executáveis do novo projeto às releases.

**Arquivo a ser modificado**: `.github/workflows/release-automation.yml`

```diff
--- a/.github/workflows/release-automation.yml
+++ b/.github/workflows/release-automation.yml
@@ -26,6 +26,10 @@
           dotnet publish ./Booking/Booking.csproj -c Release -r linux-x64 --self-contained true -o ./dist/Booking-linux-x64
           dotnet publish ./Booking/Booking.csproj -c Release -r win-x64 --self-contained true -o ./dist/Booking-win-x64
           dotnet publish ./Booking/Booking.csproj -c Release -r osx-x64 --self-contained true -o ./dist/Booking-osx-x64
+
+          dotnet publish ./SmartPhone/SmartPhone.csproj -c Release -r linux-x64 --self-contained true -o ./dist/SmartPhone-linux-x64
+          dotnet publish ./SmartPhone/SmartPhone.csproj -c Release -r win-x64 --self-contained true -o ./dist/SmartPhone-win-x64
+          dotnet publish ./SmartPhone/SmartPhone.csproj -c Release -r osx-x64 --self-contained true -o ./dist/SmartPhone-osx-x64
 
       - name: Package Artifacts
         run: |
@@ -34,6 +38,9 @@
           (cd dist/Booking-linux-x64 && zip -r ../../Booking-linux-x64.zip .)
           (cd dist/Booking-win-x64   && zip -r ../../Booking-win-x64.zip .)
           (cd dist/Booking-osx-x64   && zip -r ../../Booking-osx-x64.zip .)
+          (cd dist/SmartPhone-linux-x64 && zip -r ../../SmartPhone-linux-x64.zip .)
+          (cd dist/SmartPhone-win-x64   && zip -r ../../SmartPhone-win-x64.zip .)
+          (cd dist/SmartPhone-osx-x64   && zip -r ../../SmartPhone-osx-x64.zip .)
 
       - name: Get Release Notes from CHANGELOG
         id: get_release_notes
@@ -67,3 +74,6 @@
             Booking-linux-x64.zip
             Booking-win-x64.zip
             Booking-osx-x64.zip
+            SmartPhone-linux-x64.zip
+            SmartPhone-win-x64.zip
+            SmartPhone-osx-x64.zip
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
