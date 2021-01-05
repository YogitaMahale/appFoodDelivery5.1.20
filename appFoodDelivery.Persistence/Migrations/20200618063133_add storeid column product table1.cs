using Microsoft.EntityFrameworkCore.Migrations;

namespace appFoodDelivery.Persistence.Migrations
{
    public partial class addstoreidcolumnproducttable1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "productcuisineid",
                table: "product",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_product_productcuisineid",
                table: "product",
                column: "productcuisineid");

            migrationBuilder.AddForeignKey(
                name: "FK_product_productcuisinemaster_productcuisineid",
                table: "product",
                column: "productcuisineid",
                principalTable: "productcuisinemaster",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_product_productcuisinemaster_productcuisineid",
                table: "product");

            migrationBuilder.DropIndex(
                name: "IX_product_productcuisineid",
                table: "product");

            migrationBuilder.AlterColumn<string>(
                name: "productcuisineid",
                table: "product",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(int));
        }
    }
}
