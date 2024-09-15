using IASI.Empresas.Domain.Entities;
using IASI.Empresas.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace IASI.Empresas.Infrastructure.Data.Repositories
{
    public class SetorRepository : ISetorRepository
    {
        private readonly AppDbContext _context;

        public SetorRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<SetorEntity>> GetAllAsync()
        {
            return await _context.Setores.ToListAsync();
        }

        public async Task<SetorEntity> GetByIdAsync(int id)
        {
            return await _context.Setores.FindAsync(id);
        }

        public async Task<SetorEntity> GetByNomeAsync(string nomeSetor)
        {
            return await _context.Setores.FirstOrDefaultAsync(s => s.NomeSetor == nomeSetor);
        }

        public async Task AddAsync(SetorEntity setor)
        {
            await _context.Setores.AddAsync(setor);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(SetorEntity setor)
        {
            _context.Setores.Update(setor);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var setor = await GetByIdAsync(id);
            if (setor != null)
            {
                _context.Setores.Remove(setor);
                await _context.SaveChangesAsync();
            }
        }
    }
}
