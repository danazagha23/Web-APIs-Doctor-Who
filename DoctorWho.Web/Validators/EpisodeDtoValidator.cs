using DoctorWho.Web.Dtos;
using FluentValidation;

namespace DoctorWho.Web.Validators
{
    public class EpisodeDtoValidator : AbstractValidator<EpisodeDto>
    {
        public EpisodeDtoValidator()
        { 
            RuleFor(authorId => authorId.AuthorId).NotEmpty().WithMessage("Author id is required");
            
            RuleFor(doctorId => doctorId.DoctorId).NotEmpty().WithMessage("Doctor id is required");
            
            RuleFor(seriesNumber => seriesNumber.SeriesNumber)
                .Must(seriesNumber => seriesNumber.ToString().Length == 10);
            
            RuleFor(episodeNumber => episodeNumber.EpisodeNumber)
                .GreaterThan(0);
        }
    }
}
