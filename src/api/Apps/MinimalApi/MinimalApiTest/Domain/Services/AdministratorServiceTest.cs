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

[TestClass]
public class AdministratorServiceTest
{
    private DbContexto CreateInMemoryDbContext()
    {
        var options = new DbContextOptionsBuilder<DbContexto>()
            .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString()) // Usa um nome de DB único para cada teste
            .Options;

        // Para que isso funcione, seu DbContexto precisa ter um construtor
        // que aceite DbContextOptions<DbContexto>
        // public DbContexto(DbContextOptions<DbContexto> options) : base(options) { }
        return new DbContexto(options);
    }

    [TestMethod]
    public void SaveAdministrator()
    {
        // Arrange (Organizar)
        var context = CreateInMemoryDbContext();
        var administratorService = new ServiceAdministrator(context);

        var adm = new Administrator(
            email: "teste@teste.com.br",
            password: "123456",
            perfil: "Admin"
        );

        // Act (Agir)
        administratorService.Create(adm);

        // Assert (Verificar)
        // 1. Verifica se existe exatamente 1 administrador no banco de dados
        Assert.AreEqual(1, context.Administrators.Count());

        // 2. Busca o administrador salvo e verifica se os dados estão corretos
        var savedAdm = context.Administrators.FirstOrDefault();
        Assert.IsNotNull(savedAdm);
        Assert.AreEqual("teste@teste.com.br", savedAdm.Email);
        Assert.AreEqual("Admin", savedAdm.Perfil);
    }
}
