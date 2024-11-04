using Microsoft.Extensions.DependencyInjection;
using IASI.Empresas.Application.Services;
using IASI.Empresas.Domain.Interfaces;
using IASI.Empresas.Infrastructure.Data.Repositories;
using System.Net.Http;


namespace IASI.Empresas.Infrastructure.IoC
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddProjectDependencies(this IServiceCollection services)
        {
            services.AddScoped<EmpresaService>();
            services.AddScoped<ContatoService>();
            services.AddScoped<DocumentoService>();
            services.AddScoped<EnderecoService>();
            services.AddScoped<RelatorioService>();
            services.AddScoped<RelatorioTipoService>();
            services.AddScoped<SetorService>();
            services.AddScoped<UsuarioService>();

            services.AddScoped<IEmpresaRepository, EmpresaRepository>();
            services.AddScoped<IContatoRepository, ContatoRepository>();
            services.AddScoped<IDocumentoRepository, DocumentoRepository>();
            services.AddScoped<IEnderecoRepository, EnderecoRepository>();
            services.AddScoped<IRelatorioRepository, RelatorioRepository>();
            services.AddScoped<IRelatorioTipoRepository, RelatorioTipoRepository>();
            services.AddScoped<ISetorRepository, SetorRepository>();
            services.AddScoped<IUsuarioRepository, UsuarioRepository>();

            services.AddHttpClient<CepService>();

            return services;
        }
    }
}
