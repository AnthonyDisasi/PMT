using Microsoft.EntityFrameworkCore.Migrations;

namespace PMT.Migrations
{
    public partial class _Update_model_tache_priorite_null_4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Statut",
                table: "Soustaches");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Statut",
                table: "Soustaches",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
