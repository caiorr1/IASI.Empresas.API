namespace IASI.Empresas.Domain.Dtos
{
    /// <summary>
    /// DTO para representar dados de um documento.
    /// </summary>
    public class DocumentoDTO
    {
        public int Id { get; set; }
        public int EmpresaId { get; set; }
        public string Tipo { get; set; }
        public DateTime DataEmissao { get; set; }
        public DateTime? DataExpiracao { get; set; }
        public bool Valido { get; set; }
    }
}
