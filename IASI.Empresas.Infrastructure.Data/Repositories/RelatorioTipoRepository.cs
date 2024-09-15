using IASI.Empresas.Domain.Entities;
using IASI.Empresas.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace IASI.Empresas.Infrastructure.Data.Repositories
{
    public class RelatorioTipoRepository : IRelatorioTipoRepository
    {
        private readonly AppDbContext _context;

        public RelatorioTipoRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<RelatorioTipoEntity>> GetAllAsync()
        {
            return await _context.RelatorioTipos.ToListAsync();
        }

        public async Task<RelatorioTipoEntity> GetByIdAsync(int id)
        {
            return await _context.RelatorioTipos.FindAsync(id);
        }

        public async Task<RelatorioTipoEntity> GetByNomeAsync(string nomeTipo)
        {
            return await _context.RelatorioTipos.FirstOrDefaultAsync(r => r.NomeTipo == nomeTipo);
        }

        public async Task AddAsync(RelatorioTipoEntity relatorioTipo)
        {
            await _context.RelatorioTipos.AddAsync(relatorioTipo);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(RelatorioTipoEntity relatorioTipo)
        {
            _context.RelatorioTipos.Update(relatorioTipo);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var relatorioTipo = await GetByIdAsync(id);
            if (relatorioTipo != null)
            {
                _context.RelatorioTipos.Remove(relatorioTipo);
                await _context.SaveChangesAsync();
            }
        }
    }
}
