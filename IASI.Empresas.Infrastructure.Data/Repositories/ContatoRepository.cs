using IASI.Empresas.Domain.Entities;
using IASI.Empresas.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IASI.Empresas.Infrastructure.Data.Repositories
{
    public class ContatoRepository : IContatoRepository
    {
        private readonly AppDbContext _context;

        public ContatoRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<ContatoEntity>> GetAllAsync()
        {
            return await _context.Contatos.ToListAsync();
        }

        public async Task<ContatoEntity> GetByIdAsync(int id)
        {
            return await _context.Contatos.FindAsync(id);
        }

        public async Task<IEnumerable<ContatoEntity>> GetByEmpresaIdAsync(int empresaId)
        {
            return await _context.Contatos.Where(c => c.EmpresaId == empresaId).ToListAsync();
        }

        public async Task<ContatoEntity> GetByEmailAsync(string email)
        {
            return await _context.Contatos.FirstOrDefaultAsync(c => c.EmailContato == email);
        }

        public async Task AddAsync(ContatoEntity contato)
        {
            await _context.Contatos.AddAsync(contato);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(ContatoEntity contato)
        {
            _context.Contatos.Update(contato);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var contato = await GetByIdAsync(id);
            if (contato != null)
            {
                _context.Contatos.Remove(contato);
                await _context.SaveChangesAsync();
            }
        }
    }
}
