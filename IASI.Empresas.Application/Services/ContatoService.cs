using System.Collections.Generic;
using System.Threading.Tasks;
using IASI.Empresas.Domain.Entities;
using IASI.Empresas.Domain.Interfaces;
using IASI.Empresas.Domain.Dtos;

namespace IASI.Empresas.Application.Services
{
    public class ContatoService
    {
        private readonly IContatoRepository _contatoRepository;

        public ContatoService(IContatoRepository contatoRepository)
        {
            _contatoRepository = contatoRepository;
        }

        public async Task<IEnumerable<ContatoDTO>> GetAllContatosAsync()
        {
            var contatos = await _contatoRepository.GetAllAsync();
            var contatoDTOs = new List<ContatoDTO>();

            foreach (var contato in contatos)
            {
                contatoDTOs.Add(new ContatoDTO
                {
                    Id = contato.Id,
                    EmpresaId = contato.EmpresaId,
                    NomeContato = contato.NomeContato,
                    CargoContato = contato.CargoContato,
                    EmailContato = contato.EmailContato,
                    TelefoneContato = contato.TelefoneContato
                });
            }
            return contatoDTOs;
        }

        public async Task<ContatoDTO> GetContatoByIdAsync(int id)
        {
            var contato = await _contatoRepository.GetByIdAsync(id);
            if (contato == null) return null;

            return new ContatoDTO
            {
                Id = contato.Id,
                EmpresaId = contato.EmpresaId,
                NomeContato = contato.NomeContato,
                CargoContato = contato.CargoContato,
                EmailContato = contato.EmailContato,
                TelefoneContato = contato.TelefoneContato
            };
        }

        public async Task AddContatoAsync(ContatoDTO contatoDTO)
        {
            var contato = new ContatoEntity
            {
                EmpresaId = contatoDTO.EmpresaId,
                NomeContato = contatoDTO.NomeContato,
                CargoContato = contatoDTO.CargoContato,
                EmailContato = contatoDTO.EmailContato,
                TelefoneContato = contatoDTO.TelefoneContato,
                DataCriacao = DateTime.UtcNow
            };
            await _contatoRepository.AddAsync(contato);
        }

        public async Task UpdateContatoAsync(ContatoDTO contatoDTO)
        {
            var contato = await _contatoRepository.GetByIdAsync(contatoDTO.Id);
            if (contato != null)
            {
                contato.NomeContato = contatoDTO.NomeContato;
                contato.CargoContato = contatoDTO.CargoContato;
                contato.EmailContato = contatoDTO.EmailContato;
                contato.TelefoneContato = contatoDTO.TelefoneContato;
                contato.DataAtualizacao = DateTime.UtcNow;
                await _contatoRepository.UpdateAsync(contato);
            }
        }

        public async Task DeleteContatoAsync(int id)
        {
            await _contatoRepository.DeleteAsync(id);
        }
    }
}
