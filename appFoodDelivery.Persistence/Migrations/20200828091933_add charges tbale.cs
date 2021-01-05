using Microsoft.EntityFrameworkCore.Migrations;

namespace appFoodDelivery.Persistence.Migrations
{
    public partial class addchargestbale : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "charges",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    customer1Km = table.Column<decimal>(type: "decimal(18, 2)", nullable: false),
                    customer2K = table.Column<decimal>(type: "decimal(18, 2)", nullable: false),
                    deliveryboy1Km = table.Column<decimal>(type: "decimal(18, 2)", nullable: false),
                    deliveryboy2Km = table.Column<decimal>(type: "decimal(18, 2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_charges", x => x.id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "charges");
        }
    }
}
