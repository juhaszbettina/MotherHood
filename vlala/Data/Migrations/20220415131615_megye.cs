using Microsoft.EntityFrameworkCore.Migrations;

namespace MotherHood.Data.Migrations
{
    public partial class megye : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "MegyeId",
                table: "AspNetUsers",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "SzuletesiEv",
                table: "AspNetUsers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Megye",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nev = table.Column<string>(type: "nvarchar(255)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Megye", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_MegyeId",
                table: "AspNetUsers",
                column: "MegyeId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Megye_MegyeId",
                table: "AspNetUsers",
                column: "MegyeId",
                principalTable: "Megye",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Megye_MegyeId",
                table: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Megye");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_MegyeId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "MegyeId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "SzuletesiEv",
                table: "AspNetUsers");
        }
    }
}
