using DoctorWho.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorWho.Db.IRepositories
{
    public interface IEpisodesRepository
    {
        public void CreateEpisode(int seriesNumber, int episodeNumber, string episodeType, string title, DateTime episodeDate, int authorId, int doctorId, string notes);
        public void UpdateEpisode(int episodeId, Episode episode);
        public List<Episode> GetAllEpisodes();
        public void DeleteEpisode(Episode episode);
        public void AddEnemyToEpisode(int EnemyId, int EpisodeId);
        public void AddCompanionToEpisode(int CompanionId, int EpisodeId);

    }
}
