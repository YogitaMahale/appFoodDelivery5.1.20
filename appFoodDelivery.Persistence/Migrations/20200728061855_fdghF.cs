using Microsoft.EntityFrameworkCore.Migrations;

namespace appFoodDelivery.Persistence.Migrations
{
    public partial class fdghF : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "feedback");

            migrationBuilder.CreateTable(
                name: "customerfeedback",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    fromcustomerid = table.Column<int>(nullable: false),
                    toDeliveryboyid = table.Column<int>(nullable: false),
                    toStoredid = table.Column<int>(nullable: false),
                    comment = table.Column<string>(nullable: true),
                    rating = table.Column<string>(nullable: true),
                    isdeleted = table.Column<bool>(nullable: false),
                    isactive = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_customerfeedback", x => x.id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "customerfeedback");

            migrationBuilder.CreateTable(
                name: "feedback",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    comment = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    customerid = table.Column<int>(type: "int", nullable: false),
                    deliveryboyid = table.Column<int>(type: "int", nullable: false),
                    isactive = table.Column<bool>(type: "bit", nullable: false),
                    isdeleted = table.Column<bool>(type: "bit", nullable: false),
                    rating = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_feedback", x => x.id);
                });
        }
    }
}
