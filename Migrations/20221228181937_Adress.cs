using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Costea_Maria_ClaudiaBakeryShop.Migrations
{
    public partial class Adress : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AdressID",
                table: "Product",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Adress",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AdressName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Adress", x => x.ID);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Product_AdressID",
                table: "Product",
                column: "AdressID");

            migrationBuilder.AddForeignKey(
                name: "FK_Product_Adress_AdressID",
                table: "Product",
                column: "AdressID",
                principalTable: "Adress",
                principalColumn: "ID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Product_Adress_AdressID",
                table: "Product");

            migrationBuilder.DropTable(
                name: "Adress");

            migrationBuilder.DropIndex(
                name: "IX_Product_AdressID",
                table: "Product");

            migrationBuilder.DropColumn(
                name: "AdressID",
                table: "Product");
        }
    }
}
