using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ERP.Infra.Data.Migrations.GruposEmpresariais
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "cnaes",
                columns: table => new
                {
                    id = table.Column<Guid>(nullable: false),
                    data_cadastro = table.Column<DateTime>(nullable: false),
                    data_ultima_atualizacao = table.Column<DateTime>(nullable: false),
                    desativado = table.Column<bool>(nullable: false, defaultValue: false),
                    codigo = table.Column<string>(maxLength: 7, nullable: false),
                    descricao = table.Column<string>(maxLength: 255, nullable: false),
                    cnae_pai = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_cnae_id", x => x.id);
                    table.UniqueConstraint("AK_cnaes_codigo", x => x.codigo);
                });

            migrationBuilder.CreateTable(
                name: "grupos_empresariais",
                columns: table => new
                {
                    id = table.Column<Guid>(nullable: false),
                    data_cadastro = table.Column<DateTime>(nullable: false),
                    data_ultima_atualizacao = table.Column<DateTime>(nullable: false),
                    desativado = table.Column<bool>(nullable: false, defaultValue: false),
                    codigo = table.Column<string>(maxLength: 30, nullable: false),
                    descricao = table.Column<string>(maxLength: 150, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_grupo_empresarial_id", x => x.id);
                    table.UniqueConstraint("AK_grupos_empresariais_codigo", x => x.codigo);
                });

            migrationBuilder.CreateTable(
                name: "usuarios",
                columns: table => new
                {
                    id = table.Column<Guid>(nullable: false),
                    DataCadastro = table.Column<DateTime>(nullable: false),
                    DataUltimaAtualizacao = table.Column<DateTime>(nullable: false),
                    Desativado = table.Column<bool>(nullable: false),
                    nome = table.Column<string>(nullable: false),
                    sobrenome = table.Column<string>(nullable: false),
                    email = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_usuario_id", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "empresas",
                columns: table => new
                {
                    id = table.Column<Guid>(nullable: false),
                    data_cadastro = table.Column<DateTime>(nullable: false),
                    data_ultima_atualizacao = table.Column<DateTime>(nullable: false),
                    desativado = table.Column<bool>(nullable: false, defaultValue: false),
                    codigo = table.Column<string>(maxLength: 30, nullable: false),
                    descricao = table.Column<string>(maxLength: 150, nullable: false),
                    nome_fantasia = table.Column<string>(maxLength: 150, nullable: false),
                    email = table.Column<string>(maxLength: 150, nullable: false),
                    site = table.Column<string>(maxLength: 100, nullable: false),
                    bloqueada = table.Column<bool>(nullable: false, defaultValue: false),
                    data_registro = table.Column<DateTime>(nullable: false),
                    logotipo = table.Column<byte[]>(nullable: true),
                    observacao = table.Column<string>(nullable: true),
                    documento = table.Column<string>(maxLength: 14, nullable: false),
                    tipo_identificacao = table.Column<int>(nullable: false),
                    grupo_empresarial_id = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_empresa_id", x => x.id);
                    table.UniqueConstraint("AK_empresas_codigo", x => x.codigo);
                    table.ForeignKey(
                        name: "fk_grupo_empresarial_id",
                        column: x => x.grupo_empresarial_id,
                        principalTable: "grupos_empresariais",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "estabelecimentos",
                columns: table => new
                {
                    id = table.Column<Guid>(nullable: false),
                    data_cadastro = table.Column<DateTime>(nullable: false),
                    data_ultima_atualizacao = table.Column<DateTime>(nullable: false),
                    desativado = table.Column<bool>(nullable: false, defaultValue: false),
                    codigo = table.Column<string>(maxLength: 30, nullable: false),
                    descricao = table.Column<string>(maxLength: 150, nullable: false),
                    nome_fantasia = table.Column<string>(maxLength: 150, nullable: false),
                    inscricao_estadual = table.Column<string>(maxLength: 20, nullable: false),
                    inscricao_municipal = table.Column<string>(maxLength: 20, nullable: false),
                    email = table.Column<string>(maxLength: 150, nullable: false),
                    site = table.Column<string>(maxLength: 100, nullable: false),
                    bloqueado = table.Column<bool>(nullable: false, defaultValue: false),
                    data_registro = table.Column<DateTime>(nullable: false),
                    logotipo = table.Column<byte[]>(nullable: true),
                    matriz = table.Column<bool>(nullable: false),
                    observacao = table.Column<string>(nullable: true),
                    documento = table.Column<string>(maxLength: 14, nullable: false),
                    tipo_identificacao = table.Column<int>(nullable: false),
                    empresa_id = table.Column<Guid>(nullable: false),
                    cnae_id = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_estabelecimento_id", x => x.id);
                    table.UniqueConstraint("AK_estabelecimentos_codigo", x => x.codigo);
                    table.ForeignKey(
                        name: "fk_cnae_id",
                        column: x => x.cnae_id,
                        principalTable: "cnaes",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_empresa_id",
                        column: x => x.empresa_id,
                        principalTable: "empresas",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_empresas_grupo_empresarial_id",
                table: "empresas",
                column: "grupo_empresarial_id");

            migrationBuilder.CreateIndex(
                name: "IX_estabelecimentos_cnae_id",
                table: "estabelecimentos",
                column: "cnae_id");

            migrationBuilder.CreateIndex(
                name: "IX_estabelecimentos_empresa_id",
                table: "estabelecimentos",
                column: "empresa_id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "estabelecimentos");

            migrationBuilder.DropTable(
                name: "usuarios");

            migrationBuilder.DropTable(
                name: "cnaes");

            migrationBuilder.DropTable(
                name: "empresas");

            migrationBuilder.DropTable(
                name: "grupos_empresariais");
        }
    }
}
