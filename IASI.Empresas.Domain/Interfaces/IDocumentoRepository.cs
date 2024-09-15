using System.Collections.Generic;
using System.Threading.Tasks;
using IASI.Empresas.Domain.Entities;

namespace IASI.Empresas.Domain.Interfaces
{
    /// <summary>
    /// Interface para o repositório de documentos.
    /// </summary>
    public interface IDocumentoRepository : IRepository<DocumentoEntity>
    {
        Task<IEnumerable<DocumentoEntity>> GetByEmpresaIdAsync(int empresaId);
        Task<IEnumerable<DocumentoEntity>> GetValidosAsync();
        Task<IEnumerable<DocumentoEntity>> GetExpiradosAsync();
    }
}
