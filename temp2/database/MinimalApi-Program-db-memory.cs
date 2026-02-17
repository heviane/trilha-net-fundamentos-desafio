using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

// 1. Adiciona o DbContext e configura o provedor de banco de dados em memória.
builder.Services.AddDbContext<ApiDbContext>(options => options.UseInMemoryDatabase("MinimalApiDb"));

// 2. Registra o serviço de autenticação para injeção de dependência.
builder.Services.AddScoped<AuthService>();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapGet("/", () => "Hello World!");

// 3. Endpoint de login refatorado para usar o serviço de autenticação.
app.MapPost("/login", (LoginDTO login, AuthService authService) =>
{
    if (authService.Authenticate(login.Email, login.Password))
    {
        return Results.Ok("Login successful!");
    }

    return Results.Unauthorized();
});

app.Run();

// --- Definições de Classes ---

/// <summary>
/// DTO (Data Transfer Object) para receber dados de login.
/// </summary>
public class LoginDTO
{
    public string Email { get; set; } = default!;
    public string Password { get; set; } = default!;
}

/// <summary>
/// Entidade de usuário para o banco de dados.
/// </summary>
public class User
{
    public int Id { get; set; }
    public string Email { get; set; } = default!;
    public string Password { get; set; } = default!; // Em um app real, armazene um hash!
}

/// <summary>
/// Contexto do banco de dados da aplicação.
/// </summary>
public class ApiDbContext(DbContextOptions<ApiDbContext> options) : DbContext(options)
{
    public DbSet<User> Users { get; set; } = default!;
}

/// <summary>
/// Serviço com a lógica de negócio para autenticação.
/// </summary>
public class AuthService(ApiDbContext context)
{
    public bool Authenticate(string email, string password)
    {
        // Adiciona um usuário padrão se o banco estiver vazio (apenas para exemplo)
        if (!context.Users.Any())
        {
            context.Users.Add(new User { Email = "teste@gmail.com", Password = "123456" });
            context.SaveChanges();
        }

        return context.Users.Any(u => u.Email == email && u.Password == password);
    }
}
