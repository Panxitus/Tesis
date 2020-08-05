using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace NeraChile.Web.Migrations
{
    public partial class QuintaDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Atencions_Atencions_atencionId",
                table: "Atencions");

            migrationBuilder.RenameColumn(
                name: "atencionId",
                table: "Atencions",
                newName: "TipoVehiculoId");

            migrationBuilder.RenameIndex(
                name: "IX_Atencions_atencionId",
                table: "Atencions",
                newName: "IX_Atencions_TipoVehiculoId");

            migrationBuilder.AddColumn<int>(
                name: "AutopistaId",
                table: "Atencions",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PropietarioId",
                table: "Atencions",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Autopista",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Nombre = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Autopista", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Propietarios",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Rut = table.Column<string>(nullable: true),
                    Nombre = table.Column<string>(nullable: true),
                    Celular = table.Column<string>(nullable: true),
                    Correo_Electronico = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Propietarios", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Registro",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Descripcion = table.Column<string>(nullable: true),
                    Fecha = table.Column<DateTime>(nullable: false),
                    Estado = table.Column<string>(nullable: true),
                    Comentario = table.Column<string>(nullable: true),
                    RescateId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Registro", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Registro_Atencions_RescateId",
                        column: x => x.RescateId,
                        principalTable: "Atencions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Vehiculos",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Patente = table.Column<string>(nullable: true),
                    Nombre = table.Column<string>(nullable: true),
                    vehiculoId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vehiculos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Vehiculos_Vehiculos_vehiculoId",
                        column: x => x.vehiculoId,
                        principalTable: "Vehiculos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Atencions_AutopistaId",
                table: "Atencions",
                column: "AutopistaId");

            migrationBuilder.CreateIndex(
                name: "IX_Atencions_PropietarioId",
                table: "Atencions",
                column: "PropietarioId");

            migrationBuilder.CreateIndex(
                name: "IX_Registro_RescateId",
                table: "Registro",
                column: "RescateId");

            migrationBuilder.CreateIndex(
                name: "IX_Vehiculos_vehiculoId",
                table: "Vehiculos",
                column: "vehiculoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Atencions_Autopista_AutopistaId",
                table: "Atencions",
                column: "AutopistaId",
                principalTable: "Autopista",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Atencions_Propietarios_PropietarioId",
                table: "Atencions",
                column: "PropietarioId",
                principalTable: "Propietarios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Atencions_Vehiculos_TipoVehiculoId",
                table: "Atencions",
                column: "TipoVehiculoId",
                principalTable: "Vehiculos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Atencions_Autopista_AutopistaId",
                table: "Atencions");

            migrationBuilder.DropForeignKey(
                name: "FK_Atencions_Propietarios_PropietarioId",
                table: "Atencions");

            migrationBuilder.DropForeignKey(
                name: "FK_Atencions_Vehiculos_TipoVehiculoId",
                table: "Atencions");

            migrationBuilder.DropTable(
                name: "Autopista");

            migrationBuilder.DropTable(
                name: "Propietarios");

            migrationBuilder.DropTable(
                name: "Registro");

            migrationBuilder.DropTable(
                name: "Vehiculos");

            migrationBuilder.DropIndex(
                name: "IX_Atencions_AutopistaId",
                table: "Atencions");

            migrationBuilder.DropIndex(
                name: "IX_Atencions_PropietarioId",
                table: "Atencions");

            migrationBuilder.DropColumn(
                name: "AutopistaId",
                table: "Atencions");

            migrationBuilder.DropColumn(
                name: "PropietarioId",
                table: "Atencions");

            migrationBuilder.RenameColumn(
                name: "TipoVehiculoId",
                table: "Atencions",
                newName: "atencionId");

            migrationBuilder.RenameIndex(
                name: "IX_Atencions_TipoVehiculoId",
                table: "Atencions",
                newName: "IX_Atencions_atencionId");

            migrationBuilder.AddForeignKey(
                name: "FK_Atencions_Atencions_atencionId",
                table: "Atencions",
                column: "atencionId",
                principalTable: "Atencions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
