# Configurar o Banco de Dados

This guide will help you connect to a MySQL database, whether it's running locally on your machine or inside a Docker container.

## Configure the Connection String

In your `appsettings.json` file, set the connection string to point to your MySQL database.

- **Local MySQL Instance** OR **MySQL in Docker**:

```json
"ConnectionStrings": {
    "DefaultConnection": "Server=localhost;Database=minimal_api_db;User=root;Password=your_password;"
}
```

> **Se estiver usando Docker**: Crie e configure seu arquivo `docker-compose.yml`.
> **PRONTO!**
