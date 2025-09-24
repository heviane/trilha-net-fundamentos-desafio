# Connect to MySQL Database

This guide will help you connect to a MySQL database, whether it's running locally on your machine or inside a Docker container.

## Local MySQL Instance

```bash
# Conecta usando a senha e seleciona o banco de dados
mysql -u root -p minimal_api_db
```

- **`-u`**: Significa usuário.
  - **root**: É o superusuário padrão do MySQL.
- **`-p`**: Significa senha.

## MySQL in Docker

```bash
# Verifique se o container MySQL está rodando
docker ps

# Execute o cliente MySQL dentro do container
# Neste caso, o terminal irá pedir a senha (A senha não será exibida enquanto você digita)
docker exec -it minimalapi-mysql mysql -u root -p

# Este método não é recomendado porque sua senha fica registrada no histórico de comandos do terminal.
# Use somente em ambiente de desenvolvimento
docker exec -it minimalapi-mysql mysql -u root -p'heviane'
```

- **`docker exec`**: Comando para executar algo dentro de um container.
- **`-it`**: Flags para modo interativo. Ele permite que você execute comandos dentro de um container em execução.

> **PRONTO!**
