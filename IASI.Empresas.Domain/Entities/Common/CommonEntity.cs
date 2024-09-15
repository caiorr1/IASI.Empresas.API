using System;

namespace IASI.Empresas.Domain.Entities.Common
{
    /// <summary>
    /// Classe base para entidades comuns.
    /// </summary>
    public abstract class CommonEntity
    {
        public int Id { get; set; } // Corrigido para int

        public DateTime? DataCriacao { get; set; }
        public DateTime? DataAtualizacao { get; set; }
    }
}
