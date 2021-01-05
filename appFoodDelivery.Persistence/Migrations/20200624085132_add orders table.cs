using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace appFoodDelivery.Persistence.Migrations
{
    public partial class addorderstable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "orderhistory",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    oid = table.Column<int>(nullable: false),
                    placedate = table.Column<DateTime>(nullable: false),
                    orderstatus = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_orderhistory", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "orderproducts",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    oid = table.Column<int>(nullable: false),
                    pid = table.Column<int>(nullable: false),
                    qty = table.Column<decimal>(type: "decimal(18, 2)", nullable: false),
                    price = table.Column<decimal>(type: "decimal(18, 2)", nullable: false),
                    isdeleted = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_orderproducts", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "orders",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    customerid = table.Column<int>(nullable: false),
                    amount = table.Column<decimal>(type: "decimal(18, 2)", nullable: false),
                    placedate = table.Column<DateTime>(nullable: false),
                    deliveryboyid = table.Column<int>(nullable: false),
                    paymentstatus = table.Column<string>(nullable: true),
                    orderstatus = table.Column<string>(nullable: true),
                    isdeleted = table.Column<bool>(nullable: false),
                    isactive = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_orders", x => x.id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "orderhistory");

            migrationBuilder.DropTable(
                name: "orderproducts");

            migrationBuilder.DropTable(
                name: "orders");
        }
    }
}
