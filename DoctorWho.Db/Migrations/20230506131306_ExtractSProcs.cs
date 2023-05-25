﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DoctorWho.Db.Migrations
{
    /// <inheritdoc />
    public partial class ExtractSProcs : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"
            CREATE PROC dbo.spSummariseEpisodesCompanions
            AS
            BEGIN
	            SELECT TOP(3) c.CompanionName as [Three most frequently-appearing companions]
	            FROM EpisodeCompanions ec JOIN Companions c ON ec.CompanionId = c.CompanionId
	            GROUP BY ec.CompanionId, c.CompanionName
	            ORDER BY COUNT(ec.CompanionId) desc
            END;
            GO
            CREATE PROC dbo.spSummariseEpisodesEnemies
            AS
            BEGIN
	            SELECT TOP(3) e.EnemyName AS [Three most frequently-appearing enemies]
	            FROM EpisodeEnemies ee JOIN Enemies e ON ee.EnemyId = e.EnemyId
	            GROUP BY ee.EnemyId, e.EnemyName
	            ORDER BY COUNT(ee.EnemyId) desc
            END;      
            GO
            ");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"DROP PROC IF EXISTS spSummariseEpisodeCompanions;
                                   DROP PROC IF EXISTS spSummariseEpisodeEnemies;");
        }
    }
}
