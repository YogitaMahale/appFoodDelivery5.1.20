using Microsoft.EntityFrameworkCore.Migrations;

namespace appFoodDelivery.Persistence.Migrations
{
    public partial class addstoreidcolumnproducttable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "storeid",
                table: "product",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_product_storeid",
                table: "product",
                column: "storeid");

            migrationBuilder.AddForeignKey(
                name: "FK_product_AspNetUsers_storeid",
                table: "product",
                column: "storeid",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_product_AspNetUsers_storeid",
                table: "product");

            migrationBuilder.DropIndex(
                name: "IX_product_storeid",
                table: "product");

            migrationBuilder.DropColumn(
                name: "storeid",
                table: "product");
        }
    }
}
