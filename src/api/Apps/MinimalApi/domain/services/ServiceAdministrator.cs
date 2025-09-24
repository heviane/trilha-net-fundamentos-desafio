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

        private readonly DbContexto _dbContexto;

        public ServiceAdministrator(DbContexto dbContexto)
        {
            _dbContexto = dbContexto;
        }

        // Implementação do método de login
        public Administrator? Login(LoginDTO loginDTO)
        {
            return _dbContexto.Administrators.Where(a => a.Email == loginDTO.Email && a.Password == loginDTO.Password).FirstOrDefault();
            // return um Administrator se as credenciais forem válidas, ou null se forem inválidas
        }
    }
}
