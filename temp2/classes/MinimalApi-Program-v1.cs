using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

var builder = WebApplication.CreateBuilder(args);

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
app.MapPost("/login", (LoginDTO loginDTO) =>
{
    if (loginDTO.Email == "heviane@gmail.com" && loginDTO.Password == "123456")
    {
        return Results.Ok("Login successful!");
    }
    else
    {
        return Results.Unauthorized();
    }
});

app.Run();
