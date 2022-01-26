using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace dsd03Razor2020Assessment.Data.Migrations
{
    public partial class nulliblecast : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Movie_Cast_CastId",
                table: "Movie");

            migrationBuilder.AlterColumn<Guid>(
                name: "CastId",
                table: "Movie",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AddForeignKey(
                name: "FK_Movie_Cast_CastId",
                table: "Movie",
                column: "CastId",
                principalTable: "Cast",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Movie_Cast_CastId",
                table: "Movie");

            migrationBuilder.AlterColumn<Guid>(
                name: "CastId",
                table: "Movie",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Movie_Cast_CastId",
                table: "Movie",
                column: "CastId",
                principalTable: "Cast",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
