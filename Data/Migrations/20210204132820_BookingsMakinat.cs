using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace RentalRazorPages.Migrations
{
    public partial class BookingsMakinat : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Markat",
                columns: table => new
                {
                    MarkaId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    MarkaEmer = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Markat", x => x.MarkaId);
                });

            migrationBuilder.CreateTable(
                name: "Modelet",
                columns: table => new
                {
                    ModeliId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ModeliEmer = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MarkaId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Modelet", x => x.ModeliId);
                    table.ForeignKey(
                        name: "FK_Modelet_Markat_MarkaId",
                        column: x => x.MarkaId,
                        principalTable: "Markat",
                        principalColumn: "MarkaId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Makinat",
                columns: table => new
                {
                    MakinaId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    MakinaEmer = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MarkaId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ModeliId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    Karburanti = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FuqiaMotorrike = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Kambjo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    VitiProdhimit = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ImageName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Makinat", x => x.MakinaId);
                    table.ForeignKey(
                        name: "FK_Makinat_Markat_MarkaId",
                        column: x => x.MarkaId,
                        principalTable: "Markat",
                        principalColumn: "MarkaId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Makinat_Modelet_ModeliId",
                        column: x => x.ModeliId,
                        principalTable: "Modelet",
                        principalColumn: "ModeliId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Bookings",
                columns: table => new
                {
                    BookingId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DateFrom = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateTo = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PickUpLocation = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ReturnLocation = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MakinaId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bookings", x => x.BookingId);
                    table.ForeignKey(
                        name: "FK_Bookings_Makinat_MakinaId",
                        column: x => x.MakinaId,
                        principalTable: "Makinat",
                        principalColumn: "MakinaId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Markat",
                columns: new[] { "MarkaId", "MarkaEmer" },
                values: new object[] { "Benz", "Mercedes-benz" });

            migrationBuilder.InsertData(
                table: "Markat",
                columns: new[] { "MarkaId", "MarkaEmer" },
                values: new object[] { "Toyota", "Toyota" });

            migrationBuilder.InsertData(
                table: "Markat",
                columns: new[] { "MarkaId", "MarkaEmer" },
                values: new object[] { "Ford", "Ford" });

            migrationBuilder.InsertData(
                table: "Modelet",
                columns: new[] { "ModeliId", "MarkaId", "ModeliEmer" },
                values: new object[] { "A", "Benz", "A-class" });

            migrationBuilder.InsertData(
                table: "Modelet",
                columns: new[] { "ModeliId", "MarkaId", "ModeliEmer" },
                values: new object[] { "Yaris", "Toyota", "Yaris" });

            migrationBuilder.InsertData(
                table: "Modelet",
                columns: new[] { "ModeliId", "MarkaId", "ModeliEmer" },
                values: new object[] { "Focus", "Ford", "Focus" });

            migrationBuilder.CreateIndex(
                name: "IX_Bookings_MakinaId",
                table: "Bookings",
                column: "MakinaId");

            migrationBuilder.CreateIndex(
                name: "IX_Makinat_MarkaId",
                table: "Makinat",
                column: "MarkaId");

            migrationBuilder.CreateIndex(
                name: "IX_Makinat_ModeliId",
                table: "Makinat",
                column: "ModeliId");

            migrationBuilder.CreateIndex(
                name: "IX_Modelet_MarkaId",
                table: "Modelet",
                column: "MarkaId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Bookings");

            migrationBuilder.DropTable(
                name: "Makinat");

            migrationBuilder.DropTable(
                name: "Modelet");

            migrationBuilder.DropTable(
                name: "Markat");
        }
    }
}
