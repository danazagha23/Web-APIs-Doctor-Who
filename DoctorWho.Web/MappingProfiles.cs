using AutoMapper;
using DoctorWho.Web.Dtos;
using DoctorWho.Domain;

namespace DoctorWho.Web
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Author, AuthorDto>().ReverseMap();
            CreateMap<Companion, CompanionDto>().ReverseMap();
            CreateMap<Doctor, DoctorDto>().ReverseMap();
            CreateMap<Enemy, EnemyDto>().ReverseMap();
            CreateMap<Episode, EpisodeDto>().ReverseMap();
        }
    }
        
}
