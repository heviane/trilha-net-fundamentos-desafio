using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using System.Text.Json.Serialization;
using MinimalApi.Domain.Enums;

namespace MinimalApi.Domain.DTOs
{
    /// <summary>
    /// DTO (Data Transfer Object) para receber dados de Administrator.
    /// </summary>
    public class AdministratorDTO
    {

        public string Email { get; set; } = default!;
        public string Password { get; set; } = default!;

        // O [JsonConverter] força o desserializador a esperar uma string ("Adm" ou "User").
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public UserPerfil? Perfil { get; set; } = UserPerfil.User;
    }
}
