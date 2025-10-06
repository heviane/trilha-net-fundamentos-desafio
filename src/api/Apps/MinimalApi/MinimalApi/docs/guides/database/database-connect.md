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
# PASSO 1: Verifique se o container MySQL está rodando.
docker ps

# PASSO 2: Inicie o container MySQL se ele não estiver rodando.
  ## Iniciar o container MySQL pela primeira vez e configurar a variavel de ambiente para a senha root.
  docker run -d \
  -p 3306:3306 \
  --name mysql-dev \
  -e MYSQL_ROOT_PASSWORD='heviane' \
  mysql:latest

  ## Iniciar o container MySQL após a primeira vez (já configurado a variavel de ambiente para a senha root).
  docker run -d --name mysql-dev mysql 

# PASSO 3: Execute o cliente MySQL dentro do container.
  ## Neste caso, o terminal irá pedir a senha (A senha não será exibida enquanto você digita).
  docker exec -it mysql-dev mysql -u root -p

  ## Neste caso, use somente em ambiente de desenvolvimento.
  ## >> Este método não é recomendado porque sua senha fica registrada no histórico de comandos do terminal.
  docker exec -it mysql-dev mysql -u root -p'heviane'
```

- **`docker exec`**: Comando para executar algo dentro de um container.
- **`-it`**: Flags para modo interativo. Ele permite que você execute comandos dentro de um container em execução.

> **PRONTO!**
