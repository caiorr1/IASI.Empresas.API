using System.Threading.Tasks;
using IASI.Empresas.Domain.Entities;

namespace IASI.Empresas.Domain.Interfaces
{
    /// <summary>
    /// Interface para o repositório de setores.
    /// </summary>
    public interface ISetorRepository : IRepository<SetorEntity>
    {
        Task<SetorEntity> GetByNomeAsync(string nomeSetor);
    }
}
