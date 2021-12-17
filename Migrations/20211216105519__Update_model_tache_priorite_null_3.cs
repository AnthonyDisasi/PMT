using Microsoft.EntityFrameworkCore.Migrations;

namespace PMT.Migrations
{
    public partial class _Update_model_tache_priorite_null_3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Statut",
                table: "Taches",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Statut",
                table: "Taches");
        }
    }
}
