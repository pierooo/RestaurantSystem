using Microsoft.EntityFrameworkCore.Migrations;

namespace RestaurantSystemDataAccess.Migrations
{
    public partial class UpdatedEntities : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "UnitPrice",
                table: "Products",
                newName: "UnitPriceNetto");

            migrationBuilder.RenameColumn(
                name: "UnitPrice",
                table: "OrdersDetails",
                newName: "UnitPriceNetto");

            migrationBuilder.AddColumn<int>(
                name: "VAT",
                table: "Products",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "VAT",
                table: "Products");

            migrationBuilder.RenameColumn(
                name: "UnitPriceNetto",
                table: "Products",
                newName: "UnitPrice");

            migrationBuilder.RenameColumn(
                name: "UnitPriceNetto",
                table: "OrdersDetails",
                newName: "UnitPrice");
        }
    }
}
