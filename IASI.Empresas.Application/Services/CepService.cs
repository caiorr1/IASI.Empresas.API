using System.Net.Http;
using System.Threading.Tasks;
using IASI.Empresas.Domain.Dtos;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace IASI.Empresas.Application.Services
{
    public class CepService
    {
        private readonly HttpClient _httpClient;

        public CepService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<CepResponseDTO> BuscarEnderecoPorCepAsync(string cep)
        {
            var response = await _httpClient.GetAsync($"https://viacep.com.br/ws/{cep}/json/");
            response.EnsureSuccessStatusCode();

            var content = await response.Content.ReadAsStringAsync();

            var enderecoData = JsonConvert.DeserializeObject<CepResponseDTO>(content);

            if (enderecoData != null)
            {
                enderecoData.Pais = "Brasil";
            }
            else
            {
                throw new Exception($"A deserialização do endereço para o CEP {cep} resultou em null.");
            }

            return enderecoData;
        }

    }
}
