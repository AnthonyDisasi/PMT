using Microsoft.EntityFrameworkCore.Migrations;

namespace PMT.Migrations
{
    public partial class _add_list_soustache : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "SousTacheID",
                table: "Soustaches",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Soustaches_SousTacheID",
                table: "Soustaches",
                column: "SousTacheID");

            migrationBuilder.AddForeignKey(
                name: "FK_Soustaches_Soustaches_SousTacheID",
                table: "Soustaches",
                column: "SousTacheID",
                principalTable: "Soustaches",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Soustaches_Soustaches_SousTacheID",
                table: "Soustaches");

            migrationBuilder.DropIndex(
                name: "IX_Soustaches_SousTacheID",
                table: "Soustaches");

            migrationBuilder.DropColumn(
                name: "SousTacheID",
                table: "Soustaches");
        }
    }
}
