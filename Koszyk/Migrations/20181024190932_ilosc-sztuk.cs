using Microsoft.EntityFrameworkCore.Migrations;

namespace Koszyk.Migrations
{
    public partial class iloscsztuk : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ilosc",
                table: "produkty",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ilosc",
                table: "produkty");
        }
    }
}
