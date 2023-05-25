using System.ComponentModel.DataAnnotations.Schema;

namespace DoctorWho.Domain
{
    public class EpisodeCompanion
    {
        public int EpisodeCompanionId { get; set; } 
        public int EpisodeId { get; set; } 
        public int CompanionId { get; set; }

        [NotMapped]
        public Episode Episode { get; set; }

        [NotMapped]
        public Companion Companion { get; set; }
    }
}