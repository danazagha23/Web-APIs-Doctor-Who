using DoctorWho.Db.IRepositories;
using DoctorWho.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace DoctorWho.Db.Repositories
{
    public class CompanionsRepository : ICompanionsRepository
    {
        private readonly DoctorWhoDbContext _context;
        public CompanionsRepository(DoctorWhoDbContext context)
        {
            _context = context;
        }
        public void CreateCompanion(string companionName, string whoPlayed)
        {
            if (companionName == null || whoPlayed == null)
                throw new ArgumentNullException("Cannot create a Companion with a null CompanionName or a null WhoPlayed!");
            _context.Companions.Add(new Companion { CompanionName = companionName, WhoPlayed = whoPlayed });
            _context.SaveChanges();
        }
        public void UpdateCompanion(Companion companion)
        {
            var existingCompanion = _context.Doctors.Find(companion.CompanionId);
            if (existingCompanion == null)
            {
                throw new InvalidOperationException("Companion not Found");
            }
            _context.Entry(existingCompanion).CurrentValues.SetValues(companion);

            _context.SaveChanges();
        }
        public void DeleteCompanion(Companion companion)
        {
            if (companion == null) throw new ArgumentNullException("Cannot remove a null Companion from the Companions table");
            _context.Companions.Remove(companion);
            _context.SaveChanges();
        }
        public Companion GetCompanionById(int id)
        {
            var companion = _context.Companions.Find(id);
            if (companion != null) return companion;
            else throw new NullReferenceException("No enemies with the provided Id exist in the database");
        }

    }
}
