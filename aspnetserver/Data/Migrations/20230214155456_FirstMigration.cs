using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace aspnetserver.Data.Migrations
{
    /// <inheritdoc />
    public partial class FirstMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Korisnici",
                columns: table => new
                {
                    KorisnikId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Ime = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    Prezime = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    KorisnickoIme = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    Lozinka = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    Email = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    DatumRodjenja = table.Column<DateTime>(type: "TEXT", nullable: false),
                    TipKorisnika = table.Column<int>(type: "INTEGER", nullable: false),
                    Slika = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Korisnici", x => x.KorisnikId);
                });

            migrationBuilder.InsertData(
                table: "Korisnici",
                columns: new[] { "KorisnikId", "DatumRodjenja", "Email", "Ime", "KorisnickoIme", "Lozinka", "Prezime", "Slika", "TipKorisnika" },
                values: new object[] { 1, new DateTime(1998, 7, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "basic.aco@hotmail.com", "Aleksandar", "Aco", "Aco12345", "Basic", "", 0 });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Korisnici");
        }
    }
}
