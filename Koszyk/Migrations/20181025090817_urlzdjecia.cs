using Microsoft.EntityFrameworkCore.Migrations;

namespace Koszyk.Migrations
{
    public partial class urlzdjecia : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "nazwaObrazka",
                table: "produkty",
                newName: "urlZdjecia");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "urlZdjecia",
                table: "produkty",
                newName: "nazwaObrazka");
        }
    }
}
