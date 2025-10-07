# Executar a App Localmente

## 1. Banco de dados com Docker

Com o docker engine em execução, abra o terminal no diretório do projeto e execute:

```bash
# inicializar o container do banco de dados
docker-compose up -d
# verificar se o container está rodando
docker ps
```

## 2. Executar a App

```bash
dotnet run
```
