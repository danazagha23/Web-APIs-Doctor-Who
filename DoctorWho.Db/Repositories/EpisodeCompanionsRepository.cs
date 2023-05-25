using DoctorWho.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorWho.Db.Repositories
{
    public class EpisodeCompanionsRepository
    {
        public static void AddCompanionToEpisode(Companion companion, int EpisodeId)
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
