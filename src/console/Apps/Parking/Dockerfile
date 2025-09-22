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
RUN dotnet publish "src/console/Apps/Parking/Parking.csproj" -c Release -o /app/publish

# Estágio 2: Final
# Usamos a imagem do Runtime, que é muito menor e contém apenas o necessário para executar a aplicação.
FROM mcr.microsoft.com/dotnet/runtime:9.0
WORKDIR /app

# Copia apenas os artefatos publicados do estágio de build para a imagem final.
COPY --from=build /app/publish .

# Define o ponto de entrada. Este é o comando que será executado quando o container iniciar.
ENTRYPOINT ["dotnet", "Parking.dll"]
