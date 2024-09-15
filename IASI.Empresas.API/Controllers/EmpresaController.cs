using IASI.Empresas.Application.Services;
using IASI.Empresas.Domain.Dtos;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace IASI.Empresas.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EmpresaController : ControllerBase
    {
        private readonly EmpresaService _empresaService;

        public EmpresaController(EmpresaService empresaService)
        {
            _empresaService = empresaService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<EmpresaDTO>>> GetAll()
        {
            var empresas = await _empresaService.GetAllEmpresasAsync();
            return Ok(empresas);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<EmpresaDTO>> GetById(int id)
        {
            var empresa = await _empresaService.GetEmpresaByIdAsync(id);
            if (empresa == null)
            {
                return NotFound();
            }
            return Ok(empresa);
        }

        [HttpPost]
        public async Task<IActionResult> Create(EmpresaDTO empresaDto)
        {
            await _empresaService.AddEmpresaAsync(empresaDto);
            return CreatedAtAction(nameof(GetById), new { id = empresaDto.Id }, empresaDto);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, EmpresaDTO empresaDto)
        {
            if (id != empresaDto.Id)
            {
                return BadRequest();
            }

            await _empresaService.UpdateEmpresaAsync(empresaDto);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _empresaService.DeleteEmpresaAsync(id);
            return NoContent();
        }
    }
}
