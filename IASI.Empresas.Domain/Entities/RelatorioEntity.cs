using System;
using IASI.Empresas.Domain.Entities.Common;

namespace IASI.Empresas.Domain.Entities
{
    /// <summary>
    /// Representa um relatório gerado para uma empresa.
    /// </summary>
    public class RelatorioEntity : CommonEntity
    {
        public int EmpresaId { get; set; }
        public string TipoRelatorio { get; set; }
        public DateTime DataGeracao { get; set; }
        public string Descricao { get; set; }

        public EmpresaEntity? Empresa { get; set; }
    }
}
