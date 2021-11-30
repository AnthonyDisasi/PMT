using Microsoft.EntityFrameworkCore.Migrations;

namespace PMT.Migrations
{
    public partial class _update_12 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "EstActif",
                table: "Techniciens",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "EstActif",
                table: "Statuts",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "EstActif",
                table: "Priorites",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "EstActif",
                table: "Notes",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "EstActif",
                table: "Affectations",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EstActif",
                table: "Techniciens");

            migrationBuilder.DropColumn(
                name: "EstActif",
                table: "Statuts");

            migrationBuilder.DropColumn(
                name: "EstActif",
                table: "Priorites");

            migrationBuilder.DropColumn(
                name: "EstActif",
                table: "Notes");

            migrationBuilder.DropColumn(
                name: "EstActif",
                table: "Affectations");
        }
    }
}
