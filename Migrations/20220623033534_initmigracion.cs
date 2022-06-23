using Microsoft.EntityFrameworkCore.Migrations;

namespace NetCore_API.Migrations
{
    public partial class initmigracion : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BicicletaCategoria",
                columns: table => new
                {
                    IdBicicletaCategoria = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(unicode: false, maxLength: 50, nullable: false),
                    Descripcion = table.Column<string>(unicode: false, maxLength: 250, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BicicletaCategoria", x => x.IdBicicletaCategoria);
                });

            migrationBuilder.CreateTable(
                name: "BicicletaMarca",
                columns: table => new
                {
                    IdBicicletaMarca = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(unicode: false, maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BicicletaMarca", x => x.IdBicicletaMarca);
                });

            migrationBuilder.CreateTable(
                name: "BicicletaModelo",
                columns: table => new
                {
                    IdBicicletaModelo = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(unicode: false, maxLength: 250, nullable: false),
                    Anio = table.Column<int>(unicode: false, nullable: false),
                    IdBicicletaMarca = table.Column<int>(nullable: false),
                    IdBicicletaCategoria = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BicicletaModelo", x => x.IdBicicletaModelo);
                    table.ForeignKey(
                        name: "FK_BicicletaModelo_BicicletaCategoria_IdBicicletaCategoria",
                        column: x => x.IdBicicletaCategoria,
                        principalTable: "BicicletaCategoria",
                        principalColumn: "IdBicicletaCategoria",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BicicletaModelo_BicicletaMarca_IdBicicletaMarca",
                        column: x => x.IdBicicletaMarca,
                        principalTable: "BicicletaMarca",
                        principalColumn: "IdBicicletaMarca",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Bicicleta",
                columns: table => new
                {
                    IdBicicleta = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdBicicletaModelo = table.Column<int>(nullable: false),
                    Serial = table.Column<string>(unicode: false, maxLength: 250, nullable: false),
                    Vigente = table.Column<bool>(unicode: false, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bicicleta", x => x.IdBicicleta);
                    table.ForeignKey(
                        name: "FK_Bicicleta_BicicletaModelo_IdBicicletaModelo",
                        column: x => x.IdBicicletaModelo,
                        principalTable: "BicicletaModelo",
                        principalColumn: "IdBicicletaModelo",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Bicicleta_IdBicicletaModelo",
                table: "Bicicleta",
                column: "IdBicicletaModelo");

            migrationBuilder.CreateIndex(
                name: "IX_BicicletaModelo_IdBicicletaCategoria",
                table: "BicicletaModelo",
                column: "IdBicicletaCategoria");

            migrationBuilder.CreateIndex(
                name: "IX_BicicletaModelo_IdBicicletaMarca",
                table: "BicicletaModelo",
                column: "IdBicicletaMarca");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Bicicleta");

            migrationBuilder.DropTable(
                name: "BicicletaModelo");

            migrationBuilder.DropTable(
                name: "BicicletaCategoria");

            migrationBuilder.DropTable(
                name: "BicicletaMarca");
        }
    }
}
