using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace DoctorWho.Domain
{
    public class EpisodeEnemy
    {
        public int EpisodeEnemyId { get; set; }
        public int EpisodeId { get; set; }
        public int EnemyId { get; set; }

        [NotMapped]
        public Episode Episode { get; set; }

        [NotMapped]
        public Enemy Enemy { get; set; }
    }
}