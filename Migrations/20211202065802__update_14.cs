using Microsoft.EntityFrameworkCore.Migrations;

namespace PMT.Migrations
{
    public partial class _update_14 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Taches_Priorites_PrioriteID",
                table: "Taches");

            migrationBuilder.DropForeignKey(
                name: "FK_Taches_Statuts_StatutID",
                table: "Taches");

            migrationBuilder.DropIndex(
                name: "IX_Taches_PrioriteID",
                table: "Taches");

            migrationBuilder.DropIndex(
                name: "IX_Taches_StatutID",
                table: "Taches");

            migrationBuilder.DropColumn(
                name: "PrioriteID",
                table: "Taches");

            migrationBuilder.DropColumn(
                name: "StatutID",
                table: "Taches");

            migrationBuilder.AddColumn<string>(
                name: "Priorite",
                table: "Taches",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

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
                name: "Priorite",
                table: "Taches");

            migrationBuilder.DropColumn(
                name: "Statut",
                table: "Taches");

            migrationBuilder.AddColumn<string>(
                name: "PrioriteID",
                table: "Taches",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "StatutID",
                table: "Taches",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_Taches_PrioriteID",
                table: "Taches",
                column: "PrioriteID");

            migrationBuilder.CreateIndex(
                name: "IX_Taches_StatutID",
                table: "Taches",
                column: "StatutID");

            migrationBuilder.AddForeignKey(
                name: "FK_Taches_Priorites_PrioriteID",
                table: "Taches",
                column: "PrioriteID",
                principalTable: "Priorites",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Taches_Statuts_StatutID",
                table: "Taches",
                column: "StatutID",
                principalTable: "Statuts",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
