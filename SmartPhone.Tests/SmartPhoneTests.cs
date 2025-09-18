using System;
using System.IO;
using SmartPhone.Models;
using System.Collections.Generic;
using Xunit;

namespace SmartPhone.Tests;

public class SmartPhoneTests : IDisposable
{
    private readonly StringWriter _stringWriter;
    private readonly TextWriter _originalOutput;

    public SmartPhoneTests()
    {
        // Arrange comum: Redireciona a saída do console antes de cada teste
        // para que possamos capturar e verificar o que é escrito.
        _stringWriter = new StringWriter();
        _originalOutput = Console.Out;
        Console.SetOut(_stringWriter);
    }

    [Theory]
    [MemberData(nameof(SmartphoneTestData))]
    public void Smartphone_Constructor_ShouldSetPropertiesCorrectly(Smartphone smartphone, string expectedNumero, string expectedModelo, string expectedImei, int expectedMemoria)
    {
        // Arrange & Act (O objeto já é criado pelo MemberData)

        // Assert
        Assert.Equal(expectedNumero, smartphone.Numero);
        Assert.Equal(expectedModelo, smartphone.Modelo);
        Assert.Equal(expectedImei, smartphone.IMEI);
        Assert.Equal(expectedMemoria, smartphone.Memoria);
    }

    [Theory]
    [InlineData(typeof(Nokia), "WhatsApp", "Instalando o aplicativo \"WhatsApp\" no Nokia.")]
    [InlineData(typeof(Iphone), "Telegram", "Instalando o aplicativo \"Telegram\" no iPhone.")]
    public void InstalarAplicativo_ShouldPrintCorrectMessage_ForDeviceType(Type deviceType, string appName, string expectedOutput)
    {
        // Arrange
        // Usando reflection para criar a instância do smartphone apropriado
        Smartphone smartphone = (Smartphone)Activator.CreateInstance(deviceType, "123", "modelo", "123", 128);
        string expectedMessage = $"{expectedOutput}{Environment.NewLine}";

        // Act
        smartphone.InstalarAplicativo(appName);

        // Assert
        Assert.Equal(expectedMessage, _stringWriter.ToString());
    }

    public static IEnumerable<object[]> SmartphoneTestData()
    {
        yield return new object[] { new Nokia("912345678", "Nokia C30", "111111111111111", 64), "912345678", "Nokia C30", "111111111111111", 64 };
        yield return new object[] { new Iphone("987654321", "iPhone 14", "222222222222222", 128), "987654321", "iPhone 14", "222222222222222", 128 };
    }

    public void Dispose()
    {
        // Cleanup: Restaura a saída original do console após cada teste
        // para evitar efeitos colaterais em outros testes ou partes do sistema.
        Console.SetOut(_originalOutput);
        _stringWriter.Dispose();
    }
}
