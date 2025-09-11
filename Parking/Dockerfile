# Stage 1: Build - Usa a imagem completa do SDK para compilar a aplicação
FROM mcr.microsoft.com/dotnet/sdk:9.0-preview AS build
WORKDIR /source

# Copia o arquivo de projeto e restaura as dependências primeiro
# Isso aproveita o cache de camadas do Docker, acelerando builds futuros
COPY *.csproj .
RUN dotnet restore

# Copia o restante do código-fonte e publica a aplicação
COPY . .
RUN dotnet publish -c Release -o /app/publish

# Stage 2: Final - Usa a imagem leve de runtime para executar a aplicação
FROM mcr.microsoft.com/dotnet/runtime:9.0-preview
WORKDIR /app
COPY --from=build /app/publish .
ENTRYPOINT ["dotnet", "Parking.dll"]
