# Run SQL commands

Após conectar, você pode executar comandos SQL para interagir com seu banco de dados.

```plaintext
mysql>
```

## Banco de dados de desenvolvimento

```sql
CREATE DATABASE IF NOT EXISTS minimal_api_db
CHARACTER SET utf8mb4 
COLLATE utf8mb4_unicode_ci;
SHOW DATABASES;

USE minimal_api_db;
```

## Banco de dados de testes

```sql
CREATE DATABASE IF NOT EXISTS minimal_api_test_db
CHARACTER SET utf8mb4 
COLLATE utf8mb4_unicode_ci;
SHOW DATABASES;

use minimal_api_test_db;
```

## Comandos SQL mais comuns

```sql
SHOW TABLES;

DESC Administrators;
DESC Vehicles;

SELECT * FROM Administrators;
SELECT * FROM Vehicles;
exit;
```
