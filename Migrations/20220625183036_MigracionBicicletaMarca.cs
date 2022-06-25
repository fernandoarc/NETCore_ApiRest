using Microsoft.EntityFrameworkCore.Migrations;

namespace NetCore_API.Migrations
{
    public partial class MigracionBicicletaMarca : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Vigente",
                table: "BicicletaMarca",
                unicode: false,
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Vigente",
                table: "BicicletaMarca");
        }
    }
}
