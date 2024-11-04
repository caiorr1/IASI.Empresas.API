using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using IASI.Empresas.API.Controllers;
using IASI.Empresas.Application.Services;
using IASI.Empresas.Domain.Dtos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using Moq.Protected;
using Newtonsoft.Json;
using Xunit;

namespace IASI.Empresas.Tests
{
    public class CepControllerTest
    {
        private readonly Mock<HttpMessageHandler> _httpMessageHandlerMock;
        private readonly CepController _cepController;
        private readonly CepService _cepService;

        public CepControllerTest()
        {
            _httpMessageHandlerMock = new Mock<HttpMessageHandler>(MockBehavior.Strict);

            var httpClient = new HttpClient(_httpMessageHandlerMock.Object)
            {
                BaseAddress = new Uri("https://viacep.com.br")
            };

            _cepService = new CepService(httpClient);
            _cepController = new CepController(_cepService);
        }

        [Fact]
        public async Task GetEnderecoPorCep_ValidCep_ReturnsExpectedEndereco()
        {
            // Arrange
            var cep = "12345678";
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

            _httpMessageHandlerMock.Protected()
                .Setup<Task<HttpResponseMessage>>(
                    "SendAsync",
                    ItExpr.IsAny<HttpRequestMessage>(),
                    ItExpr.IsAny<CancellationToken>()
                )
                .ReturnsAsync(responseMessage);

            // Act
            var result = await _cepController.GetEnderecoPorCep(cep);

            // Assert
            var okResult = Assert.IsType<ActionResult<CepResponseDTO>>(result);
            var enderecoResult = Assert.IsType<CepResponseDTO>(okResult.Value);

            Assert.NotNull(enderecoResult);
            Assert.Equal("Rua A", enderecoResult.Logradouro);
            Assert.Equal("Cidade B", enderecoResult.Localidade);
            Assert.Equal("SP", enderecoResult.Uf);
            Assert.Equal("Brasil", enderecoResult.Pais);
        }
    }
}
