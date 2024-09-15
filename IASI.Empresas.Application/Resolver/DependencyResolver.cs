using Microsoft.Extensions.DependencyInjection;
using IASI.Empresas.Application.Services;

namespace IASI.Empresas.Application.Resolver
{
    /// <summary>
    /// Classe para configurar a injeção de dependências dos serviços da aplicação.
    /// </summary>
    public static class DependencyResolver
    {
        /// <summary>
        /// Registra os serviços da aplicação para injeção de dependências.
        /// </summary>
        /// <param name="services">A coleção de serviços do aplicativo.</param>
        public static void RegisterServices(IServiceCollection services)
        {
            services.AddScoped<EmpresaService>();
            services.AddScoped<ContatoService>();
            services.AddScoped<DocumentoService>();
            services.AddScoped<EnderecoService>();
            services.AddScoped<RelatorioService>();
            services.AddScoped<RelatorioTipoService>();
            services.AddScoped<SetorService>();
            services.AddScoped<UsuarioService>();
        }
    }
}
