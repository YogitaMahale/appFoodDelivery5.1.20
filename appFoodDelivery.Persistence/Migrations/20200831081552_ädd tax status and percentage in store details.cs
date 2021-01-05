using Microsoft.EntityFrameworkCore.Migrations;

namespace appFoodDelivery.Persistence.Migrations
{
    public partial class äddtaxstatusandpercentageinstoredetails : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "taxstatus",
                table: "storedetails",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "taxstatusPer",
                table: "storedetails",
                type: "decimal(18, 2)",
                nullable: false,
                defaultValue: 0m);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "taxstatus",
                table: "storedetails");

            migrationBuilder.DropColumn(
                name: "taxstatusPer",
                table: "storedetails");
        }
    }
}
