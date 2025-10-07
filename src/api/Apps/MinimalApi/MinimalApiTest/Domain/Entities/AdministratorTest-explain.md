# Explain: `AdministratorTest.cs`

O problema é que o seu teste está tentando criar uma instância da entidade com `new Administrator()`, mas, como vimos, a classe Administrator não possui um construtor sem parâmetros. Ela espera receber os dados (como email e senha) no momento da criação.

Além disso, um teste de entidade é mais valioso quando ele valida a lógica do construtor e o estado inicial do objeto, em vez de apenas testar getters e setters básicos.

## O que precisa ser ajustado?

- **Instanciação**: Usaremos o construtor correto da classe Administrator para criar o objeto.
- **Validação**: Vamos verificar se as propriedades foram inicializadas corretamente após a chamada do construtor. Também é uma boa prática verificar o Id, para garantir que ele não está nulo ou vazio.

### Correção Sugerida

Aqui está a versão corrigida do seu teste. Ele agora reflete com mais precisão como a entidade Administrator deve ser usada.

```csharp
// Em /MinimalApiTest/Domain/Entities/AdministratorTest.cs
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
```

> **PRONTO**: Com essa alteração, seu teste de unidade para a entidade **`Administrator`** fica correto e mais significativo, validando o comportamento esperado do construtor.
