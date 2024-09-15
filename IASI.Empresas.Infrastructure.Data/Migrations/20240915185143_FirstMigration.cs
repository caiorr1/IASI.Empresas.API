using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IASI.Empresas.Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class FirstMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "tb_iasi_empresas_relatorio_tipo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    NomeTipo = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    DataCriacao = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: true),
                    DataAtualizacao = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_iasi_empresas_relatorio_tipo", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tb_iasi_empresas_setor",
                columns: table => new
                {
                    Id = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    NomeSetor = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    DataCriacao = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: true),
                    DataAtualizacao = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_iasi_empresas_setor", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tb_iasi_empresas_usuario",
                columns: table => new
                {
                    Id = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    NomeUsuario = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    Email = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    Senha = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    Role = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    Ativo = table.Column<bool>(type: "NUMBER(1)", nullable: false),
                    DataCriacao = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: true),
                    DataAtualizacao = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_iasi_empresas_usuario", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tb_iasi_empresas_empresa",
                columns: table => new
                {
                    Id = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    NomeEmpresa = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    SetorIndustrialEmpresa = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    LocalizacaoEmpresa = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    TipoEmpresa = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    ConformidadeRegulamentar = table.Column<string>(type: "NVARCHAR2(1)", nullable: false),
                    SetorEntityId = table.Column<int>(type: "NUMBER(10)", nullable: true),
                    DataCriacao = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: true),
                    DataAtualizacao = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_iasi_empresas_empresa", x => x.Id);
                    table.ForeignKey(
                        name: "FK_tb_iasi_empresas_empresa_tb_iasi_empresas_setor_SetorEntityId",
                        column: x => x.SetorEntityId,
                        principalTable: "tb_iasi_empresas_setor",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "tb_iasi_empresas_contato",
                columns: table => new
                {
                    Id = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    EmpresaId = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    NomeContato = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    CargoContato = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    EmailContato = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    TelefoneContato = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    DataCriacao = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: true),
                    DataAtualizacao = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_iasi_empresas_contato", x => x.Id);
                    table.ForeignKey(
                        name: "FK_tb_iasi_empresas_contato_tb_iasi_empresas_empresa_EmpresaId",
                        column: x => x.EmpresaId,
                        principalTable: "tb_iasi_empresas_empresa",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tb_iasi_empresas_documento",
                columns: table => new
                {
                    Id = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    EmpresaId = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    TipoDocumento = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    NomeDocumento = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    DataEmissao = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: false),
                    DataValidade = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: true),
                    Conteudo = table.Column<byte[]>(type: "RAW(2000)", nullable: false),
                    DataCriacao = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: true),
                    DataAtualizacao = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_iasi_empresas_documento", x => x.Id);
                    table.ForeignKey(
                        name: "FK_tb_iasi_empresas_documento_tb_iasi_empresas_empresa_EmpresaId",
                        column: x => x.EmpresaId,
                        principalTable: "tb_iasi_empresas_empresa",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tb_iasi_empresas_endereco",
                columns: table => new
                {
                    Id = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    Rua = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    Cidade = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    Estado = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    Pais = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    CEP = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    EmpresaId = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    DataCriacao = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: true),
                    DataAtualizacao = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_iasi_empresas_endereco", x => x.Id);
                    table.ForeignKey(
                        name: "FK_tb_iasi_empresas_endereco_tb_iasi_empresas_empresa_EmpresaId",
                        column: x => x.EmpresaId,
                        principalTable: "tb_iasi_empresas_empresa",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tb_iasi_empresas_relatorio",
                columns: table => new
                {
                    Id = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    EmpresaId = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    TipoRelatorio = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    DataGeracao = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: false),
                    Descricao = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    RelatorioTipoEntityId = table.Column<int>(type: "NUMBER(10)", nullable: true),
                    DataCriacao = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: true),
                    DataAtualizacao = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_iasi_empresas_relatorio", x => x.Id);
                    table.ForeignKey(
                        name: "FK_tb_iasi_empresas_relatorio_tb_iasi_empresas_empresa_EmpresaId",
                        column: x => x.EmpresaId,
                        principalTable: "tb_iasi_empresas_empresa",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tb_iasi_empresas_relatorio_tb_iasi_empresas_relatorio_tipo_RelatorioTipoEntityId",
                        column: x => x.RelatorioTipoEntityId,
                        principalTable: "tb_iasi_empresas_relatorio_tipo",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_tb_iasi_empresas_contato_EmpresaId",
                table: "tb_iasi_empresas_contato",
                column: "EmpresaId");

            migrationBuilder.CreateIndex(
                name: "IX_tb_iasi_empresas_documento_EmpresaId",
                table: "tb_iasi_empresas_documento",
                column: "EmpresaId");

            migrationBuilder.CreateIndex(
                name: "IX_tb_iasi_empresas_empresa_SetorEntityId",
                table: "tb_iasi_empresas_empresa",
                column: "SetorEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_tb_iasi_empresas_endereco_EmpresaId",
                table: "tb_iasi_empresas_endereco",
                column: "EmpresaId");

            migrationBuilder.CreateIndex(
                name: "IX_tb_iasi_empresas_relatorio_EmpresaId",
                table: "tb_iasi_empresas_relatorio",
                column: "EmpresaId");

            migrationBuilder.CreateIndex(
                name: "IX_tb_iasi_empresas_relatorio_RelatorioTipoEntityId",
                table: "tb_iasi_empresas_relatorio",
                column: "RelatorioTipoEntityId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tb_iasi_empresas_contato");

            migrationBuilder.DropTable(
                name: "tb_iasi_empresas_documento");

            migrationBuilder.DropTable(
                name: "tb_iasi_empresas_endereco");

            migrationBuilder.DropTable(
                name: "tb_iasi_empresas_relatorio");

            migrationBuilder.DropTable(
                name: "tb_iasi_empresas_usuario");

            migrationBuilder.DropTable(
                name: "tb_iasi_empresas_empresa");

            migrationBuilder.DropTable(
                name: "tb_iasi_empresas_relatorio_tipo");

            migrationBuilder.DropTable(
                name: "tb_iasi_empresas_setor");
        }
    }
}
