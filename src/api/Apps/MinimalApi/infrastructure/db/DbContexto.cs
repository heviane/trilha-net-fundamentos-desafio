using Microsoft.EntityFrameworkCore;
using MinimalApi.domain.entities;

namespace MinimalApi.infrastructure.db;

public class DbContexto : DbContext
{
    // Método construtor para poder receber uma injeção de dependência
    private readonly IConfiguration _configurationAppSettings;
    public DbContexto(IConfiguration configurationAppSettings)
    {
        _configurationAppSettings = configurationAppSettings;
    }

    // Representa a tabela Administrators no banco de dados
    public DbSet<Administrator> Administrators { get; set; } = default!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Administrator>().HasData(
            new Administrator(
                "c1b8e9a8-5b1a-4b1a-9b0a-0b9b8e9a8c1b",
                "heviane@gmail.com",
                "123456",
                "Admin"
            )
        );
    }

    // Configura a conexão com o banco de dados MySQL
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            var connectionString = _configurationAppSettings.GetConnectionString("DefaultConnection")?.ToString();
            if (!string.IsNullOrEmpty(connectionString))
            {
                optionsBuilder.UseMySql(
                    connectionString,
                    ServerVersion.AutoDetect(connectionString)
                );
            }
            else
            {
                throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
            }
        }
    }
}
