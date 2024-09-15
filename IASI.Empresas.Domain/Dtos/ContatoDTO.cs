namespace IASI.Empresas.Domain.Dtos
{
    /// <summary>
    /// DTO para representar dados de um contato.
    /// </summary>
    public class ContatoDTO
    {
        public int Id { get; set; }
        public int EmpresaId { get; set; }
        public string NomeContato { get; set; }
        public string CargoContato { get; set; }
        public string EmailContato { get; set; }
        public string TelefoneContato { get; set; }
    }
}
