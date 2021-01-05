using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace appFoodDelivery.Persistence.Migrations
{
    public partial class addpromocodetable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "promocodemaster",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    promocode = table.Column<string>(nullable: false),
                    promocodeusagelimit = table.Column<string>(nullable: true),
                    discount = table.Column<string>(nullable: true),
                    discounttype = table.Column<string>(nullable: true),
                    expirydate = table.Column<DateTime>(nullable: false),
                    createddate = table.Column<DateTime>(nullable: false),
                    isdeleted = table.Column<bool>(nullable: false),
                    isactive = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_promocodemaster", x => x.id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "promocodemaster");
        }
    }
}
