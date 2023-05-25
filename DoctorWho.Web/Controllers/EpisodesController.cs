using System.Collections.Generic;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using DoctorWho.Db.Repositories;
using DoctorWho.Web.Dtos;
using DoctorWho.Domain;
using DoctorWho.Db;
using static Azure.Core.HttpHeader;
using DoctorWho.Db.IRepositories;

namespace DoctorWho.Web.Controllers
{
    [Route("api/episodes")]
    [ApiController]
    public class EpisodesController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IEpisodesRepository _episodeRepository;

        public EpisodesController(IMapper mapper, IEpisodesRepository episodeRepository)
        {
            _mapper = mapper;
            _episodeRepository = episodeRepository;
        }

        [HttpGet]
        public IActionResult GetEpisodes()
        {
            var episodes = _episodeRepository.GetAllEpisodes();
            var episodesDtos = _mapper.Map<IEnumerable<EpisodeDto>>(episodes);

            return Ok(episodesDtos);
        }

        [HttpPost]
        public IActionResult CreateEpisode([FromBody] EpisodeDto episodeDto)
        {
            var episode = _mapper.Map<Episode>(episodeDto);
            _episodeRepository.CreateEpisode(episode.SeriesNumber, episode.EpisodeNumber, episode.EpisodeType, episode.Title, episode.EpisodeDate, episode.AuthorId, episode.DoctorId, episode.Notes);
            
            return Ok("Episode created successfully");
        }

        [HttpPost("{episodeId:int}/enemies/{enemyId:int}")]
        public IActionResult AddEnemyToEpisode(int enemyId, int episodeId)
        {
            _episodeRepository.AddEnemyToEpisode(enemyId, episodeId);

            return Ok("Episode created successfully");
        }

        [HttpPost("{episodeId:int}/companions/{companionId:int}")]
        public IActionResult AddCompanionToEpisode(int companionId, int episodeId)
        {
            _episodeRepository.AddCompanionToEpisode(companionId, episodeId);

            return Ok("Episode created successfully");
        }
    }
}
