using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MinimalApi.Domain.DTOs;
using MinimalApi.Domain.Entities;

namespace MinimalApi.Domain.Interfaces
{
    public interface IServiceAdministrator
    {
        // Definição dos métodos relacionados a administradores
        // Será usado para criar mocks para realizar os testes de unidade

        Administrator? Login(LoginDTO loginDTO);
    }
}
