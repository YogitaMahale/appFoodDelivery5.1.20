using Microsoft.EntityFrameworkCore.Migrations;

namespace appFoodDelivery.Persistence.Migrations
{
    public partial class menumasterkfgh : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "productcuisineid",
                table: "menumasters",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_menumasters_productcuisineid",
                table: "menumasters",
                column: "productcuisineid");

            migrationBuilder.AddForeignKey(
                name: "FK_menumasters_productcuisinemaster_productcuisineid",
                table: "menumasters",
                column: "productcuisineid",
                principalTable: "productcuisinemaster",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_menumasters_productcuisinemaster_productcuisineid",
                table: "menumasters");

            migrationBuilder.DropIndex(
                name: "IX_menumasters_productcuisineid",
                table: "menumasters");

            migrationBuilder.DropColumn(
                name: "productcuisineid",
                table: "menumasters");
        }
    }
}
