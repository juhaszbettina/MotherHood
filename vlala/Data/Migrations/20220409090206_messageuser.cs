using Microsoft.EntityFrameworkCore.Migrations;

namespace MotherHood.Data.Migrations
{
    public partial class messageuser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Szerzo",
                table: "Message",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Message_Szerzo",
                table: "Message",
                column: "Szerzo");

            migrationBuilder.AddForeignKey(
                name: "FK_Message_AspNetUsers_Szerzo",
                table: "Message",
                column: "Szerzo",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Message_AspNetUsers_Szerzo",
                table: "Message");

            migrationBuilder.DropIndex(
                name: "IX_Message_Szerzo",
                table: "Message");

            migrationBuilder.AlterColumn<string>(
                name: "Szerzo",
                table: "Message",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);
        }
    }
}
