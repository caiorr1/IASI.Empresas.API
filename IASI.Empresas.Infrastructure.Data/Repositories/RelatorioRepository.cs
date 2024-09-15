using IASI.Empresas.Domain.Entities;
using IASI.Empresas.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IASI.Empresas.Infrastructure.Data.Repositories
{
    public class RelatorioRepository : IRelatorioRepository
    {
        private readonly AppDbContext _context;

        public RelatorioRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<RelatorioEntity>> GetAllAsync()
        {
            return await _context.Relatorios.ToListAsync();
        }

        public async Task<RelatorioEntity> GetByIdAsync(int id)
        {
            return await _context.Relatorios.FindAsync(id);
        }

        public async Task<IEnumerable<RelatorioEntity>> GetByEmpresaIdAsync(int empresaId)
        {
            return await _context.Relatorios.Where(r => r.EmpresaId == empresaId).ToListAsync();
        }

        public async Task<IEnumerable<RelatorioEntity>> GetByTipoAsync(string tipoRelatorio)
        {
            return await _context.Relatorios.Where(r => r.TipoRelatorio == tipoRelatorio).ToListAsync();
        }

        public async Task<IEnumerable<RelatorioEntity>> GetRecentesAsync(int quantidade)
        {
            return await _context.Relatorios.OrderByDescending(r => r.DataGeracao).Take(quantidade).ToListAsync();
        }

        public async Task AddAsync(RelatorioEntity relatorio)
        {
            await _context.Relatorios.AddAsync(relatorio);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(RelatorioEntity relatorio)
        {
            _context.Relatorios.Update(relatorio);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var relatorio = await GetByIdAsync(id);
            if (relatorio != null)
            {
                _context.Relatorios.Remove(relatorio);
                await _context.SaveChangesAsync();
            }
        }
    }
}
