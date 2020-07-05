using Microsoft.EntityFrameworkCore.Migrations;

namespace StomatoloskaOrdinacija.WebAPI.Migrations
{
    public partial class dontNeedSomeThings : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pregledi_Terapija_TerapijaId",
                table: "Pregledi");

            migrationBuilder.DropForeignKey(
                name: "FK_Pregledi_UspostavljenaDijagnoza_UspostavljenaDijagnozaId",
                table: "Pregledi");

            migrationBuilder.DropTable(
                name: "Terapija");

            migrationBuilder.DropTable(
                name: "UspostavljenaDijagnoza");

            migrationBuilder.DropIndex(
                name: "IX_Pregledi_TerapijaId",
                table: "Pregledi");

            migrationBuilder.DropIndex(
                name: "IX_Pregledi_UspostavljenaDijagnozaId",
                table: "Pregledi");

            migrationBuilder.DropColumn(
                name: "TerapijaId",
                table: "Pregledi");

            migrationBuilder.DropColumn(
                name: "UspostavljenaDijagnozaId",
                table: "Pregledi");

            migrationBuilder.AddColumn<int>(
                name: "DijagnozaId",
                table: "Pregledi",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "LijekId",
                table: "Pregledi",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Pregledi_DijagnozaId",
                table: "Pregledi",
                column: "DijagnozaId");

            migrationBuilder.CreateIndex(
                name: "IX_Pregledi_LijekId",
                table: "Pregledi",
                column: "LijekId");

            migrationBuilder.AddForeignKey(
                name: "FK_Pregledi_Dijagnoza_DijagnozaId",
                table: "Pregledi",
                column: "DijagnozaId",
                principalTable: "Dijagnoza",
                principalColumn: "DijagnozaId",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_Pregledi_Lijek_LijekId",
                table: "Pregledi",
                column: "LijekId",
                principalTable: "Lijek",
                principalColumn: "LijekId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pregledi_Dijagnoza_DijagnozaId",
                table: "Pregledi");

            migrationBuilder.DropForeignKey(
                name: "FK_Pregledi_Lijek_LijekId",
                table: "Pregledi");

            migrationBuilder.DropIndex(
                name: "IX_Pregledi_DijagnozaId",
                table: "Pregledi");

            migrationBuilder.DropIndex(
                name: "IX_Pregledi_LijekId",
                table: "Pregledi");

            migrationBuilder.DropColumn(
                name: "DijagnozaId",
                table: "Pregledi");

            migrationBuilder.DropColumn(
                name: "LijekId",
                table: "Pregledi");

            migrationBuilder.AddColumn<int>(
                name: "TerapijaId",
                table: "Pregledi",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "UspostavljenaDijagnozaId",
                table: "Pregledi",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Terapija",
                columns: table => new
                {
                    TerapijaId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Kolicina = table.Column<byte>(type: "TINYINT", nullable: false),
                    LijekId = table.Column<int>(type: "int", nullable: false),
                    VrstaTerapije = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
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
                name: "UspostavljenaDijagnoza",
                columns: table => new
                {
                    UspostavljenaDijagnozaId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DijagnozaId = table.Column<int>(type: "int", nullable: false),
                    JacinaDijagnoze = table.Column<byte>(type: "TINYINT", nullable: false),
                    Napomena = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false)
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

            migrationBuilder.CreateIndex(
                name: "IX_Pregledi_TerapijaId",
                table: "Pregledi",
                column: "TerapijaId");

            migrationBuilder.CreateIndex(
                name: "IX_Pregledi_UspostavljenaDijagnozaId",
                table: "Pregledi",
                column: "UspostavljenaDijagnozaId");

            migrationBuilder.CreateIndex(
                name: "IX_Terapija_LijekId",
                table: "Terapija",
                column: "LijekId");

            migrationBuilder.CreateIndex(
                name: "IX_UspostavljenaDijagnoza_DijagnozaId",
                table: "UspostavljenaDijagnoza",
                column: "DijagnozaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Pregledi_Terapija_TerapijaId",
                table: "Pregledi",
                column: "TerapijaId",
                principalTable: "Terapija",
                principalColumn: "TerapijaId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Pregledi_UspostavljenaDijagnoza_UspostavljenaDijagnozaId",
                table: "Pregledi",
                column: "UspostavljenaDijagnozaId",
                principalTable: "UspostavljenaDijagnoza",
                principalColumn: "UspostavljenaDijagnozaId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
