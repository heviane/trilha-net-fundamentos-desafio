using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MinimalApi.domain.dtos;
using MinimalApi.domain.entities;

namespace MinimalApi.domain.interfaces
{
    public interface IServiceAdministrator
    {
        // Definição dos métodos relacionados a administradores
        // Será usado para criar mocks para realizar os testes de unidade

        Administrator? Login(LoginDTO loginDTO);
    }
}
