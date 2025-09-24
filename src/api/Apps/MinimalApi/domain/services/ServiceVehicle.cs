using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using MinimalApi.Domain.Interfaces;
using MinimalApi.Domain.Entities;
using MinimalApi.Infrastructure.Db;
using Microsoft.EntityFrameworkCore;

namespace MinimalApi.Domain.Services
{
    public class ServiceVehicle : IServiceVehicle
    {

        // Construtor
        private readonly DbContexto _dbContexto;

        public ServiceVehicle(DbContexto dbContexto)
        {
            _dbContexto = dbContexto;
        }

        // Métodos implementados conforme a interface
        public List<Vehicle> GetAll(int? currentPage = 1, string? name = null, string? brand = null)
        {
            // Construindo a consulta
            var query = _dbContexto.Vehicles.AsQueryable();

            // Aplicando filtros
            if (!string.IsNullOrEmpty(name))
            {
                query = query.Where(v => EF.Functions.Like(v.Name.ToLower(), $"%{name.ToLower()}%"));
            }

            int itensPerPage = 10; // Definindo o número de itens por página

            // Aplicando paginação
            if (currentPage != null)
            {
                query = query.Skip(((currentPage.Value - 1) * itensPerPage)).Take(itensPerPage);
            }

            // Retornando a lista de veículos
            return query.ToList();
        }

        public Vehicle? GetById(int id)
        {
            return _dbContexto.Vehicles.Where(v => v.Id == id).FirstOrDefault();
            // throw new NotImplementedException();
        }

        public void Create(Vehicle vehicle)
        {
            _dbContexto.Vehicles.Add(vehicle);
            _dbContexto.SaveChanges();
            //throw new NotImplementedException();
        }

        public void Update(Vehicle vehicle)
        {
            _dbContexto.Vehicles.Update(vehicle);
            _dbContexto.SaveChanges();
            //throw new NotImplementedException();
        }

        public void Delete(Vehicle vehicle)
        {
            _dbContexto.Vehicles.Remove(vehicle);
            _dbContexto.SaveChanges();
            //throw new NotImplementedException();
        }
    }
}

/* --- Implementação Explícita vs. Implícita
 
    - Implementar interface (Implícita): Gera métodos públicos (public Vehicle Create(...)). É a forma mais comum.
    - Implementar interface explicitamente: Gera métodos que só podem ser acessados através de uma referência da interface (Vehicle IServiceVehicle.Create(...)). Isso é útil em cenários mais complexos, como quando uma classe implementa duas interfaces com métodos de mesmo nome.
    Para o seu caso, a implementação implícita ("Implementar interface") é a ideal.
*/
