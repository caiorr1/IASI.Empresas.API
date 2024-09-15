using IASI.Empresas.Application.Services;
using IASI.Empresas.Domain.Dtos;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace IASI.Empresas.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DocumentoController : ControllerBase
    {
        private readonly DocumentoService _documentoService;

        public DocumentoController(DocumentoService documentoService)
        {
            _documentoService = documentoService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<DocumentoDTO>>> GetAll()
        {
            var documentos = await _documentoService.GetAllDocumentosAsync();
            return Ok(documentos);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<DocumentoDTO>> GetById(int id)
        {
            var documento = await _documentoService.GetDocumentoByIdAsync(id);
            if (documento == null)
            {
                return NotFound();
            }
            return Ok(documento);
        }

        [HttpPost]
        public async Task<IActionResult> Create(DocumentoDTO documentoDto)
        {
            await _documentoService.AddDocumentoAsync(documentoDto);
            return CreatedAtAction(nameof(GetById), new { id = documentoDto.Id }, documentoDto);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, DocumentoDTO documentoDto)
        {
            if (id != documentoDto.Id)
            {
                return BadRequest();
            }

            await _documentoService.UpdateDocumentoAsync(documentoDto);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _documentoService.DeleteDocumentoAsync(id);
            return NoContent();
        }
    }
}
