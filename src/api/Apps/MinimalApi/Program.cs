using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

using Microsoft.EntityFrameworkCore;
using Pomelo.EntityFrameworkCore.MySql.Infrastructure;

using MinimalApi.Domain.DTOs;
using MinimalApi.Domain.Entities;
using MinimalApi.Domain.Interfaces;
using MinimalApi.Domain.ModelViews;
using MinimalApi.Domain.Services;
using MinimalApi.Infrastructure.Db;
using MinimalApi.Domain.Enums;


#region Builder
// Criação do builder da aplicação
var builder = WebApplication.CreateBuilder(args);

// escopo de injeção de dependência
builder.Services.AddScoped<IServiceAdministrator, ServiceAdministrator>();
builder.Services.AddScoped<IServiceVehicle, ServiceVehicle>();

// Configuração do contexto do banco de dados
builder.Services.AddDbContext<DbContexto>(options =>
{
    options.UseMySql(
        builder.Configuration.GetConnectionString("DefaultConnection"),
        ServerVersion.AutoDetect(builder.Configuration.GetConnectionString("DefaultConnection"))
    );
});

// Configuração do Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Construção da aplicação
var app = builder.Build();
#endregion

#region Home
// app.MapGet("/", () => "Hello World!");

// Redireciona a rota raiz ("/") diretamente para a documentação do Swagger.
// É uma prática comum para APIs em desenvolvimento para facilitar o acesso à documentação.
// app.MapGet("/", () => Results.Redirect("/swagger"));

// Outra abordagem é retornar uma mensagem de boas-vindas junto com o link para a documentação do Swagger.
// Isso pode ser útil para fornecer contexto adicional aos usuários que acessam a raiz da API.
// Aqui, estamos utilizando o record Home para estruturar a resposta.
// A URL da documentação do Swagger é construída dinamicamente com base no esquema e host da requisição.
// Isso garante que o link seja sempre correto, independentemente do ambiente em que a API esteja sendo executada.
// Exemplo de resposta JSON: {"message": "Welcome to the Minimal API", "doc": "http://localhost:5000/swagger"}
// Note que estamos utilizando Results.Json para retornar a resposta em formato JSON.
// Isso é importante para APIs, pois o JSON é um formato amplamente utilizado para troca de dados.
app.MapGet("/", (HttpContext context) =>
{
    var docUrl = $"{context.Request.Scheme}://{context.Request.Host}/swagger";
    var home = new Home("Welcome to the Minimal API", docUrl);
    return Results.Json(home);
}).WithTags("Home");
#endregion

#region Administrators

// Rota para cadastrar um administrador: DTO (Data Transfer Object) para receber os dados do administrador e serviço de administrador injetado.
app.MapPost("/Administrators", (AdministratorDTO administratorDTO, IServiceAdministrator serviceAdministrator) =>
{
    // Cria uma instância de ValidationErrors
    var messages = new ValidationErrors
    {
        // Inicializa a lista de mensagens de erro
        Messages = new List<string>()
        // Messages = [] // forma alternativa de inicialização simplificada
    };

    // Validação simples dos dados recebidos
    if (string.IsNullOrEmpty(administratorDTO.Email))
    {
        messages.Messages.Add("Email is required.");
    }
    if (string.IsNullOrEmpty(administratorDTO.Password))
    {
        messages.Messages.Add("Login is required.");
    }
    if (administratorDTO.Perfil == null || administratorDTO.Perfil == 0)
    {
        // Gera a lista de perfis válidos dinamicamente a partir do enum
        var validProfiles = string.Join(", ", Enum.GetNames(typeof(UserPerfil)).Select(p => $"'{p}'"));
        messages.Messages.Add($"Perfil cannot be null. Valid values are: {validProfiles}.");
    }

    // Se houver mensagens de erro, retorna 400 Bad Request com os erros
    if (messages.Messages.Count > 0)
    {
        return Results.BadRequest(messages);
    }

    // Mapeia os dados do DTO para a entidade Administrator
    var administrator = new Administrator(
        administratorDTO.Email,
        administratorDTO.Password,
        administratorDTO.Perfil?.ToString() ?? string.Empty
    );

    serviceAdministrator.Create(administrator);

    // Retorna a resposta com o status 201 Created e o administrador criado usando o modelo de visualização para não expor a senha
    return Results.Created($"/Administrators/{administrator.Id}", new AdministratorModelView
    {
        Id = administrator.Id,
        Email = administrator.Email,
        Perfil = administrator.Perfil.ToString()
    });

}).WithTags("Administrators");

// Rota para listar administradores com paginação: Query Parameters para página atual e serviço de administrador injetado.
app.MapGet("/Administrators", (int? CurrentPage, IServiceAdministrator serviceAdministrator) =>
{
    var adms = new List<AdministratorModelView>();
    var administrators = serviceAdministrator.GetAll(CurrentPage ?? 1);

    // Converte os administradores para o modelo de visualização (O objetivo deste modelo é não expor a senha do administrador)
    foreach (var administrator in administrators)
    {
        // Adiciona o administrador convertido à lista de administradores
        adms.Add(new AdministratorModelView
        {
            Id = administrator.Id,
            Email = administrator.Email,
            Perfil = administrator.Perfil.ToString()
        });
    }
    // Retorna a lista de administradores com status 200 OK
    return Results.Ok(adms);

}).WithTags("Administrators");

// Rota para buscar administrador por ID: Parâmetro de rota para o ID do administrador e serviço de administrador injetado.
app.MapGet("/Administrators/{id}", (string id, IServiceAdministrator serviceAdministrator) =>
{
    var administrator = serviceAdministrator.GetById(id);

    return administrator != null ? Results.Ok(new AdministratorModelView
    {
        Id = administrator.Id,
        Email = administrator.Email,
        Perfil = administrator.Perfil.ToString()
    }) : Results.NotFound();

}).WithTags("Administrators");

// Rota para deletar administrador por ID: Parâmetro de rota para o ID do administrador e serviço de administrador injetado.
app.MapDelete("/Administrators/{id}", (string id, IServiceAdministrator serviceAdministrator) =>
{
    var administrator = serviceAdministrator.GetById(id);

    if (administrator != null)
    {
        serviceAdministrator.Delete(administrator);
        return Results.NoContent();
    }
    else
    {
        return Results.NotFound();
    }
}).WithTags("Administrators");

// Rota para login do administrador: DTO (Data Transfer Object) para receber login e senha do administrador e serviço de administrador injetado.
app.MapPost("/Administrators/login", (LoginDTO loginDTO, IServiceAdministrator serviceAdministrator) =>
{
    if (serviceAdministrator.Login(loginDTO) != null)
    {
        return Results.Ok("Login successful!");
    }
    else
    {
        return Results.Unauthorized();
    }
}).WithTags("Administrators");
#endregion

#region Vehicles

// Função para validar os dados do DTO
static ValidationErrors validDTO(VehicleDTO vehicleDTO)
{
    // Cria uma instância de ValidationErrors
    var messages = new ValidationErrors
    {
        // Inicializa a lista de mensagens de erro
        Messages = new List<string>()
        // Messages = [] // forma alternativa de inicialização simplificada
    };

    // Validação simples dos dados recebidos
    if (string.IsNullOrEmpty(vehicleDTO.Name))
    {
        messages.Messages.Add("Name is required.");
    }
    if (string.IsNullOrEmpty(vehicleDTO.Brand))
    {
        messages.Messages.Add("Brand is required.");
    }
    if (string.IsNullOrEmpty(vehicleDTO.Model))
    {
        messages.Messages.Add("Model is required.");
    }
    if (vehicleDTO.Year <= 0)
    {
        messages.Messages.Add("Year must be a positive integer.");
    }
    else if (vehicleDTO.Year < 1950 || vehicleDTO.Year > DateTime.Now.Year + 1) // Considerando o próximo ano como válido
    {
        messages.Messages.Add($"Year must be between 1950 and {DateTime.Now.Year + 1}.");
    }

    return messages;
}

// Agrupa os endpoints de veículos sob o prefixo "/Vehicles" e a tag "Vehicles" no Swagger
var vehicleGroup = app.MapGroup("/Vehicles").WithTags("Vehicles");

// Rota para criar veículo: DTO (Data Transfer Object) para receber os dados do veículo e serviço de veículo injetado
vehicleGroup.MapPost("/", (VehicleDTO vehicleDTO, IServiceVehicle serviceVehicle) =>
{
    // Valida os dados do DTO
    var messages = validDTO(vehicleDTO);

    // Se houver mensagens de erro, retorna 400 Bad Request com os erros
    if (messages.Messages.Count > 0)
    {
        return Results.BadRequest(messages);
    }

    // Mapeia os dados do DTO para a entidade Vehicle
    var vehicle = new Vehicle(
        vehicleDTO.Name,
        vehicleDTO.Brand,
        vehicleDTO.Model,
        vehicleDTO.Year
    );

    // Salva o veículo no banco de dados
    serviceVehicle.Create(vehicle);

    // Retorna a resposta com o status 201 Created e o veículo criado
    return Results.Created($"/Vehicles/{vehicle.Id}", vehicle);
});

// Rota para listar veículos com paginação: Query Parameters para página atual e serviço de veículo injetado.
vehicleGroup.MapGet("/", (int? CurrentPage, IServiceVehicle serviceVehicle) =>
{
    var vehicles = serviceVehicle.GetAll(CurrentPage ?? 1);
    return Results.Ok(vehicles); // Retorna a lista de veículos com status 200 OK
});

// Rota para buscar veículo por ID: Parâmetro de rota para o ID do veículo e serviço de veículo injetado.
vehicleGroup.MapGet("/{id}", (int id, IServiceVehicle serviceVehicle) =>
{
    var vehicle = serviceVehicle.GetById(id);
    return vehicle != null ? Results.Ok(vehicle) : Results.NotFound();
});

// Rota para atualizar veículo por ID: Parâmetro de rota para o ID do veículo, DTO (Data Transfer Object) para receber os dados atualizados do veículo e o serviço de veículo injetado.
vehicleGroup.MapPut("/{id}", (int id, VehicleDTO vehicleDTO, IServiceVehicle serviceVehicle) =>
{
    // Busca o veículo existente no banco de dados pelo ID
    var vehicle = serviceVehicle.GetById(id);

    // Se o veículo não for encontrado, retorna 404 Not Found
    if (vehicle == null)
    {
        return Results.NotFound();
    }

    // Valida os dados do DTO
    var messages = validDTO(vehicleDTO);

    // Se houver mensagens de erro, retorna 400 Bad Request com os erros
    if (messages.Messages.Count > 0)
    {
        return Results.BadRequest(messages);
    }

    // Se o veículo for encontrado, atualiza os dados
    if (vehicle != null)
    {
        // Atualiza os campos do veículo com os dados do DTO
        vehicle.Name = vehicleDTO.Name;
        vehicle.Brand = vehicleDTO.Brand;
        vehicle.Model = vehicleDTO.Model;
        vehicle.Year = vehicleDTO.Year;

        // Atualiza o veículo no banco de dados
        serviceVehicle.Update(vehicle);

        // Retorna a resposta com o status 200 OK e o veículo atualizado
        return Results.Ok(vehicle);
    }

    // Adiciona um retorno padrão para garantir que todos os caminhos retornem um valor
    return Results.StatusCode(500);
});

// Rota para deletar veículo por ID: Parâmetro de rota para o ID do veículo e serviço de veículo injetado.
vehicleGroup.MapDelete("/{id}", (int id, IServiceVehicle serviceVehicle) =>
{
    var vehicle = serviceVehicle.GetById(id);

    if (vehicle != null)
    {
        serviceVehicle.Delete(vehicle);
        return Results.NoContent(); // Retorna 204 No Content indicando que a exclusão foi bem-sucedida
    }
    else
    {
        return Results.NotFound(); // Retorna 404 Not Found se o veículo não for encontrado
    }
});

#endregion

#region App
// Configure the HTTP request pipeline
app.UseSwagger();
app.UseSwaggerUI();

app.Run();
#endregion
