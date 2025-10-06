using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http.HttpResults;

using MinimalApi.Domain.DTOs;
using MinimalApi.Domain.Entities;
using MinimalApi.Domain.Interfaces;
using MinimalApi.Infrastructure.Db;

namespace MinimalApi.Domain.Services
{
    public class ServiceAdministrator : IServiceAdministrator
    {
        /* ----- NOTA: trabalhando aqui com acoplamento forte, mas ideal é usar uma interface
            Para seguir a Clean Architecture à risca, a camada de Application (ServiceAdministrator) não deveria conhecer o DbContexto diretamente. 
            Ela deveria depender de uma abstração (interface) de repositório, como IAdministratorRepository, 
            que seria definida no Domain e implementada na Infrastructure.

            ==>> O próximo passo natural, é desacoplar suas classes de serviço do DbContext usando o padrão de repositório.
        */

        // Construtor
        private readonly DbContexto _dbContexto;

        public ServiceAdministrator(DbContexto dbContexto)
        {
            _dbContexto = dbContexto;
        }

        // Métodos implementados conforme a interface
        public Administrator? Login(LoginDTO loginDTO)
        {
            // return um Administrator se as credenciais forem válidas, ou null se forem inválidas
            return _dbContexto.Administrators.Where(a => a.Email == loginDTO.Email && a.Password == loginDTO.Password).FirstOrDefault();
        }

        public Administrator Create(Administrator administrator)
        {
            _dbContexto.Administrators.Add(administrator);
            _dbContexto.SaveChanges();
            return administrator;
        }

        public List<Administrator> GetAll(int? currentPage = 1)
        {
            // Construindo a consulta
            var query = _dbContexto.Administrators.AsQueryable();
            int pageSize = 10;

            // Aplicando paginação
            if (currentPage != null)
            {
                query = query.Skip(((currentPage.Value - 1) * pageSize)).Take(pageSize);
            }

            // Retornando a lista de administradores
            return query.ToList();
        }

        public Administrator? GetById(string id)
        {
            return _dbContexto.Administrators.Where(a => a.Id == id).FirstOrDefault();
        }

        public void Delete(Administrator administrator)
        {
            _dbContexto.Administrators.Remove(administrator);
            _dbContexto.SaveChanges();
        }
    }
}
