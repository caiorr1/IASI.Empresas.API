namespace IASI.Empresas.Domain.Dtos
{
    /// <summary>
    /// DTO para representar dados de um endereço.
    /// </summary>
    public class EnderecoDTO
    {
        public int Id { get; set; }
        public int EmpresaId { get; set; }
        public string Rua { get; set; }
        public string Cidade { get; set; }
        public string Estado { get; set; }
        public string CEP { get; set; }
    }
}
