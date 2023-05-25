using AutoMapper;
using DoctorWho.Web.Dtos;
using DoctorWho.Domain;

namespace DoctorWho.Web
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Author, AuthorDto>();
            CreateMap<Companion, CompanionDto>();
            CreateMap<Doctor, DoctorDto>();
            CreateMap<Enemy, EnemyDto>();
            CreateMap<Episode, EpisodeDto>();
        }
    }
        
}
