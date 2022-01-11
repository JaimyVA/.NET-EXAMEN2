using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MovieStoreExamen.Migrations
{
    public partial class @new : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
    name: "Movie",
    columns: table => new
    {
        MovieId = table.Column<int>(type: "int", nullable: false)
            .Annotation("SqlServer:Identity", "1, 1"),
        MovieTitle = table.Column<string>(type: "nvarchar(max)", nullable: false),
        Rating = table.Column<int>(type: "int", nullable: false),
        Rental_Duration = table.Column<int>(type: "int", nullable: false),
        Amount_Gent = table.Column<int>(type: "int", nullable: false),
        Amount_Brussel = table.Column<int>(type: "int", nullable: false),
        Amount_Antwerpen = table.Column<int>(type: "int", nullable: false),
        Amount_Returned = table.Column<int>(type: "int", nullable: false)
    },
    constraints: table =>
    {
        table.PrimaryKey("PK_Movie", x => x.MovieId);
    });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
    name: "Movie");
        }
    }
}
