using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace appFoodDelivery.Persistence.Migrations
{
    public partial class updatetable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "collectionAmount");

            migrationBuilder.CreateTable(
                name: "deliveryboyPendingAmt",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    deliveryboyid = table.Column<int>(nullable: false),
                    anount = table.Column<decimal>(type: "decimal(18, 2)", nullable: false),
                    modifydate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_deliveryboyPendingAmt", x => x.id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "deliveryboyPendingAmt");

            migrationBuilder.CreateTable(
                name: "collectionAmount",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    currentdate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    date1 = table.Column<DateTime>(type: "datetime2", nullable: false),
                    deliveryboyid = table.Column<int>(type: "int", nullable: false),
                    finalamount = table.Column<decimal>(type: "decimal(18, 2)", nullable: false),
                    paidamt = table.Column<decimal>(type: "decimal(18, 2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_collectionAmount", x => x.id);
                });
        }
    }
}
