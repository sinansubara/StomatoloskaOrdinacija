using Microsoft.EntityFrameworkCore.Migrations;

namespace StomatoloskaOrdinacija.WebAPI.Migrations
{
    public partial class updatePregled : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "KolicinaOdabranogMaterijala",
                table: "Pregledi",
                type: "DECIMAL(18,1)",
                nullable: false,
                defaultValue: 0m);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "KolicinaOdabranogMaterijala",
                table: "Pregledi");
        }
    }
}
