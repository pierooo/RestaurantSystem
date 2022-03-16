using Microsoft.EntityFrameworkCore.Migrations;

namespace RestaurantSystemDataAccess.Migrations
{
    public partial class UpdatedEntities2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "TotalPrice",
                table: "Orders",
                newName: "TotalPriceNetto");

            migrationBuilder.AddColumn<int>(
                name: "VAT",
                table: "OrdersDetails",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<decimal>(
                name: "TotalPriceBrutto",
                table: "Orders",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "VAT",
                table: "OrdersDetails");

            migrationBuilder.DropColumn(
                name: "TotalPriceBrutto",
                table: "Orders");

            migrationBuilder.RenameColumn(
                name: "TotalPriceNetto",
                table: "Orders",
                newName: "TotalPrice");
        }
    }
}
