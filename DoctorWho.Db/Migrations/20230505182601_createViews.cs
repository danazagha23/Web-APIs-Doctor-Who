using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DoctorWho.Db.Migrations
{
    /// <inheritdoc />
    public partial class createViews : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"
            CREATE VIEW ViewEpisodes
            AS  
	            SELECT e.EpisodeId, e.Title, a.AuthorName, d.DoctorName, dbo.fnCompanions(e.EpisodeId) as Companions, dbo.fnEnemies(e.EpisodeId) as Enemies 
	
	            FROM Episodes AS e 
	
	            INNER JOIN Authors AS  a  
	            ON e.AuthorId = a.AuthorId 
	
	            INNER JOIN Doctors AS  d
	            ON e.DoctorId = d.DoctorId 
            ");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"DROP VIEW IF EXISTS viewEpisodes");
        }
    }
}
