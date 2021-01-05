using Microsoft.EntityFrameworkCore.Migrations;

namespace appFoodDelivery.Persistence.Migrations
{
    public partial class addpayamountcolumninapplicationuser1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "payamount",
                table: "AspNetUsers");

            migrationBuilder.AddColumn<decimal>(
                name: "payamount",
                table: "storedetails",
                type: "decimal(18, 2)",
                nullable: false,
                defaultValue: 0m);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "payamount",
                table: "storedetails");

            migrationBuilder.AddColumn<decimal>(
                name: "payamount",
                table: "AspNetUsers",
                type: "decimal(18, 2)",
                nullable: false,
                defaultValue: 0m);
        }
    }
}
