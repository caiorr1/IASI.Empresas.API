using IASI.Empresas.Domain.Entities;
using IASI.Empresas.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IASI.Empresas.Infrastructure.Data.Repositories
{
    public class DocumentoRepository : IDocumentoRepository
    {
        private readonly AppDbContext _context;

        public DocumentoRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<DocumentoEntity>> GetAllAsync()
        {
            return await _context.Documentos.ToListAsync();
        }

        public async Task<DocumentoEntity> GetByIdAsync(int id)
        {
            return await _context.Documentos.FindAsync(id);
        }

        public async Task<IEnumerable<DocumentoEntity>> GetByEmpresaIdAsync(int empresaId)
        {
            return await _context.Documentos.Where(d => d.EmpresaId == empresaId).ToListAsync();
        }

        public async Task<IEnumerable<DocumentoEntity>> GetValidosAsync()
        {
            return await _context.Documentos.Where(d => d.DataValidade == null || d.DataValidade > DateTime.Now).ToListAsync();
        }

        public async Task<IEnumerable<DocumentoEntity>> GetExpiradosAsync()
        {
            return await _context.Documentos.Where(d => d.DataValidade < DateTime.Now).ToListAsync();
        }

        public async Task AddAsync(DocumentoEntity documento)
        {
            await _context.Documentos.AddAsync(documento);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(DocumentoEntity documento)
        {
            _context.Documentos.Update(documento);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var documento = await GetByIdAsync(id);
            if (documento != null)
            {
                _context.Documentos.Remove(documento);
                await _context.SaveChangesAsync();
            }
        }
    }
}
