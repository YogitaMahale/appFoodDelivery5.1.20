using Microsoft.EntityFrameworkCore.Migrations;

namespace appFoodDelivery.Persistence.Migrations
{
    public partial class addtaxdeliveryboyalertamountstatustable1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "name",
                table: "status");

            migrationBuilder.AddColumn<string>(
                name: "name1",
                table: "status",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "name2",
                table: "status",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "name1",
                table: "status");

            migrationBuilder.DropColumn(
                name: "name2",
                table: "status");

            migrationBuilder.AddColumn<string>(
                name: "name",
                table: "status",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
