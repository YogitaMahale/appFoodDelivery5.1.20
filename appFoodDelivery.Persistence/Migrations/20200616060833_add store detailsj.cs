using Microsoft.EntityFrameworkCore.Migrations;

namespace appFoodDelivery.Persistence.Migrations
{
    public partial class addstoredetailsj : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "storedetails",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    storeid = table.Column<string>(nullable: true),
                    applicationUserId = table.Column<string>(nullable: true),
                    contactpersonname = table.Column<string>(nullable: false),
                    emailaddress = table.Column<string>(nullable: true),
                    contactno = table.Column<string>(nullable: true),
                    gender = table.Column<string>(nullable: true),
                    fooddelivery = table.Column<string>(nullable: true),
                    storename = table.Column<string>(nullable: true),
                    radiusid = table.Column<int>(nullable: false),
                    deliverytimeid = table.Column<int>(nullable: false),
                    orderMinAmount = table.Column<decimal>(type: "decimal(18, 2)", nullable: false),
                    packagingCharges = table.Column<decimal>(type: "decimal(18, 2)", nullable: false),
                    storeBannerPhoto = table.Column<string>(nullable: true),
                    address = table.Column<string>(nullable: true),
                    description = table.Column<string>(nullable: true),
                    storetime = table.Column<string>(nullable: true),
                    licPhoto = table.Column<string>(nullable: true),
                    isdeleted = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_storedetails", x => x.id);
                    table.ForeignKey(
                        name: "FK_storedetails_AspNetUsers_applicationUserId",
                        column: x => x.applicationUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_storedetails_deliverytimemaster_deliverytimeid",
                        column: x => x.deliverytimeid,
                        principalTable: "deliverytimemaster",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_storedetails_radiusmaster_radiusid",
                        column: x => x.radiusid,
                        principalTable: "radiusmaster",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_storedetails_applicationUserId",
                table: "storedetails",
                column: "applicationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_storedetails_deliverytimeid",
                table: "storedetails",
                column: "deliverytimeid");

            migrationBuilder.CreateIndex(
                name: "IX_storedetails_radiusid",
                table: "storedetails",
                column: "radiusid");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "storedetails");
        }
    }
}
