using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace dsd03Razor2020Assessment.Data.Migrations
{
    public partial class overview : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Overview",
                table: "Movie",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Overview",
                table: "Movie");
        }
    }
}
