using Microsoft.EntityFrameworkCore.Migrations;

namespace Koszyk.Migrations
{
    public partial class dodanieobrazkow : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "nazwaObrazka",
                table: "produkty",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "nazwaObrazka",
                table: "produkty");
        }
    }
}
