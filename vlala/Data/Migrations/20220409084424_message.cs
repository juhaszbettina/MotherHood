using Microsoft.EntityFrameworkCore.Migrations;

namespace MotherHood.Data.Migrations
{
    public partial class message : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Message",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Uzenet = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Tema = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Szerzo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Cim = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Message", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Message");
        }
    }
}
