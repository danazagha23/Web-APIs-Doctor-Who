namespace DoctorWho.Domain
{
    public class Author
    {
        public Author() 
        { 
            this.Episodes = new List<Episode>();
        }
        public int AuthorId { get; set; }
        public string AuthorName { get; set; }
        public List<Episode> Episodes { get; set; }
    }
}