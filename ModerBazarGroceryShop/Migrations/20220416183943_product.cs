using Microsoft.EntityFrameworkCore.Migrations;

namespace ModerBazarGroceryShop.Migrations
{
    public partial class product : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ProductCategoriesId",
                table: "Products");

            migrationBuilder.AddColumn<int>(
                name: "CategoryID",
                table: "Products",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CategoryID",
                table: "Products");

            migrationBuilder.AddColumn<int>(
                name: "ProductCategoriesId",
                table: "Products",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
