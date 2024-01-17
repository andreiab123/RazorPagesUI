using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RazorPagesUI.Migrations
{
    public partial class Hituri : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Hituri",
                columns: table => new
                {
                    HitId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NumeHit = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DataDeLansare = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Album = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Hituri", x => x.HitId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Hituri");
        }
    }
}
