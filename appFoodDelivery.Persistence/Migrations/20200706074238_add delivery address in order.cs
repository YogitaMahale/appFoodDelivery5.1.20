using Microsoft.EntityFrameworkCore.Migrations;

namespace appFoodDelivery.Persistence.Migrations
{
    public partial class adddeliveryaddressinorder : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "propmocode",
                table: "orders");

            migrationBuilder.AddColumn<string>(
                name: "deliveryaddress",
                table: "orders",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "paymenttype",
                table: "orders",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "promocode",
                table: "orders",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "deliveryaddress",
                table: "orders");

            migrationBuilder.DropColumn(
                name: "paymenttype",
                table: "orders");

            migrationBuilder.DropColumn(
                name: "promocode",
                table: "orders");

            migrationBuilder.AddColumn<string>(
                name: "propmocode",
                table: "orders",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
