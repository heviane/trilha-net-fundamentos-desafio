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
    public void Should_Create_Administrator_With_Correct_Properties()
    {
        // Arrange
        var email = "teste@teste.com.br";
        var password = "123456";
        var perfil = "Admin";

        // Act
        var adm = new Administrator(email, password, perfil);

        // Assert
        Assert.IsNotNull(adm);
        Assert.AreEqual(email, adm.Email);
        Assert.AreEqual(password, adm.Password);
        Assert.AreEqual(perfil, adm.Perfil);
        Assert.IsFalse(string.IsNullOrEmpty(adm.Id)); // Garante que um ID foi gerado
    }
}
