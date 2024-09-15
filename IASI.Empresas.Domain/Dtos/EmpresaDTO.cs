namespace IASI.Empresas.Domain.Dtos
{
    /// <summary>
    /// DTO para representar dados de uma empresa.
    /// </summary>
    public class EmpresaDTO
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string SetorIndustrial { get; set; }
        public string Localizacao { get; set; }
        public char ConformidadeRegulamentar { get; set; }
    }
}
