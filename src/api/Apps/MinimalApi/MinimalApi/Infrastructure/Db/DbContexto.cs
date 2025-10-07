using Microsoft.EntityFrameworkCore;

using MinimalApi.Domain.Entities;

namespace MinimalApi.Infrastructure.Db;

public class DbContexto : DbContext
{
    /*
        Toda a configuração do banco de dados está centralizada no Program.cs, que é a abordagem moderna e recomendada.
        Isso deixa seu DbContext mais limpo e focado em seu propósito principal: mapear suas entidades.
    */

    // Construtor para ser usado nos testes e na injeção de dependência
    public DbContexto(DbContextOptions<DbContexto> options) : base(options)
    {
    }

    // DbSets representam tabelas no banco de dados.
    public DbSet<Administrator> Administrators { get; set; } = default!;
    public DbSet<Vehicle> Vehicles { get; set; } = default!;

    // Método OnModelCreating() com HasData para popular o banco com um administrador padrão. 
    // Essa é uma ótima prática para garantir que sua aplicação tenha dados iniciais para testes e desenvolvimento (seeding).
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
}
