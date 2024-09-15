using System.Collections.Generic;
using System.Threading.Tasks;
using IASI.Empresas.Domain.Entities;
using IASI.Empresas.Domain.Interfaces;
using IASI.Empresas.Domain.Dtos;

namespace IASI.Empresas.Application.Services
{
    public class SetorService
    {
        private readonly ISetorRepository _setorRepository;

        public SetorService(ISetorRepository setorRepository)
        {
            _setorRepository = setorRepository;
        }

        public async Task<IEnumerable<SetorDTO>> GetAllSetoresAsync()
        {
            var setores = await _setorRepository.GetAllAsync();
            var setorDTOs = new List<SetorDTO>();

            foreach (var setor in setores)
            {
                setorDTOs.Add(new SetorDTO
                {
                    Id = setor.Id,
                    NomeSetor = setor.NomeSetor
                });
            }
            return setorDTOs;
        }

        public async Task<SetorDTO> GetSetorByIdAsync(int id)
        {
            var setor = await _setorRepository.GetByIdAsync(id);
            if (setor == null) return null;

            return new SetorDTO
            {
                Id = setor.Id,
                NomeSetor = setor.NomeSetor
            };
        }

        public async Task AddSetorAsync(SetorDTO setorDTO)
        {
            var setor = new SetorEntity
            {
                NomeSetor = setorDTO.NomeSetor,
                DataCriacao = DateTime.UtcNow
            };
            await _setorRepository.AddAsync(setor);
        }

        public async Task UpdateSetorAsync(SetorDTO setorDTO)
        {
            var setor = await _setorRepository.GetByIdAsync(setorDTO.Id);
            if (setor != null)
            {
                setor.NomeSetor = setorDTO.NomeSetor;
                setor.DataAtualizacao = DateTime.UtcNow;
                await _setorRepository.UpdateAsync(setor);
            }
        }

        public async Task DeleteSetorAsync(int id)
        {
            await _setorRepository.DeleteAsync(id);
        }
    }
}
