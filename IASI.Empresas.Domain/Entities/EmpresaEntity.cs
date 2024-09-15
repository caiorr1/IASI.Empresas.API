using System;
using System.Collections.Generic;
using IASI.Empresas.Domain.Entities.Common;

namespace IASI.Empresas.Domain.Entities
{
    /// <summary>
    /// Representa uma empresa.
    /// </summary>
    public class EmpresaEntity : CommonEntity
    {
        public string NomeEmpresa { get; set; }
        public string SetorIndustrialEmpresa { get; set; }
        public string LocalizacaoEmpresa { get; set; }
        public string TipoEmpresa { get; set; }
        public char ConformidadeRegulamentar { get; set; }

        public ICollection<ContatoEntity>? Contatos { get; set; }
        public ICollection<RelatorioEntity>? Relatorios { get; set; }
        public ICollection<EnderecoEntity>? Enderecos { get; set; }
        public ICollection<DocumentoEntity>? Documentos { get; set; }
    }
}
