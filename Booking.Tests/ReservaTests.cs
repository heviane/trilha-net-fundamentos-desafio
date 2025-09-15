using Booking.Models;

namespace Booking.Tests;

public class ReservaTests
{
    [Fact]
    public void DeveCadastrarHospedes_QuandoCapacidadeForSuficiente()
    {
        // Arrange
        var suite = new Suite(tipoSuite: "Premium", capacidade: 2, valorDiaria: 100);
        var reserva = new Reserva(diasReservados: 10);
        reserva.CadastrarSuite(suite);
        var hospedes = new List<Pessoa> { new Pessoa("Hóspede 1"), new Pessoa("Hóspede 2") };

        // Act
        reserva.CadastrarHospedes(hospedes);

        // Assert
        Assert.Equal(2, reserva.ObterQuantidadeHospedes());
        Assert.Equal(hospedes, reserva.Hospedes);
    }

    [Fact]
    public void DeveLancarExcecao_QuandoCapacidadeForInsuficiente()
    {
        // Arrange
        var suite = new Suite(tipoSuite: "Básica", capacidade: 1, valorDiaria: 50);
        var reserva = new Reserva(diasReservados: 5);
        reserva.CadastrarSuite(suite);
        var hospedes = new List<Pessoa> { new Pessoa("Hóspede 1"), new Pessoa("Hóspede 2") };

        // Act & Assert
        var exception = Assert.Throws<ArgumentException>(() => reserva.CadastrarHospedes(hospedes));
        Assert.Equal("A quantidade de hóspedes excede a capacidade da suíte.", exception.Message);
    }

    [Fact]
    public void DeveRetornarQuantidadeCorretaDeHospedes()
    {
        // Arrange
        var suite = new Suite(tipoSuite: "Master", capacidade: 3, valorDiaria: 200);
        var reserva = new Reserva(diasReservados: 7);
        reserva.CadastrarSuite(suite);
        var hospedes = new List<Pessoa> { new Pessoa("Hóspede 1"), new Pessoa("Hóspede 2"), new Pessoa("Hóspede 3") };
        reserva.CadastrarHospedes(hospedes);

        // Act
        var quantidadeHospedes = reserva.ObterQuantidadeHospedes();

        // Assert
        Assert.Equal(3, quantidadeHospedes);
    }

    [Theory]
    [InlineData(5, 500)]  // 5 dias * R$100 = R$500
    [InlineData(9, 900)]  // 9 dias * R$100 = R$900
    public void DeveCalcularValorDiaria_SemDesconto(int diasReservados, decimal valorEsperado)
    {
        // Arrange
        var suite = new Suite(tipoSuite: "Premium", capacidade: 2, valorDiaria: 100);
        var reserva = new Reserva(diasReservados: diasReservados);
        reserva.CadastrarSuite(suite);

        // Act & Assert
        Assert.Equal(valorEsperado, reserva.CalcularValorDiaria());
    }

    [Theory]
    [InlineData(10, 900)]  // 10 dias * R$100 = R$1000, com 10% de desconto = R$900
    [InlineData(15, 1350)] // 15 dias * R$100 = R$1500, com 10% de desconto = R$1350
    public void DeveCalcularValorDiaria_ComDesconto(int diasReservados, decimal valorEsperado)
    {
        // Arrange
        var suite = new Suite(tipoSuite: "Premium", capacidade: 4, valorDiaria: 100);
        var reserva = new Reserva(diasReservados: diasReservados);
        reserva.CadastrarSuite(suite);

        // Act & Assert
        Assert.Equal(valorEsperado, reserva.CalcularValorDiaria());
    }
}
