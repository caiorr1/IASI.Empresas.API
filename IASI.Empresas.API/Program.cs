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

// Configurações do appsettings.json
var configuration = builder.Configuration;
var connectionString = configuration.GetConnectionString("DefaultConnection");

// Configuração da conexão com o banco de dados Oracle
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseOracle(connectionString));

// Configuração dos serviços e injeção de dependências
builder.Services.AddProjectDependencies();

// Configuração de controladores e Swagger para documentação
builder.Services.AddControllers();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "API de Empresas e Relatórios",
        Version = "v1",
        Description = "Documentação da API para gerenciamento de empresas, contatos, relatórios e mais."
    });

    // Configuração para incluir o XML de documentação
    var xmlFile = $"{System.Reflection.Assembly.GetExecutingAssembly().GetName().Name}.xml";
    var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
    c.IncludeXmlComments(xmlPath);
});

var app = builder.Build();

// Configuração do pipeline HTTP
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();

app.MapControllers();

app.Run();
