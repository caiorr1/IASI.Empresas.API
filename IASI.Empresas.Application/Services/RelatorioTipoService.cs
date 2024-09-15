using System.Collections.Generic;
using System.Threading.Tasks;
using IASI.Empresas.Domain.Entities;
using IASI.Empresas.Domain.Interfaces;
using IASI.Empresas.Domain.Dtos;

namespace IASI.Empresas.Application.Services
{
    public class RelatorioTipoService
    {
        private readonly IRelatorioTipoRepository _relatorioTipoRepository;

        public RelatorioTipoService(IRelatorioTipoRepository relatorioTipoRepository)
        {
            _relatorioTipoRepository = relatorioTipoRepository;
        }

        public async Task<IEnumerable<RelatorioTipoDTO>> GetAllRelatorioTiposAsync()
        {
            var relatorioTipos = await _relatorioTipoRepository.GetAllAsync();
            var relatorioTipoDTOs = new List<RelatorioTipoDTO>();

            foreach (var tipo in relatorioTipos)
            {
                relatorioTipoDTOs.Add(new RelatorioTipoDTO
                {
                    Id = tipo.Id,
                    NomeTipo = tipo.NomeTipo
                });
            }
            return relatorioTipoDTOs;
        }

        public async Task<RelatorioTipoDTO> GetRelatorioTipoByIdAsync(int id)
        {
            var tipo = await _relatorioTipoRepository.GetByIdAsync(id);
            if (tipo == null) return null;

            return new RelatorioTipoDTO
            {
                Id = tipo.Id,
                NomeTipo = tipo.NomeTipo
            };
        }

        public async Task AddRelatorioTipoAsync(RelatorioTipoDTO relatorioTipoDTO)
        {
            var tipo = new RelatorioTipoEntity
            {
                NomeTipo = relatorioTipoDTO.NomeTipo,
                DataCriacao = DateTime.UtcNow
            };
            await _relatorioTipoRepository.AddAsync(tipo);
        }

        public async Task UpdateRelatorioTipoAsync(RelatorioTipoDTO relatorioTipoDTO)
        {
            var tipo = await _relatorioTipoRepository.GetByIdAsync(relatorioTipoDTO.Id);
            if (tipo != null)
            {
                tipo.NomeTipo = relatorioTipoDTO.NomeTipo;
                tipo.DataAtualizacao = DateTime.UtcNow;
                await _relatorioTipoRepository.UpdateAsync(tipo);
            }
        }

        public async Task DeleteRelatorioTipoAsync(int id)
        {
            await _relatorioTipoRepository.DeleteAsync(id);
        }
    }
}
