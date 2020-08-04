using Microsoft.EntityFrameworkCore.Migrations;

namespace NeraChile.Web.Migrations
{
    public partial class terceraBd : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Atencion_Clientes_ClienteId",
                table: "Atencion");

            migrationBuilder.DropForeignKey(
                name: "FK_Atencion_Atencion_atencionId",
                table: "Atencion");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Atencion",
                table: "Atencion");

            migrationBuilder.RenameTable(
                name: "Atencion",
                newName: "Atencions");

            migrationBuilder.RenameColumn(
                name: "tipo_vehiculo",
                table: "Atencions",
                newName: "Tipo_vehiculo");

            migrationBuilder.RenameColumn(
                name: "tipo_de_servicio",
                table: "Atencions",
                newName: "Tipo_de_servicio");

            migrationBuilder.RenameColumn(
                name: "odometro_inicial",
                table: "Atencions",
                newName: "Odometro_inicial");

            migrationBuilder.RenameColumn(
                name: "odometro_final",
                table: "Atencions",
                newName: "Odometro_final");

            migrationBuilder.RenameColumn(
                name: "odometro_de_llegada",
                table: "Atencions",
                newName: "Odometro_de_llegada");

            migrationBuilder.RenameColumn(
                name: "observaciones",
                table: "Atencions",
                newName: "Observaciones");

            migrationBuilder.RenameColumn(
                name: "hora_termino",
                table: "Atencions",
                newName: "Hora_termino");

            migrationBuilder.RenameColumn(
                name: "hora_de_llegada",
                table: "Atencions",
                newName: "Hora_de_llegada");

            migrationBuilder.RenameColumn(
                name: "hora_de_llamada",
                table: "Atencions",
                newName: "Hora_de_llamada");

            migrationBuilder.RenameIndex(
                name: "IX_Atencion_atencionId",
                table: "Atencions",
                newName: "IX_Atencions_atencionId");

            migrationBuilder.RenameIndex(
                name: "IX_Atencion_ClienteId",
                table: "Atencions",
                newName: "IX_Atencions_ClienteId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Atencions",
                table: "Atencions",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Atencions_Clientes_ClienteId",
                table: "Atencions",
                column: "ClienteId",
                principalTable: "Clientes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Atencions_Atencions_atencionId",
                table: "Atencions",
                column: "atencionId",
                principalTable: "Atencions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Atencions_Clientes_ClienteId",
                table: "Atencions");

            migrationBuilder.DropForeignKey(
                name: "FK_Atencions_Atencions_atencionId",
                table: "Atencions");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Atencions",
                table: "Atencions");

            migrationBuilder.RenameTable(
                name: "Atencions",
                newName: "Atencion");

            migrationBuilder.RenameColumn(
                name: "Tipo_vehiculo",
                table: "Atencion",
                newName: "tipo_vehiculo");

            migrationBuilder.RenameColumn(
                name: "Tipo_de_servicio",
                table: "Atencion",
                newName: "tipo_de_servicio");

            migrationBuilder.RenameColumn(
                name: "Odometro_inicial",
                table: "Atencion",
                newName: "odometro_inicial");

            migrationBuilder.RenameColumn(
                name: "Odometro_final",
                table: "Atencion",
                newName: "odometro_final");

            migrationBuilder.RenameColumn(
                name: "Odometro_de_llegada",
                table: "Atencion",
                newName: "odometro_de_llegada");

            migrationBuilder.RenameColumn(
                name: "Observaciones",
                table: "Atencion",
                newName: "observaciones");

            migrationBuilder.RenameColumn(
                name: "Hora_termino",
                table: "Atencion",
                newName: "hora_termino");

            migrationBuilder.RenameColumn(
                name: "Hora_de_llegada",
                table: "Atencion",
                newName: "hora_de_llegada");

            migrationBuilder.RenameColumn(
                name: "Hora_de_llamada",
                table: "Atencion",
                newName: "hora_de_llamada");

            migrationBuilder.RenameIndex(
                name: "IX_Atencions_atencionId",
                table: "Atencion",
                newName: "IX_Atencion_atencionId");

            migrationBuilder.RenameIndex(
                name: "IX_Atencions_ClienteId",
                table: "Atencion",
                newName: "IX_Atencion_ClienteId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Atencion",
                table: "Atencion",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Atencion_Clientes_ClienteId",
                table: "Atencion",
                column: "ClienteId",
                principalTable: "Clientes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Atencion_Atencion_atencionId",
                table: "Atencion",
                column: "atencionId",
                principalTable: "Atencion",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
