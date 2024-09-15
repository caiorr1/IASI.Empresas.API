using Microsoft.Extensions.DependencyInjection;
using IASI.Empresas.Application.Services;
using IASI.Empresas.Domain.Interfaces;
using IASI.Empresas.Infrastructure.Data.Repositories;

namespace IASI.Empresas.Infrastructure.IoC
{
    /// <summary>
    /// Classe para configurar a injeção de dependências do projeto.
    /// </summary>
    public static class DependencyInjection
    {
        /// <summary>
        /// Método de extensão para registrar todos os serviços e repositórios para injeção de dependências.
        /// </summary>
        /// <param name="services">A coleção de serviços do aplicativo.</param>
        public static IServiceCollection AddProjectDependencies(this IServiceCollection services)
        {
            // Registrando os serviços da camada Application
            services.AddScoped<EmpresaService>();
            services.AddScoped<ContatoService>();
            services.AddScoped<DocumentoService>();
            services.AddScoped<EnderecoService>();
            services.AddScoped<RelatorioService>();
            services.AddScoped<RelatorioTipoService>();
            services.AddScoped<SetorService>();
            services.AddScoped<UsuarioService>();

            // Registrando os repositórios da camada Domain/Infrastructure
            services.AddScoped<IEmpresaRepository, EmpresaRepository>();
            services.AddScoped<IContatoRepository, ContatoRepository>();
            services.AddScoped<IDocumentoRepository, DocumentoRepository>();
            services.AddScoped<IEnderecoRepository, EnderecoRepository>();
            services.AddScoped<IRelatorioRepository, RelatorioRepository>();
            services.AddScoped<IRelatorioTipoRepository, RelatorioTipoRepository>();
            services.AddScoped<ISetorRepository, SetorRepository>();
            services.AddScoped<IUsuarioRepository, UsuarioRepository>();

            // Outros registros de dependências podem ser adicionados aqui

            return services;
        }
    }
}
