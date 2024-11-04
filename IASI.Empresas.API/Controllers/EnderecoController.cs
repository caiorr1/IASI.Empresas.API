using IASI.Empresas.Application.Services;
using IASI.Empresas.Domain.Dtos;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace IASI.Empresas.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EnderecoController : ControllerBase
    {
        private readonly EnderecoService _enderecoService;

        public EnderecoController(EnderecoService enderecoService)
        {
            _enderecoService = enderecoService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<EnderecoDTO>>> GetAll()
        {
            var enderecos = await _enderecoService.GetAllEnderecosAsync();
            return Ok(enderecos);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<EnderecoDTO>> GetById(int id)
        {
            var endereco = await _enderecoService.GetEnderecoByIdAsync(id);
            if (endereco == null)
            {
                return NotFound();
            }
            return Ok(endereco);
        }

        [HttpPost]
        public async Task<IActionResult> Create(EnderecoDTO enderecoDto)
        {
            await _enderecoService.AddEnderecoAsync(enderecoDto);
            return CreatedAtAction(nameof(GetById), new { id = enderecoDto.Id }, enderecoDto);
        }

        // Novo endpoint para buscar endereço pelo CEP
        [HttpGet("cep/{cep}")]
        public async Task<ActionResult<EnderecoDTO>> GetByCep(string cep)
        {
            var endereco = await _enderecoService.BuscarEnderecoPorCepAsync(cep);
            if (endereco == null)
            {
                return NotFound("Endereço não encontrado para o CEP informado.");
            }
            return Ok(endereco);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, EnderecoDTO enderecoDto)
        {
            if (id != enderecoDto.Id)
            {
                return BadRequest();
            }

            await _enderecoService.UpdateEnderecoAsync(enderecoDto);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _enderecoService.DeleteEnderecoAsync(id);
            return NoContent();
        }
    }
}
