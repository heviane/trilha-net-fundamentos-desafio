# Start Database via Docker

## Passo 1: Iniciar o Banco de Dados via `docker-compose.yml`

Com o Docker Desktop em execução, abra o terminal no diretório do projeto e execute:

```bash
docker-compose up -d
```

- **`up`**: Cria e inicia os serviços definidos no arquivo.
- **`-d`**: (detached) Roda os containers em segundo plano.

> **PRONTO!** Seu banco de dados MySQL agora está rodando em um container! Você pode pará-lo a qualquer momento com `docker-compose down`.
