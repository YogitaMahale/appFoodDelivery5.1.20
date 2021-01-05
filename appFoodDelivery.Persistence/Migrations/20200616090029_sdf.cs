using Microsoft.EntityFrameworkCore.Migrations;

namespace appFoodDelivery.Persistence.Migrations
{
    public partial class sdf : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_storedetails_AspNetUsers_applicationUserId",
                table: "storedetails");

            migrationBuilder.DropIndex(
                name: "IX_storedetails_applicationUserId",
                table: "storedetails");

            migrationBuilder.DropColumn(
                name: "applicationUserId",
                table: "storedetails");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "applicationUserId",
                table: "storedetails",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_storedetails_applicationUserId",
                table: "storedetails",
                column: "applicationUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_storedetails_AspNetUsers_applicationUserId",
                table: "storedetails",
                column: "applicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
