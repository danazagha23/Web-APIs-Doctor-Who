using DoctorWho.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorWho.Db.IRepositories
{
    public interface IAuthorsRepository
    {
        public void CreateAuthor(string authorName);
        public void UpdateAuthor();
        public void DeleteAuthor(Author author);
    }
}
