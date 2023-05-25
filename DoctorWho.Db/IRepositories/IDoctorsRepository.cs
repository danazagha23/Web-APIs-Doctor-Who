using DoctorWho.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorWho.Db.IRepositories
{
    public interface IDoctorsRepository
    {
        public void CreateDoctor(int doctorNumber, string doctorName, DateTime birthDate, DateTime firstEpisodeDate, DateTime lastEpisodeDate);
        public void UpdateDoctor(Doctor doctor);
        public void DeleteDoctor(int doctorId);
        public List<Doctor> GetAllDoctors();
        public Doctor UpsertDoctor(Doctor doctor);
    }
}
