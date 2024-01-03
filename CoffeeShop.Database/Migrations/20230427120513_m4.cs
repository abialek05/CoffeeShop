using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CoffeeShop.Database.Migrations
{
    public partial class m4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Product_IdGrindLevel",
                table: "Product",
                column: "IdGrindLevel");

            migrationBuilder.CreateIndex(
                name: "IX_Product_IdProductType",
                table: "Product",
                column: "IdProductType");

            migrationBuilder.AddForeignKey(
                name: "FK_Product_GrindLevel_IdGrindLevel",
                table: "Product",
                column: "IdGrindLevel",
                principalTable: "GrindLevel",
                principalColumn: "IdGrindLevel",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Product_ProductType_IdProductType",
                table: "Product",
                column: "IdProductType",
                principalTable: "ProductType",
                principalColumn: "IdProductType",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Product_GrindLevel_IdGrindLevel",
                table: "Product");

            migrationBuilder.DropForeignKey(
                name: "FK_Product_ProductType_IdProductType",
                table: "Product");

            migrationBuilder.DropIndex(
                name: "IX_Product_IdGrindLevel",
                table: "Product");

            migrationBuilder.DropIndex(
                name: "IX_Product_IdProductType",
                table: "Product");
        }
    }
}
