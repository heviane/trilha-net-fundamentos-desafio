# mysqldump

O comando `mysqldump` é um programa utilitário de linha de comando do MySQL, e não um comando SQL.
Por isso, ele deve ser executado diretamente no terminal do seu sistema operacional (shell), e não dentro do prompt do MySQL.

## Backup completo do banco de dados

```sql
-- MySql local
mysqldump -u root -p'heviane' minimal_api_db > minimal_api.dump.sql;

-- MySQl via Docker
docker exec mysql-dev mysqldump -u root -p'heviane' minimal_api_db > minimal_api.dump.sql;
```

O arquivo `minimal_api.dump.sql` é criado no diretório onde o comando for executado.

## Restauração do banco de dados

```sql
-- MySql local
mysql -u root -p'heviane' minimal_api_test_db < minimal_api.dump.sql;

-- MySQl via Docker
cat minimal_api.dump.sql | docker exec -i mysql-dev mysql -u root -p'heviane' minimal_api_test_db
```

O arquivo `minimal_api.dump.sql` deve estar no diretório onde o comando for executado.
