using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MovieApi.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class AddMoviesSeriesToCategory : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "SeriesId",
                table: "Reviews",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Reviews_SeriesId",
                table: "Reviews",
                column: "SeriesId");

            migrationBuilder.AddForeignKey(
                name: "FK_Reviews_Serieses_SeriesId",
                table: "Reviews",
                column: "SeriesId",
                principalTable: "Serieses",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reviews_Serieses_SeriesId",
                table: "Reviews");

            migrationBuilder.DropIndex(
                name: "IX_Reviews_SeriesId",
                table: "Reviews");

            migrationBuilder.DropColumn(
                name: "SeriesId",
                table: "Reviews");
        }
    }
}
