using Microsoft.EntityFrameworkCore.Migrations;

namespace PMT.Migrations
{
    public partial class _init_3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Affectation_Taches_TacheID",
                table: "Affectation");

            migrationBuilder.DropForeignKey(
                name: "FK_Affectation_Techniciens_TechnicienID",
                table: "Affectation");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Affectation",
                table: "Affectation");

            migrationBuilder.RenameTable(
                name: "Affectation",
                newName: "Affectations");

            migrationBuilder.RenameIndex(
                name: "IX_Affectation_TechnicienID",
                table: "Affectations",
                newName: "IX_Affectations_TechnicienID");

            migrationBuilder.RenameIndex(
                name: "IX_Affectation_TacheID",
                table: "Affectations",
                newName: "IX_Affectations_TacheID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Affectations",
                table: "Affectations",
                column: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_Affectations_Taches_TacheID",
                table: "Affectations",
                column: "TacheID",
                principalTable: "Taches",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Affectations_Techniciens_TechnicienID",
                table: "Affectations",
                column: "TechnicienID",
                principalTable: "Techniciens",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Affectations_Taches_TacheID",
                table: "Affectations");

            migrationBuilder.DropForeignKey(
                name: "FK_Affectations_Techniciens_TechnicienID",
                table: "Affectations");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Affectations",
                table: "Affectations");

            migrationBuilder.RenameTable(
                name: "Affectations",
                newName: "Affectation");

            migrationBuilder.RenameIndex(
                name: "IX_Affectations_TechnicienID",
                table: "Affectation",
                newName: "IX_Affectation_TechnicienID");

            migrationBuilder.RenameIndex(
                name: "IX_Affectations_TacheID",
                table: "Affectation",
                newName: "IX_Affectation_TacheID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Affectation",
                table: "Affectation",
                column: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_Affectation_Taches_TacheID",
                table: "Affectation",
                column: "TacheID",
                principalTable: "Taches",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Affectation_Techniciens_TechnicienID",
                table: "Affectation",
                column: "TechnicienID",
                principalTable: "Techniciens",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
