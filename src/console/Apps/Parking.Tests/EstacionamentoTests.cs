using Parking.Models;
using System;
using Xunit;

namespace Parking.Tests
{
    public class EstacionamentoTests
    {
        private readonly decimal _precoInicial = 5.0m;
        private readonly decimal _precoPorHora = 2.0m;
        private readonly Estacionamento _estacionamento;

        public EstacionamentoTests()
        {
            // Arrange - comum a todos os testes
            _estacionamento = new Estacionamento(_precoInicial, _precoPorHora);
        }

        [Fact]
        public void AdicionarVeiculo_DeveRetornarTrueEAdicionarNaLista_QuandoPlacaValida()
        {
            // Arrange
            string placa = "ABC-1234";

            // Act
            bool resultado = _estacionamento.AdicionarVeiculo(placa);
            var veiculos = _estacionamento.ListarVeiculos();

            // Assert
            Assert.True(resultado);
            Assert.Single(veiculos);
            Assert.Contains(placa, veiculos);
        }

        [Theory]
        [InlineData("abc-5678")]
        [InlineData("ABC-5678")]
        public void AdicionarVeiculo_DeveRetornarFalse_QuandoPlacaJaExiste(string placaDuplicada)
        {
            // Arrange
            string placaOriginal = "ABC-5678";
            _estacionamento.AdicionarVeiculo(placaOriginal);

            // Act
            bool resultado = _estacionamento.AdicionarVeiculo(placaDuplicada);
            var veiculos = _estacionamento.ListarVeiculos();

            // Assert
            Assert.False(resultado);
            Assert.Single(veiculos); // Garante que a lista não foi alterada
        }

        [Fact]
        public void RemoverVeiculo_DeveRetornarValorCorretoERemoverDaLista_QuandoVeiculoExiste()
        {
            // Arrange
            string placa = "XYZ-9876";
            int horasEstacionado = 3;
            decimal valorEsperado = _precoInicial + (_precoPorHora * horasEstacionado); // 5 + 2*3 = 11
            _estacionamento.AdicionarVeiculo(placa);

            // Act
            decimal valorCobrado = _estacionamento.RemoverVeiculo(placa, horasEstacionado);
            var veiculos = _estacionamento.ListarVeiculos();

            // Assert
            Assert.Equal(valorEsperado, valorCobrado);
            Assert.Empty(veiculos); // Garante que o veículo foi removido
        }

        [Fact]
        public void RemoverVeiculo_DeveLancarInvalidOperationException_QuandoVeiculoNaoExiste()
        {
            // Arrange
            string placaInexistente = "NAO-0000";

            // Act & Assert
            var exception = Assert.Throws<InvalidOperationException>(() => _estacionamento.RemoverVeiculo(placaInexistente, 1));
            Assert.Equal("Veículo não encontrado. Confira se digitou a placa corretamente.", exception.Message);
        }

        [Theory]
        [InlineData(0)]
        [InlineData(-1)]
        public void RemoverVeiculo_DeveLancarArgumentException_QuandoHorasSaoInvalidas(int horasInvalidas)
        {
            // Arrange
            string placa = "VALID-01";
            _estacionamento.AdicionarVeiculo(placa);

            // Act & Assert
            var exception = Assert.Throws<ArgumentException>(() => _estacionamento.RemoverVeiculo(placa, horasInvalidas));
            Assert.Equal("horas", exception.ParamName);
        }
    }
}
