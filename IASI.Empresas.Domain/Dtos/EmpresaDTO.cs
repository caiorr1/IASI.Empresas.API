namespace IASI.Empresas.Domain.Dtos
{
    /// <summary>
    /// DTO para representar dados de uma empresa.
    /// </summary>
    public class EmpresaDTO
    {
        public int Id { get; set; }
        public string NomeEmpresa { get; set; }
        public string SetorIndustrialEmpresa { get; set; }
        public string LocalizacaoEmpresa { get; set; }
        public string TipoEmpresa { get; set; }
        public char ConformidadeRegulamentar { get; set; }
    }
}
