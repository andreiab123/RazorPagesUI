using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RazorPagesUI.Migrations
{
    public partial class AddConcerto : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ArtistId",
                table: "Hituri",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ArtistId",
                table: "ChitareColectie",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Concerts",
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
                    table.PrimaryKey("PK_Concerts", x => x.ConcertId);
                    table.ForeignKey(
                        name: "FK_Concerts_ArtistiColectie_ArtistId",
                        column: x => x.ArtistId,
                        principalTable: "ArtistiColectie",
                        principalColumn: "ArtistId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Hituri_ArtistId",
                table: "Hituri",
                column: "ArtistId");

            migrationBuilder.CreateIndex(
                name: "IX_ChitareColectie_ArtistId",
                table: "ChitareColectie",
                column: "ArtistId");

            migrationBuilder.CreateIndex(
                name: "IX_Concerts_ArtistId",
                table: "Concerts",
                column: "ArtistId");

            migrationBuilder.AddForeignKey(
                name: "FK_ChitareColectie_ArtistiColectie_ArtistId",
                table: "ChitareColectie",
                column: "ArtistId",
                principalTable: "ArtistiColectie",
                principalColumn: "ArtistId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Hituri_ArtistiColectie_ArtistId",
                table: "Hituri",
                column: "ArtistId",
                principalTable: "ArtistiColectie",
                principalColumn: "ArtistId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ChitareColectie_ArtistiColectie_ArtistId",
                table: "ChitareColectie");

            migrationBuilder.DropForeignKey(
                name: "FK_Hituri_ArtistiColectie_ArtistId",
                table: "Hituri");

            migrationBuilder.DropTable(
                name: "Concerts");

            migrationBuilder.DropIndex(
                name: "IX_Hituri_ArtistId",
                table: "Hituri");

            migrationBuilder.DropIndex(
                name: "IX_ChitareColectie_ArtistId",
                table: "ChitareColectie");

            migrationBuilder.DropColumn(
                name: "ArtistId",
                table: "Hituri");

            migrationBuilder.DropColumn(
                name: "ArtistId",
                table: "ChitareColectie");
        }
    }
}
