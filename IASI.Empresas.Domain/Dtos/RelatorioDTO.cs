namespace IASI.Empresas.Domain.Dtos
{
    /// <summary>
    /// DTO para representar dados de um relatório.
    /// </summary>
    public class RelatorioDTO
    {
        public int Id { get; set; }
        public int EmpresaId { get; set; }
        public string Tipo { get; set; }
        public string Descricao { get; set; }
        public DateTime DataGeracao { get; set; }
    }
}
