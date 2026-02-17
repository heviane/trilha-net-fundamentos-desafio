namespace MinimalApiTest.Domain.Services
{
    [TestClass]
    public class AdministratorServiceTest2
    {
        /*
        private DbContexto CreateInMemoryDbContext()
        {
            var options = new DbContextOptionsBuilder<DbContexto>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString()) // Usa um nome de DB único para cada teste
                .Options;
            return new DbContexto(options);
        }

        [TestMethod]
        public void SaveAdministrator()
        {
            // Arrange (Organizar)
            var context = CreateInMemoryDbContext();
            var administratorService = new AdministratorService(context);

            var adm = new Administrator
            {
                Email = "teste@teste.com.br",
                Password = "123456",
                Perfil = "Admin"
            };

            // Act (Agir)
            administratorService.Create(adm);

            // Assert (Verificar)
            // Verifica se existe exatamente 1 administrador no banco de dados
            Assert.AreEqual(1, context.Administrators.Count());
            // Verifica se o email do administrador salvo é o esperado
            var savedAdm = context.Administrators.FirstOrDefault();
            Assert.IsNotNull(savedAdm);
            Assert.AreEqual("teste@teste.com.br", savedAdm.Email);

        }
        */
    }
}
