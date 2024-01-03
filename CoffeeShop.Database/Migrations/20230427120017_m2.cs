using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CoffeeShop.Database.Migrations
{
    public partial class m2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Product_IdGrindLevel",
                table: "Product");

            migrationBuilder.DropIndex(
                name: "IX_Product_IdProductType",
                table: "Product");

            migrationBuilder.CreateIndex(
                name: "IX_Product_IdGrindLevel",
                table: "Product",
                column: "IdGrindLevel");

            migrationBuilder.CreateIndex(
                name: "IX_Product_IdProductType",
                table: "Product",
                column: "IdProductType");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Product_IdGrindLevel",
                table: "Product");

            migrationBuilder.DropIndex(
                name: "IX_Product_IdProductType",
                table: "Product");

            migrationBuilder.CreateIndex(
                name: "IX_Product_IdGrindLevel",
                table: "Product",
                column: "IdGrindLevel",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Product_IdProductType",
                table: "Product",
                column: "IdProductType",
                unique: true);
        }
    }
}
