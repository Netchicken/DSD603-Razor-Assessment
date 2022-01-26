using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace dsd03Razor2020Assessment.Data.Migrations
{
    public partial class Cast : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Movie");


            migrationBuilder.CreateTable(
               name: "Movie",
               columns: table => new
               {
                   Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),

                   Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                   ReleaseDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                   Genre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                   Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
               },
               constraints: table =>
               {
                   table.PrimaryKey("PK_Movie", x => x.Id);
               });




            migrationBuilder.AddColumn<Guid>(
                name: "CastId",
                table: "Movie",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateTable(
                name: "Cast",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ScreenName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cast", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Movie_CastId",
                table: "Movie",
                column: "CastId");

            migrationBuilder.AddForeignKey(
                name: "FK_Movie_Cast_CastId",
                table: "Movie",
                column: "CastId",
                principalTable: "Cast",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Movie_Cast_CastId",
                table: "Movie");

            migrationBuilder.DropTable(
                name: "Cast");

            migrationBuilder.DropIndex(
                name: "IX_Movie_CastId",
                table: "Movie");

            migrationBuilder.DropColumn(
                name: "CastId",
                table: "Movie");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Movie",
                newName: "ID");

            migrationBuilder.AlterColumn<int>(
                name: "ID",
                table: "Movie",
                type: "int",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier")
                .Annotation("SqlServer:Identity", "1, 1");
        }
    }
}
