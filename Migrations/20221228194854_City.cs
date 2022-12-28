using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Costea_Maria_ClaudiaBakeryShop.Migrations
{
    public partial class City : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CityID",
                table: "Product",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "City",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CityName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_City", x => x.ID);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Product_CityID",
                table: "Product",
                column: "CityID");

            migrationBuilder.AddForeignKey(
                name: "FK_Product_City_CityID",
                table: "Product",
                column: "CityID",
                principalTable: "City",
                principalColumn: "ID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Product_City_CityID",
                table: "Product");

            migrationBuilder.DropTable(
                name: "City");

            migrationBuilder.DropIndex(
                name: "IX_Product_CityID",
                table: "Product");

            migrationBuilder.DropColumn(
                name: "CityID",
                table: "Product");
        }
    }
}
