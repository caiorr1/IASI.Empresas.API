namespace IASI.Empresas.Domain.Dtos
{
    /// <summary>
    /// DTO para representar dados de um contato.
    /// </summary>
    public class ContatoDTO
    {
        public int Id { get; set; }
        public int EmpresaId { get; set; }
        public string Nome { get; set; }
        public string Cargo { get; set; }
        public string Email { get; set; }
        public string Telefone { get; set; }
    }
}
