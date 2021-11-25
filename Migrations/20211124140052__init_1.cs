using Microsoft.EntityFrameworkCore.Migrations;

namespace PMT.Migrations
{
    public partial class _init_1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "TacheID",
                table: "Taches",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Taches_TacheID",
                table: "Taches",
                column: "TacheID");

            migrationBuilder.AddForeignKey(
                name: "FK_Taches_Taches_TacheID",
                table: "Taches",
                column: "TacheID",
                principalTable: "Taches",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Taches_Taches_TacheID",
                table: "Taches");

            migrationBuilder.DropIndex(
                name: "IX_Taches_TacheID",
                table: "Taches");

            migrationBuilder.DropColumn(
                name: "TacheID",
                table: "Taches");
        }
    }
}
