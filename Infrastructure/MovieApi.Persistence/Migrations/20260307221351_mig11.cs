using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MovieApi.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class mig11 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Episode_Season_SeasonId",
                table: "Episode");

            migrationBuilder.DropForeignKey(
                name: "FK_MovieCast_Casts_CastId",
                table: "MovieCast");

            migrationBuilder.DropForeignKey(
                name: "FK_MovieCast_Movies_MovieId",
                table: "MovieCast");

            migrationBuilder.DropForeignKey(
                name: "FK_Reviews_Episode_EpisodeId",
                table: "Reviews");

            migrationBuilder.DropForeignKey(
                name: "FK_Season_Movies_MovieId",
                table: "Season");

            migrationBuilder.DropForeignKey(
                name: "FK_Season_Serieses_SeriesId",
                table: "Season");

            migrationBuilder.DropForeignKey(
                name: "FK_SeriesCast_Casts_CastId",
                table: "SeriesCast");

            migrationBuilder.DropForeignKey(
                name: "FK_SeriesCast_Serieses_SeriesId",
                table: "SeriesCast");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SeriesCast",
                table: "SeriesCast");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Season",
                table: "Season");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MovieCast",
                table: "MovieCast");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Episode",
                table: "Episode");

            migrationBuilder.RenameTable(
                name: "SeriesCast",
                newName: "SeriesCasts");

            migrationBuilder.RenameTable(
                name: "Season",
                newName: "seasons");

            migrationBuilder.RenameTable(
                name: "MovieCast",
                newName: "MovieCasts");

            migrationBuilder.RenameTable(
                name: "Episode",
                newName: "Episodes");

            migrationBuilder.RenameIndex(
                name: "IX_SeriesCast_SeriesId",
                table: "SeriesCasts",
                newName: "IX_SeriesCasts_SeriesId");

            migrationBuilder.RenameIndex(
                name: "IX_SeriesCast_CastId",
                table: "SeriesCasts",
                newName: "IX_SeriesCasts_CastId");

            migrationBuilder.RenameIndex(
                name: "IX_Season_SeriesId",
                table: "seasons",
                newName: "IX_seasons_SeriesId");

            migrationBuilder.RenameIndex(
                name: "IX_Season_MovieId",
                table: "seasons",
                newName: "IX_seasons_MovieId");

            migrationBuilder.RenameIndex(
                name: "IX_MovieCast_MovieId",
                table: "MovieCasts",
                newName: "IX_MovieCasts_MovieId");

            migrationBuilder.RenameIndex(
                name: "IX_MovieCast_CastId",
                table: "MovieCasts",
                newName: "IX_MovieCasts_CastId");

            migrationBuilder.RenameIndex(
                name: "IX_Episode_SeasonId",
                table: "Episodes",
                newName: "IX_Episodes_SeasonId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SeriesCasts",
                table: "SeriesCasts",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_seasons",
                table: "seasons",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_MovieCasts",
                table: "MovieCasts",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Episodes",
                table: "Episodes",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "UserWatchs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EpisodeId = table.Column<int>(type: "int", nullable: false),
                    IsWatched = table.Column<bool>(type: "bit", nullable: false),
                    WatchedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserWatchs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserWatchs_Episodes_EpisodeId",
                        column: x => x.EpisodeId,
                        principalTable: "Episodes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_UserWatchs_EpisodeId",
                table: "UserWatchs",
                column: "EpisodeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Episodes_seasons_SeasonId",
                table: "Episodes",
                column: "SeasonId",
                principalTable: "seasons",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MovieCasts_Casts_CastId",
                table: "MovieCasts",
                column: "CastId",
                principalTable: "Casts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MovieCasts_Movies_MovieId",
                table: "MovieCasts",
                column: "MovieId",
                principalTable: "Movies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Reviews_Episodes_EpisodeId",
                table: "Reviews",
                column: "EpisodeId",
                principalTable: "Episodes",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_seasons_Movies_MovieId",
                table: "seasons",
                column: "MovieId",
                principalTable: "Movies",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_seasons_Serieses_SeriesId",
                table: "seasons",
                column: "SeriesId",
                principalTable: "Serieses",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_SeriesCasts_Casts_CastId",
                table: "SeriesCasts",
                column: "CastId",
                principalTable: "Casts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SeriesCasts_Serieses_SeriesId",
                table: "SeriesCasts",
                column: "SeriesId",
                principalTable: "Serieses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Episodes_seasons_SeasonId",
                table: "Episodes");

            migrationBuilder.DropForeignKey(
                name: "FK_MovieCasts_Casts_CastId",
                table: "MovieCasts");

            migrationBuilder.DropForeignKey(
                name: "FK_MovieCasts_Movies_MovieId",
                table: "MovieCasts");

            migrationBuilder.DropForeignKey(
                name: "FK_Reviews_Episodes_EpisodeId",
                table: "Reviews");

            migrationBuilder.DropForeignKey(
                name: "FK_seasons_Movies_MovieId",
                table: "seasons");

            migrationBuilder.DropForeignKey(
                name: "FK_seasons_Serieses_SeriesId",
                table: "seasons");

            migrationBuilder.DropForeignKey(
                name: "FK_SeriesCasts_Casts_CastId",
                table: "SeriesCasts");

            migrationBuilder.DropForeignKey(
                name: "FK_SeriesCasts_Serieses_SeriesId",
                table: "SeriesCasts");

            migrationBuilder.DropTable(
                name: "UserWatchs");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SeriesCasts",
                table: "SeriesCasts");

            migrationBuilder.DropPrimaryKey(
                name: "PK_seasons",
                table: "seasons");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MovieCasts",
                table: "MovieCasts");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Episodes",
                table: "Episodes");

            migrationBuilder.RenameTable(
                name: "SeriesCasts",
                newName: "SeriesCast");

            migrationBuilder.RenameTable(
                name: "seasons",
                newName: "Season");

            migrationBuilder.RenameTable(
                name: "MovieCasts",
                newName: "MovieCast");

            migrationBuilder.RenameTable(
                name: "Episodes",
                newName: "Episode");

            migrationBuilder.RenameIndex(
                name: "IX_SeriesCasts_SeriesId",
                table: "SeriesCast",
                newName: "IX_SeriesCast_SeriesId");

            migrationBuilder.RenameIndex(
                name: "IX_SeriesCasts_CastId",
                table: "SeriesCast",
                newName: "IX_SeriesCast_CastId");

            migrationBuilder.RenameIndex(
                name: "IX_seasons_SeriesId",
                table: "Season",
                newName: "IX_Season_SeriesId");

            migrationBuilder.RenameIndex(
                name: "IX_seasons_MovieId",
                table: "Season",
                newName: "IX_Season_MovieId");

            migrationBuilder.RenameIndex(
                name: "IX_MovieCasts_MovieId",
                table: "MovieCast",
                newName: "IX_MovieCast_MovieId");

            migrationBuilder.RenameIndex(
                name: "IX_MovieCasts_CastId",
                table: "MovieCast",
                newName: "IX_MovieCast_CastId");

            migrationBuilder.RenameIndex(
                name: "IX_Episodes_SeasonId",
                table: "Episode",
                newName: "IX_Episode_SeasonId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SeriesCast",
                table: "SeriesCast",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Season",
                table: "Season",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_MovieCast",
                table: "MovieCast",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Episode",
                table: "Episode",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Episode_Season_SeasonId",
                table: "Episode",
                column: "SeasonId",
                principalTable: "Season",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MovieCast_Casts_CastId",
                table: "MovieCast",
                column: "CastId",
                principalTable: "Casts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MovieCast_Movies_MovieId",
                table: "MovieCast",
                column: "MovieId",
                principalTable: "Movies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Reviews_Episode_EpisodeId",
                table: "Reviews",
                column: "EpisodeId",
                principalTable: "Episode",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Season_Movies_MovieId",
                table: "Season",
                column: "MovieId",
                principalTable: "Movies",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Season_Serieses_SeriesId",
                table: "Season",
                column: "SeriesId",
                principalTable: "Serieses",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_SeriesCast_Casts_CastId",
                table: "SeriesCast",
                column: "CastId",
                principalTable: "Casts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SeriesCast_Serieses_SeriesId",
                table: "SeriesCast",
                column: "SeriesId",
                principalTable: "Serieses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
