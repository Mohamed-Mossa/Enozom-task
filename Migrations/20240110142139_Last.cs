using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Enozomtask.Migrations
{
    /// <inheritdoc />
    public partial class Last : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Hotels",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    name = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Hotels", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Prices",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Cost = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    Room = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    HotelID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Prices", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Prices_Hotels_HotelID",
                        column: x => x.HotelID,
                        principalTable: "Hotels",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.InsertData(
                table: "Hotels",
                columns: new[] { "Id", "name" },
                values: new object[,]
                {
                    { 1, "Sheraton" },
                    { 2, "Helnan" },
                    { 3, "Tolip" }
                });

            migrationBuilder.InsertData(
                table: "Prices",
                columns: new[] { "Id", "Cost", "HotelID", "Room" },
                values: new object[,]
                {
                    { 1, 200m, 1, "Double Room Sea View" },
                    { 2, 150m, 1, "SingleRoom Sea View" },
                    { 3, 170m, 1, "Double Room City View" },
                    { 4, 120m, 1, "Single Room City View " },
                    { 5, 100m, 2, "Double Room Garden View" },
                    { 6, 90m, 2, "Single Room Garden View" },
                    { 7, 120m, 2, "Double Room Pool View" },
                    { 8, 110m, 2, "Single Room Pool View" },
                    { 9, 80m, 3, "Double Room Standard" },
                    { 10, 70m, 3, "Single Room Standard" },
                    { 11, 100m, 3, "Double Room Deluxe" },
                    { 12, 95m, 3, "Single Room Deluxe" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Prices_HotelID",
                table: "Prices",
                column: "HotelID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Prices");

            migrationBuilder.DropTable(
                name: "Hotels");
        }
    }
}
