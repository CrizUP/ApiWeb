using Microsoft.EntityFrameworkCore.Migrations;

namespace ApiWeb.Migrations
{
    public partial class MigracionBD2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Descripcion",
                schema: "Cat",
                table: "UnidadMedida",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldMaxLength: 100);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Descripcion",
                schema: "Cat",
                table: "UnidadMedida",
                type: "int",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 100);
        }
    }
}
