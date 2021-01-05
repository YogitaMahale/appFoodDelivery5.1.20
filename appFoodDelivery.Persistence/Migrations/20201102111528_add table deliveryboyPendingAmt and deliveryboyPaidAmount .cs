using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace appFoodDelivery.Persistence.Migrations
{
    public partial class addtabledeliveryboyPendingAmtanddeliveryboyPaidAmount : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DriverPayamount",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    deliveryboyid = table.Column<int>(nullable: false),
                    amount = table.Column<decimal>(type: "decimal(18, 2)", nullable: false),
                    paydate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DriverPayamount", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "StoredPayamount",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    storeid = table.Column<string>(nullable: true),
                    amount = table.Column<decimal>(type: "decimal(18, 2)", nullable: false),
                    paydate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StoredPayamount", x => x.id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DriverPayamount");

            migrationBuilder.DropTable(
                name: "StoredPayamount");
        }
    }
}
