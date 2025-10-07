# Instalar Entity Framework

...

## Instalar a Ferramenta de Linha de Comando do EF Core

Instale a ferramenta `dotnet-ef` globalmente.

> **OBS:** Você só precisa fazer isso uma vez na sua máquina.

```bash
dotnet tool install --global dotnet-ef
```

## Instalar os Pacotes do Entity Framework

No diretório do projeto, via terminal:

```bash
dotnet add package Microsoft.EntityFrameworkCore
dotnet add package Microsoft.EntityFrameworkCore.Design
dotnet add package Pomelo.EntityFrameworkCore.MySql
```
