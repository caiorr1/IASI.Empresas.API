using System.Collections.Generic;
using System.Threading.Tasks;
using IASI.Empresas.Domain.Entities;
using IASI.Empresas.Domain.Interfaces;
using IASI.Empresas.Domain.Dtos;

namespace IASI.Empresas.Application.Services
{
    public class DocumentoService
    {
        private readonly IDocumentoRepository _documentoRepository;

        public DocumentoService(IDocumentoRepository documentoRepository)
        {
            _documentoRepository = documentoRepository;
        }

        public async Task<IEnumerable<DocumentoDTO>> GetAllDocumentosAsync()
        {
            var documentos = await _documentoRepository.GetAllAsync();
            var documentoDTOs = new List<DocumentoDTO>();

            foreach (var documento in documentos)
            {
                documentoDTOs.Add(new DocumentoDTO
                {
                    Id = documento.Id,
                    EmpresaId = documento.EmpresaId,
                    TipoDocumento = documento.TipoDocumento,
                    NomeDocumento = documento.NomeDocumento,
                    DataEmissao = documento.DataEmissao,
                    DataValidade = documento.DataValidade,
                    Conteudo = documento.Conteudo
                });
            }
            return documentoDTOs;
        }

        public async Task<DocumentoDTO> GetDocumentoByIdAsync(int id)
        {
            var documento = await _documentoRepository.GetByIdAsync(id);
            if (documento == null) return null;

            return new DocumentoDTO
            {
                Id = documento.Id,
                EmpresaId = documento.EmpresaId,
                TipoDocumento = documento.TipoDocumento,
                NomeDocumento = documento.NomeDocumento,
                DataEmissao = documento.DataEmissao,
                DataValidade = documento.DataValidade,
                Conteudo = documento.Conteudo
            };
        }

        public async Task AddDocumentoAsync(DocumentoDTO documentoDTO)
        {
            var documento = new DocumentoEntity
            {
                EmpresaId = documentoDTO.EmpresaId,
                TipoDocumento = documentoDTO.TipoDocumento,
                NomeDocumento = documentoDTO.NomeDocumento,
                DataEmissao = documentoDTO.DataEmissao,
                DataValidade = documentoDTO.DataValidade,
                Conteudo = documentoDTO.Conteudo,
                DataCriacao = DateTime.UtcNow
            };
            await _documentoRepository.AddAsync(documento);
        }

        public async Task UpdateDocumentoAsync(DocumentoDTO documentoDTO)
        {
            var documento = await _documentoRepository.GetByIdAsync(documentoDTO.Id);
            if (documento != null)
            {
                documento.TipoDocumento = documentoDTO.TipoDocumento;
                documento.NomeDocumento = documentoDTO.NomeDocumento;
                documento.DataEmissao = documentoDTO.DataEmissao;
                documento.DataValidade = documentoDTO.DataValidade;
                documento.Conteudo = documentoDTO.Conteudo;
                documento.DataAtualizacao = DateTime.UtcNow;
                await _documentoRepository.UpdateAsync(documento);
            }
        }

        public async Task DeleteDocumentoAsync(int id)
        {
            await _documentoRepository.DeleteAsync(id);
        }
    }
}
