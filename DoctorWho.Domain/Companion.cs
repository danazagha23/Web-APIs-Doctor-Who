namespace DoctorWho.Domain
{
    public class Companion
    {
        public Companion()
        {
            this.EpisodeCompanions = new List<EpisodeCompanion>();
        }
        public int CompanionId { get; set; }
        public string CompanionName { get; set; }
        public string WhoPlayed { get; set; }
        public List<EpisodeCompanion> EpisodeCompanions { get; set;}
    }
}