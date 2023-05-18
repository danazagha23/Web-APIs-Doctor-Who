using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DoctorWho.Db.Migrations
{
    /// <inheritdoc />
    public partial class seedTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Authors",
                columns: new[] { "AuthorId", "AuthorName" },
                values: new object[,]
                {
                    { 1, "Chris Chibnall" },
                    { 2, "Gareth Roberts" },
                    { 3, "Helen Raynor" },
                    { 4, "James Moran" },
                    { 5, "James Strong" }
                });

            migrationBuilder.InsertData(
                table: "Companions",
                columns: new[] { "CompanionId", "CompanionName", "WhoPlayed" },
                values: new object[,]
                {
                    { 1, "River Song", "Alex Kingston" },
                    { 2, "Rory Williams", "Arthur Darvill" },
                    { 3, "Wilfred Mott", "Bernard Cribbins" },
                    { 4, "Rose Tyler", "Billie Piper" },
                    { 5, "James Strong", "Bruno Langley" }
                });

            migrationBuilder.InsertData(
                table: "Doctors",
                columns: new[] { "DoctorId", "BirthDate", "DoctorName", "DoctorNumber", "FirstEpisodeDate", "LastEpisodeDate" },
                values: new object[,]
                {
                    { 1, new DateTime(1964, 2, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), "Christopher Eccleston", 9, new DateTime(2005, 3, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2005, 5, 18, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2, new DateTime(1943, 6, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), "Colin Baker", 6, new DateTime(1984, 3, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1986, 12, 6, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 3, new DateTime(1971, 4, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "David Tennant", 10, new DateTime(2005, 6, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2010, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 4, new DateTime(1930, 7, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), "Jon Pertwee", 3, new DateTime(1970, 1, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1974, 6, 8, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 5, new DateTime(1982, 10, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Matt Smith", 11, new DateTime(2010, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2013, 12, 25, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "Enemies",
                columns: new[] { "EnemyId", "Description", "EnemyName" },
                values: new object[,]
                {
                    { 1, "Murderous mannequins", "The Autons" },
                    { 2, "The last living human being", "Lady Cassandra" },
                    { 3, "An alien species comprised of gas", "The Gelth" },
                    { 4, "A baby-faced alien family", "The Slitheen" },
                    { 5, "Armoured aliens", "Daleks" }
                });

            migrationBuilder.InsertData(
                table: "Episodes",
                columns: new[] { "EpisodeId", "AuthorId", "DoctorId", "EpisodeDate", "EpisodeNumber", "EpisodeType", "Notes", "SeriesNumber", "Title" },
                values: new object[,]
                {
                    { 1, 1, 1, new DateTime(2005, 3, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Normal episode", "", 1, "Rose" },
                    { 2, 2, 2, new DateTime(2005, 4, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "Normal episode", "", 1, "The End of the World" },
                    { 3, 3, 3, new DateTime(2005, 4, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, "Normal episode", "", 1, "The Unquiet Dead" },
                    { 4, 4, 4, new DateTime(2005, 4, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), 4, "Normal episode", "", 1, "Aliens of London (Part 1)" },
                    { 5, 5, 5, new DateTime(2005, 4, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), 5, "Normal episode", "", 1, "World War Three (Part 2)" }
                });

            migrationBuilder.InsertData(
                table: "EpisodeCompanions",
                columns: new[] { "CompanionId", "EpisodeCompanionId", "EpisodeId" },
                values: new object[,]
                {
                    { 1, 1, 1 },
                    { 2, 2, 2 },
                    { 3, 3, 3 },
                    { 4, 4, 4 },
                    { 5, 4, 5 }
                });

            migrationBuilder.InsertData(
                table: "EpisodeEnemies",
                columns: new[] { "EpisodeEnemyId", "EnemyId", "EpisodeId" },
                values: new object[,]
                {
                    { 1, 1, 1 },
                    { 2, 2, 2 },
                    { 3, 3, 3 },
                    { 4, 4, 4 },
                    { 5, 5, 5 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "EpisodeCompanions",
                keyColumn: "CompanionId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "EpisodeCompanions",
                keyColumn: "CompanionId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "EpisodeCompanions",
                keyColumn: "CompanionId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "EpisodeCompanions",
                keyColumn: "CompanionId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "EpisodeCompanions",
                keyColumn: "CompanionId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "EpisodeEnemies",
                keyColumn: "EpisodeEnemyId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "EpisodeEnemies",
                keyColumn: "EpisodeEnemyId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "EpisodeEnemies",
                keyColumn: "EpisodeEnemyId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "EpisodeEnemies",
                keyColumn: "EpisodeEnemyId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "EpisodeEnemies",
                keyColumn: "EpisodeEnemyId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Companions",
                keyColumn: "CompanionId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Companions",
                keyColumn: "CompanionId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Companions",
                keyColumn: "CompanionId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Companions",
                keyColumn: "CompanionId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Companions",
                keyColumn: "CompanionId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Enemies",
                keyColumn: "EnemyId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Enemies",
                keyColumn: "EnemyId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Enemies",
                keyColumn: "EnemyId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Enemies",
                keyColumn: "EnemyId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Enemies",
                keyColumn: "EnemyId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Episodes",
                keyColumn: "EpisodeId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Episodes",
                keyColumn: "EpisodeId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Episodes",
                keyColumn: "EpisodeId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Episodes",
                keyColumn: "EpisodeId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Episodes",
                keyColumn: "EpisodeId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Authors",
                keyColumn: "AuthorId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Authors",
                keyColumn: "AuthorId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Authors",
                keyColumn: "AuthorId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Authors",
                keyColumn: "AuthorId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Authors",
                keyColumn: "AuthorId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Doctors",
                keyColumn: "DoctorId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Doctors",
                keyColumn: "DoctorId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Doctors",
                keyColumn: "DoctorId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Doctors",
                keyColumn: "DoctorId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Doctors",
                keyColumn: "DoctorId",
                keyValue: 5);
        }
    }
}
