using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MotherHood.Data.Migrations
{
    public partial class szuletes2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "SzuletesiEv",
                table: "AspNetUsers",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SzuletesiEv",
                table: "AspNetUsers");
        }
    }
}
