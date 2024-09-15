using System.Threading.Tasks;
using IASI.Empresas.Domain.Entities;

namespace IASI.Empresas.Domain.Interfaces
{
    /// <summary>
    /// Interface para o repositório de usuários.
    /// </summary>
    public interface IUsuarioRepository : IRepository<UsuarioEntity>
    {
        Task<UsuarioEntity> GetByEmailAsync(string email);
        Task<IEnumerable<UsuarioEntity>> GetByRoleAsync(string role);
    }
}
