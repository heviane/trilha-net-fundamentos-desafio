using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MinimalApi.Domain.Entities;

namespace MinimalApi.Domain.Interfaces
{
    public interface IServiceVehicle
    {

        // Métodos sincronos

        /// <summary>
        /// Obtém uma lista paginada de veículos, com filtros opcionais.
        /// </summary>
        /// <param name="currentPage">O número da página a ser retornada.</param>
        /// <param name="name">Filtro opcional para o nome do veículo.</param>
        /// <param name="brand">Filtro opcional para a marca do veículo.</param>
        /// <returns>Uma lista de veículos, opcionalmente filtrada e paginada.</returns>
        List<Vehicle>? GetAll(int? currentPage = 1, string? name = null, string? brand = null);

        /// <summary>
        /// Obtém um veículo específico pelo seu identificador único.
        /// </summary>
        /// <param name="id">O ID do veículo a ser buscado.</param>
        /// <returns>O veículo encontrado ou nulo caso não exista.</returns>
        Vehicle? GetById(int id);

        /// <summary>
        /// Adiciona um novo veículo ao sistema.
        /// </summary>
        /// <param name="vehicle">O objeto do veículo a ser criado.</param>
        /// <returns></returns>
        void Create(Vehicle vehicle);

        /// <summary>
        /// Atualiza os dados de um veículo existente.
        /// </summary>
        /// <param name="vehicle">O objeto do veículo com os dados atualizados.</param>
        /// <returns></returns>
        void Update(Vehicle vehicle);

        /// <summary>
        /// Remove um veículo do sistema.
        /// </summary>
        /// <param name="vehicle">O objeto do veículo a ser removido.</param>
        /// <returns></returns>
        void Delete(Vehicle vehicle);
    }
}
