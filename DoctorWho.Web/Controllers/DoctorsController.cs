using System.Collections.Generic;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using DoctorWho.Db.Repositories;
using DoctorWho.Web.Dtos;
using DoctorWho.Domain;

namespace DoctorWho.Web.Controllers
{
    [Route("api/doctors")]
    [ApiController]
    public class DoctorsController : ControllerBase
    {
        private readonly IMapper _mapper;

        public DoctorsController(IMapper mapper)
        {
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetDoctors()
        {
            var doctors = DoctorsRepository.current.GetAllDoctors();
            var doctorsDtos = _mapper.Map<IEnumerable<DoctorDto>>(doctors);

            return Ok(doctorsDtos);
        }

        [HttpPost]
        public IActionResult UpsertDoctor([FromBody] DoctorDto doctorDto)
        {
            var doctor = _mapper.Map<Doctor>(doctorDto);
            var upsertedDoctor = DoctorsRepository.current.UpsertDoctor(doctor);
            var upsertedDoctorDto = _mapper.Map<DoctorDto>(upsertedDoctor);

            return Ok(upsertedDoctorDto);
        }
    }
}
