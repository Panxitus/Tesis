using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace NeraChile.Web.Migrations
{
    public partial class SextaDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Hora_de_llamada",
                table: "Rescate");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "Hora_de_llamada",
                table: "Rescate",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }
    }
}
