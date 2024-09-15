using System.Collections.Generic;
using System.Threading.Tasks;
using IASI.Empresas.Domain.Entities;

namespace IASI.Empresas.Domain.Interfaces
{
    /// <summary>
    /// Interface para o repositório de empresas.
    /// </summary>
    public interface IEmpresaRepository : IRepository<EmpresaEntity>
    {
        Task<IEnumerable<EmpresaEntity>> GetBySetorAsync(string setor);
        Task<EmpresaEntity> GetByNomeAsync(string nome);
        Task<IEnumerable<EmpresaEntity>> GetEmpresasComConformidadeAsync(char conformidade);
    }
}
