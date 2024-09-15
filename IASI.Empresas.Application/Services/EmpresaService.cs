using System.Collections.Generic;
using System.Threading.Tasks;
using IASI.Empresas.Domain.Entities;
using IASI.Empresas.Domain.Interfaces;
using IASI.Empresas.Domain.Dtos;

namespace IASI.Empresas.Application.Services
{
    /// <summary>
    /// Serviço para gerenciar operações relacionadas a empresas.
    /// </summary>
    public class EmpresaService
    {
        private readonly IEmpresaRepository _empresaRepository;

        public EmpresaService(IEmpresaRepository empresaRepository)
        {
            _empresaRepository = empresaRepository;
        }

        public async Task<IEnumerable<EmpresaDTO>> GetAllEmpresasAsync()
        {
            var empresas = await _empresaRepository.GetAllAsync();
            // Mapeamento de entidades para DTOs
            var empresaDTOs = new List<EmpresaDTO>();
            foreach (var empresa in empresas)
            {
                empresaDTOs.Add(new EmpresaDTO
                {
                    Id = empresa.Id,
                    Nome = empresa.NomeEmpresa,
                    SetorIndustrial = empresa.SetorIndustrialEmpresa,
                    Localizacao = empresa.LocalizacaoEmpresa,
                    ConformidadeRegulamentar = empresa.ConformidadeRegulamentar
                });
            }
            return empresaDTOs;
        }

        public async Task<EmpresaDTO> GetEmpresaByIdAsync(int id)
        {
            var empresa = await _empresaRepository.GetByIdAsync(id);
            if (empresa == null)
                return null;

            return new EmpresaDTO
            {
                Id = empresa.Id,
                Nome = empresa.Nome,
                SetorIndustrial = empresa.SetorIndustrial,
                Localizacao = empresa.Localizacao,
                ConformidadeRegulamentar = empresa.ConformidadeRegulamentar
            };
        }

        public async Task AddEmpresaAsync(EmpresaDTO empresaDTO)
        {
            var empresa = new EmpresaEntity
            {
                Nome = empresaDTO.Nome,
                SetorIndustrial = empresaDTO.SetorIndustrial,
                Localizacao = empresaDTO.Localizacao,
                ConformidadeRegulamentar = empresaDTO.ConformidadeRegulamentar
            };
            await _empresaRepository.AddAsync(empresa);
        }

        public async Task UpdateEmpresaAsync(EmpresaDTO empresaDTO)
        {
            var empresa = await _empresaRepository.GetByIdAsync(empresaDTO.Id);
            if (empresa != null)
            {
                empresa.Nome = empresaDTO.Nome;
                empresa.SetorIndustrial = empresaDTO.SetorIndustrial;
                empresa.Localizacao = empresaDTO.Localizacao;
                empresa.ConformidadeRegulamentar = empresaDTO.ConformidadeRegulamentar;
                await _empresaRepository.UpdateAsync(empresa);
            }
        }

        public async Task DeleteEmpresaAsync(int id)
        {
            await _empresaRepository.DeleteAsync(id);
        }
    }
}
