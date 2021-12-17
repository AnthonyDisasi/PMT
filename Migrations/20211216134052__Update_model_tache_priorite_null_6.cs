using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PMT.Migrations
{
    public partial class _Update_model_tache_priorite_null_6 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Affectations");

            migrationBuilder.DropTable(
                name: "Priorites");

            migrationBuilder.DropTable(
                name: "Statuts");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Affectations",
                columns: table => new
                {
                    ID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Date_Affectation = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EstActif = table.Column<bool>(type: "bit", nullable: false),
                    TacheID = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    TechnicienID = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Affectations", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Affectations_Taches_TacheID",
                        column: x => x.TacheID,
                        principalTable: "Taches",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Affectations_Techniciens_TechnicienID",
                        column: x => x.TechnicienID,
                        principalTable: "Techniciens",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Priorites",
                columns: table => new
                {
                    ID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    EstActif = table.Column<bool>(type: "bit", nullable: false),
                    Nom = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Priorites", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Statuts",
                columns: table => new
                {
                    ID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    EstActif = table.Column<bool>(type: "bit", nullable: false),
                    Nom = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Statuts", x => x.ID);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Affectations_TacheID",
                table: "Affectations",
                column: "TacheID");

            migrationBuilder.CreateIndex(
                name: "IX_Affectations_TechnicienID",
                table: "Affectations",
                column: "TechnicienID");
        }
    }
}
