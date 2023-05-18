using DoctorWho.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorWho.Db.Repositories
{
    public class AuthorsRepository
    {
        public static void CreateAuthor(string authorName)
        {
            if (authorName == null) throw new ArgumentNullException("Cannot create an Author with a null AuthorName!");
            DoctorWhoDbContext.context.Authors.Add(new Author { AuthorName = authorName });
            DoctorWhoDbContext.context.SaveChanges();
        }
        public static void UpdateAuthor()
        {
            DoctorWhoDbContext.context.ChangeTracker.DetectChanges();
            DoctorWhoDbContext.context.SaveChanges();
        }
        public static void DeleteAuthor(Author author)
        {
            if (author == null) throw new ArgumentNullException("Cannot remove a null Author from the Authors table");
            DoctorWhoDbContext.context.Authors.Remove(author);
            DoctorWhoDbContext.context.SaveChanges();
        }
    }
}
