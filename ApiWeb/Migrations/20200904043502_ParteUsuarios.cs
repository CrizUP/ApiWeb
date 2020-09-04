using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ApiWeb.Migrations
{
    public partial class ParteUsuarios : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Usuario",
                schema: "Cat",
                columns: table => new
                {
                    IdUsuario = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClientId = table.Column<string>(nullable: false),
                    HashPassword = table.Column<byte[]>(nullable: false),
                    SaltPassword = table.Column<byte[]>(nullable: false),
                    Activo = table.Column<bool>(nullable: false),
                    FechaCreo = table.Column<DateTime>(nullable: false),
                    FechaModifico = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuario", x => x.IdUsuario);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Usuario",
                schema: "Cat");
        }
    }
}
