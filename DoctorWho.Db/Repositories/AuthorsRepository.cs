using DoctorWho.Db.IRepositories;
using DoctorWho.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DoctorWho.Db.IRepositories;
using System.Numerics;

namespace DoctorWho.Db.Repositories
{
    public class AuthorsRepository : IAuthorsRepository
    {
        private readonly DoctorWhoDbContext _context;
        public AuthorsRepository(DoctorWhoDbContext context)
        {
            _context = context;
        }
        public void CreateAuthor(string authorName)
        {
            if (authorName == null) throw new ArgumentNullException("Cannot create an Author with a null AuthorName!");
            _context.Authors.Add(new Author { AuthorName = authorName });
            _context.SaveChanges();
        }
        public void UpdateAuthor(int authorId, Author author)
        {
            var existingAuthor = _context.Authors.Find(authorId);
            if (existingAuthor == null)
            {
                throw new InvalidOperationException("Author not Found");
            }
            existingAuthor.AuthorName = author.AuthorName;

            _context.SaveChanges();
        }
        public void DeleteAuthor(Author author)
        {
            if (author == null) throw new ArgumentNullException("Cannot remove a null Author from the Authors table");
            _context.Authors.Remove(author);
            _context.SaveChanges();
        }
    }
}
