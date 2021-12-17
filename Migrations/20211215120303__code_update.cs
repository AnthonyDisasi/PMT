using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PMT.Migrations
{
    public partial class _code_update : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AddColumn<double>(
                name: "Progression",
                table: "Taches",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.CreateTable(
                name: "Soustaches",
                columns: table => new
                {
                    ID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    TacheID = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    CreateurTache = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Nom = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Statut = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Priorite = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Prgression = table.Column<double>(type: "float", nullable: false),
                    EstActif = table.Column<bool>(type: "bit", nullable: false),
                    ResponsableTache = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Date_Debut = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Date_Fin = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Soustaches", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Soustaches_Taches_TacheID",
                        column: x => x.TacheID,
                        principalTable: "Taches",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Soustaches_TacheID",
                table: "Soustaches",
                column: "TacheID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Soustaches");

            migrationBuilder.DropColumn(
                name: "Progression",
                table: "Taches");

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
    }
}
