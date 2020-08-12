using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TPAplicada1.Migrations
{
    public partial class Inicial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "amigos",
                columns: table => new
                {
                    AmigoId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nombre = table.Column<string>(nullable: true),
                    Direccion = table.Column<string>(nullable: true),
                    Telefono = table.Column<string>(nullable: true),
                    Celular = table.Column<string>(nullable: true),
                    FechaNacimiento = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_amigos", x => x.AmigoId);
                });

            migrationBuilder.CreateTable(
                name: "entradas",
                columns: table => new
                {
                    EntradaId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Fecha = table.Column<DateTime>(nullable: false),
                    JuegoId = table.Column<int>(nullable: false),
                    Cantidad = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_entradas", x => x.EntradaId);
                });

            migrationBuilder.CreateTable(
                name: "juegos",
                columns: table => new
                {
                    JuegoId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    FechaCompra = table.Column<DateTime>(nullable: false),
                    Descripcion = table.Column<string>(nullable: true),
                    Precio = table.Column<double>(nullable: false),
                    Existencias = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_juegos", x => x.JuegoId);
                });

            migrationBuilder.CreateTable(
                name: "prestamos",
                columns: table => new
                {
                    PrestamoId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Fecha = table.Column<DateTime>(nullable: false),
                    AmigoId = table.Column<int>(nullable: false),
                    Observacion = table.Column<string>(nullable: true),
                    CantidadJuegos = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_prestamos", x => x.PrestamoId);
                });

            migrationBuilder.CreateTable(
                name: "PrestamosDetalle",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    PrestamoId = table.Column<int>(nullable: false),
                    Fecha = table.Column<DateTime>(nullable: false),
                    JuegoId = table.Column<int>(nullable: false),
                    Juego_Nombre = table.Column<string>(nullable: true),
                    Amigo_Nombre = table.Column<string>(nullable: true),
                    Cantidad = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PrestamosDetalle", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PrestamosDetalle_prestamos_PrestamoId",
                        column: x => x.PrestamoId,
                        principalTable: "prestamos",
                        principalColumn: "PrestamoId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PrestamosDetalle_PrestamoId",
                table: "PrestamosDetalle",
                column: "PrestamoId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "amigos");

            migrationBuilder.DropTable(
                name: "entradas");

            migrationBuilder.DropTable(
                name: "juegos");

            migrationBuilder.DropTable(
                name: "PrestamosDetalle");

            migrationBuilder.DropTable(
                name: "prestamos");
        }
    }
}
