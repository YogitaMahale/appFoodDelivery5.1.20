using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace appFoodDelivery.Persistence.Migrations
{
    public partial class newmigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_storedetails_deliverytimemaster_deliverytimeid",
                table: "storedetails");

            migrationBuilder.DropForeignKey(
                name: "FK_storedetails_radiusmaster_radiusid",
                table: "storedetails");

            migrationBuilder.DropTable(
                name: "storeowner");

            migrationBuilder.AlterColumn<int>(
                name: "radiusid",
                table: "storedetails",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "deliverytimeid",
                table: "storedetails",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_storedetails_deliverytimemaster_deliverytimeid",
                table: "storedetails",
                column: "deliverytimeid",
                principalTable: "deliverytimemaster",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_storedetails_radiusmaster_radiusid",
                table: "storedetails",
                column: "radiusid",
                principalTable: "radiusmaster",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_storedetails_deliverytimemaster_deliverytimeid",
                table: "storedetails");

            migrationBuilder.DropForeignKey(
                name: "FK_storedetails_radiusmaster_radiusid",
                table: "storedetails");

            migrationBuilder.AlterColumn<int>(
                name: "radiusid",
                table: "storedetails",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "deliverytimeid",
                table: "storedetails",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "storeowner",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    createddate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    deviceid = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    emailid = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    gender = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    isactive = table.Column<bool>(type: "bit", nullable: false),
                    isdeleted = table.Column<bool>(type: "bit", nullable: false),
                    latitude = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    longitude = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    mobileno = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    password = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    profilephoto = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_storeowner", x => x.id);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_storedetails_deliverytimemaster_deliverytimeid",
                table: "storedetails",
                column: "deliverytimeid",
                principalTable: "deliverytimemaster",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_storedetails_radiusmaster_radiusid",
                table: "storedetails",
                column: "radiusid",
                principalTable: "radiusmaster",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
