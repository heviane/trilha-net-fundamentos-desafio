using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

using Microsoft.EntityFrameworkCore;
using Pomelo.EntityFrameworkCore.MySql.Infrastructure;

using MinimalApi.domain.dtos;
using MinimalApi.domain.interfaces;
using MinimalApi.domain.services;
using MinimalApi.infrastructure.db;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddScoped<IServiceAdministrator, ServiceAdministrator>();
builder.Services.AddDbContext<DbContexto>(options =>
{
    options.UseMySql(
        builder.Configuration.GetConnectionString("DefaultConnection"),
        ServerVersion.AutoDetect(builder.Configuration.GetConnectionString("DefaultConnection"))
    );
});

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
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

// DTO (Data Transfer Object) para receber login
app.MapPost("/login", (LoginDTO loginDTO, IServiceAdministrator serviceAdministrator) =>
{
    if (serviceAdministrator.Login(loginDTO) != null)
    {
        return Results.Ok("Login successful!");
    }
    else
    {
        return Results.Unauthorized();
    }
});

app.Run();
