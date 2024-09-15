using System.Collections.Generic;
using System.Threading.Tasks;

namespace IASI.Empresas.Domain.Interfaces
{
    /// <summary>
    /// Interface genérica para operações de repositório comuns.
    /// </summary>
    /// <typeparam name="TEntity">Tipo da entidade.</typeparam>
    public interface IRepository<TEntity> where TEntity : class
    {
        Task<IEnumerable<TEntity>> GetAllAsync();
        Task<TEntity> GetByIdAsync(int id);
        Task AddAsync(TEntity entity);
        Task UpdateAsync(TEntity entity);
        Task DeleteAsync(int id);
    }
}
