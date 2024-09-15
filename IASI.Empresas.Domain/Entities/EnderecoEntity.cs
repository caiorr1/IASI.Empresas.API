using IASI.Empresas.Domain.Entities.Common;

namespace IASI.Empresas.Domain.Entities
{
    /// <summary>
    /// Representa um endereço de uma empresa.
    /// </summary>
    public class EnderecoEntity : CommonEntity
    {
        public string Rua { get; set; }
        public string Cidade { get; set; }
        public string Estado { get; set; }
        public string Pais { get; set; }
        public string CEP { get; set; }

        public int EmpresaId { get; set; }
        public EmpresaEntity? Empresa { get; set; }
    }
}
