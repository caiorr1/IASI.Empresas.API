using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IASI.Empresas.Domain.Entities.Common
{
    /// <summary>
    ///  Classe base para entidades comuns.
    /// </summary>
    public abstract class CommonEntity
    {

        public string Id { get; set; }

        public string DateTime? DataCriacao { get; set; }
        public DateTime? DataAtualizacao { get; set; }


}
}
