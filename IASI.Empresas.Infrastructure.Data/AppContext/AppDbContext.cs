using Microsoft.EntityFrameworkCore;
using IASI.Empresas.Domain.Entities;

namespace IASI.Empresas.Infrastructure.Data
{
    /// <summary>
    /// Contexto do banco de dados para a aplicação IASI.Empresas.
    /// </summary>
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        // DbSets para as entidades
        public DbSet<EmpresaEntity> Empresas { get; set; }
        public DbSet<ContatoEntity> Contatos { get; set; }
        public DbSet<DocumentoEntity> Documentos { get; set; }
        public DbSet<EnderecoEntity> Enderecos { get; set; }
        public DbSet<RelatorioEntity> Relatorios { get; set; }
        public DbSet<RelatorioTipoEntity> RelatorioTipos { get; set; }
        public DbSet<SetorEntity> Setores { get; set; }
        public DbSet<UsuarioEntity> Usuarios { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configurações adicionais de mapeamento
            modelBuilder.Entity<EmpresaEntity>().ToTable("tb_iasi_empresas_empresa");
            modelBuilder.Entity<ContatoEntity>().ToTable("tb_iasi_empresas_contato");
            modelBuilder.Entity<DocumentoEntity>().ToTable("tb_iasi_empresas_documento");
            modelBuilder.Entity<EnderecoEntity>().ToTable("tb_iasi_empresas_endereco");
            modelBuilder.Entity<RelatorioEntity>().ToTable("tb_iasi_empresas_relatorio");
            modelBuilder.Entity<RelatorioTipoEntity>().ToTable("tb_iasi_empresas_relatorio_tipo");
            modelBuilder.Entity<SetorEntity>().ToTable("tb_iasi_empresas_setor");

            // Mapeamento de tipo de dados para o campo Ativo da tabela UsuarioEntity
            modelBuilder.Entity<UsuarioEntity>(entity =>
            {
                entity.ToTable("tb_iasi_empresas_usuario");
                entity.Property(e => e.Ativo).HasColumnType("NUMBER(1)").IsRequired();
            });
        }
    }
}
