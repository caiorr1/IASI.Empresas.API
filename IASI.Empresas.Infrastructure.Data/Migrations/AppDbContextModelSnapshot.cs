﻿// <auto-generated />
using System;
using IASI.Empresas.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Oracle.EntityFrameworkCore.Metadata;

#nullable disable

namespace IASI.Empresas.Infrastructure.Data.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            OracleModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("IASI.Empresas.Domain.Entities.ContatoEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("NUMBER(10)");

                    OraclePropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("CargoContato")
                        .IsRequired()
                        .HasColumnType("NVARCHAR2(2000)");

                    b.Property<DateTime?>("DataAtualizacao")
                        .HasColumnType("TIMESTAMP(7)");

                    b.Property<DateTime?>("DataCriacao")
                        .HasColumnType("TIMESTAMP(7)");

                    b.Property<string>("EmailContato")
                        .IsRequired()
                        .HasColumnType("NVARCHAR2(2000)");

                    b.Property<int>("EmpresaId")
                        .HasColumnType("NUMBER(10)");

                    b.Property<string>("NomeContato")
                        .IsRequired()
                        .HasColumnType("NVARCHAR2(2000)");

                    b.Property<string>("TelefoneContato")
                        .IsRequired()
                        .HasColumnType("NVARCHAR2(2000)");

                    b.HasKey("Id");

                    b.HasIndex("EmpresaId");

                    b.ToTable("tb_iasi_empresas_contato", (string)null);
                });

            modelBuilder.Entity("IASI.Empresas.Domain.Entities.DocumentoEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("NUMBER(10)");

                    OraclePropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<byte[]>("Conteudo")
                        .IsRequired()
                        .HasColumnType("RAW(2000)");

                    b.Property<DateTime?>("DataAtualizacao")
                        .HasColumnType("TIMESTAMP(7)");

                    b.Property<DateTime?>("DataCriacao")
                        .HasColumnType("TIMESTAMP(7)");

                    b.Property<DateTime>("DataEmissao")
                        .HasColumnType("TIMESTAMP(7)");

                    b.Property<DateTime?>("DataValidade")
                        .HasColumnType("TIMESTAMP(7)");

                    b.Property<int>("EmpresaId")
                        .HasColumnType("NUMBER(10)");

                    b.Property<string>("NomeDocumento")
                        .IsRequired()
                        .HasColumnType("NVARCHAR2(2000)");

                    b.Property<string>("TipoDocumento")
                        .IsRequired()
                        .HasColumnType("NVARCHAR2(2000)");

                    b.HasKey("Id");

                    b.HasIndex("EmpresaId");

                    b.ToTable("tb_iasi_empresas_documento", (string)null);
                });

            modelBuilder.Entity("IASI.Empresas.Domain.Entities.EmpresaEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("NUMBER(10)");

                    OraclePropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ConformidadeRegulamentar")
                        .IsRequired()
                        .HasColumnType("NVARCHAR2(1)");

                    b.Property<DateTime?>("DataAtualizacao")
                        .HasColumnType("TIMESTAMP(7)");

                    b.Property<DateTime?>("DataCriacao")
                        .HasColumnType("TIMESTAMP(7)");

                    b.Property<string>("LocalizacaoEmpresa")
                        .IsRequired()
                        .HasColumnType("NVARCHAR2(2000)");

                    b.Property<string>("NomeEmpresa")
                        .IsRequired()
                        .HasColumnType("NVARCHAR2(2000)");

                    b.Property<int?>("SetorEntityId")
                        .HasColumnType("NUMBER(10)");

                    b.Property<string>("SetorIndustrialEmpresa")
                        .IsRequired()
                        .HasColumnType("NVARCHAR2(2000)");

                    b.Property<string>("TipoEmpresa")
                        .IsRequired()
                        .HasColumnType("NVARCHAR2(2000)");

                    b.HasKey("Id");

                    b.HasIndex("SetorEntityId");

                    b.ToTable("tb_iasi_empresas_empresa", (string)null);
                });

            modelBuilder.Entity("IASI.Empresas.Domain.Entities.EnderecoEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("NUMBER(10)");

                    OraclePropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("CEP")
                        .IsRequired()
                        .HasColumnType("NVARCHAR2(2000)");

                    b.Property<string>("Cidade")
                        .IsRequired()
                        .HasColumnType("NVARCHAR2(2000)");

                    b.Property<DateTime?>("DataAtualizacao")
                        .HasColumnType("TIMESTAMP(7)");

                    b.Property<DateTime?>("DataCriacao")
                        .HasColumnType("TIMESTAMP(7)");

                    b.Property<int>("EmpresaId")
                        .HasColumnType("NUMBER(10)");

                    b.Property<string>("Estado")
                        .IsRequired()
                        .HasColumnType("NVARCHAR2(2000)");

                    b.Property<string>("Pais")
                        .IsRequired()
                        .HasColumnType("NVARCHAR2(2000)");

                    b.Property<string>("Rua")
                        .IsRequired()
                        .HasColumnType("NVARCHAR2(2000)");

                    b.HasKey("Id");

                    b.HasIndex("EmpresaId");

                    b.ToTable("tb_iasi_empresas_endereco", (string)null);
                });

            modelBuilder.Entity("IASI.Empresas.Domain.Entities.RelatorioEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("NUMBER(10)");

                    OraclePropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime?>("DataAtualizacao")
                        .HasColumnType("TIMESTAMP(7)");

                    b.Property<DateTime?>("DataCriacao")
                        .HasColumnType("TIMESTAMP(7)");

                    b.Property<DateTime>("DataGeracao")
                        .HasColumnType("TIMESTAMP(7)");

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasColumnType("NVARCHAR2(2000)");

                    b.Property<int>("EmpresaId")
                        .HasColumnType("NUMBER(10)");

                    b.Property<int?>("RelatorioTipoEntityId")
                        .HasColumnType("NUMBER(10)");

                    b.Property<string>("TipoRelatorio")
                        .IsRequired()
                        .HasColumnType("NVARCHAR2(2000)");

                    b.HasKey("Id");

                    b.HasIndex("EmpresaId");

                    b.HasIndex("RelatorioTipoEntityId");

                    b.ToTable("tb_iasi_empresas_relatorio", (string)null);
                });

            modelBuilder.Entity("IASI.Empresas.Domain.Entities.RelatorioTipoEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("NUMBER(10)");

                    OraclePropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime?>("DataAtualizacao")
                        .HasColumnType("TIMESTAMP(7)");

                    b.Property<DateTime?>("DataCriacao")
                        .HasColumnType("TIMESTAMP(7)");

                    b.Property<string>("NomeTipo")
                        .IsRequired()
                        .HasColumnType("NVARCHAR2(2000)");

                    b.HasKey("Id");

                    b.ToTable("tb_iasi_empresas_relatorio_tipo", (string)null);
                });

            modelBuilder.Entity("IASI.Empresas.Domain.Entities.SetorEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("NUMBER(10)");

                    OraclePropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime?>("DataAtualizacao")
                        .HasColumnType("TIMESTAMP(7)");

                    b.Property<DateTime?>("DataCriacao")
                        .HasColumnType("TIMESTAMP(7)");

                    b.Property<string>("NomeSetor")
                        .IsRequired()
                        .HasColumnType("NVARCHAR2(2000)");

                    b.HasKey("Id");

                    b.ToTable("tb_iasi_empresas_setor", (string)null);
                });

            modelBuilder.Entity("IASI.Empresas.Domain.Entities.UsuarioEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("NUMBER(10)");

                    OraclePropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<bool>("Ativo")
                        .HasColumnType("NUMBER(1)");

                    b.Property<DateTime?>("DataAtualizacao")
                        .HasColumnType("TIMESTAMP(7)");

                    b.Property<DateTime?>("DataCriacao")
                        .HasColumnType("TIMESTAMP(7)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("NVARCHAR2(2000)");

                    b.Property<string>("NomeUsuario")
                        .IsRequired()
                        .HasColumnType("NVARCHAR2(2000)");

                    b.Property<string>("Role")
                        .IsRequired()
                        .HasColumnType("NVARCHAR2(2000)");

                    b.Property<string>("Senha")
                        .IsRequired()
                        .HasColumnType("NVARCHAR2(2000)");

                    b.HasKey("Id");

                    b.ToTable("tb_iasi_empresas_usuario", (string)null);
                });

            modelBuilder.Entity("IASI.Empresas.Domain.Entities.ContatoEntity", b =>
                {
                    b.HasOne("IASI.Empresas.Domain.Entities.EmpresaEntity", "Empresa")
                        .WithMany("Contatos")
                        .HasForeignKey("EmpresaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Empresa");
                });

            modelBuilder.Entity("IASI.Empresas.Domain.Entities.DocumentoEntity", b =>
                {
                    b.HasOne("IASI.Empresas.Domain.Entities.EmpresaEntity", "Empresa")
                        .WithMany("Documentos")
                        .HasForeignKey("EmpresaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Empresa");
                });

            modelBuilder.Entity("IASI.Empresas.Domain.Entities.EmpresaEntity", b =>
                {
                    b.HasOne("IASI.Empresas.Domain.Entities.SetorEntity", null)
                        .WithMany("Empresas")
                        .HasForeignKey("SetorEntityId");
                });

            modelBuilder.Entity("IASI.Empresas.Domain.Entities.EnderecoEntity", b =>
                {
                    b.HasOne("IASI.Empresas.Domain.Entities.EmpresaEntity", "Empresa")
                        .WithMany("Enderecos")
                        .HasForeignKey("EmpresaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Empresa");
                });

            modelBuilder.Entity("IASI.Empresas.Domain.Entities.RelatorioEntity", b =>
                {
                    b.HasOne("IASI.Empresas.Domain.Entities.EmpresaEntity", "Empresa")
                        .WithMany("Relatorios")
                        .HasForeignKey("EmpresaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("IASI.Empresas.Domain.Entities.RelatorioTipoEntity", null)
                        .WithMany("Relatorios")
                        .HasForeignKey("RelatorioTipoEntityId");

                    b.Navigation("Empresa");
                });

            modelBuilder.Entity("IASI.Empresas.Domain.Entities.EmpresaEntity", b =>
                {
                    b.Navigation("Contatos");

                    b.Navigation("Documentos");

                    b.Navigation("Enderecos");

                    b.Navigation("Relatorios");
                });

            modelBuilder.Entity("IASI.Empresas.Domain.Entities.RelatorioTipoEntity", b =>
                {
                    b.Navigation("Relatorios");
                });

            modelBuilder.Entity("IASI.Empresas.Domain.Entities.SetorEntity", b =>
                {
                    b.Navigation("Empresas");
                });
#pragma warning restore 612, 618
        }
    }
}
