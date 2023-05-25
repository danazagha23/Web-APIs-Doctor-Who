using DoctorWho.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorWho.Db.Repositories
{
    public class EpisodesRepository
    {
        public static void CreateEpisode(int seriesNumber, int episodeNumber, string episodeType, string title, DateTime episodeDate, int authorId, int doctorId, string notes)
        {
            if (title == null) throw new ArgumentNullException("Cannot create an Episode with a null Title!");
            DoctorWhoDbContext.context.Episodes.Add(new Episode { SeriesNumber = seriesNumber, EpisodeNumber = episodeNumber, EpisodeType = episodeType, Title = title, EpisodeDate = episodeDate, AuthorId = authorId, DoctorId = doctorId, Notes = notes });
            DoctorWhoDbContext.context.SaveChanges();
        }
        public static void UpdateEpisode()
        {
            DoctorWhoDbContext.context.ChangeTracker.DetectChanges();
            DoctorWhoDbContext.context.SaveChanges();
        }
        public static void DeleteEpisode(Episode episode)
        {
            if (episode == null) throw new ArgumentNullException("Cannot remove a null Episode from the Episodes table");
            DoctorWhoDbContext.context.Episodes.Remove(episode);
            DoctorWhoDbContext.context.SaveChanges();
        }
    }
}
