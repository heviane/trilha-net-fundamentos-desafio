using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using MinimalApi.Infrastructure.Db;
using MinimalApi.Domain.ModelViews;
using MinimalApi.Domain.Services;
using MinimalApi.Domain.Entities;

namespace MinimalApiTest.Domain.Services;

// ler a configuração, criar o DbContext e gerenciar a limpeza do banco.

[TestClass]
public class AdministratorServiceTestDb
{
    private static DbContextOptions<DbContexto> _options = null!;
    private DbContexto _context = null!;

    [ClassInitialize]
    public static void ClassInitialize(TestContext context)
    {
        var configuration = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.testing.json")
            .Build();

        var connectionString = configuration.GetConnectionString("DefaultConnection");

        _options = new DbContextOptionsBuilder<DbContexto>()
            .UseMySql(connectionString, ServerVersion.AutoDetect(connectionString))
            .Options;
    }

    [TestInitialize]
    public void TestInitialize()
    {
        // Cria uma nova instância do contexto e o banco de dados ANTES de cada teste
        _context = new DbContexto(_options);
        _context.Database.EnsureCreated();
    }

    [TestCleanup]
    public void TestCleanup()
    {
        // Garante que o banco de dados seja destruído e o contexto liberado DEPOIS de cada teste
        _context.Database.EnsureDeleted();
        _context.Dispose();
    }

    // Exemplo de como seria um teste de persistência/integração
    [TestMethod]
    public void SaveAdministrator_ShouldPersistToRealDatabase()
    {
        // Arrange (Organizar)
        // O contexto já foi criado e o banco de dados preparado pelo [TestInitialize]
        var administratorService = new ServiceAdministrator(_context);
        var email = $"persistencia-{Guid.NewGuid()}@teste.com.br";
        var adm = new Administrator(
            email: email,
            password: "123456",
            perfil: "Admin"
        );

        // Act (Agir)
        administratorService.Create(adm);

        // Assert (Verificar)
        // Busca o administrador em uma nova instância do contexto para garantir
        // que ele foi realmente salvo e recuperado do banco de dados, e não apenas da memória do EF.
        using var assertContext = new DbContexto(_options);
        var savedAdm = assertContext.Administrators.FirstOrDefault(a => a.Email == email);

        Assert.IsNotNull(savedAdm);
        Assert.AreEqual("Admin", savedAdm.Perfil);
        Assert.AreEqual(email, savedAdm.Email);
    }
}
