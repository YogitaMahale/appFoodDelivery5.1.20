using Microsoft.EntityFrameworkCore.Migrations;

namespace appFoodDelivery.Persistence.Migrations
{
    public partial class addAssignDeliveryboyToManagertable1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AssignDeliveryboyToManager",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    managerId = table.Column<string>(nullable: true),
                    deliveryboyid = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AssignDeliveryboyToManager", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AssignDeliveryboyToManager_driverRegistration_deliveryboyid",
                        column: x => x.deliveryboyid,
                        principalTable: "driverRegistration",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AssignDeliveryboyToManager_AspNetUsers_managerId",
                        column: x => x.managerId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AssignDeliveryboyToManager_deliveryboyid",
                table: "AssignDeliveryboyToManager",
                column: "deliveryboyid");

            migrationBuilder.CreateIndex(
                name: "IX_AssignDeliveryboyToManager_managerId",
                table: "AssignDeliveryboyToManager",
                column: "managerId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AssignDeliveryboyToManager");
        }
    }
}
