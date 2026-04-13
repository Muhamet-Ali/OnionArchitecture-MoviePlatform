using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MovieApi.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class ForDeleteSeazonEpisodeReview : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reviews_Episodes_EpisodeId",
                table: "Reviews");

            migrationBuilder.AddForeignKey(
                name: "FK_Reviews_Episodes_EpisodeId",
                table: "Reviews",
                column: "EpisodeId",
                principalTable: "Episodes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reviews_Episodes_EpisodeId",
                table: "Reviews");

            migrationBuilder.AddForeignKey(
                name: "FK_Reviews_Episodes_EpisodeId",
                table: "Reviews",
                column: "EpisodeId",
                principalTable: "Episodes",
                principalColumn: "Id");
        }
    }
}
