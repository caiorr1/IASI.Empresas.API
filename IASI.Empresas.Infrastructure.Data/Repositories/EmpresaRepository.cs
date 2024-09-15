using IASI.Empresas.Domain.Entities;
using IASI.Empresas.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace IASI.Empresas.Infrastructure.Data.Repositories
{
    public class EmpresaRepository : IEmpresaRepository
    {
        private readonly AppDbContext _context;

        public EmpresaRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<EmpresaEntity>> GetAllAsync()
        {
            return await _context.Empresas.Include(e => e.Contatos)
                                          .Include(e => e.Documentos)
                                          .Include(e => e.Enderecos)
                                          .Include(e => e.Relatorios)
                                          .ToListAsync();
        }

        public async Task<EmpresaEntity> GetByIdAsync(int id)
        {
            return await _context.Empresas.Include(e => e.Contatos)
                                          .Include(e => e.Documentos)
                                          .Include(e => e.Enderecos)
                                          .Include(e => e.Relatorios)
                                          .FirstOrDefaultAsync(e => e.Id == id);
        }

        public async Task AddAsync(EmpresaEntity empresa)
        {
            await _context.Empresas.AddAsync(empresa);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(EmpresaEntity empresa)
        {
            _context.Empresas.Update(empresa);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var empresa = await GetByIdAsync(id);
            if (empresa != null)
            {
                _context.Empresas.Remove(empresa);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<EmpresaEntity>> GetBySetorAsync(string setor)
        {
            return await _context.Empresas.Include(e => e.Contatos)
                                          .Include(e => e.Documentos)
                                          .Include(e => e.Enderecos)
                                          .Include(e => e.Relatorios)
                                          .Where(e => e.SetorIndustrialEmpresa == setor)
                                          .ToListAsync();
        }

        public async Task<EmpresaEntity> GetByNomeAsync(string nome)
        {
            return await _context.Empresas.Include(e => e.Contatos)
                                          .Include(e => e.Documentos)
                                          .Include(e => e.Enderecos)
                                          .Include(e => e.Relatorios)
                                          .FirstOrDefaultAsync(e => e.NomeEmpresa == nome);
        }

        public async Task<IEnumerable<EmpresaEntity>> GetEmpresasComConformidadeAsync(char conformidade)
        {
            return await _context.Empresas.Include(e => e.Contatos)
                                          .Include(e => e.Documentos)
                                          .Include(e => e.Enderecos)
                                          .Include(e => e.Relatorios)
                                          .Where(e => e.ConformidadeRegulamentar == conformidade)
                                          .ToListAsync();
        }
    }
}
