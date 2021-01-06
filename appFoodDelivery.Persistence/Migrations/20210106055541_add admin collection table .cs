using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace appFoodDelivery.Persistence.Migrations
{
    public partial class addadmincollectiontable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AdminCollection",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    collectManagerId = table.Column<string>(nullable: true),
                    amount = table.Column<decimal>(type: "decimal(18, 2)", nullable: false),
                    date1 = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AdminCollection", x => x.id);
                    table.ForeignKey(
                        name: "FK_AdminCollection_AspNetUsers_collectManagerId",
                        column: x => x.collectManagerId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AdminCollection_collectManagerId",
                table: "AdminCollection",
                column: "collectManagerId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AdminCollection");
        }
    }
}
