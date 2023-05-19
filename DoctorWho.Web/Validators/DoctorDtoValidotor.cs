using DoctorWho.Web.Dtos;
using FluentValidation;

namespace DoctorWho.Web.NewFolder1
{
    public class DoctorDtoValidotor : AbstractValidator<DoctorDto>
    {
        public DoctorDtoValidotor()
        {
            RuleFor(dnumber => dnumber.DoctorNumber).NotEmpty().WithMessage("Doctor number is required."); ;
            RuleFor(dname => dname.DoctorName).NotEmpty().WithMessage("Doctor name is required."); ;

            RuleFor(le => le.LastEpisodeDate)
                .Null()
                .When(fe => !fe.FirstEpisodeDate.HasValue)
                .WithMessage("FirstEpisode is required when lastEpisode has a value.");

            RuleFor(le => le.LastEpisodeDate)
                .GreaterThanOrEqualTo(fe => fe.FirstEpisodeDate)
                .When(e => e.FirstEpisodeDate.HasValue && e.LastEpisodeDate.HasValue)
                .WithMessage("LastEpisode date should be greater or equal than first episode date.");
        }
    }
}
