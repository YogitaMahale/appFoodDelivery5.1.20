using Microsoft.EntityFrameworkCore.Migrations;

namespace appFoodDelivery.Persistence.Migrations
{
    public partial class fdF : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "instructions",
                table: "orders",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "DeliveryboytoCustomerfeedback",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    deliveryboyid = table.Column<int>(nullable: false),
                    customerid = table.Column<int>(nullable: false),
                    comment = table.Column<string>(nullable: true),
                    rating = table.Column<string>(nullable: true),
                    isdeleted = table.Column<bool>(nullable: false),
                    isactive = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DeliveryboytoCustomerfeedback", x => x.id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DeliveryboytoCustomerfeedback");

            migrationBuilder.DropColumn(
                name: "instructions",
                table: "orders");
        }
    }
}
