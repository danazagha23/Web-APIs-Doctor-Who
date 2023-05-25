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
        private readonly DoctorWhoDbContext _context;
        public EpisodesRepository(DoctorWhoDbContext context)
        {
            _context = context;
        }
        public void CreateEpisode(int seriesNumber, int episodeNumber, string episodeType, string title, DateTime episodeDate, int authorId, int doctorId, string notes)
        {
            if (title == null) throw new ArgumentNullException("Cannot create an Episode with a null Title!");
            _context.Episodes.Add(new Episode { SeriesNumber = seriesNumber, EpisodeNumber = episodeNumber, EpisodeType = episodeType, Title = title, EpisodeDate = episodeDate, AuthorId = authorId, DoctorId = doctorId, Notes = notes });
            _context.SaveChanges();
        }
        public void UpdateEpisode(int episodeId, Episode episode)
        {
            var existingEpisode = _context.Authors.Find(episode.EpisodeId);
            if (existingEpisode == null)
            {
                throw new InvalidOperationException("Episode not Found");
            }
            _context.Entry(existingEpisode).CurrentValues.SetValues(episode);

            _context.SaveChanges();
        }
        public List<Episode> GetAllEpisodes()
        {
            return _context.Episodes.ToList();
        }
        public void DeleteEpisode(Episode episode)
        {
            if (episode == null) throw new ArgumentNullException("Cannot remove a null Episode from the Episodes table");
            _context.Episodes.Remove(episode);
            _context.SaveChanges();
        }
        public void AddEnemyToEpisode(int EnemyId, int EpisodeId)
        {
            var enemy = _context.Enemies.Find(EnemyId);
            if (enemy == null) throw new ArgumentNullException("Please provide an enemy instance that is not null");
            var episode = _context.Episodes.Find(EpisodeId);
            if (episode != null)
            {
                episode.EpisodeEnemies.Add(new EpisodeEnemy { EnemyId = enemy.EnemyId, EpisodeId = EpisodeId });
                _context.SaveChanges();
            }
            else throw new InvalidOperationException("No episodes with the provided Id exist in the database!");
        }
        public void AddCompanionToEpisode(int companionId, int EpisodeId)
        {
            var companion = _context.Companions.Find(companionId);
            if (companion == null) throw new ArgumentNullException("Please provide a companion instance that is not null");
            var episode = _context.Episodes.Find(EpisodeId);
            if (episode != null)
            {
                episode.EpisodeCompanions.Add(new EpisodeCompanion { CompanionId = companion.CompanionId, EpisodeId = EpisodeId });
                _context.SaveChanges();
            }
            else throw new InvalidOperationException("No episodes with the provided Id exist in the database!");
        }
    }
}
