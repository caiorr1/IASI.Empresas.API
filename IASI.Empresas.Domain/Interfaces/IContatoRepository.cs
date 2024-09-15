using System.Collections.Generic;
using System.Threading.Tasks;
using IASI.Empresas.Domain.Entities;

namespace IASI.Empresas.Domain.Interfaces
{
    /// <summary>
    /// Interface para o repositório de contatos.
    /// </summary>
    public interface IContatoRepository : IRepository<ContatoEntity>
    {
        Task<IEnumerable<ContatoEntity>> GetByEmpresaIdAsync(int empresaId);
        Task<ContatoEntity> GetByEmailAsync(string email);
    }
}
