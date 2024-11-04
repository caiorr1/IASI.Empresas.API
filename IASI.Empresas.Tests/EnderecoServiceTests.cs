using System.Net;
using System.Text;
using System.Threading.Tasks;
using IASI.Empresas.Application.Services;
using IASI.Empresas.Domain.Dtos;
using IASI.Empresas.Domain.Entities;
using IASI.Empresas.Domain.Interfaces;
using Microsoft.Extensions.Logging;
using Moq;
using Moq.Protected;
using Newtonsoft.Json;
using Xunit;

namespace IASI.Empresas.Tests
{
    public class EnderecoServiceTests
    {
        private readonly Mock<IEnderecoRepository> _enderecoRepositoryMock;
        private readonly EnderecoService _enderecoService;
        private readonly Mock<HttpMessageHandler> _httpMessageHandlerMock;

        public EnderecoServiceTests()
        {
            _enderecoRepositoryMock = new Mock<IEnderecoRepository>();
            _httpMessageHandlerMock = new Mock<HttpMessageHandler>();

            var httpClient = new HttpClient(_httpMessageHandlerMock.Object);
            var cepService = new CepService(httpClient);

            _enderecoService = new EnderecoService(_enderecoRepositoryMock.Object, cepService);
        }

        [Fact]
        public async Task AddEnderecoAsync_ValidEnderecoDTO_AddsEnderecoWithCepData()
        {
            var cep = "12345678";
            var enderecoDto = new EnderecoDTO
            {
                CEP = cep,
                EmpresaId = 1
            };

            var cepResponse = new CepResponseDTO
            {
                Logradouro = "Rua A",
                Localidade = "Cidade B",
                Uf = "SP",
                Pais = "Brasil"
            };

            var responseMessage = new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new StringContent(JsonConvert.SerializeObject(cepResponse), Encoding.UTF8, "application/json")
            };

            _httpMessageHandlerMock
                .Protected()
                .Setup<Task<HttpResponseMessage>>(
                    "SendAsync",
                    ItExpr.IsAny<HttpRequestMessage>(),
                    ItExpr.IsAny<CancellationToken>()
                )
                .ReturnsAsync(responseMessage);

            await _enderecoService.AddEnderecoAsync(enderecoDto);

            _enderecoRepositoryMock.Verify(repo => repo.AddAsync(It.Is<EnderecoEntity>(e =>
                e.Rua == "Rua A" &&
                e.Cidade == "Cidade B" &&
                e.Estado == "SP" &&
                e.Pais == "Brasil" &&
                e.CEP == cep &&
                e.EmpresaId == 1
            )), Times.Once);
        }
    }
}
