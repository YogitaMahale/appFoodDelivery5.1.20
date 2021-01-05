using Microsoft.EntityFrameworkCore.Migrations;

namespace appFoodDelivery.Persistence.Migrations
{
    public partial class addbankdetailsindeliveryboy : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "accountno",
                table: "driverRegistration",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "banklocation",
                table: "driverRegistration",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "bankname",
                table: "driverRegistration",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ifsccode",
                table: "driverRegistration",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "accountno",
                table: "driverRegistration");

            migrationBuilder.DropColumn(
                name: "banklocation",
                table: "driverRegistration");

            migrationBuilder.DropColumn(
                name: "bankname",
                table: "driverRegistration");

            migrationBuilder.DropColumn(
                name: "ifsccode",
                table: "driverRegistration");
        }
    }
}
