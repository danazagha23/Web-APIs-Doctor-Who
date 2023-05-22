using AutoMapper;
using DoctorWho.Db;
using DoctorWho.Db.Repositories;
using DoctorWho.Web.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace DoctorWho.Web.Controllers
{
    [Route("api/authors")]
    [ApiController]
    public class AuthorsController : ControllerBase
    {
        [HttpPut("{authorId}")]
        public IActionResult updateAuthor(int authorId, [FromBody] AuthorDto authorDto)
        {
            var author = DoctorWhoDbContext.context.Authors.Find(authorId);
            if(author != null)
            {
                author.AuthorName = authorDto.AuthorName;
                AuthorsRepository.UpdateAuthor();
                return Ok(author);
            }
            return NotFound("Author not found");
        }
        
    }
}
