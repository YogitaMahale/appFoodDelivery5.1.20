using Microsoft.EntityFrameworkCore.Migrations;

namespace appFoodDelivery.Persistence.Migrations
{
    public partial class addcityidinstore : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "cityid",
                table: "storedetails",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "latitude",
                table: "storedetails",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "longitude",
                table: "storedetails",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_storedetails_cityid",
                table: "storedetails",
                column: "cityid");

            migrationBuilder.AddForeignKey(
                name: "FK_storedetails_CityRegistration_cityid",
                table: "storedetails",
                column: "cityid",
                principalTable: "CityRegistration",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_storedetails_CityRegistration_cityid",
                table: "storedetails");

            migrationBuilder.DropIndex(
                name: "IX_storedetails_cityid",
                table: "storedetails");

            migrationBuilder.DropColumn(
                name: "cityid",
                table: "storedetails");

            migrationBuilder.DropColumn(
                name: "latitude",
                table: "storedetails");

            migrationBuilder.DropColumn(
                name: "longitude",
                table: "storedetails");
        }
    }
}
