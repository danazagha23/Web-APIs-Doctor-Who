using System.Collections.Generic;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using DoctorWho.Db.Repositories;
using DoctorWho.Web.Dtos;
using DoctorWho.Domain;
using DoctorWho.Db;
using static Azure.Core.HttpHeader;

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

        [HttpPost]
        public IActionResult CreateEpisode([FromBody] EpisodeDto episodeDto)
        {
            var episode = _mapper.Map<Episode>(episodeDto);
            EpisodesRepository.current.CreateEpisode(episode.SeriesNumber, episode.EpisodeNumber, episode.EpisodeType, episode.Title, episode.EpisodeDate, episode.AuthorId, episode.DoctorId, episode.Notes);
            
            return Ok("Episode created successfully");
        }
    }
}
