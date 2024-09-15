using IASI.Empresas.Application.Services;
using IASI.Empresas.Domain.Dtos;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace IASI.Empresas.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SetorController : ControllerBase
    {
        private readonly SetorService _setorService;

        public SetorController(SetorService setorService)
        {
            _setorService = setorService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<SetorDTO>>> GetAll()
        {
            var setores = await _setorService.GetAllSetoresAsync();
            return Ok(setores);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<SetorDTO>> GetById(int id)
        {
            var setor = await _setorService.GetSetorByIdAsync(id);
            if (setor == null)
            {
                return NotFound();
            }
            return Ok(setor);
        }

        [HttpPost]
        public async Task<IActionResult> Create(SetorDTO setorDto)
        {
            await _setorService.AddSetorAsync(setorDto);
            return CreatedAtAction(nameof(GetById), new { id = setorDto.Id }, setorDto);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, SetorDTO setorDto)
        {
            if (id != setorDto.Id)
            {
                return BadRequest();
            }

            await _setorService.UpdateSetorAsync(setorDto);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _setorService.DeleteSetorAsync(id);
            return NoContent();
        }
    }
}
