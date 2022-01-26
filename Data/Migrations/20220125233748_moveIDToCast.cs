using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace dsd03Razor2020Assessment.Data.Migrations
{
    public partial class moveIDToCast : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Movie_Cast_CastId",
                table: "Movie");

            migrationBuilder.DropIndex(
                name: "IX_Movie_CastId",
                table: "Movie");

            migrationBuilder.DropColumn(
                name: "CastId",
                table: "Movie");

            migrationBuilder.AddColumn<Guid>(
                name: "MovieId",
                table: "Cast",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Cast_MovieId",
                table: "Cast",
                column: "MovieId");

            migrationBuilder.AddForeignKey(
                name: "FK_Cast_Movie_MovieId",
                table: "Cast",
                column: "MovieId",
                principalTable: "Movie",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cast_Movie_MovieId",
                table: "Cast");

            migrationBuilder.DropIndex(
                name: "IX_Cast_MovieId",
                table: "Cast");

            migrationBuilder.DropColumn(
                name: "MovieId",
                table: "Cast");

            migrationBuilder.AddColumn<Guid>(
                name: "CastId",
                table: "Movie",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Movie_CastId",
                table: "Movie",
                column: "CastId");

            migrationBuilder.AddForeignKey(
                name: "FK_Movie_Cast_CastId",
                table: "Movie",
                column: "CastId",
                principalTable: "Cast",
                principalColumn: "Id");
        }
    }
}
