using Microsoft.EntityFrameworkCore.Migrations;

namespace RestaurantSystemDataAccess.Migrations
{
    public partial class updatedemployee2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Salt",
                table: "Employees",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Salt",
                table: "Employees");
        }
    }
}
