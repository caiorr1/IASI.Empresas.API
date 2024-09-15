using IASI.Empresas.Application.Services;
using IASI.Empresas.Domain.Dtos;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace IASI.Empresas.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ContatoController : ControllerBase
    {
        private readonly ContatoService _contatoService;

        public ContatoController(ContatoService contatoService)
        {
            _contatoService = contatoService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ContatoDTO>>> GetAll()
        {
            var contatos = await _contatoService.GetAllContatosAsync();
            return Ok(contatos);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ContatoDTO>> GetById(int id)
        {
            var contato = await _contatoService.GetContatoByIdAsync(id);
            if (contato == null)
            {
                return NotFound();
            }
            return Ok(contato);
        }

        [HttpPost]
        public async Task<IActionResult> Create(ContatoDTO contatoDto)
        {
            await _contatoService.AddContatoAsync(contatoDto);
            return CreatedAtAction(nameof(GetById), new { id = contatoDto.Id }, contatoDto);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, ContatoDTO contatoDto)
        {
            if (id != contatoDto.Id)
            {
                return BadRequest();
            }

            await _contatoService.UpdateContatoAsync(contatoDto);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _contatoService.DeleteContatoAsync(id);
            return NoContent();
        }
    }
}
