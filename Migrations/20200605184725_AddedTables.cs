using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace kolEF.Migrations
{
    public partial class AddedTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Klientt",
                columns: table => new
                {
                    IdKlientt = table.Column<int>(nullable: false),
                    Imie = table.Column<string>(maxLength: 50, nullable: false),
                    Nazwisko = table.Column<string>(maxLength: 60, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("Klientt_PK", x => x.IdKlientt);
                });

            migrationBuilder.CreateTable(
                name: "Pracownikk",
                columns: table => new
                {
                    IdPracownikk = table.Column<int>(nullable: false),
                    Imie = table.Column<string>(maxLength: 50, nullable: false),
                    Nazwisko = table.Column<string>(maxLength: 60, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("Pracownikk_PK", x => x.IdPracownikk);
                });

            migrationBuilder.CreateTable(
                name: "WyrobCukierniczy",
                columns: table => new
                {
                    IdWyrobuCukierniczego = table.Column<int>(nullable: false),
                    Nazwa = table.Column<string>(maxLength: 200, nullable: false),
                    CenaZaSzt = table.Column<float>(nullable: false),
                    Typ = table.Column<string>(maxLength: 40, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("WyrobCukierniczy_PK", x => x.IdWyrobuCukierniczego);
                });

            migrationBuilder.CreateTable(
                name: "Zamowienie",
                columns: table => new
                {
                    IdZamowienia = table.Column<int>(nullable: false),
                    DataPrzyjecia = table.Column<DateTime>(nullable: false),
                    DataRealizacji = table.Column<DateTime>(nullable: true),
                    Uwagi = table.Column<string>(maxLength: 300, nullable: true),
                    IdKlientt = table.Column<int>(nullable: false),
                    IdPracownikk = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("Zamowienie_PK", x => x.IdZamowienia);
                    table.ForeignKey(
                        name: "Zamowienie_Klientt",
                        column: x => x.IdKlientt,
                        principalTable: "Klientt",
                        principalColumn: "IdKlientt",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "Zamowienie_Pracownikk",
                        column: x => x.IdPracownikk,
                        principalTable: "Pracownikk",
                        principalColumn: "IdPracownikk",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Zamowienie_WyrobCukierniczy",
                columns: table => new
                {
                    IdWyrobuCukierniczego = table.Column<int>(nullable: false),
                    IdZamowienia = table.Column<int>(nullable: false),
                    Ilosc = table.Column<int>(nullable: false),
                    Uwagi = table.Column<string>(maxLength: 300, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("Zamowienie_WyrobCukierniczy_PK", x => new { x.IdWyrobuCukierniczego, x.IdZamowienia });
                    table.ForeignKey(
                        name: "Zamowienie_WyrobCukierniczy_WyrobCukierniczy",
                        column: x => x.IdWyrobuCukierniczego,
                        principalTable: "WyrobCukierniczy",
                        principalColumn: "IdWyrobuCukierniczego",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "Zamowienie_WyrobCukierniczy_Zamowienie",
                        column: x => x.IdZamowienia,
                        principalTable: "Zamowienie",
                        principalColumn: "IdZamowienia",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Zamowienie_IdKlientt",
                table: "Zamowienie",
                column: "IdKlientt");

            migrationBuilder.CreateIndex(
                name: "IX_Zamowienie_IdPracownikk",
                table: "Zamowienie",
                column: "IdPracownikk");

            migrationBuilder.CreateIndex(
                name: "IX_Zamowienie_WyrobCukierniczy_IdZamowienia",
                table: "Zamowienie_WyrobCukierniczy",
                column: "IdZamowienia");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Zamowienie_WyrobCukierniczy");

            migrationBuilder.DropTable(
                name: "WyrobCukierniczy");

            migrationBuilder.DropTable(
                name: "Zamowienie");

            migrationBuilder.DropTable(
                name: "Klientt");

            migrationBuilder.DropTable(
                name: "Pracownikk");
        }
    }
}
