using System.Collections.Generic;
using IASI.Empresas.Domain.Entities.Common;

namespace IASI.Empresas.Domain.Entities
{
    /// <summary>
    /// Representa um setor industrial.
    /// </summary>
    public class SetorEntity : CommonEntity
    {
        public string NomeSetor { get; set; }

        public ICollection<EmpresaEntity>? Empresas { get; set; }
    }
}
