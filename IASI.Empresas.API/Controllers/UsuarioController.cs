using IASI.Empresas.Application.Services;
using IASI.Empresas.Domain.Dtos;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace IASI.Empresas.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsuarioController : ControllerBase
    {
        private readonly UsuarioService _usuarioService;

        public UsuarioController(UsuarioService usuarioService)
        {
            _usuarioService = usuarioService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<UsuarioDTO>>> GetAll()
        {
            var usuarios = await _usuarioService.GetAllUsuariosAsync();
            return Ok(usuarios);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<UsuarioDTO>> GetById(int id)
        {
            var usuario = await _usuarioService.GetUsuarioByIdAsync(id);
            if (usuario == null)
            {
                return NotFound();
            }
            return Ok(usuario);
        }

        [HttpPost]
        public async Task<IActionResult> Create(UsuarioDTO usuarioDto)
        {
            if (usuarioDto == null || string.IsNullOrEmpty(usuarioDto.Senha))
            {
                return BadRequest("Os dados do usuário ou a senha estão incompletos.");
            }
            await _usuarioService.AddUsuarioAsync(usuarioDto);
            return CreatedAtAction(nameof(GetById), new { id = usuarioDto.Id }, usuarioDto);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, UsuarioDTO usuarioDto)
        {
            if (id != usuarioDto.Id)
            {
                return BadRequest();
            }

            await _usuarioService.UpdateUsuarioAsync(usuarioDto);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _usuarioService.DeleteUsuarioAsync(id);
            return NoContent();
        }
    }
}
