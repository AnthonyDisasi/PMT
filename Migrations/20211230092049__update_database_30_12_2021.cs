using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PMT.Migrations
{
    public partial class _update_database_30_12_2021 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Commentaires",
                columns: table => new
                {
                    ID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    SousTacheID = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    Note = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Date_Post = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UserPost = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EstActif = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Commentaires", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Commentaires_Soustaches_SousTacheID",
                        column: x => x.SousTacheID,
                        principalTable: "Soustaches",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Commentaires_SousTacheID",
                table: "Commentaires",
                column: "SousTacheID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Commentaires");
        }
    }
}
