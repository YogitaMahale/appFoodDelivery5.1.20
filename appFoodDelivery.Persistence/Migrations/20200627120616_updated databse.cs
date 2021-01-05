using Microsoft.EntityFrameworkCore.Migrations;

namespace appFoodDelivery.Persistence.Migrations
{
    public partial class updateddatabse : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_storedetails_CityRegistration_cityid",
                table: "storedetails");

            migrationBuilder.AlterColumn<int>(
                name: "cityid",
                table: "storedetails",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_storedetails_CityRegistration_cityid",
                table: "storedetails",
                column: "cityid",
                principalTable: "CityRegistration",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_storedetails_CityRegistration_cityid",
                table: "storedetails");

            migrationBuilder.AlterColumn<int>(
                name: "cityid",
                table: "storedetails",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_storedetails_CityRegistration_cityid",
                table: "storedetails",
                column: "cityid",
                principalTable: "CityRegistration",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
