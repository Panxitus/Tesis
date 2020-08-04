using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace NeraChile.Web.Migrations
{
    public partial class SegundaDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Atencion",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    hora_de_llamada = table.Column<DateTime>(nullable: false),
                    Fecha_de_llamada = table.Column<DateTime>(nullable: false),
                    odometro_inicial = table.Column<int>(nullable: false),
                    tipo_de_servicio = table.Column<string>(nullable: true),
                    tipo_vehiculo = table.Column<string>(nullable: true),
                    hora_de_llegada = table.Column<DateTime>(nullable: false),
                    odometro_de_llegada = table.Column<int>(nullable: false),
                    observaciones = table.Column<string>(nullable: true),
                    odometro_final = table.Column<int>(nullable: false),
                    hora_termino = table.Column<DateTime>(nullable: false),
                    Estado_del_Servicio = table.Column<string>(nullable: true),
                    atencionId = table.Column<int>(nullable: true),
                    ClienteId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Atencion", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Atencion_Clientes_ClienteId",
                        column: x => x.ClienteId,
                        principalTable: "Clientes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Atencion_Atencion_atencionId",
                        column: x => x.atencionId,
                        principalTable: "Atencion",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Atencion_ClienteId",
                table: "Atencion",
                column: "ClienteId");

            migrationBuilder.CreateIndex(
                name: "IX_Atencion_atencionId",
                table: "Atencion",
                column: "atencionId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Atencion");
        }
    }
}
