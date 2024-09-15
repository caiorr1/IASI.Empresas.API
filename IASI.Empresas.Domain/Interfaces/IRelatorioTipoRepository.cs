using System.Threading.Tasks;
using IASI.Empresas.Domain.Entities;

namespace IASI.Empresas.Domain.Interfaces
{
    /// <summary>
    /// Interface para o repositório de tipos de relatórios.
    /// </summary>
    public interface IRelatorioTipoRepository : IRepository<RelatorioTipoEntity>
    {
        Task<RelatorioTipoEntity> GetByNomeAsync(string nomeTipo);
    }
}
