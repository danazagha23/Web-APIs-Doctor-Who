using DoctorWho.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorWho.Db.IRepositories
{
    public interface ICompanionsRepository
    {
        public void CreateCompanion(string companionName, string whoPlayed);
        public void UpdateCompanion();
        public void DeleteCompanion(Companion companion);
        public Companion GetCompanionById(int id);

    }
}
