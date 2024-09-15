using IASI.Empresas.Domain.Entities.Common;

namespace IASI.Empresas.Domain.Entities
{
    /// <summary>
    /// Representa um usuário do sistema.
    /// </summary>
    public class UsuarioEntity : CommonEntity
    {
        public string NomeUsuario { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        public string Role { get; set; }
        public bool Ativo { get; set; }

    }
}
