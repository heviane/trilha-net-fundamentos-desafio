using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MinimalApi.domain.entities;

namespace MinimalApi.domain.interfaces
{
    public interface IServiceVehicle
    {
        /// <summary>
        /// Obtém uma lista paginada de veículos, com filtros opcionais.
        /// </summary>
        /// <param name="currentPage">O número da página a ser retornada.</param>
        /// <param name="name">Filtro opcional para o nome do veículo.</param>
        /// <param name="brand">Filtro opcional para a marca do veículo.</param>
        /// <returns>Uma tarefa que representa a operação assíncrona, contendo a lista de veículos.</returns>
        Task<List<Vehicle>> GetAllAsync(int currentPage = 1, string? name = null, string? brand = null);

        /// <summary>
        /// Obtém um veículo específico pelo seu identificador único.
        /// </summary>
        /// <param name="id">O ID do veículo a ser buscado.</param>
        /// <returns>Uma tarefa que representa a operação assíncrona, contendo o veículo encontrado ou nulo.</returns>
        Task<Vehicle?> GetByIdAsync(int id);

        /// <summary>
        /// Adiciona um novo veículo ao sistema.
        /// </summary>
        /// <param name="vehicle">O objeto do veículo a ser criado.</param>
        /// <returns>Uma tarefa que representa a operação assíncrona, contendo o veículo recém-criado.</returns>
        Task<Vehicle> CreateAsync(Vehicle vehicle);

        /// <summary>
        /// Atualiza os dados de um veículo existente.
        /// </summary>
        /// <param name="vehicle">O objeto do veículo com os dados atualizados.</param>
        /// <returns>Uma tarefa que representa a operação assíncrona, contendo o veículo atualizado.</returns>
        Task<Vehicle> UpdateAsync(Vehicle vehicle);

        /// <summary>
        /// Remove um veículo do sistema.
        /// </summary>
        /// <param name="vehicle">O objeto do veículo a ser removido.</param>
        /// <returns>Uma tarefa que representa a operação assíncrona.</returns>
        Task<Vehicle> DeleteAsync(Vehicle vehicle);

        /*
            Sincronia vs. Assincronia (Ponto mais importante)
            
        */
    }
}
