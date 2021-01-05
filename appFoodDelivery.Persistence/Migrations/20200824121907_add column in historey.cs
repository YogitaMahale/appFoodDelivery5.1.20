using Microsoft.EntityFrameworkCore.Migrations;

namespace appFoodDelivery.Persistence.Migrations
{
    public partial class addcolumninhistorey : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "deliveryboyCheckStaus",
                table: "orderhistory",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "reason",
                table: "orderhistory",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "storeCheckStaus",
                table: "orderhistory",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "deliveryboyCheckStaus",
                table: "orderhistory");

            migrationBuilder.DropColumn(
                name: "reason",
                table: "orderhistory");

            migrationBuilder.DropColumn(
                name: "storeCheckStaus",
                table: "orderhistory");
        }
    }
}
