using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ERP.Infra.Data.Migrations.GruposEmpresariais
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "usuarios",
                columns: table => new
                {
                    id = table.Column<Guid>(nullable: false),
                    data_cadastro = table.Column<DateTime>(nullable: false),
                    data_ultima_atualizacao = table.Column<DateTime>(nullable: false),
                    ativo = table.Column<bool>(nullable: false, defaultValue: true),
                    nome = table.Column<string>(nullable: false),
                    sobrenome = table.Column<string>(nullable: false),
                    email = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_usuario_id", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "cnaes",
                columns: table => new
                {
                    id = table.Column<Guid>(nullable: false),
                    data_cadastro = table.Column<DateTime>(nullable: false),
                    data_ultima_atualizacao = table.Column<DateTime>(nullable: false),
                    ativo = table.Column<bool>(nullable: false, defaultValue: true),
                    usuario_id = table.Column<Guid>(nullable: false),
                    codigo = table.Column<string>(maxLength: 30, nullable: false),
                    descricao = table.Column<string>(maxLength: 255, nullable: false),
                    cnae_pai = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_cnae_id", x => x.id);
                    table.ForeignKey(
                        name: "fk_usuario_id_cnae",
                        column: x => x.usuario_id,
                        principalTable: "usuarios",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "grupos_empresariais",
                columns: table => new
                {
                    id = table.Column<Guid>(nullable: false),
                    data_cadastro = table.Column<DateTime>(nullable: false),
                    data_ultima_atualizacao = table.Column<DateTime>(nullable: false),
                    ativo = table.Column<bool>(nullable: false, defaultValue: true),
                    usuario_id = table.Column<Guid>(nullable: false),
                    codigo = table.Column<string>(maxLength: 30, nullable: false),
                    descricao = table.Column<string>(maxLength: 150, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_grupo_empresarial_id", x => x.id);
                    table.ForeignKey(
                        name: "fk_usuario_id_grupo_empresarial",
                        column: x => x.usuario_id,
                        principalTable: "usuarios",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "empresas",
                columns: table => new
                {
                    id = table.Column<Guid>(nullable: false),
                    data_cadastro = table.Column<DateTime>(nullable: false),
                    data_ultima_atualizacao = table.Column<DateTime>(nullable: false),
                    ativo = table.Column<bool>(nullable: false, defaultValue: true),
                    usuario_id = table.Column<Guid>(nullable: false),
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
                    table.ForeignKey(
                        name: "fk_grupo_empresarial_id_empresa",
                        column: x => x.grupo_empresarial_id,
                        principalTable: "grupos_empresariais",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_usuario_id_empresa",
                        column: x => x.usuario_id,
                        principalTable: "usuarios",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "estabelecimentos",
                columns: table => new
                {
                    id = table.Column<Guid>(nullable: false),
                    data_cadastro = table.Column<DateTime>(nullable: false),
                    data_ultima_atualizacao = table.Column<DateTime>(nullable: false),
                    ativo = table.Column<bool>(nullable: false, defaultValue: true),
                    usuario_id = table.Column<Guid>(nullable: false),
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
                    table.ForeignKey(
                        name: "fk_cnae_id_estabelecimento",
                        column: x => x.cnae_id,
                        principalTable: "cnaes",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_empresa_id_estabelecimento",
                        column: x => x.empresa_id,
                        principalTable: "empresas",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_usuario_id_estabelecimento",
                        column: x => x.usuario_id,
                        principalTable: "usuarios",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "uk_cnae_codigo",
                table: "cnaes",
                column: "codigo",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_cnaes_usuario_id",
                table: "cnaes",
                column: "usuario_id");

            migrationBuilder.CreateIndex(
                name: "uk_empresa_codigo",
                table: "empresas",
                column: "codigo",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_empresas_grupo_empresarial_id",
                table: "empresas",
                column: "grupo_empresarial_id");

            migrationBuilder.CreateIndex(
                name: "IX_empresas_usuario_id",
                table: "empresas",
                column: "usuario_id");

            migrationBuilder.CreateIndex(
                name: "IX_estabelecimentos_cnae_id",
                table: "estabelecimentos",
                column: "cnae_id");

            migrationBuilder.CreateIndex(
                name: "uk_estabelecimento_codigo",
                table: "estabelecimentos",
                column: "codigo",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_estabelecimentos_empresa_id",
                table: "estabelecimentos",
                column: "empresa_id");

            migrationBuilder.CreateIndex(
                name: "IX_estabelecimentos_usuario_id",
                table: "estabelecimentos",
                column: "usuario_id");

            migrationBuilder.CreateIndex(
                name: "uk_grupo_empresarial_codigo",
                table: "grupos_empresariais",
                column: "codigo",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_grupos_empresariais_usuario_id",
                table: "grupos_empresariais",
                column: "usuario_id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "estabelecimentos");

            migrationBuilder.DropTable(
                name: "cnaes");

            migrationBuilder.DropTable(
                name: "empresas");

            migrationBuilder.DropTable(
                name: "grupos_empresariais");

            migrationBuilder.DropTable(
                name: "usuarios");
        }
    }
}
