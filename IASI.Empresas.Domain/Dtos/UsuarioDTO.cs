namespace IASI.Empresas.Domain.Dtos
{
    /// <summary>
    /// DTO para representar dados de um usuário.
    /// </summary>
    public class UsuarioDTO
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Role { get; set; }
        public bool Ativo { get; set; }
    }
}
