using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MinimalApi.Domain.DTOs;

/// <summary>
/// DTO (Data Transfer Object) para receber dados de veículo.
/// </summary>
public record VehicleDTO
{
    /// <summary>
    /// Nome do veículo.
    /// </summary>
    public string Name { get; set; } = default!;

    /// <summary>
    /// Marca do veículo.
    /// </summary>
    public string Brand { get; set; } = default!;

    /// <summary>
    /// Modelo do veículo.
    /// </summary>
    public string Model { get; set; } = default!;

    /// <summary>
    /// Ano do veículo.
    /// </summary>
    public int Year { get; set; } = default!;
}
