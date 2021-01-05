using Microsoft.EntityFrameworkCore.Migrations;

namespace appFoodDelivery.Persistence.Migrations
{
    public partial class addcountrystatecitytable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CountryRegistration",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    countryname = table.Column<string>(nullable: false),
                    countrycode = table.Column<string>(nullable: true),
                    isdeleted = table.Column<bool>(nullable: false),
                    isactive = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CountryRegistration", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "StateRegistration",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    countryid = table.Column<int>(nullable: false),
                    StateName = table.Column<string>(nullable: false),
                    isdeleted = table.Column<bool>(nullable: false),
                    isactive = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StateRegistration", x => x.id);
                    table.ForeignKey(
                        name: "FK_StateRegistration_CountryRegistration_countryid",
                        column: x => x.countryid,
                        principalTable: "CountryRegistration",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CityRegistration",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    stateid = table.Column<int>(nullable: false),
                    cityName = table.Column<string>(nullable: false),
                    isdeleted = table.Column<bool>(nullable: false),
                    isactive = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CityRegistration", x => x.id);
                    table.ForeignKey(
                        name: "FK_CityRegistration_StateRegistration_stateid",
                        column: x => x.stateid,
                        principalTable: "StateRegistration",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CityRegistration_stateid",
                table: "CityRegistration",
                column: "stateid");

            migrationBuilder.CreateIndex(
                name: "IX_StateRegistration_countryid",
                table: "StateRegistration",
                column: "countryid");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CityRegistration");

            migrationBuilder.DropTable(
                name: "StateRegistration");

            migrationBuilder.DropTable(
                name: "CountryRegistration");
        }
    }
}
