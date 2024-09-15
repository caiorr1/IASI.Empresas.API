namespace IASI.Empresas.Domain.Dtos
{
    /// <summary>
    /// DTO para representar dados de um documento.
    /// </summary>
    public class DocumentoDTO
    {
        public int Id { get; set; }
        public int EmpresaId { get; set; }
        public string TipoDocumento { get; set; }
        public string NomeDocumento { get; set; }
        public DateTime DataEmissao { get; set; }
        public DateTime? DataValidade { get; set; }
        public byte[] Conteudo { get; set; }
    }
}
