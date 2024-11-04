using IASI.Empresas.Domain.Entities.Common;

namespace IASI.Empresas.Domain.Entities
{
    /// <summary>
    /// Representa um endereço de uma empresa.
    /// </summary>
    public class EnderecoEntity : CommonEntity
    {
        public string Rua { get; set; } 
        public string Bairro { get; set; }
        public string Complemento { get; set; }
        public string Cidade { get; set; }
        public string Estado { get; set; } 
        public string Pais { get; set; }
        public string CEP { get; set; }
        public string Ibge { get; set; }
        public string Gia { get; set; }
        public string Ddd { get; set; }
        public string Siafi { get; set; }

        public int EmpresaId { get; set; }
        public EmpresaEntity? Empresa { get; set; }
    }
}
