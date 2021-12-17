using Microsoft.EntityFrameworkCore.Migrations;

namespace PMT.Migrations
{
    public partial class _code_update_3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Prgression",
                table: "Soustaches",
                newName: "Progression");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Progression",
                table: "Soustaches",
                newName: "Prgression");
        }
    }
}
