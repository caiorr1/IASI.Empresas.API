using System.Collections.Generic;
using System.Threading.Tasks;
using IASI.Empresas.Domain.Entities;

namespace IASI.Empresas.Domain.Interfaces
{
    /// <summary>
    /// Interface para o repositório de relatórios.
    /// </summary>
    public interface IRelatorioRepository : IRepository<RelatorioEntity>
    {
        Task<IEnumerable<RelatorioEntity>> GetByEmpresaIdAsync(int empresaId);
        Task<IEnumerable<RelatorioEntity>> GetByTipoAsync(string tipoRelatorio);
        Task<IEnumerable<RelatorioEntity>> GetRecentesAsync(int quantidade);
    }
}
