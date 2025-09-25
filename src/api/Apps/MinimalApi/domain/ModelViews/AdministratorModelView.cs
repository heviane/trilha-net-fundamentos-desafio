using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using MinimalApi.Domain.Enums;

namespace MinimalApi.Domain.ModelViews
{
    public record AdministratorModelView
    {
        public string Id { get; set; } = default!;
        public string Email { get; set; } = default!;
        public string Perfil { get; set; } = default!;
    }
}
