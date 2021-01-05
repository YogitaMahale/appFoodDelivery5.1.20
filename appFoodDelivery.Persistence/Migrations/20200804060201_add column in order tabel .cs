using Microsoft.EntityFrameworkCore.Migrations;

namespace appFoodDelivery.Persistence.Migrations
{
    public partial class addcolumninordertabel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "customerdeliverylatitude",
                table: "orders",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "customerdeliverylongitude",
                table: "orders",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "deliveryboylatitude",
                table: "orders",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "deliveryboylongitude",
                table: "orders",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "storelatitude",
                table: "orders",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "storelongitude",
                table: "orders",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "customerdeliverylatitude",
                table: "orders");

            migrationBuilder.DropColumn(
                name: "customerdeliverylongitude",
                table: "orders");

            migrationBuilder.DropColumn(
                name: "deliveryboylatitude",
                table: "orders");

            migrationBuilder.DropColumn(
                name: "deliveryboylongitude",
                table: "orders");

            migrationBuilder.DropColumn(
                name: "storelatitude",
                table: "orders");

            migrationBuilder.DropColumn(
                name: "storelongitude",
                table: "orders");
        }
    }
}
