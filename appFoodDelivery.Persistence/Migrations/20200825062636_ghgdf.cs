using Microsoft.EntityFrameworkCore.Migrations;

namespace appFoodDelivery.Persistence.Migrations
{
    public partial class ghgdf : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "deliveryboyCheckStaus",
                table: "orderhistory");

            migrationBuilder.DropColumn(
                name: "storeCheckStaus",
                table: "orderhistory");

            migrationBuilder.AddColumn<bool>(
                name: "deliveryboyCheckStaus",
                table: "orderproducts",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "storeCheckStaus",
                table: "orderproducts",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "deliveryboyCheckStaus",
                table: "orderproducts");

            migrationBuilder.DropColumn(
                name: "storeCheckStaus",
                table: "orderproducts");

            migrationBuilder.AddColumn<bool>(
                name: "deliveryboyCheckStaus",
                table: "orderhistory",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "storeCheckStaus",
                table: "orderhistory",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }
    }
}
