using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ApiWeb.Migrations
{
    public partial class MigracionBD : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "Cat");

            migrationBuilder.CreateTable(
                name: "Grupo",
                schema: "Cat",
                columns: table => new
                {
                    IdGrupo = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(maxLength: 100, nullable: false),
                    Descripcion = table.Column<string>(maxLength: 300, nullable: false),
                    Activo = table.Column<bool>(nullable: false),
                    FechaCreo = table.Column<DateTime>(nullable: false),
                    FechaModifico = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Grupo", x => x.IdGrupo);
                });

            migrationBuilder.CreateTable(
                name: "Proveedor",
                schema: "Cat",
                columns: table => new
                {
                    IdProveedor = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(maxLength: 100, nullable: false),
                    Correo = table.Column<string>(maxLength: 320, nullable: false),
                    Direccion = table.Column<string>(maxLength: 200, nullable: false),
                    Pais = table.Column<string>(maxLength: 50, nullable: false),
                    Activo = table.Column<bool>(nullable: false),
                    FechaCreo = table.Column<DateTime>(nullable: false),
                    FechaModifico = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Proveedor", x => x.IdProveedor);
                });

            migrationBuilder.CreateTable(
                name: "UnidadMedida",
                schema: "Cat",
                columns: table => new
                {
                    IdUnidadMedida = table.Column<string>(nullable: false),
                    Descripcion = table.Column<int>(maxLength: 100, nullable: false),
                    FechaModifico = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UnidadMedida", x => x.IdUnidadMedida);
                });

            migrationBuilder.CreateTable(
                name: "Contacto",
                schema: "Cat",
                columns: table => new
                {
                    IdContacto = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Numero = table.Column<int>(nullable: false),
                    Nombre = table.Column<string>(maxLength: 100, nullable: false),
                    Telefono = table.Column<string>(maxLength: 100, nullable: false),
                    IdProveedor = table.Column<int>(nullable: false),
                    Activo = table.Column<bool>(nullable: false),
                    FechaCreo = table.Column<DateTime>(nullable: false),
                    FechaModifico = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contacto", x => x.IdContacto);
                    table.ForeignKey(
                        name: "FK_Contacto_Proveedor_IdProveedor",
                        column: x => x.IdProveedor,
                        principalSchema: "Cat",
                        principalTable: "Proveedor",
                        principalColumn: "IdProveedor",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Producto",
                schema: "Cat",
                columns: table => new
                {
                    IdProducto = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descripcion = table.Column<string>(maxLength: 100, nullable: false),
                    Costo = table.Column<decimal>(type: "money", nullable: false),
                    Precio = table.Column<decimal>(type: "money", nullable: false),
                    Codigo = table.Column<string>(maxLength: 50, nullable: false),
                    IdGrupo = table.Column<int>(nullable: false),
                    IdProveedor = table.Column<int>(nullable: false),
                    IdUnidadMedida = table.Column<string>(nullable: false),
                    Activo = table.Column<bool>(nullable: false),
                    FechaCreo = table.Column<DateTime>(nullable: false),
                    FechaModifico = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Producto", x => x.IdProducto);
                    table.ForeignKey(
                        name: "FK_Producto_Grupo_IdGrupo",
                        column: x => x.IdGrupo,
                        principalSchema: "Cat",
                        principalTable: "Grupo",
                        principalColumn: "IdGrupo",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Producto_Proveedor_IdProveedor",
                        column: x => x.IdProveedor,
                        principalSchema: "Cat",
                        principalTable: "Proveedor",
                        principalColumn: "IdProveedor",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Producto_UnidadMedida_IdUnidadMedida",
                        column: x => x.IdUnidadMedida,
                        principalSchema: "Cat",
                        principalTable: "UnidadMedida",
                        principalColumn: "IdUnidadMedida",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Contacto_IdProveedor",
                schema: "Cat",
                table: "Contacto",
                column: "IdProveedor");

            migrationBuilder.CreateIndex(
                name: "IX_Producto_IdGrupo",
                schema: "Cat",
                table: "Producto",
                column: "IdGrupo");

            migrationBuilder.CreateIndex(
                name: "IX_Producto_IdProveedor",
                schema: "Cat",
                table: "Producto",
                column: "IdProveedor");

            migrationBuilder.CreateIndex(
                name: "IX_Producto_IdUnidadMedida",
                schema: "Cat",
                table: "Producto",
                column: "IdUnidadMedida");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Contacto",
                schema: "Cat");

            migrationBuilder.DropTable(
                name: "Producto",
                schema: "Cat");

            migrationBuilder.DropTable(
                name: "Grupo",
                schema: "Cat");

            migrationBuilder.DropTable(
                name: "Proveedor",
                schema: "Cat");

            migrationBuilder.DropTable(
                name: "UnidadMedida",
                schema: "Cat");
        }
    }
}
