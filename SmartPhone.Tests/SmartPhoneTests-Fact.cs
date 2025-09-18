/*
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

    [Fact]
    public void Nokia_Constructor_ShouldSetPropertiesCorrectly()
    {
        // Arrange
        string numero = "912345678";
        string modelo = "Nokia C30";
        string imei = "111111111111111";
        int memoria = 64;

        // Act
        var nokia = new Nokia(numero, modelo, imei, memoria);

        // Assert
        Assert.Equal(numero, nokia.Numero);
        Assert.Equal(modelo, nokia.Modelo);
        Assert.Equal(imei, nokia.IMEI);
        Assert.Equal(memoria, nokia.Memoria);
    }

    [Fact]
    public void Iphone_Constructor_ShouldSetPropertiesCorrectly()
    {
        // Arrange
        string numero = "987654321";
        string modelo = "iPhone 14";
        string imei = "222222222222222";
        int memoria = 128;

        // Act
        var iphone = new Iphone(numero, modelo, imei, memoria);

        // Assert
        Assert.Equal(numero, iphone.Numero);
        Assert.Equal(modelo, iphone.Modelo);
        Assert.Equal(imei, iphone.IMEI);
        Assert.Equal(memoria, iphone.Memoria);
    }

    [Fact]
    public void Nokia_InstalarAplicativo_ShouldPrintCorrectMessage()
    {
        // Arrange
        var nokia = new Nokia("912345678", "Nokia C30", "111111111111111", 64);
        string appName = "WhatsApp";
        string expectedOutput = $"Instalando o aplicativo \"{appName}\" no Nokia.{Environment.NewLine}";

        // Act
        nokia.InstalarAplicativo(appName);

        // Assert
        Assert.Equal(expectedOutput, _stringWriter.ToString());
    }

    [Fact]
    public void Iphone_InstalarAplicativo_ShouldPrintCorrectMessage()
    {
        // Arrange
        var iphone = new Iphone("987654321", "iPhone 14", "222222222222222", 128);
        string appName = "Telegram";
        string expectedOutput = $"Instalando o aplicativo \"{appName}\" no iPhone.{Environment.NewLine}";

        // Act
        iphone.InstalarAplicativo(appName);

        // Assert
        Assert.Equal(expectedOutput, _stringWriter.ToString());
    }

    public void Dispose()
    {
        // Cleanup: Restaura a saída original do console após cada teste
        // para evitar efeitos colaterais em outros testes ou partes do sistema.
        Console.SetOut(_originalOutput);
        _stringWriter.Dispose();
    }
}
*/
