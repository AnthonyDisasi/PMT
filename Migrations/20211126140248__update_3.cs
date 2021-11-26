using Microsoft.EntityFrameworkCore.Migrations;

namespace PMT.Migrations
{
    public partial class _update_3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Taches_Techniciens_TechnicienID",
                table: "Taches");

            migrationBuilder.DropIndex(
                name: "IX_Taches_TechnicienID",
                table: "Taches");

            migrationBuilder.DropColumn(
                name: "TechnicienID",
                table: "Taches");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "TechnicienID",
                table: "Taches",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Taches_TechnicienID",
                table: "Taches",
                column: "TechnicienID");

            migrationBuilder.AddForeignKey(
                name: "FK_Taches_Techniciens_TechnicienID",
                table: "Taches",
                column: "TechnicienID",
                principalTable: "Techniciens",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
