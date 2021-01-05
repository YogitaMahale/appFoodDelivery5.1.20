using Microsoft.EntityFrameworkCore.Migrations;

namespace appFoodDelivery.Persistence.Migrations
{
    public partial class dhjf : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_productcuisinemaster_AspNetUsers_ApplicationUserId",
                table: "productcuisinemaster");

            migrationBuilder.DropIndex(
                name: "IX_productcuisinemaster_ApplicationUserId",
                table: "productcuisinemaster");

            migrationBuilder.DropColumn(
                name: "ApplicationUserId",
                table: "productcuisinemaster");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ApplicationUserId",
                table: "productcuisinemaster",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_productcuisinemaster_ApplicationUserId",
                table: "productcuisinemaster",
                column: "ApplicationUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_productcuisinemaster_AspNetUsers_ApplicationUserId",
                table: "productcuisinemaster",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
