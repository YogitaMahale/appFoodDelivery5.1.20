using Microsoft.EntityFrameworkCore.Migrations;

namespace appFoodDelivery.Persistence.Migrations
{
    public partial class addcollectManageridcolumnindeliveryboyPaidAmountnew : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "collectManagerid",
                table: "deliveryboyPaidAmount",
                newName: "collectManagerId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "collectManagerId",
                table: "deliveryboyPaidAmount",
                newName: "collectManagerid");
        }
    }
}
