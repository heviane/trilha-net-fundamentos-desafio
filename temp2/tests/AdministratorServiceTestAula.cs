namespace MinimalApiTest.Domain.Services
{
    [TestClass]
    public class AdministratorServiceTestAula
    {
        /*
        private DbContexto CreateDbContextTest()
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddEnvironmentVariables();

            var configuration = builder.Build();

            return new DbContexto(configuration);
            var options = new DbContextOptionsBuilder<DbContexto>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString()) // Usa um nome de DB único para cada teste
                .Options;
            return new DbContexto(options);
        }

        [TestMethod]
        public void SaveAdministrator()
        {
            var context = CreateDbContextTest();

            context.Database.ExecuteSqlRaw("TRUNCATE TABLE Administrators;");

            var adm = new Administrator();
            adm.Email = "teste@teste.com.br";
            adm.Password = "123456";
            adm.Perfil = "Admin";

            var AdministratorService = new AdministratorService(context);

            AdministratorService.Create(adm);

            Assert.AreEqual(1, context.AdministratorsService.AGetAll(1).Count());
        }
        */
    }
}
