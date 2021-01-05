using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace appFoodDelivery.Persistence.Migrations
{
    public partial class fdsjhjh : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "createddate",
                table: "AspNetUsers",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "deviceid",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "gender",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "isactive",
                table: "AspNetUsers",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "isdeleted",
                table: "AspNetUsers",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "latitude",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "longitude",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "mobileno",
                table: "AspNetUsers",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "name",
                table: "AspNetUsers",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "profilephoto",
                table: "AspNetUsers",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "createddate",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "deviceid",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "gender",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "isactive",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "isdeleted",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "latitude",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "longitude",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "mobileno",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "name",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "profilephoto",
                table: "AspNetUsers");
        }
    }
}
