using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace web.Migrations
{
    public partial class Narocilo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Lastnik");

            migrationBuilder.CreateTable(
                name: "Narocilo",
                columns: table => new
                {
                    NarociloId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ime = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    priimek = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    enaslov = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    naslov = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    posta = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    vrednostNarocila = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Narocilo", x => x.NarociloId);
                });

            migrationBuilder.CreateTable(
                name: "InfoONarocilu",
                columns: table => new
                {
                    InfoONarociluId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NarociloId = table.Column<int>(type: "int", nullable: false),
                    ArtikelId = table.Column<int>(type: "int", nullable: false),
                    Kolicina = table.Column<int>(type: "int", nullable: false),
                    Cena = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InfoONarocilu", x => x.InfoONarociluId);
                    table.ForeignKey(
                        name: "FK_InfoONarocilu_Artikel_ArtikelId",
                        column: x => x.ArtikelId,
                        principalTable: "Artikel",
                        principalColumn: "ArtikelId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_InfoONarocilu_Narocilo_NarociloId",
                        column: x => x.NarociloId,
                        principalTable: "Narocilo",
                        principalColumn: "NarociloId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_InfoONarocilu_ArtikelId",
                table: "InfoONarocilu",
                column: "ArtikelId");

            migrationBuilder.CreateIndex(
                name: "IX_InfoONarocilu_NarociloId",
                table: "InfoONarocilu",
                column: "NarociloId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "InfoONarocilu");

            migrationBuilder.DropTable(
                name: "Narocilo");

            migrationBuilder.CreateTable(
                name: "Lastnik",
                columns: table => new
                {
                    LastnikId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TrgovinaId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Lastnik", x => x.LastnikId);
                    table.ForeignKey(
                        name: "FK_Lastnik_Trgovina_TrgovinaId",
                        column: x => x.TrgovinaId,
                        principalTable: "Trgovina",
                        principalColumn: "TrgovinaId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Lastnik_TrgovinaId",
                table: "Lastnik",
                column: "TrgovinaId");
        }
    }
}
