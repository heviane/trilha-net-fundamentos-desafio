using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MinimalApi.domain.dtos
{
    /// <summary>
    /// DTO (Data Transfer Object) para receber dados de login.
    /// </summary>
    public class LoginDTO
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public string Email { get; set; } = default!;
        public string Password { get; set; } = default!;
    }
}
