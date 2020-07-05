using Microsoft.EntityFrameworkCore.Migrations;

namespace StomatoloskaOrdinacija.WebAPI.Migrations
{
    public partial class updatePregleda : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "SkladisteId",
                table: "Pregledi",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Pregledi_SkladisteId",
                table: "Pregledi",
                column: "SkladisteId");

            migrationBuilder.AddForeignKey(
                name: "FK_Pregledi_Skladiste_SkladisteId",
                table: "Pregledi",
                column: "SkladisteId",
                principalTable: "Skladiste",
                principalColumn: "SkladisteId",
                onDelete: ReferentialAction.NoAction);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pregledi_Skladiste_SkladisteId",
                table: "Pregledi");

            migrationBuilder.DropIndex(
                name: "IX_Pregledi_SkladisteId",
                table: "Pregledi");

            migrationBuilder.DropColumn(
                name: "SkladisteId",
                table: "Pregledi");
        }
    }
}
