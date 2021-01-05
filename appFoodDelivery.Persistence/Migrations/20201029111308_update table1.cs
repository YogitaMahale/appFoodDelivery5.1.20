using Microsoft.EntityFrameworkCore.Migrations;

namespace appFoodDelivery.Persistence.Migrations
{
    public partial class updatetable1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "anount",
                table: "deliveryboyPendingAmt",
                newName: "amount");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "amount",
                table: "deliveryboyPendingAmt",
                newName: "anount");
        }
    }
}
