using Microsoft.EntityFrameworkCore.Migrations;

namespace PMT.Migrations
{
    public partial class EstActif_SousTache : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EstActif",
                table: "Soustaches");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "EstActif",
                table: "Soustaches",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }
    }
}
