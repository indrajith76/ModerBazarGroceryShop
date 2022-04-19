using Microsoft.EntityFrameworkCore.Migrations;

namespace ModerBazarGroceryShop.Migrations
{
    public partial class added2ndtimeCategory : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ProductCategories",
                table: "Products");

            migrationBuilder.AddColumn<int>(
                name: "CategoriesCategoryID",
                table: "Products",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ProductCategoriesId",
                table: "Products",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Products_CategoriesCategoryID",
                table: "Products",
                column: "CategoriesCategoryID");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Categories_CategoriesCategoryID",
                table: "Products",
                column: "CategoriesCategoryID",
                principalTable: "Categories",
                principalColumn: "CategoryID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_Categories_CategoriesCategoryID",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Products_CategoriesCategoryID",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "CategoriesCategoryID",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "ProductCategoriesId",
                table: "Products");

            migrationBuilder.AddColumn<string>(
                name: "ProductCategories",
                table: "Products",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
