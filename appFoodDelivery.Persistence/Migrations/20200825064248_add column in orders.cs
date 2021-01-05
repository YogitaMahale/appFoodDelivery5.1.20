using Microsoft.EntityFrameworkCore.Migrations;

namespace appFoodDelivery.Persistence.Migrations
{
    public partial class addcolumninorders : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "deliveryboyCheckStaus",
                table: "orderproducts");

            migrationBuilder.DropColumn(
                name: "storeCheckStaus",
                table: "orderproducts");

            migrationBuilder.AddColumn<string>(
                name: "deliveryboyCheckStaus",
                table: "orders",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "storeCheckStaus",
                table: "orders",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "deliveryboyCheckStaus",
                table: "orders");

            migrationBuilder.DropColumn(
                name: "storeCheckStaus",
                table: "orders");

            migrationBuilder.AddColumn<bool>(
                name: "deliveryboyCheckStaus",
                table: "orderproducts",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "storeCheckStaus",
                table: "orderproducts",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }
    }
}
