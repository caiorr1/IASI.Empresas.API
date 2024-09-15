using IASI.Empresas.Domain.Entities;
using IASI.Empresas.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IASI.Empresas.Infrastructure.Data.Repositories
{
    public class EnderecoRepository : IEnderecoRepository
    {
        private readonly AppDbContext _context;

        public EnderecoRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<EnderecoEntity>> GetAllAsync()
        {
            return await _context.Enderecos.ToListAsync();
        }

        public async Task<EnderecoEntity> GetByIdAsync(int id)
        {
            return await _context.Enderecos.FindAsync(id);
        }

        public async Task<IEnumerable<EnderecoEntity>> GetByEmpresaIdAsync(int empresaId)
        {
            return await _context.Enderecos.Where(e => e.EmpresaId == empresaId).ToListAsync();
        }

        public async Task<IEnumerable<EnderecoEntity>> GetByCidadeAsync(string cidade)
        {
            return await _context.Enderecos.Where(e => e.Cidade == cidade).ToListAsync();
        }

        public async Task AddAsync(EnderecoEntity endereco)
        {
            await _context.Enderecos.AddAsync(endereco);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(EnderecoEntity endereco)
        {
            _context.Enderecos.Update(endereco);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var endereco = await GetByIdAsync(id);
            if (endereco != null)
            {
                _context.Enderecos.Remove(endereco);
                await _context.SaveChangesAsync();
            }
        }
    }
}
