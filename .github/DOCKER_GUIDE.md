# 🐳 Guia de Conteinerização com Docker

<p align="center">
  <img src="https://img.shields.io/badge/Docker-Build_&_Run-blue?style=for-the-badge&logo=docker" alt="Docker">
  <img src="https://img.shields.io/badge/.NET-SDK_&_Runtime-purple?style=for-the-badge&logo=dotnet" alt=".NET">
</p>

Este documento é o guia central para a containerização de aplicações .NET neste repositório. O objetivo é padronizar a forma como criamos e executamos nossos projetos em ambientes isolados e portáteis.

## Por que usamos Docker?

1. **Consistência**: Garante que a aplicação execute da mesma forma em qualquer ambiente (desenvolvimento, teste, produção), eliminando o clássico "mas na minha máquina funciona".
2. **Isolamento**: Cada aplicação roda em seu próprio container com suas dependências, sem interferir com outros projetos ou com o sistema operacional hospedeiro.
3. **Portabilidade**: Uma imagem Docker pode ser executada em qualquer sistema que tenha o Docker instalado, seja Windows, macOS ou Linux.

---

## Estrutura de um Projeto Containerizado

Cada projeto de aplicação (ex: `Parking/`) deve conter dois arquivos essenciais:

- `Dockerfile`: A "receita" que ensina o Docker a construir a imagem da nossa aplicação.
- `.dockerignore`: Similar ao `.gitignore`, instrui o Docker sobre quais arquivos e pastas ignorar durante o processo de build.

---

## Analisando o `Dockerfile`: O Padrão Multi-Stage Build

Nossos `Dockerfile`s utilizam uma técnica chamada **multi-stage build**. Isso nos permite usar uma imagem grande e cheia de ferramentas (o .NET SDK) para compilar a aplicação, e depois copiar apenas os arquivos necessários para uma imagem final muito menor (o .NET Runtime), otimizando o tamanho e a segurança.

Vamos analisar um `Dockerfile` típico para um projeto chamado `NewChallenge`:

```dockerfile
# Dockerfile para o projeto NewChallenge

# Estágio 1: Build
# Usamos a imagem do SDK do .NET, que contém todas as ferramentas para compilar o projeto.
FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
WORKDIR /source

# Copia todo o código-fonte para dentro do container.
# Esta abordagem foi escolhida pela simplicidade de manutenção. Em vez de listar
# cada arquivo .csproj, copiamos todo o contexto.
COPY . .

# Restaura as dependências e publica a aplicação em modo Release.
# A saída é direcionada para a pasta /app/publish.
RUN dotnet publish "src/console/Apps/NewChallenge/NewChallenge.csproj" -c Release -o /app/publish

# Estágio 2: Final
# Usamos a imagem do Runtime, que é muito menor e contém apenas o necessário para executar a aplicação.
FROM mcr.microsoft.com/dotnet/runtime:9.0
WORKDIR /app

# Copia apenas os artefatos publicados do estágio de build para a imagem final.
COPY --from=build /app/publish .

# Define o ponto de entrada. Este é o comando que será executado quando o container iniciar.
ENTRYPOINT ["dotnet", "NewChallenge.dll"]
```

### Analisando o `.dockerignore`

Este arquivo é crucial para otimizar o tempo de build e manter a imagem limpa. Ele evita que arquivos desnecessários (como pastas `bin`/`obj`, arquivos de configuração local e o próprio Git) sejam copiados para o contexto de build do Docker.

```gitignore
# .dockerignore

# Pastas de build e cache
bin/
obj/

# Arquivos de configuração de IDE e sistema
.vs/
.idea/
.DS_Store

# Controle de versão
.git/
.gitignore

# Documentação
*.md
```

---

## Como Containerizar um Novo Desafio

1. Crie um arquivo `Dockerfile` na raiz do novo projeto (ex: `NewChallenge/Dockerfile`) e use o template acima, substituindo `NewChallenge` pelo nome do seu projeto.
2. Crie um arquivo `.dockerignore` na mesma pasta e use o template acima.

---

## Comandos Essenciais

**Importante**: Execute sempre os comandos a partir da **pasta raiz do repositório**, pois nossos `Dockerfile`s esperam ter acesso a toda a solução.

### Construir a Imagem

```bash
# docker build -t <nome-da-imagem> -f <caminho-para-o-dockerfile> .
docker build -t newchallenge-app -f src/console/Apps/NewChallenge/Dockerfile .
```

### Executar o Container

Para aplicações de console, é essencial usar as flags `-it` (interativo) e `--rm` (remove o container após o uso).

```bash
docker run -it --rm newchallenge-app
```
