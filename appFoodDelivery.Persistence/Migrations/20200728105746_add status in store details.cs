using Microsoft.EntityFrameworkCore.Migrations;

namespace appFoodDelivery.Persistence.Migrations
{
    public partial class addstatusinstoredetails : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "accountno",
                table: "storedetails",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "banklocation",
                table: "storedetails",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "bankname",
                table: "storedetails",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ifsccode",
                table: "storedetails",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "status",
                table: "storedetails",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "accountno",
                table: "storedetails");

            migrationBuilder.DropColumn(
                name: "banklocation",
                table: "storedetails");

            migrationBuilder.DropColumn(
                name: "bankname",
                table: "storedetails");

            migrationBuilder.DropColumn(
                name: "ifsccode",
                table: "storedetails");

            migrationBuilder.DropColumn(
                name: "status",
                table: "storedetails");
        }
    }
}
