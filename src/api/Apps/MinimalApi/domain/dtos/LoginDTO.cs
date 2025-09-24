using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MinimalApi.Domain.DTOs;

/// <summary>
/// DTO (Data Transfer Object) para receber dados de login.
/// </summary>
public class LoginDTO
{
    public string Email { get; set; } = default!;
    public string Password { get; set; } = default!;
}
