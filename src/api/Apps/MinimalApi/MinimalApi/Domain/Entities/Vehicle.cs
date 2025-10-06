using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MinimalApi.Domain.Entities
{
    public class Vehicle
    {
        /// <summary>
        /// Identificador único do veículo.
        /// </summary>
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)] // Gera o valor automaticamente no banco de dados
        public int Id { get; set; } = default!;

        /// <summary>
        /// Nome do veículo.
        /// </summary>
        [Required]
        [StringLength(100)]
        public string Name { get; set; } = default!;

        /// <summary>
        /// Marca do veículo.
        /// </summary>
        [Required]
        [StringLength(50)]
        public string Brand { get; set; } = default!;

        /// <summary>
        /// Modelo do veículo.
        /// </summary>
        [Required]
        [StringLength(50)]
        public string Model { get; set; } = default!;

        /// <summary>
        /// Ano do veículo.
        /// </summary>
        [Required]
        public int Year { get; set; } = default!;

        /// <summary>
        /// Construtor com parâmetros.
        /// </summary>
        /// <param name="name">Nome do veículo.</param>
        /// <param name="brand">Marca do veículo.</param>
        /// <param name="model">Modelo do veículo.</param>
        /// <param name="year">Ano do veículo.</param>
        /// </summary>
        public Vehicle(string name, string brand, string model, int year)
        {
            // TODO: Validações podem ser adicionadas aqui...
            this.Name = name;
            this.Brand = brand;
            this.Model = model;
            this.Year = year;
        }
    }
}
