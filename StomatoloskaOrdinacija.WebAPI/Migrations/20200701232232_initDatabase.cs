using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace StomatoloskaOrdinacija.WebAPI.Migrations
{
    public partial class initDatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Dijagnoza",
                columns: table => new
                {
                    DijagnozaId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Naziv = table.Column<string>(maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Dijagnoza", x => x.DijagnozaId);
                });

            migrationBuilder.CreateTable(
                name: "Drzava",
                columns: table => new
                {
                    DrzavaId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Naziv = table.Column<string>(maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Drzava", x => x.DrzavaId);
                });

            migrationBuilder.CreateTable(
                name: "Lijek",
                columns: table => new
                {
                    LijekId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Naziv = table.Column<string>(maxLength: 70, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Lijek", x => x.LijekId);
                });

            migrationBuilder.CreateTable(
                name: "Uloges",
                columns: table => new
                {
                    UlogaId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Naziv = table.Column<string>(maxLength: 100, nullable: false),
                    Opis = table.Column<string>(maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Uloges", x => x.UlogaId);
                });

            migrationBuilder.CreateTable(
                name: "Usluga",
                columns: table => new
                {
                    UslugaId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Naziv = table.Column<string>(maxLength: 150, nullable: false),
                    Cijena = table.Column<decimal>(type: "DECIMAL(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usluga", x => x.UslugaId);
                });

            migrationBuilder.CreateTable(
                name: "UspostavljenaDijagnoza",
                columns: table => new
                {
                    UspostavljenaDijagnozaId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DijagnozaId = table.Column<int>(nullable: false),
                    JacinaDijagnoze = table.Column<byte>(type: "TINYINT", nullable: false),
                    Napomena = table.Column<string>(maxLength: 300, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UspostavljenaDijagnoza", x => x.UspostavljenaDijagnozaId);
                    table.ForeignKey(
                        name: "FK_UspostavljenaDijagnoza_Dijagnoza_DijagnozaId",
                        column: x => x.DijagnozaId,
                        principalTable: "Dijagnoza",
                        principalColumn: "DijagnozaId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Grad",
                columns: table => new
                {
                    GradId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DrzavaId = table.Column<int>(nullable: false),
                    Naziv = table.Column<string>(maxLength: 100, nullable: false),
                    PostanskiBroj = table.Column<string>(maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Grad", x => x.GradId);
                    table.ForeignKey(
                        name: "FK_Grad_Drzava_DrzavaId",
                        column: x => x.DrzavaId,
                        principalTable: "Drzava",
                        principalColumn: "DrzavaId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Terapija",
                columns: table => new
                {
                    TerapijaId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LijekId = table.Column<int>(nullable: false),
                    VrstaTerapije = table.Column<string>(maxLength: 100, nullable: false),
                    Kolicina = table.Column<byte>(type: "TINYINT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Terapija", x => x.TerapijaId);
                    table.ForeignKey(
                        name: "FK_Terapija_Lijek_LijekId",
                        column: x => x.LijekId,
                        principalTable: "Lijek",
                        principalColumn: "LijekId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Korisnici",
                columns: table => new
                {
                    KorisnikId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ime = table.Column<string>(maxLength: 100, nullable: false),
                    Prezime = table.Column<string>(maxLength: 100, nullable: false),
                    Email = table.Column<string>(maxLength: 320, nullable: false),
                    KorisnickoIme = table.Column<string>(maxLength: 100, nullable: false),
                    LozinkaHash = table.Column<string>(maxLength: 100, nullable: false),
                    LozinkaSalt = table.Column<string>(maxLength: 50, nullable: false),
                    Kreirano = table.Column<DateTime>(nullable: false),
                    JMBG = table.Column<string>(maxLength: 13, nullable: false),
                    DatumRodjenja = table.Column<DateTime>(type: "SMALLDATETIME", nullable: false),
                    Mobitel = table.Column<string>(maxLength: 30, nullable: false),
                    Adresa = table.Column<string>(maxLength: 200, nullable: false),
                    GradId = table.Column<int>(nullable: false),
                    Spol = table.Column<string>(maxLength: 10, nullable: false),
                    Slika = table.Column<byte[]>(nullable: true),
                    UlogaId = table.Column<int>(nullable: false),
                    Status = table.Column<bool>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Korisnici", x => x.KorisnikId);
                    table.ForeignKey(
                        name: "FK_Korisnici_Grad_GradId",
                        column: x => x.GradId,
                        principalTable: "Grad",
                        principalColumn: "GradId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Korisnici_Uloges_UlogaId",
                        column: x => x.UlogaId,
                        principalTable: "Uloges",
                        principalColumn: "UlogaId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Pacijenti",
                columns: table => new
                {
                    PacijentId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    KorisnikId = table.Column<int>(nullable: false),
                    AlergijaNaLijek = table.Column<bool>(type: "BIT", nullable: false),
                    Proteza = table.Column<bool>(type: "BIT", nullable: false),
                    Terapija = table.Column<bool>(type: "BIT", nullable: false),
                    Navlake = table.Column<bool>(type: "BIT", nullable: false),
                    Aparatic = table.Column<bool>(type: "BIT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pacijenti", x => x.PacijentId);
                    table.ForeignKey(
                        name: "FK_Pacijenti_Korisnici_KorisnikId",
                        column: x => x.KorisnikId,
                        principalTable: "Korisnici",
                        principalColumn: "KorisnikId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Popusts",
                columns: table => new
                {
                    PopustId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UslugaId = table.Column<int>(nullable: false),
                    KorisnikId = table.Column<int>(nullable: false),
                    PopustOdDatuma = table.Column<DateTime>(nullable: false),
                    PopustDoDatuma = table.Column<DateTime>(nullable: false),
                    VrijednostPopusta = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Popusts", x => x.PopustId);
                    table.ForeignKey(
                        name: "FK_Popusts_Korisnici_KorisnikId",
                        column: x => x.KorisnikId,
                        principalTable: "Korisnici",
                        principalColumn: "KorisnikId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Popusts_Usluga_UslugaId",
                        column: x => x.UslugaId,
                        principalTable: "Usluga",
                        principalColumn: "UslugaId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PromjenaLozinkes",
                columns: table => new
                {
                    PromjenaLozinkeID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Vrijednost = table.Column<string>(maxLength: 30, nullable: false),
                    KorisnikId = table.Column<int>(nullable: false),
                    DatumPromjene = table.Column<DateTime>(type: "SMALLDATETIME", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PromjenaLozinkes", x => x.PromjenaLozinkeID);
                    table.ForeignKey(
                        name: "FK_PromjenaLozinkes_Korisnici_KorisnikId",
                        column: x => x.KorisnikId,
                        principalTable: "Korisnici",
                        principalColumn: "KorisnikId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UlazUSkladiste",
                columns: table => new
                {
                    UlazUSkladisteID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    KorisnikId = table.Column<int>(nullable: false),
                    BrojFakture = table.Column<string>(maxLength: 50, nullable: false),
                    Datum = table.Column<DateTime>(type: "SMALLDATETIME", nullable: false),
                    IznosRacuna = table.Column<decimal>(type: "DECIMAL(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UlazUSkladiste", x => x.UlazUSkladisteID);
                    table.ForeignKey(
                        name: "FK_UlazUSkladiste_Korisnici_KorisnikId",
                        column: x => x.KorisnikId,
                        principalTable: "Korisnici",
                        principalColumn: "KorisnikId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Ocjenes",
                columns: table => new
                {
                    OcjenaId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PacijentId = table.Column<int>(nullable: false),
                    UslugaId = table.Column<int>(nullable: false),
                    Kreirano = table.Column<DateTime>(nullable: false),
                    Ocjena = table.Column<decimal>(type: "DECIMAL(18,2)", nullable: false),
                    Komentar = table.Column<string>(maxLength: 300, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ocjenes", x => x.OcjenaId);
                    table.ForeignKey(
                        name: "FK_Ocjenes_Pacijenti_PacijentId",
                        column: x => x.PacijentId,
                        principalTable: "Pacijenti",
                        principalColumn: "PacijentId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Ocjenes_Usluga_UslugaId",
                        column: x => x.UslugaId,
                        principalTable: "Usluga",
                        principalColumn: "UslugaId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Pretplatas",
                columns: table => new
                {
                    PretplataId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UslugaId = table.Column<int>(nullable: false),
                    PacijentId = table.Column<int>(nullable: false),
                    DatumPretplate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pretplatas", x => x.PretplataId);
                    table.ForeignKey(
                        name: "FK_Pretplatas_Pacijenti_PacijentId",
                        column: x => x.PacijentId,
                        principalTable: "Pacijenti",
                        principalColumn: "PacijentId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Pretplatas_Usluga_UslugaId",
                        column: x => x.UslugaId,
                        principalTable: "Usluga",
                        principalColumn: "UslugaId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Termini",
                columns: table => new
                {
                    TerminId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PacijentId = table.Column<int>(nullable: false),
                    UslugaId = table.Column<int>(nullable: false),
                    DatumVrijeme = table.Column<DateTime>(nullable: false),
                    Razlog = table.Column<string>(maxLength: 200, nullable: false),
                    Hitan = table.Column<bool>(type: "BIT", nullable: false),
                    IsOdobren = table.Column<bool>(type: "BIT", nullable: false),
                    IsNaCekanju = table.Column<bool>(type: "BIT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Termini", x => x.TerminId);
                    table.ForeignKey(
                        name: "FK_Termini_Pacijenti_PacijentId",
                        column: x => x.PacijentId,
                        principalTable: "Pacijenti",
                        principalColumn: "PacijentId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Termini_Usluga_UslugaId",
                        column: x => x.UslugaId,
                        principalTable: "Usluga",
                        principalColumn: "UslugaId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Skladiste",
                columns: table => new
                {
                    SkladisteId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UlazUSkladisteId = table.Column<int>(nullable: false),
                    Naziv = table.Column<string>(maxLength: 100, nullable: false),
                    Opis = table.Column<string>(maxLength: 300, nullable: false),
                    Vrsta = table.Column<string>(maxLength: 100, nullable: false),
                    Proizvodjac = table.Column<string>(maxLength: 100, nullable: false),
                    Kolicina = table.Column<decimal>(type: "DECIMAL(18,1)", nullable: false),
                    MjernaJedinica = table.Column<string>(maxLength: 20, nullable: false),
                    Cijena = table.Column<decimal>(type: "DECIMAL(18,2)", nullable: false),
                    Slika = table.Column<byte[]>(nullable: true),
                    SlikaThumb = table.Column<byte[]>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Skladiste", x => x.SkladisteId);
                    table.ForeignKey(
                        name: "FK_Skladiste_UlazUSkladiste_UlazUSkladisteId",
                        column: x => x.UlazUSkladisteId,
                        principalTable: "UlazUSkladiste",
                        principalColumn: "UlazUSkladisteID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Pregledi",
                columns: table => new
                {
                    PregledId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    KorisnikId = table.Column<int>(nullable: false),
                    TerminId = table.Column<int>(nullable: false),
                    TerapijaId = table.Column<int>(nullable: false),
                    UspostavljenaDijagnozaId = table.Column<int>(nullable: false),
                    TrajanjePregleda = table.Column<short>(type: "SMALLINT", nullable: false),
                    Napomena = table.Column<string>(maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pregledi", x => x.PregledId);
                    table.ForeignKey(
                        name: "FK_Pregledi_Korisnici_KorisnikId",
                        column: x => x.KorisnikId,
                        principalTable: "Korisnici",
                        principalColumn: "KorisnikId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Pregledi_Terapija_TerapijaId",
                        column: x => x.TerapijaId,
                        principalTable: "Terapija",
                        principalColumn: "TerapijaId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Pregledi_Termini_TerminId",
                        column: x => x.TerminId,
                        principalTable: "Termini",
                        principalColumn: "TerminId",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Pregledi_UspostavljenaDijagnoza_UspostavljenaDijagnozaId",
                        column: x => x.UspostavljenaDijagnozaId,
                        principalTable: "UspostavljenaDijagnoza",
                        principalColumn: "UspostavljenaDijagnozaId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MedicinskiKarton",
                columns: table => new
                {
                    MedicinskiKartonId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PregledId = table.Column<int>(nullable: false),
                    PacijentId = table.Column<int>(nullable: false),
                    Datum = table.Column<DateTime>(nullable: false),
                    Napomena = table.Column<string>(maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MedicinskiKarton", x => x.MedicinskiKartonId);
                    table.ForeignKey(
                        name: "FK_MedicinskiKarton_Pacijenti_PacijentId",
                        column: x => x.PacijentId,
                        principalTable: "Pacijenti",
                        principalColumn: "PacijentId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MedicinskiKarton_Pregledi_PregledId",
                        column: x => x.PregledId,
                        principalTable: "Pregledi",
                        principalColumn: "PregledId",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "Racun",
                columns: table => new
                {
                    RacunId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    KorisnikId = table.Column<int>(nullable: false),
                    PregledId = table.Column<int>(nullable: false),
                    UkupnaCijena = table.Column<decimal>(type: "DECIMAL(18,2)", nullable: false),
                    DatumIzdavanjaRacuna = table.Column<DateTime>(type: "SMALLDATETIME", nullable: false),
                    IsPlatio = table.Column<bool>(type: "BIT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Racun", x => x.RacunId);
                    table.ForeignKey(
                        name: "FK_Racun_Korisnici_KorisnikId",
                        column: x => x.KorisnikId,
                        principalTable: "Korisnici",
                        principalColumn: "KorisnikId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Racun_Pregledi_PregledId",
                        column: x => x.PregledId,
                        principalTable: "Pregledi",
                        principalColumn: "PregledId",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Grad_DrzavaId",
                table: "Grad",
                column: "DrzavaId");

            migrationBuilder.CreateIndex(
                name: "IX_Korisnici_GradId",
                table: "Korisnici",
                column: "GradId");

            migrationBuilder.CreateIndex(
                name: "IX_Korisnici_UlogaId",
                table: "Korisnici",
                column: "UlogaId");

            migrationBuilder.CreateIndex(
                name: "IX_MedicinskiKarton_PacijentId",
                table: "MedicinskiKarton",
                column: "PacijentId");

            migrationBuilder.CreateIndex(
                name: "IX_MedicinskiKarton_PregledId",
                table: "MedicinskiKarton",
                column: "PregledId");

            migrationBuilder.CreateIndex(
                name: "IX_Ocjenes_PacijentId",
                table: "Ocjenes",
                column: "PacijentId");

            migrationBuilder.CreateIndex(
                name: "IX_Ocjenes_UslugaId",
                table: "Ocjenes",
                column: "UslugaId");

            migrationBuilder.CreateIndex(
                name: "IX_Pacijenti_KorisnikId",
                table: "Pacijenti",
                column: "KorisnikId");

            migrationBuilder.CreateIndex(
                name: "IX_Popusts_KorisnikId",
                table: "Popusts",
                column: "KorisnikId");

            migrationBuilder.CreateIndex(
                name: "IX_Popusts_UslugaId",
                table: "Popusts",
                column: "UslugaId");

            migrationBuilder.CreateIndex(
                name: "IX_Pregledi_KorisnikId",
                table: "Pregledi",
                column: "KorisnikId");

            migrationBuilder.CreateIndex(
                name: "IX_Pregledi_TerapijaId",
                table: "Pregledi",
                column: "TerapijaId");

            migrationBuilder.CreateIndex(
                name: "IX_Pregledi_TerminId",
                table: "Pregledi",
                column: "TerminId");

            migrationBuilder.CreateIndex(
                name: "IX_Pregledi_UspostavljenaDijagnozaId",
                table: "Pregledi",
                column: "UspostavljenaDijagnozaId");

            migrationBuilder.CreateIndex(
                name: "IX_Pretplatas_PacijentId",
                table: "Pretplatas",
                column: "PacijentId");

            migrationBuilder.CreateIndex(
                name: "IX_Pretplatas_UslugaId",
                table: "Pretplatas",
                column: "UslugaId");

            migrationBuilder.CreateIndex(
                name: "IX_PromjenaLozinkes_KorisnikId",
                table: "PromjenaLozinkes",
                column: "KorisnikId");

            migrationBuilder.CreateIndex(
                name: "IX_Racun_KorisnikId",
                table: "Racun",
                column: "KorisnikId");

            migrationBuilder.CreateIndex(
                name: "IX_Racun_PregledId",
                table: "Racun",
                column: "PregledId");

            migrationBuilder.CreateIndex(
                name: "IX_Skladiste_UlazUSkladisteId",
                table: "Skladiste",
                column: "UlazUSkladisteId");

            migrationBuilder.CreateIndex(
                name: "IX_Terapija_LijekId",
                table: "Terapija",
                column: "LijekId");

            migrationBuilder.CreateIndex(
                name: "IX_Termini_PacijentId",
                table: "Termini",
                column: "PacijentId");

            migrationBuilder.CreateIndex(
                name: "IX_Termini_UslugaId",
                table: "Termini",
                column: "UslugaId");

            migrationBuilder.CreateIndex(
                name: "IX_UlazUSkladiste_KorisnikId",
                table: "UlazUSkladiste",
                column: "KorisnikId");

            migrationBuilder.CreateIndex(
                name: "IX_UspostavljenaDijagnoza_DijagnozaId",
                table: "UspostavljenaDijagnoza",
                column: "DijagnozaId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MedicinskiKarton");

            migrationBuilder.DropTable(
                name: "Ocjenes");

            migrationBuilder.DropTable(
                name: "Popusts");

            migrationBuilder.DropTable(
                name: "Pretplatas");

            migrationBuilder.DropTable(
                name: "PromjenaLozinkes");

            migrationBuilder.DropTable(
                name: "Racun");

            migrationBuilder.DropTable(
                name: "Skladiste");

            migrationBuilder.DropTable(
                name: "Pregledi");

            migrationBuilder.DropTable(
                name: "UlazUSkladiste");

            migrationBuilder.DropTable(
                name: "Terapija");

            migrationBuilder.DropTable(
                name: "Termini");

            migrationBuilder.DropTable(
                name: "UspostavljenaDijagnoza");

            migrationBuilder.DropTable(
                name: "Lijek");

            migrationBuilder.DropTable(
                name: "Pacijenti");

            migrationBuilder.DropTable(
                name: "Usluga");

            migrationBuilder.DropTable(
                name: "Dijagnoza");

            migrationBuilder.DropTable(
                name: "Korisnici");

            migrationBuilder.DropTable(
                name: "Grad");

            migrationBuilder.DropTable(
                name: "Uloges");

            migrationBuilder.DropTable(
                name: "Drzava");
        }
    }
}
