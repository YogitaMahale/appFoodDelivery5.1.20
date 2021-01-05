using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace appFoodDelivery.Persistence.Migrations
{
    public partial class addcollectiontable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "collectionAmount",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    deliveryboyid = table.Column<int>(nullable: false),
                    finalamount = table.Column<decimal>(type: "decimal(18, 2)", nullable: false),
                    paidamt = table.Column<decimal>(type: "decimal(18, 2)", nullable: false),
                    date1 = table.Column<DateTime>(nullable: false),
                    currentdate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_collectionAmount", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "versions",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    storeVersion = table.Column<string>(nullable: true),
                    isdeleted = table.Column<bool>(nullable: false),
                    isactive = table.Column<bool>(nullable: false),
                    customerVersion = table.Column<string>(nullable: true),
                    deliveryboyVersion = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_versions", x => x.id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "collectionAmount");

            migrationBuilder.DropTable(
                name: "versions");
        }
    }
}
