using DoctorWho.Db.IRepositories;
using DoctorWho.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorWho.Db.Repositories
{
    public class CompanionsRepository : ICompanionsRepository
    {
        public void CreateCompanion(string companionName, string whoPlayed)
        {
            if (companionName == null || whoPlayed == null)
                throw new ArgumentNullException("Cannot create a Companion with a null CompanionName or a null WhoPlayed!");
            DoctorWhoDbContext.context.Companions.Add(new Companion { CompanionName = companionName, WhoPlayed = whoPlayed });
            DoctorWhoDbContext.context.SaveChanges();
        }
        public void UpdateCompanion()
        {
            DoctorWhoDbContext.context.ChangeTracker.DetectChanges();
            DoctorWhoDbContext.context.SaveChanges();
        }
        public void DeleteCompanion(Companion companion)
        {
            if (companion == null) throw new ArgumentNullException("Cannot remove a null Companion from the Companions table");
            DoctorWhoDbContext.context.Companions.Remove(companion);
            DoctorWhoDbContext.context.SaveChanges();
        }
        public Companion GetCompanionById(int id)
        {
            var companion = DoctorWhoDbContext.context.Companions.Find(id);
            if (companion != null) return companion;
            else throw new NullReferenceException("No enemies with the provided Id exist in the database");
        }

    }
}
