# NuGet

## Listar Pacotes Nuget do Projeto

Execute este comando no diretório que contém o arquivo `.csproj` do seu projeto:

```bash
# Sempre execute estes comandos antes de consultar as dependencias instaladas no projeto
dotnet clean
dotnet restore

# Lista as dependencias instaladas no projeto
dotnet list package

# Lista as dependencias instaladas no projeto, incluindo as transitivas (pacotes que seus pacotes instalados exigem)
dotnet list package --include-transitive
```

## Listar Pacotes Nuget da Solution `.sln`

Se você tiver uma solução com múltiplos projetos e quiser listar os pacotes de todos eles.
Execute este comando no diretório raiz da solução que contém o arquivo `.sln`:

```Bash
dotnet sln NOME_DA_SUA_SOLUCAO.sln list package
```

## Arquivo **`project.assets.json`**

Fica na pasta `obj/` do seu projeto e é gerado pelo NuGet após o comando `dotnet restore`.
Ele mapeia todas as dependências diretas e transitivas para que o compilador e as ferramentas saibam quais DLLs usar.
