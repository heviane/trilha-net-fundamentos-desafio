# App com modelo de Veículo

## Criar o modelo de veículo

- namespace: MinimalApi.domain.entities
  - classe: Vehicle

## Mapeamento no DBContext

- Criar um DbSet para veículos.

## Crie e Aplique igration para a tabela `Vehicle`

```bash
# Criar a migration
dotnet ef migrations add VehicleMigration
# Aplicar a migration
dotnet ef database update
```

> **PRONTO!** Migrations concluídas. Agora verifique o banco de dados.

## Criar o serviço de Veículo

1. Criar uma interface em domain/interfaces/IServiceVehicle.cs
2. Criar uma classe de serviço em domain/services/ServiceVehicle.cs
3. No `Program.cs`, add o CRUD para veículos.
