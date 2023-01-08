using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace web.Migrations
{
    public partial class Narocilo2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "datumNarocila",
                table: "Narocilo",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "kraj",
                table: "Narocilo",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "telefon",
                table: "Narocilo",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "datumNarocila",
                table: "Narocilo");

            migrationBuilder.DropColumn(
                name: "kraj",
                table: "Narocilo");

            migrationBuilder.DropColumn(
                name: "telefon",
                table: "Narocilo");
        }
    }
}
