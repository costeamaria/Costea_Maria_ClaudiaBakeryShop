using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Costea_Maria_ClaudiaBakeryShop.Migrations
{
    public partial class Quantity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "QuantityID",
                table: "Product",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Quantity",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    QuantityName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Quantity", x => x.ID);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Product_QuantityID",
                table: "Product",
                column: "QuantityID");

            migrationBuilder.AddForeignKey(
                name: "FK_Product_Quantity_QuantityID",
                table: "Product",
                column: "QuantityID",
                principalTable: "Quantity",
                principalColumn: "ID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Product_Quantity_QuantityID",
                table: "Product");

            migrationBuilder.DropTable(
                name: "Quantity");

            migrationBuilder.DropIndex(
                name: "IX_Product_QuantityID",
                table: "Product");

            migrationBuilder.DropColumn(
                name: "QuantityID",
                table: "Product");
        }
    }
}
