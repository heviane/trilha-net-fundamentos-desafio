# Configure Database with Docker

Você combina o melhor dos dois mundos:

- Não instala nada permanentemente na sua máquina, mantendo-a limpa.
- Usa um banco de dados real e persistente, o que significa que seus dados não serão perdidos quando a API reiniciar.
- O ambiente fica muito mais próximo de produção, o que é uma ótima prática.

Vamos fazer isso usando o docker-compose, que é a ferramenta ideal para gerenciar um ou mais containers (como nossa API e o banco de dados) de forma simples.

## Criação do Arquivo `docker-compose.yml`

No diretório do projeto, crie um novo arquivo chamado `docker-compose.yml` com o seguinte conteúdo.

```yml
services:
  # Define o serviço do banco de dados MySQL
  mysql_db:
    image: mysql:8.0 # Fixa a versão para evitar upgrades inesperados
    container_name: minimalapi-mysql
    restart: unless-stopped
    environment:
      MYSQL_ROOT_PASSWORD: "admin" # Senha para o superusuário root
      MYSQL_DATABASE: "minimalapi_test_db" # Cria este banco de dados na inicialização
      MYSQL_USER: "test_user" # Cria este usuário para os testes
      MYSQL_PASSWORD: "test_password" # Define a senha para o novo usuário
    ports:
      - "3306:3306" # Mapeia a porta do container para a sua máquina
    volumes:
      - mysql_data:/var/lib/mysql # Garante que os dados sejam persistidos

volumes:
  mysql_data:
```

O que este arquivo faz?

- Define um serviço chamado `mysql_db` usando a imagem oficial do **MySQL 8.0**.
- Configura as variáveis de ambiente com a senha (heviane) e o nome do banco de dados (minimal_api_db) que você já tem no seu `appsettings.json`.
- Expõe a porta 3306 do container na porta 3306 da sua máquina (localhost), permitindo que sua API se conecte.
- Cria um "volume" chamado `mysql_data` para que os dados do banco de dados sejam salvos em disco e não se percam se o container for parado.

## Como executar

```bash
docker-compose up -d
```
