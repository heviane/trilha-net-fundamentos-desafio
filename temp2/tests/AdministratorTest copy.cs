using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MinimalApi.Domain.Entities;

namespace MinimalApiTest.Domain.Entities;

[TestClass]
public class AdministratorTest
{

    [TestMethod]
    public void TestGetSetProperties()
    {
        // Arrange (variáveis e objetos)
        var adm = new Administrator();

        // Act (Ação a ser testada)
        adm.Email = "teste@teste.com.br";
        adm.Password = "123456";
        adm.Perfil = "Admin";
        // Assert (Verificações e validações)
        Assert.AreEqual("teste@teste.com.br", adm.Email);
        Assert.AreEqual("123456", adm.Password);
        Assert.AreEqual("Admin", adm.Perfil);
    }
}
