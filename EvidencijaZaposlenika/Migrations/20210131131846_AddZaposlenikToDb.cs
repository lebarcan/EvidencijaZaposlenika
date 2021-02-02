using Microsoft.EntityFrameworkCore.Migrations;

namespace EvidencijaZaposlenika.Migrations
{
    public partial class AddZaposlenikToDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Zaposlenici",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ime = table.Column<string>(nullable: false),
                    Prezime = table.Column<string>(nullable: false),
                    Pozicija = table.Column<string>(nullable: false),
                    Ured = table.Column<string>(nullable: false),
                    Kontakt = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Zaposlenici", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Zaposlenici");
        }
    }
}
