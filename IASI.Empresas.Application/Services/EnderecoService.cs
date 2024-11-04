using System.Collections.Generic;
using System.Threading.Tasks;
using IASI.Empresas.Domain.Entities;
using IASI.Empresas.Domain.Interfaces;
using IASI.Empresas.Domain.Dtos;
using Microsoft.Extensions.Logging;

namespace IASI.Empresas.Application.Services
{
    public class EnderecoService
    {
        private readonly IEnderecoRepository _enderecoRepository;
        private readonly CepService _cepService;

        public EnderecoService(IEnderecoRepository enderecoRepository, CepService cepService)
        {
            _enderecoRepository = enderecoRepository;
            _cepService = cepService;
        }

        public async Task<CepResponseDTO> BuscarEnderecoPorCepAsync(string cep)
        {
            return await _cepService.BuscarEnderecoPorCepAsync(cep);
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
            var enderecoData = await _cepService.BuscarEnderecoPorCepAsync(enderecoDTO.CEP);
            if (enderecoData != null)
            {
                enderecoDTO.Rua = enderecoData.Logradouro;
                enderecoDTO.Cidade = enderecoData.Localidade;
                enderecoDTO.Estado = enderecoData.Uf;
                enderecoDTO.Pais = enderecoData.Pais;
            }

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
            var enderecoData = await _cepService.BuscarEnderecoPorCepAsync(enderecoDTO.CEP);
            if (enderecoData != null)
            {
                enderecoDTO.Rua = enderecoData.Logradouro;
                enderecoDTO.Cidade = enderecoData.Localidade;
                enderecoDTO.Estado = enderecoData.Uf;
                enderecoDTO.Pais = enderecoData.Pais;
            }

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
