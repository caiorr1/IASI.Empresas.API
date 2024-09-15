using System.Collections.Generic;
using System.Threading.Tasks;
using IASI.Empresas.Domain.Entities;
using IASI.Empresas.Domain.Interfaces;
using IASI.Empresas.Domain.Dtos;

namespace IASI.Empresas.Application.Services
{
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
            var empresaDTOs = new List<EmpresaDTO>();

            foreach (var empresa in empresas)
            {
                empresaDTOs.Add(new EmpresaDTO
                {
                    Id = empresa.Id,
                    NomeEmpresa = empresa.NomeEmpresa,
                    SetorIndustrialEmpresa = empresa.SetorIndustrialEmpresa,
                    LocalizacaoEmpresa = empresa.LocalizacaoEmpresa,
                    TipoEmpresa = empresa.TipoEmpresa,
                    ConformidadeRegulamentar = empresa.ConformidadeRegulamentar
                });
            }
            return empresaDTOs;
        }

        public async Task<EmpresaDTO> GetEmpresaByIdAsync(int id)
        {
            var empresa = await _empresaRepository.GetByIdAsync(id);
            if (empresa == null) return null;

            return new EmpresaDTO
            {
                Id = empresa.Id,
                NomeEmpresa = empresa.NomeEmpresa,
                SetorIndustrialEmpresa = empresa.SetorIndustrialEmpresa,
                LocalizacaoEmpresa = empresa.LocalizacaoEmpresa,
                TipoEmpresa = empresa.TipoEmpresa,
                ConformidadeRegulamentar = empresa.ConformidadeRegulamentar
            };
        }

        public async Task AddEmpresaAsync(EmpresaDTO empresaDTO)
        {
            var empresa = new EmpresaEntity
            {
                NomeEmpresa = empresaDTO.NomeEmpresa,
                SetorIndustrialEmpresa = empresaDTO.SetorIndustrialEmpresa,
                LocalizacaoEmpresa = empresaDTO.LocalizacaoEmpresa,
                TipoEmpresa = empresaDTO.TipoEmpresa,
                ConformidadeRegulamentar = empresaDTO.ConformidadeRegulamentar,
                DataCriacao = DateTime.UtcNow
            };
            await _empresaRepository.AddAsync(empresa);
        }

        public async Task UpdateEmpresaAsync(EmpresaDTO empresaDTO)
        {
            var empresa = await _empresaRepository.GetByIdAsync(empresaDTO.Id);
            if (empresa != null)
            {
                empresa.NomeEmpresa = empresaDTO.NomeEmpresa;
                empresa.SetorIndustrialEmpresa = empresaDTO.SetorIndustrialEmpresa;
                empresa.LocalizacaoEmpresa = empresaDTO.LocalizacaoEmpresa;
                empresa.TipoEmpresa = empresaDTO.TipoEmpresa;
                empresa.ConformidadeRegulamentar = empresaDTO.ConformidadeRegulamentar;
                empresa.DataAtualizacao = DateTime.UtcNow;
                await _empresaRepository.UpdateAsync(empresa);
            }
        }

        public async Task DeleteEmpresaAsync(int id)
        {
            await _empresaRepository.DeleteAsync(id);
        }
    }
}
