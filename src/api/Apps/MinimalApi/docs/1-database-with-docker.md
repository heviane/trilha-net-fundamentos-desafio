# database with docker

Usar um container Docker para o MySQL é a solução perfeita. 
Você combina o melhor dos dois mundos:

- Não instala nada permanentemente na sua máquina, mantendo-a limpa.
- Usa um banco de dados real e persistente, o que significa que seus dados não serão perdidos quando a API reiniciar.
- O ambiente fica muito mais próximo de produção, o que é uma ótima prática.
Vamos fazer isso usando o docker-compose, que é a ferramenta ideal para gerenciar um ou mais containers (como nossa API e o banco de dados) de forma simples.

## Passo 1: Criar o Arquivo `docker-compose.yml`

No diretório do projeto, crie um novo arquivo chamado `docker-compose.yml` com o seguinte conteúdo.

```yml
version: '3.8'

services:
  # Define o serviço do banco de dados MySQL
  mysql_db:
    image: mysql:8.0
    container_name: minimalapi-mysql
    restart: unless-stopped
    environment:
      MYSQL_ROOT_PASSWORD: heviane # A senha que você definiu no appsettings
      MYSQL_DATABASE: minimal_api_db # O nome do banco de dados
    ports:
      - "3306:3306" # Mapeia a porta do container para a sua máquina
    volumes:
      - mysql_data:/var/lib/mysql # Garante que os dados sejam persistidos

volumes:
  mysql_data:
```

O que este arquivo faz?

- Define um serviço chamado mysql_db usando a imagem oficial do MySQL 8.0.
- Configura as variáveis de ambiente com a senha (heviane) e o nome do banco de dados (minimal_api_db) que você já tem no seu appsettings.json.
- Expõe a porta 3306 do container na porta 3306 da sua máquina (localhost), permitindo que sua API se conecte.
- Cria um "volume" chamado mysql_data para que os dados do banco de dados sejam salvos em disco e não se percam se o container for parado.

## Passo 2: Iniciar o Banco de Dados

Com o Docker Desktop em execução, abra o terminal no diretório do projeto e execute:

```bash
docker-compose up -d
```

O que este comando faz?

- **`up`**: Cria e inicia os serviços definidos no arquivo.
- **`-d`**: (detached) Roda os containers em segundo plano.

Seu banco de dados MySQL agora está rodando em um container! Você pode pará-lo a qualquer momento com docker-compose down.

> **Seu ambiente está pronto!** A API agora está configurada para se conectar ao banco de dados MySQL rodando no Docker.

## Próximo Passo: Criar a Tabela no Banco de Dados

O próximo passo é criar a tabela Administrators nesse banco de dados usando as migrations do Entity Framework.
