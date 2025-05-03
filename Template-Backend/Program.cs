using InfrastructureTemplate.Application.Interfaces;
using InfrastructureTemplate.Context;
using InfrastructureTemplate.UnitOfWork;
using Microsoft.EntityFrameworkCore;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
// Configurar DbContext
//builder.Services.AddDbContext<AppDbContext>(options =>
//    options.UseInMemoryDatabase("TestDb")); // Puedes cambiar a SQL Server

// Inyecciones de dependencias
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
