﻿using System.Globalization;
using Parking.Models;

// Coloca o encoding para UTF8 para exibir acentuação
Console.OutputEncoding = System.Text.Encoding.UTF8;
// Define a cultura para pt-BR para formatação de moeda
CultureInfo.DefaultThreadCurrentCulture = new CultureInfo("pt-BR");
CultureInfo.DefaultThreadCurrentUICulture = new CultureInfo("pt-BR");

decimal precoInicial = 0;
decimal precoPorHora = 0;

Console.WriteLine("Seja bem vindo ao sistema de estacionamento!\n" +
                  "Digite o preço inicial:");
while (!decimal.TryParse(Console.ReadLine(), out precoInicial) || precoInicial <= 0)
{
    Console.WriteLine("Valor inválido. Por favor, digite um preço inicial maior que zero:");
}

Console.WriteLine("Agora digite o preço por hora:");
while (!decimal.TryParse(Console.ReadLine(), out precoPorHora) || precoPorHora <= 0)
{
    Console.WriteLine("Valor inválido. Por favor, digite um preço por hora maior que zero:");
}

// Instancia a classe Estacionamento com os preços definidos pelo usuário.
Estacionamento es = new Estacionamento(precoInicial, precoPorHora);

bool exibirMenu = true;

// Realiza o loop do menu
while (exibirMenu)
{
    Console.Clear();
    Console.WriteLine("Digite a sua opção:");
    Console.WriteLine("1 - Cadastrar veículo");
    Console.WriteLine("2 - Remover veículo");
    Console.WriteLine("3 - Listar veículos");
    Console.WriteLine("4 - Encerrar");

    switch (Console.ReadLine())
    {
        case "1":
            CadastrarVeiculo();
            break;

        case "2":
            RemoverVeiculo();
            break;

        case "3":
            ListarVeiculos();
            break;

        case "4":
            exibirMenu = false;
            break;

        default:
            Console.WriteLine("Opção inválida");
            break;
    }

    Console.WriteLine("\nPressione uma tecla para continuar");
    Console.ReadLine();
}

Console.WriteLine("O programa se encerrou");


void CadastrarVeiculo()
{
    Console.WriteLine("Digite a placa do veículo para estacionar:");
    string placa = Console.ReadLine();

    // Chama o método AdicionarVeiculo, que agora tem a lógica pura, e trata o retorno.
    if (es.AdicionarVeiculo(placa))
    {
        Console.WriteLine("Veículo estacionado com sucesso!");
    }
    else
    {
        Console.WriteLine($"Não foi possível estacionar. O veículo com a placa '{placa}' já está estacionado ou a placa é inválida.");
    }
}

void RemoverVeiculo()
{
    Console.WriteLine("Digite a placa do veículo para remover:");
    string placa = Console.ReadLine();

    Console.WriteLine("Digite a quantidade de horas que o veículo permaneceu estacionado:");
    if (!int.TryParse(Console.ReadLine(), out int horas))
    {
        Console.WriteLine("Entrada de horas inválida. Apenas números são permitidos. Operação cancelada.");
        return;
    }

    try
    {
        decimal valorTotal = es.RemoverVeiculo(placa, horas);
        Console.WriteLine($"O veículo {placa} foi removido e o preço total foi de: {valorTotal:C2}");
    }
    catch (Exception ex) // Captura qualquer exceção lançada pela camada de negócio (veículo não existe, horas <= 0).
    {
        Console.WriteLine($"Erro ao remover veículo: {ex.Message}");
    }
}

void ListarVeiculos()
{
    var veiculos = es.ListarVeiculos();
    
    if (veiculos.Any())
    {
        Console.WriteLine("Os veículos estacionados são:");
        foreach (var veiculo in veiculos)
        {
            Console.WriteLine(veiculo);
        }
    }
    else
    {
        Console.WriteLine("Não há veículos estacionados.");
    }
}
