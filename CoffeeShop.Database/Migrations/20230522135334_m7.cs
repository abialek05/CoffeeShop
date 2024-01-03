using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CoffeeShop.Database.Migrations
{
    public partial class m7 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Product_GrindLevel_IdGrindLevel",
                table: "Product");

            migrationBuilder.DropForeignKey(
                name: "FK_Product_ProductType_IdProductType",
                table: "Product");

            migrationBuilder.RenameColumn(
                name: "IdProductType",
                table: "Product",
                newName: "ProductTypeId");

            migrationBuilder.RenameColumn(
                name: "IdGrindLevel",
                table: "Product",
                newName: "GrindLevelId");

            migrationBuilder.RenameIndex(
                name: "IX_Product_IdProductType",
                table: "Product",
                newName: "IX_Product_ProductTypeId");

            migrationBuilder.RenameIndex(
                name: "IX_Product_IdGrindLevel",
                table: "Product",
                newName: "IX_Product_GrindLevelId");

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Product",
                type: "nvarchar(MAX)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "PhotoURL",
                table: "Product",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<decimal>(
                name: "Price",
                table: "Product",
                type: "money",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddForeignKey(
                name: "FK_Product_GrindLevel_GrindLevelId",
                table: "Product",
                column: "GrindLevelId",
                principalTable: "GrindLevel",
                principalColumn: "IdGrindLevel",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Product_ProductType_ProductTypeId",
                table: "Product",
                column: "ProductTypeId",
                principalTable: "ProductType",
                principalColumn: "IdProductType",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Product_GrindLevel_GrindLevelId",
                table: "Product");

            migrationBuilder.DropForeignKey(
                name: "FK_Product_ProductType_ProductTypeId",
                table: "Product");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "Product");

            migrationBuilder.DropColumn(
                name: "PhotoURL",
                table: "Product");

            migrationBuilder.DropColumn(
                name: "Price",
                table: "Product");

            migrationBuilder.RenameColumn(
                name: "ProductTypeId",
                table: "Product",
                newName: "IdProductType");

            migrationBuilder.RenameColumn(
                name: "GrindLevelId",
                table: "Product",
                newName: "IdGrindLevel");

            migrationBuilder.RenameIndex(
                name: "IX_Product_ProductTypeId",
                table: "Product",
                newName: "IX_Product_IdProductType");

            migrationBuilder.RenameIndex(
                name: "IX_Product_GrindLevelId",
                table: "Product",
                newName: "IX_Product_IdGrindLevel");

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
    }
}
