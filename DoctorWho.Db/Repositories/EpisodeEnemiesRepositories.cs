using DoctorWho.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorWho.Db.Repositories
{
    public class EpisodeEnemiesRepositories
    {
        public static EpisodeEnemiesRepositories current = new EpisodeEnemiesRepositories();
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
    }
}
