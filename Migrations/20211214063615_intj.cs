using Microsoft.EntityFrameworkCore.Migrations;

namespace PMT.Migrations
{
    public partial class intj : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Etat",
                table: "Taches");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Etat",
                table: "Taches",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
