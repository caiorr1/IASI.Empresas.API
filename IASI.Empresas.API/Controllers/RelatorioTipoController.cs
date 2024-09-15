using IASI.Empresas.Application.Services;
using IASI.Empresas.Domain.Dtos;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace IASI.Empresas.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RelatorioTipoController : ControllerBase
    {
        private readonly RelatorioTipoService _relatorioTipoService;

        public RelatorioTipoController(RelatorioTipoService relatorioTipoService)
        {
            _relatorioTipoService = relatorioTipoService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<RelatorioTipoDTO>>> GetAll()
        {
            var tipos = await _relatorioTipoService.GetAllRelatorioTiposAsync();
            return Ok(tipos);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<RelatorioTipoDTO>> GetById(int id)
        {
            var tipo = await _relatorioTipoService.GetRelatorioTipoByIdAsync(id);
            if (tipo == null)
            {
                return NotFound();
            }
            return Ok(tipo);
        }

        [HttpPost]
        public async Task<IActionResult> Create(RelatorioTipoDTO tipoDto)
        {
            await _relatorioTipoService.AddRelatorioTipoAsync(tipoDto);
            return CreatedAtAction(nameof(GetById), new { id = tipoDto.Id }, tipoDto);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, RelatorioTipoDTO tipoDto)
        {
            if (id != tipoDto.Id)
            {
                return BadRequest();
            }

            await _relatorioTipoService.UpdateRelatorioTipoAsync(tipoDto);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _relatorioTipoService.DeleteRelatorioTipoAsync(id);
            return NoContent();
        }
    }
}
