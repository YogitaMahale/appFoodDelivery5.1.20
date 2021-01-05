using Microsoft.EntityFrameworkCore.Migrations;

namespace appFoodDelivery.Persistence.Migrations
{
    public partial class addpayamountcolumninapplicationuser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "oid",
                table: "StoredPayamount");

            migrationBuilder.DropColumn(
                name: "payamount",
                table: "storedetails");

            migrationBuilder.DropColumn(
                name: "oid",
                table: "DriverPayamount");

            migrationBuilder.AddColumn<decimal>(
                name: "payamount",
                table: "AspNetUsers",
                type: "decimal(18, 2)",
                nullable: false,
                defaultValue: 0m);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "payamount",
                table: "AspNetUsers");

            migrationBuilder.AddColumn<int>(
                name: "oid",
                table: "StoredPayamount",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<decimal>(
                name: "payamount",
                table: "storedetails",
                type: "decimal(18, 2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<int>(
                name: "oid",
                table: "DriverPayamount",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
