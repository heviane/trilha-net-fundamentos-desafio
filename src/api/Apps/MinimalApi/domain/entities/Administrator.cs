using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MinimalApi.Domain.Entities

{
    public class Administrator
    {
        /// <summary>
        /// Identificador único do administrador.
        /// </summary>
        [Key]
        public string Id { get; init; } = Guid.NewGuid().ToString();

        /// <summary>
        /// E-mail do administrador.
        /// </summary>
        [Required]
        [StringLength(255)]
        public string Email { get; set; }

        /// <summary>
        /// Senha do administrador.
        /// </summary>
        [Required]
        [StringLength(20)]
        public string Password { get; set; }

        /// <summary>
        /// Perfil do administrador (ex: "Admin", "SuperAdmin").
        /// </summary>
        [Required]
        [StringLength(10)]
        public string Perfil { get; set; }

        /// <summary>
        /// Construtor para garantir que um Administrador seja sempre criado com um e-mail, senha e perfil válidos.
        /// </summary>
        /// <param name="id">O identificador único do administrador.</param>
        /// <param name="email">O e-mail do administrador.</param>
        /// <param name="password">A senha do administrador.</param>
        /// <param name="perfil">O perfil do administrador.</param>
        public Administrator(string id, string email, string password, string perfil)
        {
            // TODO: Validações podem ser adicionadas aqui... (ex: e-mail em formato válido)
            this.Id = id;
            this.Email = email;
            this.Password = password;
            this.Perfil = perfil;
        }
    }
}
