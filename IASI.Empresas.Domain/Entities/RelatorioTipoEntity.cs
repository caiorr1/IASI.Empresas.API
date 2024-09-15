using System.Collections.Generic;
using IASI.Empresas.Domain.Entities.Common;

namespace IASI.Empresas.Domain.Entities
{
    /// <summary>
    /// Representa um tipo de relatório.
    /// </summary>
    public class RelatorioTipoEntity : CommonEntity
    {
        public string NomeTipo { get; set; }

        public ICollection<RelatorioEntity>? Relatorios { get; set; }
    }
}
