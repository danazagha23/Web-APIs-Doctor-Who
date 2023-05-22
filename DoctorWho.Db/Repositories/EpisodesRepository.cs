using DoctorWho.Db.IRepositories;
using DoctorWho.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorWho.Db.Repositories
{
    public class EpisodesRepository : IEpisodesRepository
    {
        public void CreateEpisode(int seriesNumber, int episodeNumber, string episodeType, string title, DateTime episodeDate, int authorId, int doctorId, string notes)
        {
            if (title == null) throw new ArgumentNullException("Cannot create an Episode with a null Title!");
            DoctorWhoDbContext.context.Episodes.Add(new Episode { SeriesNumber = seriesNumber, EpisodeNumber = episodeNumber, EpisodeType = episodeType, Title = title, EpisodeDate = episodeDate, AuthorId = authorId, DoctorId = doctorId, Notes = notes });
            DoctorWhoDbContext.context.SaveChanges();
        }
        public void UpdateEpisode()
        {
            DoctorWhoDbContext.context.ChangeTracker.DetectChanges();
            DoctorWhoDbContext.context.SaveChanges();
        }
        public List<Episode> GetAllEpisodes()
        {
            return DoctorWhoDbContext.context.Episodes.ToList();
        }
        public void DeleteEpisode(Episode episode)
        {
            if (episode == null) throw new ArgumentNullException("Cannot remove a null Episode from the Episodes table");
            DoctorWhoDbContext.context.Episodes.Remove(episode);
            DoctorWhoDbContext.context.SaveChanges();
        }
        public void AddEnemyToEpisode(Enemy enemy, int EpisodeId)
        {
            if (enemy == null) throw new ArgumentNullException("Please provide an enemy instance that is not null");
            var episode = DoctorWhoDbContext.context.Episodes.Find(EpisodeId);
            if (episode != null)
            {
                episode.EpisodeEnemies.Add(new EpisodeEnemy { EnemyId = enemy.EnemyId, EpisodeId = EpisodeId });
                DoctorWhoDbContext.context.SaveChanges();
            }
            else throw new InvalidOperationException("No episodes with the provided Id exist in the database!");
        }
        public void AddCompanionToEpisode(Companion companion, int EpisodeId)
        {
            if (companion == null) throw new ArgumentNullException("Please provide a companion instance that is not null");
            var episode = DoctorWhoDbContext.context.Episodes.Find(EpisodeId);
            if (episode != null)
            {
                episode.EpisodeCompanions.Add(new EpisodeCompanion { CompanionId = companion.CompanionId, EpisodeId = EpisodeId });
                DoctorWhoDbContext.context.SaveChanges();
            }
            else throw new InvalidOperationException("No episodes with the provided Id exist in the database!");
        }
    }
}
