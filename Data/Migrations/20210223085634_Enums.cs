using Microsoft.EntityFrameworkCore.Migrations;

namespace RentalRazorPages.Migrations
{
    public partial class Enums : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Kambjo",
                table: "Makinat",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Kambjo",
                table: "Makinat");
        }
    }
}
