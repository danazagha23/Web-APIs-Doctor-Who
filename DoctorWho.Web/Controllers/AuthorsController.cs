using AutoMapper;
using DoctorWho.Db;
using DoctorWho.Db.IRepositories;
using DoctorWho.Db.Repositories;
using DoctorWho.Domain;
using DoctorWho.Web.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace DoctorWho.Web.Controllers
{
    [Route("api/authors")]
    [ApiController]
    public class AuthorsController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IAuthorsRepository _authorsRepository;
        public AuthorsController(IMapper mapper, IAuthorsRepository authorsRepository)
        {
            _mapper = mapper;
            _authorsRepository = authorsRepository;
        }

        [HttpPut("{authorId}")]
        public IActionResult updateAuthor(int authorId, [FromBody] AuthorDto authorDto)
        {
            var author = _mapper.Map<Author>(authorDto);
            _authorsRepository.UpdateAuthor(authorId, author);
            return Ok(author);
        }
        
    }
}
