using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RazorPagesUI.Migrations
{
    public partial class AddConcertov2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Concerts");

            migrationBuilder.CreateTable(
                name: "Concerte",
                columns: table => new
                {
                    ConcertId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NumeConcert = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DataConcert = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Locatie = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ArtistId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Concerte", x => x.ConcertId);
                    table.ForeignKey(
                        name: "FK_Concerte_ArtistiColectie_ArtistId",
                        column: x => x.ArtistId,
                        principalTable: "ArtistiColectie",
                        principalColumn: "ArtistId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Concerte_ArtistId",
                table: "Concerte",
                column: "ArtistId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Concerte");

            migrationBuilder.CreateTable(
                name: "Concerts",
                columns: table => new
                {
                    ConcertId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ArtistId = table.Column<int>(type: "int", nullable: false),
                    DataConcert = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Locatie = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NumeConcert = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Concerts", x => x.ConcertId);
                    table.ForeignKey(
                        name: "FK_Concerts_ArtistiColectie_ArtistId",
                        column: x => x.ArtistId,
                        principalTable: "ArtistiColectie",
                        principalColumn: "ArtistId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Concerts_ArtistId",
                table: "Concerts",
                column: "ArtistId");
        }
    }
}
