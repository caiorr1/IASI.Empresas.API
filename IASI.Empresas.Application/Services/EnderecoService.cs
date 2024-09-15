using System.Collections.Generic;
using System.Threading.Tasks;
using IASI.Empresas.Domain.Entities;
using IASI.Empresas.Domain.Interfaces;
using IASI.Empresas.Domain.Dtos;

namespace IASI.Empresas.Application.Services
{
    public class EnderecoService
    {
        private readonly IEnderecoRepository _enderecoRepository;

        public EnderecoService(IEnderecoRepository enderecoRepository)
        {
            _enderecoRepository = enderecoRepository;
        }

        public async Task<IEnumerable<EnderecoDTO>> GetAllEnderecosAsync()
        {
            var enderecos = await _enderecoRepository.GetAllAsync();
            var enderecoDTOs = new List<EnderecoDTO>();

            foreach (var endereco in enderecos)
            {
                enderecoDTOs.Add(new EnderecoDTO
                {
                    Id = endereco.Id,
                    Rua = endereco.Rua,
                    Cidade = endereco.Cidade,
                    Estado = endereco.Estado,
                    Pais = endereco.Pais,
                    CEP = endereco.CEP,
                    EmpresaId = endereco.EmpresaId
                });
            }
            return enderecoDTOs;
        }

        public async Task<EnderecoDTO> GetEnderecoByIdAsync(int id)
        {
            var endereco = await _enderecoRepository.GetByIdAsync(id);
            if (endereco == null) return null;

            return new EnderecoDTO
            {
                Id = endereco.Id,
                Rua = endereco.Rua,
                Cidade = endereco.Cidade,
                Estado = endereco.Estado,
                Pais = endereco.Pais,
                CEP = endereco.CEP,
                EmpresaId = endereco.EmpresaId
            };
        }

        public async Task AddEnderecoAsync(EnderecoDTO enderecoDTO)
        {
            var endereco = new EnderecoEntity
            {
                Rua = enderecoDTO.Rua,
                Cidade = enderecoDTO.Cidade,
                Estado = enderecoDTO.Estado,
                Pais = enderecoDTO.Pais,
                CEP = enderecoDTO.CEP,
                EmpresaId = enderecoDTO.EmpresaId,
                DataCriacao = DateTime.UtcNow
            };
            await _enderecoRepository.AddAsync(endereco);
        }

        public async Task UpdateEnderecoAsync(EnderecoDTO enderecoDTO)
        {
            var endereco = await _enderecoRepository.GetByIdAsync(enderecoDTO.Id);
            if (endereco != null)
            {
                endereco.Rua = enderecoDTO.Rua;
                endereco.Cidade = enderecoDTO.Cidade;
                endereco.Estado = enderecoDTO.Estado;
                endereco.Pais = enderecoDTO.Pais;
                endereco.CEP = enderecoDTO.CEP;
                endereco.DataAtualizacao = DateTime.UtcNow;
                await _enderecoRepository.UpdateAsync(endereco);
            }
        }

        public async Task DeleteEnderecoAsync(int id)
        {
            await _enderecoRepository.DeleteAsync(id);
        }
    }
}
