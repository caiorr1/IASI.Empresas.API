using System;
using IASI.Empresas.Domain.Entities.Common;

namespace IASI.Empresas.Domain.Entities
{
    /// <summary>
    /// Representa um documento associado a uma empresa.
    /// </summary>
    public class DocumentoEntity : CommonEntity
    {
        public int EmpresaId { get; set; }
        public string TipoDocumento { get; set; }
        public string NomeDocumento { get; set; }
        public DateTime DataEmissao { get; set; }
        public DateTime? DataValidade { get; set; }
        public byte[] Conteudo { get; set; }

        public EmpresaEntity? Empresa { get; set; }
    }
}
