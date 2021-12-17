using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PMT.Migrations
{
    public partial class _cont_ : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ResponsableTache",
                table: "Taches",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Notifications",
                columns: table => new
                {
                    ID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Expediteur = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Destinataire = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateMessage = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Message = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Lu = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Notifications", x => x.ID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Notifications");

            migrationBuilder.DropColumn(
                name: "ResponsableTache",
                table: "Taches");
        }
    }
}
