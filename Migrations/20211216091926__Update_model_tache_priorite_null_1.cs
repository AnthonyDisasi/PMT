using Microsoft.EntityFrameworkCore.Migrations;

namespace PMT.Migrations
{
    public partial class _Update_model_tache_priorite_null_1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Priorite",
                table: "Taches");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Priorite",
                table: "Taches",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
