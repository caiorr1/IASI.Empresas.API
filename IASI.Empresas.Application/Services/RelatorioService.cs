using System.Collections.Generic;
using System.Threading.Tasks;
using IASI.Empresas.Domain.Entities;
using IASI.Empresas.Domain.Interfaces;
using IASI.Empresas.Domain.Dtos;

namespace IASI.Empresas.Application.Services
{
    public class RelatorioService
    {
        private readonly IRelatorioRepository _relatorioRepository;

        public RelatorioService(IRelatorioRepository relatorioRepository)
        {
            _relatorioRepository = relatorioRepository;
        }

        public async Task<IEnumerable<RelatorioDTO>> GetAllRelatoriosAsync()
        {
            var relatorios = await _relatorioRepository.GetAllAsync();
            var relatorioDTOs = new List<RelatorioDTO>();

            foreach (var relatorio in relatorios)
            {
                relatorioDTOs.Add(new RelatorioDTO
                {
                    Id = relatorio.Id,
                    EmpresaId = relatorio.EmpresaId,
                    TipoRelatorio = relatorio.TipoRelatorio,
                    Descricao = relatorio.Descricao,
                    DataGeracao = relatorio.DataGeracao
                });
            }
            return relatorioDTOs;
        }

        public async Task<RelatorioDTO> GetRelatorioByIdAsync(int id)
        {
            var relatorio = await _relatorioRepository.GetByIdAsync(id);
            if (relatorio == null) return null;

            return new RelatorioDTO
            {
                Id = relatorio.Id,
                EmpresaId = relatorio.EmpresaId,
                TipoRelatorio = relatorio.TipoRelatorio,
                Descricao = relatorio.Descricao,
                DataGeracao = relatorio.DataGeracao
            };
        }

        public async Task AddRelatorioAsync(RelatorioDTO relatorioDTO)
        {
            var relatorio = new RelatorioEntity
            {
                EmpresaId = relatorioDTO.EmpresaId,
                TipoRelatorio = relatorioDTO.TipoRelatorio,
                Descricao = relatorioDTO.Descricao,
                DataGeracao = relatorioDTO.DataGeracao,
                DataCriacao = DateTime.UtcNow
            };
            await _relatorioRepository.AddAsync(relatorio);
        }

        public async Task UpdateRelatorioAsync(RelatorioDTO relatorioDTO)
        {
            var relatorio = await _relatorioRepository.GetByIdAsync(relatorioDTO.Id);
            if (relatorio != null)
            {
                relatorio.TipoRelatorio = relatorioDTO.TipoRelatorio;
                relatorio.Descricao = relatorioDTO.Descricao;
                relatorio.DataGeracao = relatorioDTO.DataGeracao;
                relatorio.DataAtualizacao = DateTime.UtcNow;
                await _relatorioRepository.UpdateAsync(relatorio);
            }
        }

        public async Task DeleteRelatorioAsync(int id)
        {
            await _relatorioRepository.DeleteAsync(id);
        }
    }
}
