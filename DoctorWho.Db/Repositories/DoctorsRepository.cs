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
        private readonly DoctorWhoDbContext _context;
        public DoctorsRepository(DoctorWhoDbContext context)
        {
            _context = context;
        }
        public void CreateDoctor(int doctorNumber, string doctorName, DateTime birthDate, DateTime firstEpisodeDate, DateTime lastEpisodeDate)
        {
            if (doctorName == null) throw new ArgumentNullException("Cannot create an Doctor with a null DoctorName!");
            _context.Doctors.Add(new Doctor { DoctorNumber = doctorNumber, DoctorName = doctorName, BirthDate = birthDate, FirstEpisodeDate = firstEpisodeDate, LastEpisodeDate = lastEpisodeDate });
            _context.SaveChanges();
        }
        public void UpdateDoctor(Doctor doctor)
        {
            var existingDoctor = _context.Doctors.Find(doctor.DoctorId);
            if(existingDoctor == null)
            {
                throw new InvalidOperationException("Doctor not Found");
            }
            _context.Entry(existingDoctor).CurrentValues.SetValues(doctor);

            _context.SaveChanges();
        }
        public void DeleteDoctor(int doctorId)
        {
            var deletedDoctor = _context.Doctors.Find(doctorId);
            if (deletedDoctor == null) throw new ArgumentNullException("Cannot remove a null Doctor from the Doctors table");
            _context.Doctors.Remove(deletedDoctor);
            _context.SaveChanges();
        }
        public List<Doctor> GetAllDoctors()
        {
            return _context.Doctors.ToList();
        }
        public Doctor UpsertDoctor(Doctor doctor)
        {
            var existingDoctor = _context.Doctors.Find(doctor.DoctorId);
            if(existingDoctor == null)
            {
                _context.Add(doctor);
            }
            else
            {
                _context.Entry(existingDoctor).CurrentValues.SetValues(doctor);
            }
            _context.SaveChanges();
            return doctor;
        }
    }
}
