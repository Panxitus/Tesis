using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace NeraChile.Web.Migrations
{
    public partial class InicioDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Clientes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Rut = table.Column<string>(nullable: false),
                    Nombre = table.Column<string>(nullable: false),
                    Apellido_Paterno = table.Column<string>(nullable: false),
                    Apellido_Materno = table.Column<string>(nullable: false),
                    Dirección = table.Column<string>(nullable: false),
                    Comuna = table.Column<string>(nullable: false),
                    Ciudad = table.Column<string>(nullable: false),
                    Telefono = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clientes", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Clientes");
        }
    }
}
