using IASI.Empresas.Domain.Entities.Common;

namespace IASI.Empresas.Domain.Entities
{
    /// <summary>
    /// Representa um contato de uma empresa.
    /// </summary>
    public class ContatoEntity : CommonEntity
    {
        public int EmpresaId { get; set; }
        public string NomeContato { get; set; }
        public string CargoContato { get; set; }
        public string EmailContato { get; set; }
        public string TelefoneContato { get; set; }

        public EmpresaEntity? Empresa { get; set; }
    }
}
