using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ERP.Infra.Data.Migrations
{
    public partial class EventStore : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "stored_events",
                columns: table => new
                {
                    id = table.Column<Guid>(nullable: false),
                    acao = table.Column<string>(type: "varchar(100)", nullable: true),
                    aggregate_id = table.Column<Guid>(nullable: false),
                    data_cadastro = table.Column<DateTime>(nullable: false),
                    data = table.Column<string>(nullable: true),
                    usuario = table.Column<string>(type: "varchar(100)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_stored_event_id", x => x.id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "stored_events");
        }
    }
}
