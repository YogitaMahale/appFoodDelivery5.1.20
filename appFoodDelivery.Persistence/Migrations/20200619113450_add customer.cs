using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace appFoodDelivery.Persistence.Migrations
{
    public partial class addcustomer : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CustomerRegistration",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(nullable: false),
                    profilephoto = table.Column<string>(nullable: true),
                    address = table.Column<string>(nullable: true),
                    mobileno1 = table.Column<string>(nullable: false),
                    mobileno2 = table.Column<string>(nullable: true),
                    emailid1 = table.Column<string>(nullable: true),
                    latitude = table.Column<string>(nullable: true),
                    longitude = table.Column<string>(nullable: true),
                    password = table.Column<string>(nullable: false),
                    gender = table.Column<string>(nullable: false),
                    DOB = table.Column<DateTime>(nullable: false),
                    createddate = table.Column<DateTime>(nullable: false),
                    isdeleted = table.Column<bool>(nullable: false),
                    isactive = table.Column<bool>(nullable: false),
                    deviceid = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomerRegistration", x => x.id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CustomerRegistration");
        }
    }
}
