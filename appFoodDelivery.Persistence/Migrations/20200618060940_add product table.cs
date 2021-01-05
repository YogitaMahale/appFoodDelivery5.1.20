using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace appFoodDelivery.Persistence.Migrations
{
    public partial class addproducttable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "product",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    productcuisineid = table.Column<string>(nullable: true),
                    name = table.Column<string>(nullable: false),
                    img = table.Column<string>(nullable: true),
                    foodtype = table.Column<string>(nullable: true),
                    amount = table.Column<decimal>(type: "decimal(18, 2)", nullable: false),
                    description = table.Column<string>(nullable: true),
                    discounttype = table.Column<string>(nullable: true),
                    discountamount = table.Column<decimal>(type: "decimal(18, 2)", nullable: false),
                    createddate = table.Column<DateTime>(nullable: false),
                    isdeleted = table.Column<bool>(nullable: false),
                    isactive = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_product", x => x.id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "product");
        }
    }
}
