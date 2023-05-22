using DoctorWho.Db.IRepositories;
using DoctorWho.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorWho.Db.Repositories
{
    public class DoctorsRepository : IDoctorsRepository
    {
        public void CreateDoctor(int doctorNumber, string doctorName, DateTime birthDate, DateTime firstEpisodeDate, DateTime lastEpisodeDate)
        {
            if (doctorName == null) throw new ArgumentNullException("Cannot create an Doctor with a null DoctorName!");
            DoctorWhoDbContext.context.Doctors.Add(new Doctor { DoctorNumber = doctorNumber, DoctorName = doctorName, BirthDate = birthDate, FirstEpisodeDate = firstEpisodeDate, LastEpisodeDate = lastEpisodeDate });
            DoctorWhoDbContext.context.SaveChanges();
        }
        public void UpdateDoctor()
        {
            DoctorWhoDbContext.context.ChangeTracker.DetectChanges();
            DoctorWhoDbContext.context.SaveChanges();
        }
        public void DeleteDoctor(Doctor doctor)
        {
            if (doctor == null) throw new ArgumentNullException("Cannot remove a null Doctor from the Doctors table");
            DoctorWhoDbContext.context.Doctors.Remove(doctor);
            DoctorWhoDbContext.context.SaveChanges();
        }
        public List<Doctor> GetAllDoctors()
        {
            return DoctorWhoDbContext.context.Doctors.ToList();
        }
        public Doctor UpsertDoctor(Doctor doctor)
        {
            var existingDoctor = DoctorWhoDbContext.context.Doctors.Find(doctor.DoctorId);
            if(existingDoctor == null)
            {
                DoctorWhoDbContext.context.Add(doctor);
            }
            else
            {
                DoctorWhoDbContext.context.Entry(existingDoctor).CurrentValues.SetValues(doctor);
            }
            DoctorWhoDbContext.context.SaveChanges();
            return doctor;
        }
    }
}
