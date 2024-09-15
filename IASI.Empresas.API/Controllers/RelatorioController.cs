using IASI.Empresas.Application.Services;
using IASI.Empresas.Domain.Dtos;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace IASI.Empresas.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RelatorioController : ControllerBase
    {
        private readonly RelatorioService _relatorioService;

        public RelatorioController(RelatorioService relatorioService)
        {
            _relatorioService = relatorioService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<RelatorioDTO>>> GetAll()
        {
            var relatorios = await _relatorioService.GetAllRelatoriosAsync();
            return Ok(relatorios);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<RelatorioDTO>> GetById(int id)
        {
            var relatorio = await _relatorioService.GetRelatorioByIdAsync(id);
            if (relatorio == null)
            {
                return NotFound();
            }
            return Ok(relatorio);
        }

        [HttpPost]
        public async Task<IActionResult> Create(RelatorioDTO relatorioDto)
        {
            await _relatorioService.AddRelatorioAsync(relatorioDto);
            return CreatedAtAction(nameof(GetById), new { id = relatorioDto.Id }, relatorioDto);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, RelatorioDTO relatorioDto)
        {
            if (id != relatorioDto.Id)
            {
                return BadRequest();
            }

            await _relatorioService.UpdateRelatorioAsync(relatorioDto);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _relatorioService.DeleteRelatorioAsync(id);
            return NoContent();
        }
    }
}
