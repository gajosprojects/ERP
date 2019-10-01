using Microsoft.EntityFrameworkCore.Migrations;

namespace ERP.Infra.Data.Migrations.GruposEmpresariais
{
    public partial class CheckConstraintTipoIdentificacao : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("ALTER TABLE empresas ADD CONSTRAINT empresa_check_tipo_identificacao CHECK (tipo_identificacao = 1 OR tipo_identificacao = 2)");
            migrationBuilder.Sql("ALTER TABLE estabelecimentos ADD CONSTRAINT estabelecimento_check_tipo_identificacao CHECK(tipo_identificacao = 1 OR tipo_identificacao = 2)");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("ALTER TABLE empresas DROP CONSTRAINT empresa_check_tipo_identificacao;");
            migrationBuilder.Sql("ALTER TABLE estabelecimentos DROP CONSTRAINT estabelecimento_check_tipo_identificacao;");
        }
    }
}
