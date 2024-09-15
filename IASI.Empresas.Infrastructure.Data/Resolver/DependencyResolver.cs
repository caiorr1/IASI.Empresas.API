using IASI.Empresas.Domain.Interfaces;
using IASI.Empresas.Infrastructure.Data.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace IASI.Empresas.Infrastructure.Data.Resolver
{
    /// <summary>
    /// Classe para registrar os repositórios no serviço de injeção de dependência.
    /// </summary>
    public static class DependencyResolver
    {
        /// <summary>
        /// Registra os repositórios na coleção de serviços.
        /// </summary>
        /// <param name="services">A coleção de serviços do aplicativo.</param>
        public static void RegisterRepositories(IServiceCollection services)
        {
            services.AddScoped<IContatoRepository, ContatoRepository>();
            services.AddScoped<IDocumentoRepository, DocumentoRepository>();
            services.AddScoped<IEnderecoRepository, EnderecoRepository>();
            services.AddScoped<IRelatorioRepository, RelatorioRepository>();
            services.AddScoped<IRelatorioTipoRepository, RelatorioTipoRepository>();
            services.AddScoped<ISetorRepository, SetorRepository>();
            services.AddScoped<IUsuarioRepository, UsuarioRepository>();
            services.AddScoped<IEmpresaRepository, EmpresaRepository>();
        }
    }
}
