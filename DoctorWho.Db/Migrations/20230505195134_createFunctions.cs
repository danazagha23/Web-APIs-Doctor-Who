using DoctorWho.Domain;
using Microsoft.EntityFrameworkCore.Migrations;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Collections.Generic;

#nullable disable

namespace DoctorWho.Db.Migrations
{
    /// <inheritdoc />
    public partial class createFunctions : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //create function to list companions of specific episode
            migrationBuilder.Sql(@"
            CREATE FUNCTION fnCompanions (
	            @EpisodeId int
            )
            RETURNS varchar(100)
            AS
            begin
	            declare @companions varchar(100) = ''

	            SELECT
			            @companions = @companions + case when len(@companions) > 0 THEN ', ' ELSE '' END + c.CompanionName
	
	            FROM 
			            Companions as c INNER JOIN EpisodeCompanions as ec ON c.CompanionId = ec.CompanionId
			
	            WHERE
			            @EpisodeId = ec.EpisodeId

	            RETURN @companions
            end
            ");

            //create function to list enemies of specific episode
            migrationBuilder.Sql(@"
            CREATE FUNCTION fnEnemies (
	            @EpisodeId int
            )
            RETURNS varchar(100)
            AS
            begin
	            declare @enemies varchar(100) = ''

	            SELECT
			            @enemies = @enemies + case when len(@enemies) > 0 THEN ', ' ELSE '' END + e.EnemyName
	
	            FROM 
			            Enemies as e INNER JOIN EpisodeEnemies as ee ON e.EnemyId = ee.EnemyId
			
	            WHERE
			            @EpisodeId = ee.EpisodeId

	            RETURN @enemies
            end
            ");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"DROP FUNCTION IF EXISTS fnCompanions;");
            migrationBuilder.Sql(@"DROP FUNCTION IF EXISTS fnEnimies;");
        }
    }
}
