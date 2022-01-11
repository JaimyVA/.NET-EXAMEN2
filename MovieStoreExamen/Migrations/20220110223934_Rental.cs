using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MovieStoreExamen.Migrations
{
    public partial class Rental : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
    name: "Rental",
    columns: table => new
    {
        RentalId = table.Column<int>(type: "int", nullable: false)
            .Annotation("SqlServer:Identity", "1, 1"),
        RentalDate = table.Column<DateTime>(type: "datetime2", nullable: false),
        RentalExpiry = table.Column<DateTime>(type: "datetime2", nullable: true),
        CustomerId = table.Column<int>(type: "int", nullable: false)
    },
    constraints: table =>
    {
        table.PrimaryKey("PK_Rental", x => x.RentalId);
        table.ForeignKey(
            name: "FK_Rental_Customer_CustomerId",
            column: x => x.CustomerId,
            principalTable: "Customer",
            principalColumn: "Id",
            onDelete: ReferentialAction.Cascade);
    });

            migrationBuilder.CreateIndex(
                name: "IX_Rental_CustomerId",
                table: "Rental",
                column: "CustomerId");

            migrationBuilder.AddColumn<int>(
                name: "MovieId",
                table: "Rental",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Rental_MovieId",
                table: "Rental",
                column: "MovieId");

            migrationBuilder.AddForeignKey(
                name: "FK_Rental_Movie_MovieId",
                table: "Rental",
                column: "MovieId",
                principalTable: "Movie",
                principalColumn: "MovieId",
                onDelete: ReferentialAction.Cascade);
        }


        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Rental_Movie_MovieId",
                table: "Rental");

            migrationBuilder.DropIndex(
                name: "IX_Rental_MovieId",
                table: "Rental");

            migrationBuilder.DropColumn(
                name: "MovieId",
                table: "Rental");
            migrationBuilder.DropTable(
    name: "Rental");
        }
    }
}
