using Microsoft.EntityFrameworkCore.Migrations;

namespace appFoodDelivery.Persistence.Migrations
{
    public partial class addoidinstoredpayamounttable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "oid",
                table: "StoredPayamount",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "oid",
                table: "DriverPayamount",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "oid",
                table: "StoredPayamount");

            migrationBuilder.DropColumn(
                name: "oid",
                table: "DriverPayamount");
        }
    }
}
