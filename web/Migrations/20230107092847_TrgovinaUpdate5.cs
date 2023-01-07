using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace web.Migrations
{
    public partial class TrgovinaUpdate5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Trgovina_trgovincaTrgovinaId",
                table: "AspNetUsers");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_trgovincaTrgovinaId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "lastnik",
                table: "Artikel");

            migrationBuilder.RenameColumn(
                name: "trgovincaTrgovinaId",
                table: "AspNetUsers",
                newName: "TrgovinaId");

            migrationBuilder.AddColumn<string>(
                name: "lastnikId",
                table: "Artikel",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Artikel_lastnikId",
                table: "Artikel",
                column: "lastnikId");

            migrationBuilder.AddForeignKey(
                name: "FK_Artikel_AspNetUsers_lastnikId",
                table: "Artikel",
                column: "lastnikId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Artikel_AspNetUsers_lastnikId",
                table: "Artikel");

            migrationBuilder.DropIndex(
                name: "IX_Artikel_lastnikId",
                table: "Artikel");

            migrationBuilder.DropColumn(
                name: "lastnikId",
                table: "Artikel");

            migrationBuilder.RenameColumn(
                name: "TrgovinaId",
                table: "AspNetUsers",
                newName: "trgovincaTrgovinaId");

            migrationBuilder.AddColumn<string>(
                name: "lastnik",
                table: "Artikel",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_trgovincaTrgovinaId",
                table: "AspNetUsers",
                column: "trgovincaTrgovinaId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Trgovina_trgovincaTrgovinaId",
                table: "AspNetUsers",
                column: "trgovincaTrgovinaId",
                principalTable: "Trgovina",
                principalColumn: "TrgovinaId");
        }
    }
}
