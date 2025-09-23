using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MinimalApi.domain.interfaces;
using MinimalApi.domain.dtos;
using MinimalApi.domain.entities;
using MinimalApi.infrastructure.db;
using Microsoft.AspNetCore.Http.HttpResults;


namespace MinimalApi.domain.services
{
    public class ServiceAdministrator : IServiceAdministrator
    {

        // Lógica de negócio relacionada a administradores

        // ...trabalhando aqui com acoplamento forte, mas ideal é usar uma interface

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
