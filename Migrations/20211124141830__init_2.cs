using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PMT.Migrations
{
    public partial class _init_2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Nom",
                table: "Techniciens",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Post",
                table: "Techniciens",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Postnom",
                table: "Techniciens",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Prenom",
                table: "Techniciens",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "Date_Debut",
                table: "Taches",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "Date_Fin",
                table: "Taches",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "Priorite",
                table: "Taches",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Statut",
                table: "Taches",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TechnicienID",
                table: "Taches",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Type",
                table: "Taches",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Nom",
                table: "Statuts",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Nom",
                table: "Priorites",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Commentaire",
                table: "Notes",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "Date_Post",
                table: "Notes",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "TacheID",
                table: "Notes",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserPost",
                table: "Notes",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Affectation",
                columns: table => new
                {
                    ID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    TacheID = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    TechnicienID = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    Date_Affectation = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Affectation", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Affectation_Taches_TacheID",
                        column: x => x.TacheID,
                        principalTable: "Taches",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Affectation_Techniciens_TechnicienID",
                        column: x => x.TechnicienID,
                        principalTable: "Techniciens",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Taches_TechnicienID",
                table: "Taches",
                column: "TechnicienID");

            migrationBuilder.CreateIndex(
                name: "IX_Notes_TacheID",
                table: "Notes",
                column: "TacheID");

            migrationBuilder.CreateIndex(
                name: "IX_Affectation_TacheID",
                table: "Affectation",
                column: "TacheID");

            migrationBuilder.CreateIndex(
                name: "IX_Affectation_TechnicienID",
                table: "Affectation",
                column: "TechnicienID");

            migrationBuilder.AddForeignKey(
                name: "FK_Notes_Taches_TacheID",
                table: "Notes",
                column: "TacheID",
                principalTable: "Taches",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Taches_Techniciens_TechnicienID",
                table: "Taches",
                column: "TechnicienID",
                principalTable: "Techniciens",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Notes_Taches_TacheID",
                table: "Notes");

            migrationBuilder.DropForeignKey(
                name: "FK_Taches_Techniciens_TechnicienID",
                table: "Taches");

            migrationBuilder.DropTable(
                name: "Affectation");

            migrationBuilder.DropIndex(
                name: "IX_Taches_TechnicienID",
                table: "Taches");

            migrationBuilder.DropIndex(
                name: "IX_Notes_TacheID",
                table: "Notes");

            migrationBuilder.DropColumn(
                name: "Nom",
                table: "Techniciens");

            migrationBuilder.DropColumn(
                name: "Post",
                table: "Techniciens");

            migrationBuilder.DropColumn(
                name: "Postnom",
                table: "Techniciens");

            migrationBuilder.DropColumn(
                name: "Prenom",
                table: "Techniciens");

            migrationBuilder.DropColumn(
                name: "Date_Debut",
                table: "Taches");

            migrationBuilder.DropColumn(
                name: "Date_Fin",
                table: "Taches");

            migrationBuilder.DropColumn(
                name: "Priorite",
                table: "Taches");

            migrationBuilder.DropColumn(
                name: "Statut",
                table: "Taches");

            migrationBuilder.DropColumn(
                name: "TechnicienID",
                table: "Taches");

            migrationBuilder.DropColumn(
                name: "Type",
                table: "Taches");

            migrationBuilder.DropColumn(
                name: "Nom",
                table: "Statuts");

            migrationBuilder.DropColumn(
                name: "Nom",
                table: "Priorites");

            migrationBuilder.DropColumn(
                name: "Commentaire",
                table: "Notes");

            migrationBuilder.DropColumn(
                name: "Date_Post",
                table: "Notes");

            migrationBuilder.DropColumn(
                name: "TacheID",
                table: "Notes");

            migrationBuilder.DropColumn(
                name: "UserPost",
                table: "Notes");
        }
    }
}
