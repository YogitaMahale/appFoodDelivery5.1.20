using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace appFoodDelivery.Persistence.Migrations
{
    public partial class adddriver : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "driverRegistration",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(nullable: true),
                    profilephoto = table.Column<string>(nullable: true),
                    mobileno = table.Column<string>(nullable: true),
                    emailid = table.Column<string>(nullable: true),
                    password = table.Column<string>(nullable: true),
                    gender = table.Column<string>(nullable: true),
                    latitude = table.Column<string>(nullable: true),
                    longitude = table.Column<string>(nullable: true),
                    deviceid = table.Column<string>(nullable: true),
                    createddate = table.Column<DateTime>(nullable: false),
                    biketype = table.Column<string>(nullable: true),
                    manufacturename = table.Column<string>(nullable: true),
                    modelname = table.Column<string>(nullable: true),
                    modelyear = table.Column<string>(nullable: true),
                    vehicleplateno = table.Column<string>(nullable: true),
                    drivinglicphoto = table.Column<string>(nullable: true),
                    vehicleinsurancephoto = table.Column<string>(nullable: true),
                    isdeleted = table.Column<bool>(nullable: false),
                    isactive = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_driverRegistration", x => x.id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "driverRegistration");
        }
    }
}
