using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using IASI.Empresas.Application.Services;
using IASI.Empresas.Domain.Dtos;

namespace IASI.Empresas.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CepController : ControllerBase
    {
        private readonly CepService _cepService;

        public CepController(CepService cepService)
        {
            _cepService = cepService;
        }

        [HttpGet("{cep}")]
        public async Task<ActionResult<CepResponseDTO>> GetEnderecoPorCep(string cep)
        {

            try
            {
                var endereco = await _cepService.BuscarEnderecoPorCepAsync(cep);

                if (endereco == null)
                {
                    return NotFound("CEP não encontrado.");
                }

                return Ok(endereco);
            }
            catch (System.Exception ex)
            {
                return StatusCode(500, "Erro ao consultar o CEP.");
            }
        }
    }
}
