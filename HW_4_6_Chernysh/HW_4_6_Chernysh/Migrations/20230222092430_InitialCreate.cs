using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace HW_4_6_Chernysh.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Artists",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    DateOfBirth = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateOfDeath = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Phone = table.Column<int>(type: "int", maxLength: 50, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    InstagramUrl = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Artists", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Genres",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Genres", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Songs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Duration = table.Column<TimeSpan>(type: "time", nullable: false),
                    ReleasedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    GenreId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Songs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Songs_Genres_GenreId",
                        column: x => x.GenreId,
                        principalTable: "Genres",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ArtistSong",
                columns: table => new
                {
                    ArtistsId = table.Column<int>(type: "int", nullable: false),
                    SongsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ArtistSong", x => new { x.ArtistsId, x.SongsId });
                    table.ForeignKey(
                        name: "FK_ArtistSong_Artists_ArtistsId",
                        column: x => x.ArtistsId,
                        principalTable: "Artists",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ArtistSong_Songs_SongsId",
                        column: x => x.SongsId,
                        principalTable: "Songs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Artists",
                columns: new[] { "Id", "DateOfBirth", "DateOfDeath", "Email", "InstagramUrl", "Name", "Phone" },
                values: new object[,]
                {
                    { 1, new DateTime(1994, 5, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, "Сплин", null },
                    { 2, new DateTime(1994, 10, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, "https://www.instagram.com/okeanelzy_official", "Океан Эльзы", null },
                    { 3, new DateTime(2000, 2, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, "https://www.instagram.com/yeat", "Yeat", null },
                    { 4, new DateTime(1988, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, "Deftones", null },
                    { 5, new DateTime(1987, 12, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2000, 7, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, "Сектор Газа", null }
                });

            migrationBuilder.InsertData(
                table: "Genres",
                columns: new[] { "Id", "Title" },
                values: new object[,]
                {
                    { 1, "Alternative rock" },
                    { 2, "Punk rock" },
                    { 3, "Post-punk" },
                    { 4, "Hip hop" },
                    { 5, "Indie rock" }
                });

            migrationBuilder.InsertData(
                table: "Songs",
                columns: new[] { "Id", "Duration", "GenreId", "ReleasedDate", "Title" },
                values: new object[,]
                {
                    { 1, new TimeSpan(0, 0, 6, 53, 0), 1, new DateTime(2012, 11, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Rosemary" },
                    { 2, new TimeSpan(0, 0, 4, 30, 0), 1, new DateTime(2005, 9, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "Без бою" },
                    { 3, new TimeSpan(0, 0, 4, 10, 0), 5, new DateTime(2014, 9, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "Танцуй!" },
                    { 4, new TimeSpan(0, 0, 3, 44, 0), 2, new DateTime(1992, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Бомж" },
                    { 5, new TimeSpan(0, 0, 2, 54, 0), 4, new DateTime(2022, 9, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "Talk" }
                });

            migrationBuilder.InsertData(
                table: "ArtistSong",
                columns: new[] { "ArtistsId", "SongsId" },
                values: new object[,]
                {
                    { 1, 3 },
                    { 2, 2 },
                    { 3, 5 },
                    { 4, 1 },
                    { 5, 4 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_ArtistSong_SongsId",
                table: "ArtistSong",
                column: "SongsId");

            migrationBuilder.CreateIndex(
                name: "IX_Songs_GenreId",
                table: "Songs",
                column: "GenreId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ArtistSong");

            migrationBuilder.DropTable(
                name: "Artists");

            migrationBuilder.DropTable(
                name: "Songs");

            migrationBuilder.DropTable(
                name: "Genres");
        }
    }
}
