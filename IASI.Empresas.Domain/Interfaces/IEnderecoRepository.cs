using System.Collections.Generic;
using System.Threading.Tasks;
using IASI.Empresas.Domain.Entities;

namespace IASI.Empresas.Domain.Interfaces
{
    /// <summary>
    /// Interface para o repositório de endereços.
    /// </summary>
    public interface IEnderecoRepository : IRepository<EnderecoEntity>
    {
        Task<IEnumerable<EnderecoEntity>> GetByEmpresaIdAsync(int empresaId);
        Task<IEnumerable<EnderecoEntity>> GetByCidadeAsync(string cidade);
    }
}
