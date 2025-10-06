# Run SQL commands

Após conectar, você pode executar comandos SQL para interagir com seu banco de dados.

```plaintext
mysql>
```

Comandos SQL mais comuns:

```sql
CREATE DATABASE IF NOT EXISTS minimal_api_db
CHARACTER SET utf8mb4 
COLLATE utf8mb4_unicode_ci;

USE minimal_api_db;
SHOW TABLES;

DESC Administrators;
DESC Vehicles;

SELECT * FROM Administrators;
SELECT * FROM Vehicles;
exit;
```
