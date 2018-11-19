using Microsoft.EntityFrameworkCore.Migrations;

namespace Koszyk.Migrations
{
    public partial class urlzdjeciarequired : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "urlZdjecia",
                table: "produkty",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "urlZdjecia",
                table: "produkty",
                nullable: true,
                oldClrType: typeof(string));
        }
    }
}
