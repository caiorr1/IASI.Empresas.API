using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.OpenApi.Models;
using IASI.Empresas.Infrastructure.IoC;
using IASI.Empresas.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;

var builder = WebApplication.CreateBuilder(args);

// Configura��es do appsettings.json
var configuration = builder.Configuration;
var connectionString = configuration.GetConnectionString("DefaultConnection");

// Configura��o da conex�o com o banco de dados Oracle
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseOracle(connectionString));

// Configura��o dos servi�os e inje��o de depend�ncias
builder.Services.AddProjectDependencies();

// Configura��o de controladores e Swagger para documenta��o
builder.Services.AddControllers();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "API de Empresas e Relat�rios",
        Version = "v1",
        Description = "Documenta��o da API para gerenciamento de empresas, contatos, relat�rios e mais."
    });

    // Configura��o para incluir o XML de documenta��o
    var xmlFile = $"{System.Reflection.Assembly.GetExecutingAssembly().GetName().Name}.xml";
    var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
    c.IncludeXmlComments(xmlPath);
});

var app = builder.Build();

// Configura��o do pipeline HTTP
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();

app.MapControllers();

app.Run();
