using System.Collections.Generic;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using DoctorWho.Db.Repositories;
using DoctorWho.Web.Dtos;
using DoctorWho.Domain;
using DoctorWho.Db;

namespace DoctorWho.Web.Controllers
{
    [Route("api/episodes")]
    [ApiController]
    public class EpisodesController : ControllerBase
    {
        private readonly IMapper _mapper;

        public EpisodesController(IMapper mapper)
        {
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetEpisodes()
        {
            var episodes = EpisodesRepository.current.GetAllEpisodes();
            var episodesDtos = _mapper.Map<IEnumerable<EpisodeDto>>(episodes);

            return Ok(episodesDtos);
        }
    }
}
