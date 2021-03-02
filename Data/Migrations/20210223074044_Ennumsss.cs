using Microsoft.EntityFrameworkCore.Migrations;

namespace RentalRazorPages.Migrations
{
    public partial class Ennumsss : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Karburanti",
                table: "Makinat",
                type: "int",
                nullable: false,
                defaultValue: 0);


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
                name: "Karburanti",
                table: "Makinat");

            migrationBuilder.DropColumn(
                name: "Kambjo",
                table: "Makinat");
        }
    }
}
